using OpenQA.Selenium.Remote;
using Plemiona.Core.Enums;
using Plemiona.Core.Exceptions;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Models.Features;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.DestopApp.Models;
using Plemiona.DestopApp.Properties;
using Plemiona.DestopApp.Services;
using Plemiona.Logic.Services.PlemionaSettingsInitialization;
using Plemiona.Logic.Services.Registration;
using Plemiona.Logic.Services.WindowsPosition;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmMain : Form
    {
        private readonly IPlemionaFeaturesDiagnostics _plemionaFeaturesDiagnostics;
        private readonly IWebDriverProviderService _webDriverProviderService;
        private readonly IStepDelayService _stepDelayService;
        private RemoteWebDriver _webDriver;

        private readonly IWindowsPositionService _windowsPositionService;
        private readonly IPlemionaSettingsInitializationService _plemionaSettingsInitializationService;

        private readonly PlemionaToolLocalDataService _plemionaToolLocalDataService = new PlemionaToolLocalDataService();
        private PlemionaFeaturesDiagnosticsService _plemionaFeaturesDiagnosticsService;
        private PlemionaToolLocalData _plemionaToolLocalData;

        private TroopsTemplate _selectedTroopsTemplate;
        private TroopsAction _selectedTroopsAction;

        public FrmMain(
            IPlemionaFeaturesDiagnostics plemionaFeaturesDiagnostics,
            IWebDriverProviderService webDriverProviderService,
            IStepDelayService stepDelayService,
            IWindowsPositionService windowsPositionService,
            IPlemionaSettingsInitializationService plemionaSettingsInitializationService,
            IRegistrationService registrationService
            )
        {
            InitializeComponent();

            _plemionaFeaturesDiagnostics = plemionaFeaturesDiagnostics;
            _webDriverProviderService = webDriverProviderService;
            _stepDelayService = stepDelayService;
            _windowsPositionService = windowsPositionService;
            _plemionaSettingsInitializationService = plemionaSettingsInitializationService;

            Initialize(registrationService, webDriverProviderService);
        }

        private void Initialize(IRegistrationService registrationService, IWebDriverProviderService webDriverProviderService)
        {
            if (!registrationService.IsCurrentMachineRegistrated())
            {
                MessageBox.Show("Your machine has not been registered.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            _plemionaToolLocalData = _plemionaToolLocalDataService.Load();

            _webDriver = webDriverProviderService.CreateWebDriver();

            _windowsPositionService.SetMainFormWindow(this);

            var browserWindow = _webDriver.Manage().Window;

            _windowsPositionService.SetBrowserWindow(browserWindow);

            GridTroopsTemplates.LostFocus += (s, e) => GridTroopsTemplates.ClearSelection();
            GridTroopsOrders.LostFocus += (s, e) => GridTroopsOrders.ClearSelection();

            _plemionaFeaturesDiagnosticsService = new PlemionaFeaturesDiagnosticsService(TbxDiagnostics);
            _plemionaFeaturesDiagnostics.OnStepDelay += _plemionaFeaturesDiagnosticsService.LogStepDelay;
            //_plemionaFeaturesDiagnostics.OnStepStart += _plemionaFeaturesDiagnosticsService.LogStepStart;
            _plemionaFeaturesDiagnostics.OnStepEnd += _plemionaFeaturesDiagnosticsService.LogStepEnd;
            _plemionaFeaturesDiagnostics.OnFeatureStart += _plemionaFeaturesDiagnosticsService.LogFeatureStart;
            _plemionaFeaturesDiagnostics.OnFeatureEnd += _plemionaFeaturesDiagnosticsService.LogFeatureEnd;
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            foreach (var troopsTemplate in _plemionaToolLocalData.TroopsTemplates)
            {
                GridTroopsTemplates.Rows.Add(GridTroopsTemplates.RowCount + 1, troopsTemplate.Name);
            }

            GridTroopsTemplates.ClearSelection();

            foreach (var troopsAction in _plemionaToolLocalData.TroopsActions)
            {
                GridTroopsOrders.Rows.Add(GridTroopsOrders.RowCount + 1, troopsAction.Name, string.Join("..", troopsAction.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}")), troopsAction.ExecutionDate, troopsAction.Everyday);
            }

            GridTroopsOrders.ClearSelection();

            SetReady(false);

            await Task.Run(() =>
            {
                _plemionaSettingsInitializationService.Initialize();

                string username = ConfigurationManager.AppSettings["Username"];
                string password = ConfigurationManager.AppSettings["Password"];
                int worldNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WorldNumber"]);

                _plemionaFeaturesDiagnostics.SignIn(username, password, worldNumber);
            });

            SetReady(true);
        }

        #region TroopsTemplates

        private void BtnAddTroopsTemplate_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (var frmTroopsTemplate = new FrmTroopsTemplate(_plemionaToolLocalData.TroopsTemplates.Select(tt => tt.Name)))
                {
                    var dialogResult = frmTroopsTemplate.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        var troopsTemplate = frmTroopsTemplate.TroopsTemplate;

                        _plemionaToolLocalData.TroopsTemplates.Add(troopsTemplate);

                        GridTroopsTemplates.Rows.Add(GridTroopsTemplates.RowCount + 1, troopsTemplate.Name);
                    }
                }
            }
        }

        private void GridTroopsTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string clickedTroopsTemplateName = GridTroopsTemplates.Rows[e.RowIndex].Cells[1].Value.ToString();

                var clickedTroopTemplates = _plemionaToolLocalData.TroopsTemplates.Single(tt => tt.Name == clickedTroopsTemplateName);

                if (clickedTroopTemplates == _selectedTroopsTemplate)
                {
                    _selectedTroopsTemplate = null;
                    GridTroopsTemplates.ClearSelection();
                }
                else
                {
                    _selectedTroopsTemplate = clickedTroopTemplates;
                }
            }
        }

        private void GridTroopsTemplates_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex > 0)
                {
                    var troopsTemplateName = GridTroopsTemplates.Rows[e.RowIndex].Cells[1].Value.ToString();

                    var troopsTemplate = _plemionaToolLocalData.TroopsTemplates.Single(tt => tt.Name == troopsTemplateName);

                    using (var frmTroopsTemplate = new FrmTroopsTemplate(_plemionaToolLocalData.TroopsTemplates.Select(tt => tt.Name), troopsTemplate))
                    {
                        var dialogResult = frmTroopsTemplate.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            if (frmTroopsTemplate.Deletetion)
                            {
                                _plemionaToolLocalData.TroopsTemplates.Remove(troopsTemplate);
                                GridTroopsTemplates.Rows.RemoveAt(e.RowIndex);
                                FixGridNumbers(GridTroopsTemplates);
                            }
                            else
                            {
                                GridTroopsTemplates.Rows[e.RowIndex].Cells[1].Value = troopsTemplate.Name;
                            }
                        }
                    }
                }
            }
        }

        private void GridTroopsTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_selectedTroopsTemplate != null)
                {
                    _plemionaToolLocalData.TroopsTemplates.Remove(_selectedTroopsTemplate);

                    var selectedRow = GridTroopsTemplates.Rows.Cast<DataGridViewRow>().Single(r => r.Cells[1].Value.ToString() == _selectedTroopsTemplate.Name);

                    GridTroopsTemplates.Rows.RemoveAt(selectedRow.Index);

                    FixGridNumbers(GridTroopsTemplates);

                    GridTroopsTemplates.ClearSelection();

                    _selectedTroopsTemplate = null;
                }
            }
        }

        #endregion

        #region TroopsActions

        private void BtnAddTroopsAction_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (var frmTroopsAction = new FrmTroopsAction(_plemionaToolLocalData.TroopsActions.Select(tt => tt.Name), _plemionaToolLocalData.TroopsTemplates))
                {
                    var dialogResult = frmTroopsAction.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        var troopsAction = frmTroopsAction.TroopsAction;

                        _plemionaToolLocalData.TroopsActions.Add(troopsAction);

                        GridTroopsOrders.Rows.Add(GridTroopsTemplates.RowCount + 1, troopsAction.Name, string.Join("..", troopsAction.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}")), troopsAction.ExecutionDate, troopsAction.Everyday);
                    }
                }
            }
        }

        private void GridTroopsActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string clickedTroopsActionName = GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

                var clickedTroopAction = _plemionaToolLocalData.TroopsActions.Single(ta => ta.Name == clickedTroopsActionName);

                if (clickedTroopAction == _selectedTroopsAction)
                {
                    _selectedTroopsAction = null;
                    GridTroopsTemplates.ClearSelection();
                }
                else
                {
                    _selectedTroopsAction = clickedTroopAction;
                }
            }
        }

        private void GridTroopsActions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex > 0)
                {
                    var troopsActionName = GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

                    var troopsAction = _plemionaToolLocalData.TroopsActions.Single(ta => ta.Name == troopsActionName);

                    using (var frmTroopsAction = new FrmTroopsAction(_plemionaToolLocalData.TroopsActions.Select(tt => tt.Name), _plemionaToolLocalData.TroopsTemplates, troopsAction))
                    {
                        var dialogResult = frmTroopsAction.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            if (frmTroopsAction.Deletetion)
                            {
                                _plemionaToolLocalData.TroopsActions.Remove(troopsAction);
                                GridTroopsOrders.Rows.RemoveAt(e.RowIndex);
                                FixGridNumbers(GridTroopsOrders);
                            }
                            else
                            {
                                GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value = troopsAction.Name;
                                GridTroopsOrders.Rows[e.RowIndex].Cells[2].Value = string.Join("..", troopsAction.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}"));
                                GridTroopsOrders.Rows[e.RowIndex].Cells[3].Value = troopsAction.ExecutionDate.ToLongDateString();
                                GridTroopsOrders.Rows[e.RowIndex].Cells[4].Value = troopsAction.Everyday;
                            }
                        }
                    }
                }
            }
        }

        private void GridTroopsActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_selectedTroopsAction != null)
                {
                    _plemionaToolLocalData.TroopsActions.Remove(_selectedTroopsAction);

                    var selectedRow = GridTroopsOrders.Rows.Cast<DataGridViewRow>().Single(r => r.Cells[1].Value.ToString() == _selectedTroopsAction.Name);

                    GridTroopsOrders.Rows.RemoveAt(selectedRow.Index);

                    FixGridNumbers(GridTroopsOrders);

                    GridTroopsOrders.ClearSelection();

                    _selectedTroopsAction = null;
                }
            }
        }

        private async void GridTroopsActions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridTroopsOrders.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string clickedTroopsActionName = GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

                var clickedTroopAction = _plemionaToolLocalData.TroopsActions.Single(ta => ta.Name == clickedTroopsActionName);

                var dialogResult = MessageBox.Show($"Are you sure that you want to perform action \"{clickedTroopAction.Name}\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SetReady(false);

                    await Task.Run(() =>
                    {
                        int actionCount = clickedTroopAction.VillagesCoordinates.Count();

                        for (int i = 0; i < actionCount; i++)
                        {
                            var coordinates = clickedTroopAction.VillagesCoordinates[i];

                            try
                            {
                                _plemionaFeaturesDiagnostics.SendTroops(clickedTroopAction.TroopsTemplate.Troops, coordinates.X, coordinates.Y, TroopsIntentions.Attack, SendingTroopsInfo.Create(i + 1, actionCount));
                            }
                            catch (BotCheckException)
                            {
                                MessageBox.Show("Bot check detected, action stopped", "Bot check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            catch (FeatureException fe)
                            {
                                MessageBox.Show($"{coordinates.X}|{coordinates.Y}\n" + fe.PlemionaErrorMessage, $"{(fe.PlemionaError ? "Plemiona" : "Unexpected")} Error", MessageBoxButtons.OK, fe.PlemionaError ? MessageBoxIcon.Warning: MessageBoxIcon.Error);
                            }
                        }
                    });

                    SetReady(true);
                }
            }
        }

        #endregion

        private void FixGridNumbers(DataGridView grid)
        {
            for (int i = 0; i < GridTroopsTemplates.RowCount - 1; i++)
            {
                grid.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _plemionaToolLocalDataService.Save(_plemionaToolLocalData);
            }
            catch
            {
                MessageBox.Show($"Saving data failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _webDriver.Quit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var village = _plemionaFeaturesDiagnostics.GetVillage(692, 518);

                ;
            }
            catch (BotCheckException)
            {
                MessageBox.Show("Bot check detected, action stopped", "Bot check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (FeatureException fe)
            {
                MessageBox.Show(fe.PlemionaErrorMessage, $"{(fe.PlemionaError ? "Plemiona" : "Unexpected")} Error", MessageBoxButtons.OK, fe.PlemionaError ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
        }

        private void SetReady(bool ready)
        {
            PctbxStatus.Image = ready ? null : Resources.GifLoading;
            PctbxStatus.BackgroundImage = ready ? Resources.PictureReady : null;
            LblStatus.Text = ready ? "Ready" : "Processing...";

            BtnAddTroopsTemplate.Enabled = ready;
            GridTroopsTemplates.Enabled = ready;

            BtnAddTroopsOrders.Enabled = ready;
            GridTroopsOrders.Enabled = ready;
        }
    }
}