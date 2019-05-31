using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Lib_MeasurementUtilities
{
    public class DataLogger
    {
        private List<string> argNames;
        private string title;
        private string _logDir;

        public DataLogger(List<string> argNames, string logDir)
        {
            this.argNames = argNames;
            this._logDir = logDir;
            title = string.Join(",", this.argNames);

        }

        public string WriteLine(string line)
        {
            string logFile = _logDir + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

            if (!File.Exists(logFile))
            {
                using (var ss = new StreamWriter(logFile, true))
                {
                    ss.WriteLine(title);
                    ss.WriteLine(line);
                }
            }
            else
            {
                using (var ss = new StreamWriter(logFile, true))
                {
                    ss.WriteLine(line);
                }
            }

            return logFile;
        }
    }
}
