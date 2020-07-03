using System;
using System.Linq;
using System.Management;

namespace Plemiona.Logic.Services.Registration.UniqueMachineKey
{
    public class UniqueProcessorKeyService : IUniqueMachineKeyService
    {
        public string GetKey()
        {
            string query = "Select ProcessorId From Win32_processor";

            using (var managementObjectSearcher = new ManagementObjectSearcher(query))
            {
                var managementObjects = managementObjectSearcher.Get();
                var processorManagementObject = managementObjects.Cast<ManagementObject>().FirstOrDefault();

                if (processorManagementObject == null)
                {
                    throw new Exception("No management object was found.");
                }

                string processorKey = processorManagementObject["ProcessorId"].ToString();

                foreach (var managementObject in managementObjects)
                {
                    managementObject.Dispose();
                }

                return processorKey;
            }
        }
    }
}