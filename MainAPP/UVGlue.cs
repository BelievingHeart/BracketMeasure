using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;
using Lib_MeasurementUtilities;
using MainAPP.UI;


namespace MainAPP
{
    static class UVGlue
    {
        //消息常量
        private const int WM_USER = 0x400;

        //通信部分
        public const ushort IN_TRIGER = 1;
        public const ushort OUT_OK = 1;
        public const ushort OUT_NG = 2;
        public const ushort OUT_PRODUCT = 3;
        public static int triger1 = 1;
        public static string logFile = "UnhandleExceptions.txt";

        public static AutoResetEvent cond_ReadyToRun = new AutoResetEvent(false);

        //视觉部分
        //public static CogToolGroup tgCheck;
        public static CogToolBlock tbCheck;


        public static string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "/VPP";

        public static string vppFilePath = Path.Combine(projectDir, "Template.vpp");


        //
        public static FormMain _formMain;

        public static bool applicationIsRunning;

        public static object mu_alive = new object();

        public static Thread threadListen;
        public static Thread threadExecute;

        public static double
            Y1,
            Y2,
            X1,
            X2,
            X1_pixel,
            X2_pixel,
            Y1_pixel,
            Y2_pixel,
            angle;

        private static string logDir = AppDomain.CurrentDomain.BaseDirectory + "Log";

        private static List<string> logTitile = new List<string>
            {"时间", "X1", "X2", "Y1", "Y2", "角度", "结果", "序号", " ", "X1_pixel", "X2_pixel", "Y1_pixel", "Y2_pixel"};

        private static DataLogger dataLogger = new DataLogger(logTitile, logDir);

        // summery section
        private static bool noErrorInThisRound = true;

        // image module
        public static object mu_recentNGImagePath = new object();
        public static string recentNGIMagePath = "";
        public static bool saveAsScreenShot = true;
        public static object mu_SaveAsScreenShot = new object();

        // rectifier section
        public static string csvFile;

        // section handle result
        public static string resultOK = "OK", resultNG = "NG", resultNoProduct = "无料";
        public static List<string> resultsThatImagesSholdBeSaved;
        public static object mu_resultsThatImagesShouldBeSaved = new object();


        public static void LoadVPP()
        {
            tbCheck = (CogToolBlock) CogSerializer.LoadObjectFromFile(vppFilePath);
        }

