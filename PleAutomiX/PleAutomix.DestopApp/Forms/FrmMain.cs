using System.ComponentModel;
using System.Windows.Forms;

namespace PleAutomix.DestopApp.Forms
{
    private static readonly IContainer _container = new NInjectContainer();

    private static AppSettings _appSettings;
    private static IActionExecuteService _actionExecuteService;
    private static ITranslationService _translationService;
    private static IInputService _inputService;

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
    }
}
