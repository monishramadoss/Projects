using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Vectorizer
{
    class Program
    {
        static Dictionary<string, List<string>> Data = new Dictionary<string, List<string>>();
        static Dictionary<string, int> voc = new Dictionary<string, int>();
        static int ThreadCount = Environment.ProcessorCount;
        

        static void Run_PyScript()
        {
            ProcessStartInfo pyStart = new ProcessStartInfo();
            pyStart.FileName = @"./Python36/python.exe";
            pyStart.Arguments = @"./PyScript.py";
            pyStart.UseShellExecute = false;
            pyStart.CreateNoWindow = true;
            pyStart.RedirectStandardError = true;
            pyStart.RedirectStandardOutput = true;
            Console.WriteLine("CSV reader started");

            using (Process process = Process.Start(pyStart))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    var stdout = reader.ReadToEnd();
                    var stderr = process.StandardError.ReadToEnd();

                    if (stderr != "")
                    {
                        Console.WriteLine(stderr);
                    }

                    else{
                        var DataSet = stdout.Split(')');
                        for (uint i = 1; i < DataSet.Length; i++)
                        {
                            var sentTxt = DataSet[i].Split('(')[0].Split(',');
                            var cls = DataSet[i].Split('(')[1].Replace("\r", string.Empty).Replace(" ", string.Empty).Replace("\n",string.Empty);

                            for (uint j = 0; j < sentTxt.Length; j++)
                            {
                                var word = sentTxt[j];
                                //var typ = word.Split('#')[word.Split('#').Length - 1];
                                if (Data.ContainsKey(cls))
                                {
                                    Data[cls].Add(word);
                                }
                                else
                                {
                                    Data.Add(cls, new List<string> { word });
                                }

                                Vocab.Add(word);
                                
                            }
                        }
                        Console.WriteLine("CSV reader Executed");

                    }
                }


            }

        }
        static void Run_JsonDmp(string input)
        {
            ProcessStartInfo pyStart = new ProcessStartInfo();
            pyStart.FileName = @"./Python36/python.exe";
            pyStart.Arguments = @"./JsonDmp.py";
            pyStart.UseShellExecute = false;
            pyStart.CreateNoWindow = true;
            pyStart.RedirectStandardError = true;
            pyStart.RedirectStandardInput = true;
            using (Process process = Process.Start(pyStart))
            {
                using(StreamWriter writer = process.StandardInput)
                {
                    writer.WriteLine(input);
                    string stderr = process.StandardError.ReadToEnd();

                    if (stderr != "")
                    {
                        Console.WriteLine(stderr);
                    }

                }

            }
        }



        static void DataAnalysis(Tuple<List<List<string>>,int> data)
        {
            var TrainData = data.Item1;
            var idx = data.Item2;
            Dictionary<string, int>[] sentanceData = new Dictionary<string, int>[TrainData.Count];
            Console.WriteLine("Thread Starting {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < sentanceData.Length; i++)
            {
                sentanceData[i] = new Dictionary<string,int>(voc);
            }

            for(int i = 0; i < TrainData.Count; i++)
            {
                foreach(string words in TrainData[i])
                {
                    foreach(string word in ui)
                    {                        
                        if(words == word)
                        {
                            if (sentanceData[i].ContainsKey(word))
                            {
                                sentanceData[i][word]++;
                            }
                            else
                            {
                                sentanceData[i].Add(word, 1);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Thread Conpleted {0}", Thread.CurrentThread.ManagedThreadId);
            que[idx] = sentanceData;
            
        }

        static int size = 0;
        static HashSet<string> ui;
        static List<string> Vocab = new List<string>();
        static Dictionary<string, int>[][] que = new Dictionary<string, int>[ThreadCount][];


        static void Main(string[] args)
        {
            Run_PyScript();
            
            var keys = new List<string>(Data.Keys);
            var items = new List<List<string>>(Data.Values);
            ui = new HashSet<string>(Vocab);
            List<Task> tsk = new List<Task>();


            foreach (string str in ui)
            {
                voc.Add(str, 0);
            }

            size = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(keys.Count / ThreadCount))) + 1;

            var cn = 0;
            for (int i = 0; i < Data.Keys.Count; i += size)
            {

                var da = items.GetRange(i, Math.Min(size, Data.Keys.Count - i));
                // DataAnalysis(da, count);

                var tup = new Tuple<List<List<string>>, int>(da, cn);
                tsk.Add(Task.Factory.StartNew(() => DataAnalysis(tup)));
                cn++;
            }

            Task.WaitAll(tsk.ToArray());
            var superString = new List<string>();


            for (int i = 0; i < que.Length; i++)
            {
                for (int j = 0; j < que[i].Length; j++)
                {
                    var idx = j + i * size;

                    foreach (var vec in que[i][j])
                    {
                        superString.Add(keys[idx] + "::" + vec.Key + "," + vec.Value);

                    }
                }
            }

          
            Console.WriteLine("Running JSON Dump");
            Run_JsonDmp(string.Join("**",superString));
            Console.WriteLine("JSON Dump Executed");

            Console.WriteLine("PROGRAM TERMINATED");
        }
       
    }
}