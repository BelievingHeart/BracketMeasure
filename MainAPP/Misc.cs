
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VP_DogDll;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Net;
using System.Net.Configuration;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Drawing.Imaging;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Display;

namespace MainAPP
{
    static class Misc
    {
        public static Process GetRunningInstance()
        {
            Process current_process = Process.GetCurrentProcess();
            Process[] same_name_processes = Process.GetProcessesByName(current_process.ProcessName);
            for (int i = 0; i < same_name_processes.Length; i++)
            {
                if (same_name_processes[i].MainModule.FileName == current_process.MainModule.FileName && same_name_processes[i].Id != current_process.Id)
                {
                    return same_name_processes[i];
                }
            }
            return null;
        }
        public static void WriteXML(object obj, string fileName)
        {
            if (null == obj)
            {
                throw new ArgumentNullException("obj", "obj对象不能为null");
            }
            
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.OmitXmlDeclaration = true;
            ws.Indent = true;            
            StreamWriter sw = new StreamWriter(fileName, false);
            using (XmlWriter writer = XmlWriter.Create(sw, ws))
            {
                //去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                XmlSerializer formatter = new XmlSerializer(obj.GetType());
                formatter.Serialize(writer, obj, ns);
                writer.Close();
            }
            sw.Close();
        }
        public static object ReadXML(string fileName, Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type", "type不能为null");
            }
            XmlSerializer serializer = new XmlSerializer(type);
            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
            object obj = serializer.Deserialize(sr);
            sr.Close();
            return obj;
        }
             
        public static void CloseCognexCamera(CogToolBlock toolblock)
        {
            if (toolblock == null) return;

            int n = toolblock.Tools.Count;
            for (int i = 0; i < n; i++)
            {
                if (toolblock.Tools[i] is CogAcqFifoTool)
                {
                    CogAcqFifoTool fifo = (CogAcqFifoTool)toolblock.Tools[i];
                    if (fifo.Operator != null && fifo.Operator.FrameGrabber != null)
                    {
                        fifo.Operator.FrameGrabber.Disconnect(false);
                    }
                }
                else if (toolblock.Tools[i] is CogToolBlock)
                {
                    CogToolBlock tb = (CogToolBlock)toolblock.Tools[i];
                    CloseCognexCamera(tb);
                }
            }

        }

        public static void GetRoratedCoordinator(double XCenter, double YCenter, double ARotate, double XBefore, double YBefore, ref double XAfter, ref double YAfter)
        {
            double Rad = 0.0;
            Rad = ARotate * Math.Acos(-1) / 180;

            XAfter = (XBefore - XCenter) * Math.Cos(Rad) - (YBefore - YCenter) * Math.Sin(Rad) + XCenter;
            YAfter = (YBefore - YCenter) * Math.Cos(Rad) + (XBefore - XCenter) * Math.Sin(Rad) + YCenter;
        }
       

    }//class
}//namespace