﻿using System;

namespace Class1
{
    public class NetInfo
    {
        /// <summary>
        /// Get Mac address
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            System.Diagnostics.Process Process = new System.Diagnostics.Process();
            Process.StartInfo.FileName = "arp";
            Process.StartInfo.Arguments = "-a " + ipAddress;
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.CreateNoWindow = true;
            Process.Start();
            string strOutput = Process.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                         + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                         + "-" + substrings[7] + "-" + substrings[8].Substring(0, 2);
                return macAddress;
            }

            else
            {
                return "OWN Machine";
            }
        }

        /// <summary>
        /// get the name of host
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            return null;
        }
        /// <summary>
        /// Get list of Ports
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        List<int> getportid(string host)
        {
            List<int> vars = new List<int>();

            for (int i = 0; i < 1024; i++)
            {
                if (GetPort(host, i))
                {
                    vars.Add(i);
                }
            }
            return vars;

        }

        bool GetPort(string host, int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(200));
                    if (!success)
                    {
                        return false;
                    }

                    client.EndConnect(result);
                }

            }
            catch
            {
                return false;
            }
            return true;
        }


    }
}
