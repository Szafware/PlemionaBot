using Plemiona.Core.Interfaces;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmMain : Form
    {
        private readonly IPlemionaFeatures _plemionaFeatures;

        public FrmMain(IPlemionaFeatures plemionaFeatures)
        {
            InitializeComponent();

            _plemionaFeatures = plemionaFeatures;
        }
    }
}