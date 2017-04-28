using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;
using System.Timers;

namespace HardwareMonitor
{
    class Program
    {
        static Computer thisPC;

        static HardwareType[] Hardware_Type = { HardwareType.CPU, HardwareType.RAM, HardwareType.GpuNvidia, HardwareType.HDD, HardwareType.Mainboard};
        static SensorType[] Sensor_Type = { SensorType.Load, SensorType.Power, SensorType.Temperature,  SensorType.Clock};

        static  private int SystemStatus(HardwareType CheckHard, SensorType CheckSensor)
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
                               return Convert.ToInt32(sensor.Value.Value);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            return 0;

        }
        



        static void Main(string[] args)
        {

            thisPC = new Computer() { GPUEnabled = true, CPUEnabled = true, RAMEnabled = true, HDDEnabled = true, FanControllerEnabled = true, MainboardEnabled = true };
            thisPC.Open();
            Timer timr = new Timer();
            timr.Start();

            var starttime = DateTime.Now;

            while (true)
            {
                var delta = DateTime.Now - starttime;

                Console.WriteLine(String.Format("TIME: {0} UPTIME: {1}", DateTime.Now, delta.ToString()));
                Console.WriteLine(String.Format("CPU Usage: {0}, CPU TEMP: {1}, CPU POWER: {2}, CPU CLOCK: {3}", SystemStatus(Hardware_Type[0], Sensor_Type[0]), SystemStatus(Hardware_Type[0], Sensor_Type[2]), SystemStatus(Hardware_Type[0], Sensor_Type[1]), SystemStatus(Hardware_Type[0], Sensor_Type[3])));
                Console.WriteLine(String.Format("MEM Usage: {0}, MEM TEMP: {1}, MEM POWER: {2}", SystemStatus(Hardware_Type[1], Sensor_Type[0]), SystemStatus(Hardware_Type[1], Sensor_Type[2]), SystemStatus(Hardware_Type[1], Sensor_Type[1])));
                Console.WriteLine(String.Format("GPU Usage: {0}, GPU TEMP: {1}, GPU POWER: {2}, GPU CLCOK: {3}", SystemStatus(Hardware_Type[2], Sensor_Type[0]), SystemStatus(Hardware_Type[2], Sensor_Type[2]), SystemStatus(Hardware_Type[2], Sensor_Type[1]), SystemStatus(Hardware_Type[2], Sensor_Type[3])));
                Console.WriteLine(String.Format("HDD Usage: {0}, HDD TEMP: {1}, HDD POWER: {2}", SystemStatus(Hardware_Type[3], Sensor_Type[0]), SystemStatus(Hardware_Type[3], Sensor_Type[2]), SystemStatus(Hardware_Type[3], Sensor_Type[1])));
                Console.WriteLine(String.Format("MOM Usage: {0}, MOM TEMP: {1}, MOM POWER: {2}", SystemStatus(Hardware_Type[4], Sensor_Type[0]), SystemStatus(Hardware_Type[4], Sensor_Type[2]), SystemStatus(Hardware_Type[4], Sensor_Type[1])));

                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

        }
    }
}
