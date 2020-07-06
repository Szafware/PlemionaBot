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
using System.Drawing;
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
        private TroopsOrder _selectedTroopsOrder;

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

            //BackColor = Color.FromArgb(205, 189, 155);
            //TabTroopsTemplates.BackColor = Color.FromArgb(205, 189, 155);
            //TabTroopsOrders.BackColor = Color.FromArgb(205, 189, 155);
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            foreach (var troopsTemplate in _plemionaToolLocalData.TroopsTemplates)
            {
                GridTroopsTemplates.Rows.Add(GridTroopsTemplates.RowCount + 1, troopsTemplate.Name);
            }

            GridTroopsTemplates.ClearSelection();

            foreach (var troopsOrder in _plemionaToolLocalData.TroopsOrders)
            {
                GridTroopsOrders.Rows.Add(GridTroopsOrders.RowCount + 1, troopsOrder.Name, string.Join("..", troopsOrder.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}")), troopsOrder.ExecutionDate, troopsOrder.Everyday);
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
                if (e.RowIndex >= 0)
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

        #region TroopsOrders

        private void BtnAddTroopsOrder_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (var frmTroopsOrder = new FrmTroopsOrder(_plemionaToolLocalData.TroopsOrders.Select(tt => tt.Name), _plemionaToolLocalData.TroopsTemplates))
                {
                    var dialogResult = frmTroopsOrder.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        var troopsOrder = frmTroopsOrder.TroopsOrder;

                        _plemionaToolLocalData.TroopsOrders.Add(troopsOrder);

                        GridTroopsOrders.Rows.Add(GridTroopsOrders.RowCount + 1, troopsOrder.Name, string.Join("..", troopsOrder.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}")), troopsOrder.ExecutionDate, troopsOrder.Everyday);
                    }
                }
            }
        }

        private void GridTroopsOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string clickedTroopsOrderName = GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

                var clickedTroopOrder = _plemionaToolLocalData.TroopsOrders.Single(to => to.Name == clickedTroopsOrderName);

                if (clickedTroopOrder == _selectedTroopsOrder)
                {
                    _selectedTroopsOrder = null;
                    GridTroopsOrders.ClearSelection();
                }
                else
                {
                    _selectedTroopsOrder = clickedTroopOrder;
                }
            }
        }

        private void GridTroopsOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0)
                {
                    var troopsOrderName = GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

                    var troopsOrder = _plemionaToolLocalData.TroopsOrders.Single(ta => ta.Name == troopsOrderName);

                    using (var frmTroopsOrder = new FrmTroopsOrder(_plemionaToolLocalData.TroopsOrders.Select(tt => tt.Name), _plemionaToolLocalData.TroopsTemplates, troopsOrder))
                    {
                        var dialogResult = frmTroopsOrder.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            if (frmTroopsOrder.Deletetion)
                            {
                                _plemionaToolLocalData.TroopsOrders.Remove(troopsOrder);
                                GridTroopsOrders.Rows.RemoveAt(e.RowIndex);
                                FixGridNumbers(GridTroopsOrders);
                            }
                            else
                            {
                                GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value = troopsOrder.Name;
                                GridTroopsOrders.Rows[e.RowIndex].Cells[2].Value = string.Join("..", troopsOrder.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}"));
                                GridTroopsOrders.Rows[e.RowIndex].Cells[3].Value = troopsOrder.ExecutionDate.ToLongDateString();
                                GridTroopsOrders.Rows[e.RowIndex].Cells[4].Value = troopsOrder.Everyday;
                            }
                        }
                    }
                }
            }
        }

        private void GridTroopsOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_selectedTroopsOrder != null)
                {
                    _plemionaToolLocalData.TroopsOrders.Remove(_selectedTroopsOrder);

                    var selectedRow = GridTroopsOrders.Rows.Cast<DataGridViewRow>().Single(r => r.Cells[1].Value.ToString() == _selectedTroopsOrder.Name);

                    GridTroopsOrders.Rows.RemoveAt(selectedRow.Index);

                    FixGridNumbers(GridTroopsOrders);

                    GridTroopsOrders.ClearSelection();

                    _selectedTroopsOrder = null;
                }
            }
        }

        private async void GridTroopsOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridTroopsOrders.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string clickedTroopsOrderName = GridTroopsOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

                var clickedTroopOrder = _plemionaToolLocalData.TroopsOrders.Single(ta => ta.Name == clickedTroopsOrderName);

                var dialogResult = MessageBox.Show($"Are you sure that you want to perform order \"{clickedTroopOrder.Name}\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SetReady(false);

                    await Task.Run(() =>
                    {
                        int orderCount = clickedTroopOrder.VillagesCoordinates.Count();

                        int currentOrderNumber = 0;

                        for (int i = 0; i < orderCount; i++)
                        {
                            var coordinates = clickedTroopOrder.VillagesCoordinates[i];

                            try
                            {
                                currentOrderNumber++;

                                _plemionaFeaturesDiagnostics.SendTroops(clickedTroopOrder.TroopsTemplate.Troops, coordinates.X, coordinates.Y, TroopsIntentions.Attack, SendingTroopsInfo.Create(currentOrderNumber, orderCount));
                            }
                            catch (BotCheckException)
                            {
                                MessageBox.Show("Bot check detected, order stopped.", "Bot check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                SetReady(true);
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
            for (int i = 0; i < grid.RowCount - 1; i++)
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
                MessageBox.Show("Bot check detected, feature stopped", "Bot check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            GridTroopsTemplates.Enabled = ready;

            GridTroopsOrders.Enabled = ready;

            PnlStatus.BackColor = ready ? Color.Transparent : Color.Goldenrod;
        }
    }
}