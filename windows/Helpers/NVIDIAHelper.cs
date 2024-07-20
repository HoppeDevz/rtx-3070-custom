using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibreHardwareMonitor.Hardware;
using rtx_display.Entities;

namespace rtx_display.Helpers
{
    public class NVIDIAHelper
    {

        private static Label gpuUsageLabel;
        private static Label gpuTempLabel;
        private static Label threadIndicatorLabel;

        private static string microControllerRoute = "http://192.168.3.111:32455/update-gpu-data";
        private static readonly HttpClient client = new HttpClient();

        private static Computer computer = new Computer()
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMotherboardEnabled = true,
            IsMemoryEnabled = true,
            IsStorageEnabled = true,
            IsNetworkEnabled = false
        };

        public static void StartGpuThread(Label gpuUsageLbl, Label gpuTempLbl, Label threadIndicatorLbl)
        {
            gpuUsageLabel = gpuUsageLbl;
            gpuTempLabel = gpuTempLbl;
            threadIndicatorLabel = threadIndicatorLbl;

            computer.Open();
            new Task(GpuDataLoop).Start();
        }

        public static void GpuDataLoop()
        {
            while (true)
            {
                GpuDataThread();
                Thread.Sleep(2 * 1000);
            }
        }

        public static void GpuDataThread()
        {
            try
            {

                threadIndicatorLabel.Text = "Sending Data...";

                IGpuData monitor = new IGpuData()
                {
                    gpu_usage = 0.0,
                    gpu_temperature = 0.0
                };

                foreach (IHardware hardware in computer.Hardware)
                { 
                    if (hardware.HardwareType == HardwareType.GpuNvidia)
                    {

                        hardware.Update();
                        hardware.GetReport();

                        foreach (ISensor sensor in hardware.Sensors)
                        {

                            string sensorName = sensor.Name;
                            Console.WriteLine(sensorName);

                            if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                            {
                                monitor.gpu_usage = sensor.Value.GetValueOrDefault() / 100;
                            }

                            //if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("GPU Core"))
                            //{
                            //    monitor.clockFrequency = sensor.Value.GetValueOrDefault();
                            //}

                            if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                            {
                                monitor.gpu_temperature = sensor.Value.GetValueOrDefault();
                            }
                        }
                    }
                }

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(monitor);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.PostAsync(microControllerRoute, content);
                
                gpuUsageLabel.Text = $"GPU USAGE: {monitor.gpu_usage * 100}%";
                gpuTempLabel.Text = $"GPU TEMPERATURE: {monitor.gpu_temperature} C";

                threadIndicatorLabel.Text = "";

            } catch
            {
                throw;
            }
        }

    }
}
