using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

struct Variables
{

    public static int counter = 0;
    public static IPAddress startIP;
    public static IPAddress endIP;
    public static List<IPAddress> listofIP = new List<IPAddress>();
    public static List<ListViewItem> listofeverythin = new List<ListViewItem>();
    public static Thread MainThread;
    public static List<string> validIPs = new List<string>();
    public static List<string> ConsoleTxt = new List<string>();

   
}; 


namespace IPScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("IP", 100);
            listView1.Columns.Add("HostName", 200);
            listView1.Columns.Add("MAC Address", 300);
            listView1.Columns.Add("PORTS", 400);
            listView1.Sorting = SortOrder.Descending;
            performanceCounter1.BeginInit();

            timer1.Start();
        }


        public void Ping_all()
        {
            foreach (IPAddress i in Variables.listofIP)
            {
                Ping(i.ToString(), 4, 2000);
            }

        }
        /// <summary>
        /// Gives list of IP to a public list
        /// </summary>
        /// 
        public void giveIP()
        {
            Variables.startIP = IPAddress.Parse(StartIP.Text);
            Variables.endIP = IPAddress.Parse(EndIP.Text);

            List<IPAddress> lofIP = new List<IPAddress>();
            var bytes1 = Variables.startIP.GetAddressBytes();
            var bytes2 = Variables.endIP.GetAddressBytes();
            Array.Reverse(bytes1);
            Array.Reverse(bytes2);

            uint tempval_1 = BitConverter.ToUInt32(bytes1, 0);
            uint tempval_2 = BitConverter.ToUInt32(bytes2, 0);

            for (uint i = tempval_1; i < tempval_2; i++)
            {
                if (lofIP.Count != tempval_2 - tempval_1)
                {
                    var bytes = BitConverter.GetBytes(i);
                    Array.Reverse(bytes);
                    lofIP.Add(new IPAddress(bytes));
                }
            }
            Variables.listofIP = lofIP;
        }

        /// <summary>
        /// Ping
        /// </summary>
        /// <param name="host"></param>
        /// <param name="att"></param>
        /// <param name="time"></param>
        public void Ping(string host, int att, int time)
        {
            new Thread(delegate ()
            {

                for (int i = 0; i < att; i++)
                {
                    if (Variables.validIPs.Contains(host) == false)
                    {

                        try
                        {
                            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                            ping.PingCompleted += new PingCompletedEventHandler(PingCompleted);
                            ping.SendAsync(host, time, host);
                        }
                        catch
                        {
                            Thread.CurrentThread.Abort();
                        }
                    }
                    Variables.counter++;
                }
            }).Start();     
        }

        /// <summary>
        /// Ping handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PingCompleted(object sender, PingCompletedEventArgs e)
        {

            string ip = (string)e.UserState;
            Variables.validIPs.Add(ip);

            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                string hostname = NetInfo.GetHostName(ip);
                string macaddres = NetInfo.GetMacAddress(ip);
                string ports = " ";
                List<int> portisopen = NetInfo.getportid(ip, Convert.ToInt32(MaxPortValue.Text));
                string[] arr = new string[4];

                foreach (int i in portisopen)
                {
                    ports = ports + "," + i.ToString();
                }
                //store all three parameters to be shown on ListView
                arr[0] = ip;
                arr[1] = hostname;
                arr[2] = macaddres;
                arr[3] = ports;

                // Logic for Ping Reply Success
                ListViewItem item;
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        item = new ListViewItem(arr);
                        listView1.Items.Add(item);
                        Variables.counter++;
                    }));
                }
            }
          

        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            giveIP();
            
            progressBar1.Maximum = Variables.listofIP.Count() * 8;

            Variables.MainThread = new Thread(delegate ()
            {
                Ping_all();
            });
            Variables.MainThread.Name = "MAINTHREAD";
            Variables.MainThread.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // progressBar1.Value = Variables.counter;
            Variables.ConsoleTxt.Add(performanceCounter1.NextValue().ToString());
            Console.Lines = Variables.ConsoleTxt.ToArray<string>();
            MemoryStatus.Value = Convert.ToInt32(MEMperformance.NextValue());
            CPUStatus.Value = Convert.ToInt32(CPUperformance.NextValue());
            timer1.Interval += 1;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string[] array = NetInfo.NetworkGateway().Split('.');
            StartIP.Text = array[0] + "." + array[1] + "." + array[2] + "." + array[3];
            EndIP.Text = array[0] + "." + array[1] + "." + array[2] + "." + "255";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
