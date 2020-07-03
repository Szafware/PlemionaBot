using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace Plemiona.HardwareId.Desktop
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnGetHardwareId_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    string query = "Select ProcessorId From Win32_processor";
                    var managementObjectSearcher = new ManagementObjectSearcher(query);
                    var managementObjects = managementObjectSearcher.Get();
                    var managementObject = managementObjects.Cast<ManagementObject>().FirstOrDefault();
                    if (managementObject == null)
                    {
                        throw new Exception("No management object was found.");
                    }

                    string processorKey = managementObject["ProcessorId"].ToString();

                    TbxPlemionaKey.Clear();
                    TbxPlemionaKey.Text = processorKey;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Key could not be generated...\nMessage: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
