using System;
using System.Linq;
using System.Management;

namespace Plemiona.Logic.Services.Registration.UniqueMachineKey
{
    public class ProcessorAndMotherboardKeyService : IUniqueMachineKeyService
    {
        public string GetKey()
        {
            string processorKey = GetManagementObjectValue("SELECT ProcessorId From Win32_processor", "ProcessorId");
            string motherboardKey = GetManagementObjectValue("SELECT SerialNumber FROM Win32_BaseBoard", "SerialNumber");

            int processorKeyHalf = processorKey.Length / 2;

            string plemKey = processorKey.Substring(0, processorKeyHalf) + motherboardKey + processorKey.Substring(processorKeyHalf);

            return plemKey;
        }

        private string GetManagementObjectValue(string query, string key)
        {
            using (var managementObjectSearcher = new ManagementObjectSearcher(query))
            {
                var managementObjects = managementObjectSearcher.Get();

                using (var managementObject = managementObjects.Cast<ManagementObject>().FirstOrDefault())
                {
                    if (managementObject == null)
                    {
                        throw new Exception("No management object was found.");
                    }

                    string value = managementObject[key].ToString();

                    return value;
                }
            }
        }
    }
}