using System;
using Rssdp;

namespace SharpSSDP
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using (var deviceLocator = new SsdpDeviceLocator())
            {
                var foundDevices = await deviceLocator.SearchAsync(); // Can pass search arguments here (device type, uuid). No arguments means all devices.

                foreach (var foundDevice in foundDevices)
                {
                    // Device data returned only contains basic device details and location ]
                    // of full device description.
                    Console.WriteLine("Found " + foundDevice.Usn + " at " + foundDevice.DescriptionLocation.ToString());

                    // Can retrieve the full device description easily though.
                    var fullDevice = await foundDevice.GetDeviceInfo();
                    Console.WriteLine(fullDevice.FriendlyName);
                    Console.WriteLine();
                }
            }
        }
    }
}
