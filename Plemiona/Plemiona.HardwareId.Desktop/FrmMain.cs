using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace Plemiona.PlemKeyGenerator.Desktop
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnGeneratePlemKey_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    string processorKey = GetManagementObjectValue("SELECT ProcessorId From Win32_processor", "ProcessorId");
                    string motherboardKey = GetManagementObjectValue("SELECT SerialNumber FROM Win32_BaseBoard", "SerialNumber");

                    int processorKeyHalf = processorKey.Length / 2;

                    string plemKey = processorKey.Substring(0, processorKeyHalf) + motherboardKey + processorKey.Substring(processorKeyHalf);

                    TbxPlemKey.Clear();
                    TbxPlemKey.Text = plemKey;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Key could not be generated...\nMessage: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void TbxPlemKey_MouseClick(object sender, MouseEventArgs e)
        {
            TbxPlemKey.SelectAll();
        }
    }
}
