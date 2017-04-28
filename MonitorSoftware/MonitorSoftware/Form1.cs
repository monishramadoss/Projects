using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;


namespace MonitorSoftware
{
    public partial class Form1 : Form
    {
        Computer thisPC;

        HardwareType[] Hardware_Type =  { HardwareType.GpuNvidia, HardwareType.CPU, HardwareType.HDD, HardwareType.RAM, HardwareType.Mainboard };
        SensorType[] Sensor_Type = {SensorType.Load, SensorType.Power, SensorType.Temperature, SensorType.Voltage};


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SystemFunction(Hardware_Type[0], Sensor_Type[0], GPUStatus);
            SystemFunction(Hardware_Type[1], Sensor_Type[0], CPUStatus);
            SystemFunction(Hardware_Type[3], Sensor_Type[0], MEMStatus);

            timer1.Interval += 1;

        }

        private void SystemFunction(HardwareType CheckHard, SensorType CheckSensor, ProgressBar bar)
        {

            foreach (var hardwareItem in thisPC.Hardware)
            {
                if (hardwareItem.HardwareType == CheckHard)
                {
                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                    {
                        subHardware.Update();
                    }
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == CheckSensor)
                        {
                            try
                            {
                                bar.Value = Convert.ToInt32(sensor.Value.Value);
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
