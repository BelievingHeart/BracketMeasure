using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro.ToolBlock;

namespace Lib_MeasurementUtilities
{
    public class Rectifier
    {
        public static Dictionary<string, double> calcAveragedDiff(Dictionary<string, List<double>> standardDataDict, Dictionary<string, List<double>> distsUnBiased)
        {
            Dictionary<string, double> ret = new Dictionary<string, double>();
            foreach (var key in distsUnBiased.Keys)
            {
                ret[key] = standardDataDict[key].Zip(distsUnBiased[key], (a, b) => a - b).Average();
            }

            return ret;
        }

        public static Dictionary<string, List<double>> calDistsUnbiased(Dictionary<string, List<double>> sampleDataDict, double multiplier, params Tuple<string, string>[] namePairs_FromTo)
        {

            // init return value
            Dictionary<string, List<double>> ret = new Dictionary<string, List<double>>();
            foreach (var namePair in namePairs_FromTo)
            {
                ret[namePair.Item2] = sampleDataDict[namePair.Item1].Select(item => item * multiplier).ToList();
            }

            return ret;
        }

        public static double calcMultiplier(Dictionary<string, List<double>> standardDataDict, Dictionary<string, List<double>> sampleDataDict, params Tuple<string, string>[] keyPairs)
        {

            int totalColumns = keyPairs.Length;

            double sumOfAverage = 0;

            foreach (var keyPair in keyPairs)
            {
                var averageMPerCol = standardDataDict[keyPair.Item1].Zip(sampleDataDict[keyPair.Item2], (a, b) => a / b).Average();
                sumOfAverage += averageMPerCol;
            }

            return sumOfAverage / totalColumns;
        }

        public static Dictionary<string, List<double>> parseCSV_reversed(string filePath, List<string> header, int numLines)
        {

            // init return value
            Dictionary<string, List<double>> ret = new Dictionary<string, List<double>>();
            foreach (var key in header)
            {
                ret[key] = new List<double>();
            }

            var lastNumlines = File.ReadAllLines(filePath).Reverse().Take(numLines).Reverse();
            foreach (var line in lastNumlines)
            {
                int index = 0;
                foreach (var item in line.Split(','))
                {
                    double outNum;
                    double.TryParse(item, out outNum);

                    ret[header[index]].Add(outNum);
                    index++;
                }
            }

            return ret;
        }

        public static Dictionary<string, List<double>> calcDiffs(Dictionary<string, List<double>> standardDataDict,
            Dictionary<string, List<double>> sampleDataDict)
        {
            Dictionary<string, List<double>> ret = new Dictionary<string, List<double>>();

            foreach (var key in standardDataDict.Keys)
            {
                ret[key] = standardDataDict[key].Zip(sampleDataDict[key], (a, b) => a - b).ToList();
            }

            return ret;
        }

        public static string serializeDataDict(Dictionary<string, List<double>> dict, string outDir)
        {
            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

            var outFile = outDir + "/" + "相关性.csv";

            var numRows = dict.ElementAt(0).Value.Count;
            Debug.Assert(dict.Values.All(a => a.Count == numRows));
            using (var fs = new StreamWriter(outFile, false))
            {
                fs.WriteLine(string.Join(",", dict.Keys));

                for (int i = 0; i < numRows; i++)
                {
                    List<double> currentValues = new List<double>();
                    foreach (var col in dict.Values)
                    {
                        currentValues.Add(col[i]);
                    }

                    var line = string.Join(",", currentValues);
                    fs.WriteLine(line);
                }
            }

            return outFile;
        }

        public static string serializeWeightAndBiases(double w, Dictionary<string, double> biases, string outDir)
        {
            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

            var outFile = outDir + "/" + "放大倍数及补偿值.txt";

            using (var fs = new StreamWriter(outFile, false))
            {
                fs.WriteLine("m: " + w);
                foreach (var bias in biases)
                {
                    fs.WriteLine(bias.Key + ": " + bias.Value);
                }
            }

            return outFile;
        }

        public static ObservableCollection<RectifiedParam> GenerateDataSource(double w,
            Dictionary<string, double> biases)
        {
            ObservableCollection<RectifiedParam> ret = new ObservableCollection<RectifiedParam>()
                {new RectifiedParam() {Name = "m", Value = w}};
            foreach (var bias in biases)
            {
                ret.Add(new RectifiedParam() {Name = bias.Key, Value = bias.Value});
            }

            return ret;
        }

        public static void FilterBiases(ref Dictionary<string, double> biases, params string[] keysToBeFiltered)
        {
            Dictionary<string, double> ret = new Dictionary<string, double>();
            foreach (var bias in biases)
            {
                bool matchAny = false;
                foreach (var key in keysToBeFiltered)
                {
                    if (key == bias.Key)
                    {
                        matchAny = true;
                    }
                }

                if (!matchAny)
                {
                    ret.Add(bias.Key, bias.Value);
                }
            }

            biases = ret;
        }

        public static void EditBlockInputParams(ObservableCollection<RectifiedParam> dataSource, List<Tuple<string, string>> nameMapping_fromTo, ref CogToolBlock block)
        {
            Debug.Assert(dataSource.Count == nameMapping_fromTo.Count);

            var dict = new Dictionary<string, double>();
            foreach (var d in dataSource)
            {
                dict.Add(d.Name, d.Value);
            }
            
            for (int i = 0; i < dataSource.Count; i++)
            {
                block.Inputs[nameMapping_fromTo[i].Item2].Value = dict[nameMapping_fromTo[i].Item1];
            }
        }
    }
}
