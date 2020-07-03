﻿using OpenQA.Selenium.Remote;
using Plemiona.Core.Enums;
using Plemiona.Core.Exceptions;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Models.Features;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.DestopApp.Models;
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
        private readonly IPlemionaFeatures _plemionaFeatures;
        private readonly IWebDriverProviderService _webDriverProviderService;
        private readonly IStepDelayService _stepDelayService;
        private readonly RemoteWebDriver _webDriver;

        private readonly IWindowsPositionService _windowsPositionService;
        private readonly IPlemionaSettingsInitializationService _plemionaSettingsInitializationService;

        private readonly PlemionaToolLocalDataService _plemionaToolLocalDataService = new PlemionaToolLocalDataService();
        private readonly PlemionaToolLocalData _plemionaToolLocalData;

        private TroopsTemplate _selectedTroopsTemplate;
        private TroopsAction _selectedTroopsAction;

        public FrmMain(
            IPlemionaFeatures plemionaFeatures,
            IWebDriverProviderService webDriverProviderService,
            IStepDelayService stepDelayService,
            IWindowsPositionService windowsPositionService,
            IPlemionaSettingsInitializationService plemionaSettingsInitializationService,
            IRegistrationService registrationService
            )
        {
            if (!registrationService.IsCurrentMachineRegistrated())
            {
                MessageBox.Show("Your machine has not been registered.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            InitializeComponent();

            _plemionaFeatures = plemionaFeatures;
            _webDriverProviderService = webDriverProviderService;
            _stepDelayService = stepDelayService;
            _windowsPositionService = windowsPositionService;
            _plemionaSettingsInitializationService = plemionaSettingsInitializationService;

            _plemionaToolLocalData = _plemionaToolLocalDataService.Load();

            _webDriver = webDriverProviderService.CreateWebDriver();

            _windowsPositionService.SetMainFormWindow(this);

            var browserWindow = _webDriver.Manage().Window;

            _windowsPositionService.SetBrowserWindow(browserWindow);

            GridTroopsTemplates.LostFocus += (s, e) => GridTroopsTemplates.ClearSelection();
            GridTroopsActions.LostFocus += (s, e) => GridTroopsActions.ClearSelection();
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
                GridTroopsActions.Rows.Add(GridTroopsActions.RowCount + 1, troopsAction.Name, string.Join("..", troopsAction.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}")), troopsAction.ExecutionDate, troopsAction.Everyday);
            }

            GridTroopsActions.ClearSelection();

            await Task.Run(() =>
            {
                _plemionaSettingsInitializationService.Initialize();

                string username = ConfigurationManager.AppSettings["Username"];
                string password = ConfigurationManager.AppSettings["Password"];
                int worldNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WorldNumber"]);

                _plemionaFeatures.SignIn(username, password, worldNumber);
            });
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

                        GridTroopsActions.Rows.Add(GridTroopsTemplates.RowCount + 1, troopsAction.Name, string.Join("..", troopsAction.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}")), troopsAction.ExecutionDate, troopsAction.Everyday);
                    }
                }
            }
        }

        private void GridTroopsActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string clickedTroopsActionName = GridTroopsActions.Rows[e.RowIndex].Cells[1].Value.ToString();

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
                    var troopsActionName = GridTroopsActions.Rows[e.RowIndex].Cells[1].Value.ToString();

                    var troopsAction = _plemionaToolLocalData.TroopsActions.Single(ta => ta.Name == troopsActionName);

                    using (var frmTroopsAction = new FrmTroopsAction(_plemionaToolLocalData.TroopsActions.Select(tt => tt.Name), _plemionaToolLocalData.TroopsTemplates, troopsAction))
                    {
                        var dialogResult = frmTroopsAction.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            if (frmTroopsAction.Deletetion)
                            {
                                _plemionaToolLocalData.TroopsActions.Remove(troopsAction);
                                GridTroopsActions.Rows.RemoveAt(e.RowIndex);
                                FixGridNumbers(GridTroopsActions);
                            }
                            else
                            {
                                GridTroopsActions.Rows[e.RowIndex].Cells[1].Value = troopsAction.Name;
                                GridTroopsActions.Rows[e.RowIndex].Cells[2].Value = string.Join("..", troopsAction.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}"));
                                GridTroopsActions.Rows[e.RowIndex].Cells[3].Value = troopsAction.ExecutionDate.ToLongDateString();
                                GridTroopsActions.Rows[e.RowIndex].Cells[4].Value = troopsAction.Everyday;
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

                    var selectedRow = GridTroopsActions.Rows.Cast<DataGridViewRow>().Single(r => r.Cells[1].Value.ToString() == _selectedTroopsAction.Name);

                    GridTroopsActions.Rows.RemoveAt(selectedRow.Index);

                    FixGridNumbers(GridTroopsActions);

                    GridTroopsActions.ClearSelection();

                    _selectedTroopsAction = null;
                }
            }
        }

        private async void GridTroopsActions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridTroopsActions.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string clickedTroopsActionName = GridTroopsActions.Rows[e.RowIndex].Cells[1].Value.ToString();

                var clickedTroopAction = _plemionaToolLocalData.TroopsActions.Single(ta => ta.Name == clickedTroopsActionName);

                var dialogResult = MessageBox.Show($"Are you sure that you want to perform action \"{clickedTroopAction.Name}\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    await Task.Run(() =>
                    {
                        int actionCount = clickedTroopAction.VillagesCoordinates.Count();

                        for (int i = 0; i < actionCount; i++)
                        {
                            var coordinates = clickedTroopAction.VillagesCoordinates[i];

                            try
                            {
                                _plemionaFeatures.SendTroops(clickedTroopAction.TroopsTemplate.Troops, coordinates.X, coordinates.Y, TroopsIntentions.Attack, SendingTroopsInfo.Create(i + 1, actionCount));
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
                //_plemionaFeatures.SendTroops(new Core.Models.Troops { Scouts = 1 }, 692, 517, TroopsIntentions.Attack);
                var player = _plemionaFeatures.GetOwnPlayer();
            }
            catch (FeatureException ex)
            {
                MessageBox.Show(ex.Message, "Plemiona Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}