        public static void SaveVPP()
        {
            CogSerializer.SaveObjectToFile(tbCheck, vppFilePath, typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
        }

        public static void CloseVPP()
        {
            Misc.CloseCognexCamera(tbCheck);
        }

   


        public static void Listen()
        {
          
                int temp1 = 0;
                while (true)
                {
                    lock (mu_alive)
                    {
                        if (!applicationIsRunning) break;
                    }

                    Thread.Sleep(3);


                    temp1 = IOC0640.ioc_read_inbit(0, IN_TRIGER);

                    //工位1
                    if (triger1 != temp1)
                    {
                        triger1 = temp1;
                        if (triger1 == 0)
                        {
                            switch (triger1)
                            {
                                case 0:
                                    _formMain.ShowAndSaveMsg_Invoke("收到触发信号");
                                    cond_ReadyToRun.Set();
                                    break;
                            }
                        }
                    }
                }
          
        }

        public static void ListenPos1()
        {
            
                while (true)
                {
                    cond_ReadyToRun.WaitOne();
                    lock (mu_alive)
                    {
                        if (!applicationIsRunning) break;
                    }

                    RunOnce();
                }
        }


        public static void RunOnce()
        {
            _formMain.Invoke((MethodInvoker) (() => { _formMain.btnReset.Enabled = true; }));
            for (int i = 0; i < tbCheck.Outputs.Count; i++)
            {
                tbCheck.Outputs[i].Value = 0.0;
            }

            tbCheck.Run();
            _formMain.Invoke((MethodInvoker) (() =>
            {
                _formMain.cogRecordDisplay1.Record =
                    tbCheck.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            }));

            string runResult;
            if (CogToolResultConstants.Accept == tbCheck.RunStatus.Result)
            {
                runResult = resultOK;
            }
            else
            {
                CogPMAlignTool pma = (CogPMAlignTool) tbCheck.Tools["判断有无料"];
                runResult = pma.Results.Count == 0 ? resultNoProduct : resultNG;
            }
            HandleResult(runResult);


            Y1 = (double) tbCheck.Outputs["Y1"].Value;
            Y2 = (double) tbCheck.Outputs["Y2"].Value;
            X1 = (double) tbCheck.Outputs["X1"].Value;
            X2 = (double) tbCheck.Outputs["X2"].Value;
            angle = (double) tbCheck.Outputs["Angle"].Value;
            X1_pixel = (double) tbCheck.Outputs["X1_pixel"].Value;
            X2_pixel = (double) tbCheck.Outputs["X2_pixel"].Value;
            Y1_pixel = (double) tbCheck.Outputs["Y1_pixel"].Value;
            Y2_pixel = (double) tbCheck.Outputs["Y2_pixel"].Value;

            lock (_formMain._chartFormMarshaller.mu_currentIndex)
            {
                SaveLog(_formMain._chartFormMarshaller.currentIndex, runResult);
                _formMain.showCurrentIndex(_formMain._chartFormMarshaller.currentIndex);
                _formMain._chartFormMarshaller.incrementItemCount();
                noErrorInThisRound &= (tbCheck.RunStatus.Result != CogToolResultConstants.Error);
                _formMain._chartFormMarshaller.collectData(X1, X2, Y1, Y2, angle);
                if (_formMain._chartFormMarshaller.RoundEndReached())
                {
                    // if no error occur within a round, update summery and clear. Otherwise, just clear.
                    _formMain._chartFormMarshaller.resetItemCount();
                    if (noErrorInThisRound)
                    {
                        _formMain._chartFormMarshaller.GenerateSummery();
                    }

                    _formMain._chartFormMarshaller.clearDataBuffers();
                    // reset this flag for next round
                    noErrorInThisRound = true;
                }
            }
        }

        private static void HandleResult(string result)
        {
            SubmitResult(result);
            DisplayResult_Invoke(result);
            lock (_formMain._chartFormMarshaller.mu_currentIndex)
            {
                saveImage(_formMain.cogRecordDisplay1, _formMain._chartFormMarshaller.currentIndex, result);
            }
        }

        private static void DisplayResult_Invoke(string result)
        {
            _formMain.ShowAndSaveMsg_Invoke(result);
            CogColorConstants outColor = result == resultOK ? CogColorConstants.Green : CogColorConstants.Red;
            ShowLabel_Invoke(_formMain.cogRecordDisplay1, 30, 1600, 100, outColor, result);
        }

        private static void SubmitResult(string result)
        {
            var outPort = result == resultOK ? OUT_OK :
                result == resultNG ? OUT_NG :
                OUT_PRODUCT;
            IOC0640.ioc_write_outbit(0, outPort, 0);
            Thread.Sleep(100);
            IOC0640.ioc_write_outbit(0, outPort, 1);
        }


        public static void ShowLabel_Invoke(CogRecordDisplay disp, float size, double posX, double posY,
            CogColorConstants color, string text)
        {
            CogGraphicLabel label = new CogGraphicLabel();
            label.SelectedSpaceName = "#";
            label.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
            label.Font = new Font("Arial", size);
            label.Color = color;
            label.SetXYText(posX, posY, text);
            _formMain.Invoke((MethodInvoker) (() => { disp.StaticGraphics.Add(label, "label"); }));
        }

        public static void saveImage(CogRecordDisplay image, int index, string result)
        {
            string imageBaseDir = AppDomain.CurrentDomain.BaseDirectory + "Image";
            if (!Directory.Exists(imageBaseDir))
            {
                Directory.CreateDirectory(imageBaseDir);
            }


            var imageDir_today = imageBaseDir + "\\" + DateTime.Now.ToString("MM-dd");
            if (!Directory.Exists(imageDir_today))
            {
                Directory.CreateDirectory(imageDir_today);
            }

            var imagePath = imageDir_today + "\\" + index + "_" + DateTime.Now.ToString("HHmmss") + ".jpg";
            if (result == resultNG)
                lock (mu_recentNGImagePath)
                {
                    recentNGIMagePath = imagePath;
                }

            if (ShouldImageBeSavedBasedOnResult(result))
            {
                try
                {
                    using (CogImageFileTool fileTool = new CogImageFileTool())
                    {
                        Image img;
                        lock (mu_SaveAsScreenShot)
                        {
                            img = image.CreateContentBitmap(saveAsScreenShot
                                ? CogDisplayContentBitmapConstants.Display
                                : CogDisplayContentBitmapConstants.Image);
                        }

                        Bitmap bmp = new Bitmap(img);
                        CogImage24PlanarColor cogImage = new CogImage24PlanarColor(bmp);
                        fileTool.InputImage = cogImage;
                        lock (mu_recentNGImagePath)
                        {
                            fileTool.Operator.Open(imagePath, CogImageFileModeConstants.Write);
                        }

                        fileTool.Run();
                    }
                }
                catch (Exception e)
                {
                    UnhandledExceptionLogger.Log(logFile, e, false);
                }
            }


            //删除过期文件夹
            removeOutdatedDirs(imageBaseDir);
        }

        private static bool ShouldImageBeSavedBasedOnResult(string result)
        {
            bool ret;
            lock (mu_resultsThatImagesShouldBeSaved)
            {
                ret = resultsThatImagesSholdBeSaved.Contains(result);
            }

            return ret;
        }

        private static void removeOutdatedDirs(string imageBaseDir)
        {
            string[] dirs = Directory.GetDirectories(imageBaseDir);
            for (int i = 0; i < dirs.Length; i++)
            {
                DateTime dt = Directory.GetCreationTime(dirs[i]);
                TimeSpan ts = DateTime.Now - dt;
                if (ts.Days > 30)
                {
                    Directory.Delete(dirs[i], true);
                }
            }
        }

        public static void SaveLog(int itemIndex, string runResult)
        {
            //创建文件夹
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            var lineVals = new List<string>
            {
                DateTime.Now.ToString("HH:mm:ss"), X1.ToString("f3"), X2.ToString("f3"), Y1.ToString("f3"),
                Y2.ToString("f3"), angle.ToString("f3"),
                runResult, itemIndex.ToString(), " ", X1_pixel.ToString("f3"), X2_pixel.ToString("f3"),
                Y1_pixel.ToString("f3"), Y2_pixel.ToString("f3")
            };
            var line = string.Join(",", lineVals);

            csvFile = dataLogger.WriteLine(line);

            removeOutdatedFiles(logDir);
        }

        private static void removeOutdatedFiles(string dir)
        {
            //删除过期文件
            string[] files = Directory.GetFiles(dir);
            for (int i = 0; i < files.Length; i++)
            {
                DateTime dt = File.GetCreationTime(files[i]);
                TimeSpan ts = DateTime.Now - dt;
                if (ts.Days > 30)
                {
                    File.Delete(files[i]);
                }
            }
        }

        public static void JoinBackgroundThreads()
        {
            lock (mu_alive)
            {
                applicationIsRunning = false;
            }

            cond_ReadyToRun.Set();
            threadExecute.Join();
            threadListen.Join();
        }

        public static void cleanUp()
        {
            UVGlue.CloseVPP();
            IOC0640.ioc_board_close();
        }
    }
}