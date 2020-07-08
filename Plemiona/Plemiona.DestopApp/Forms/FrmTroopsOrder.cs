using Plemiona.Core.Models;
using Plemiona.DestopApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmTroopsOrder : Form
    {
        private readonly IEnumerable<string> _invalidNames;
        private readonly IEnumerable<TroopsTemplate> _troopsTemplates;

        private readonly bool _editionMode;

        private Troops _ownTroops;
        private Troops _requiredTroops;

        public TroopsOrder TroopsOrder { get; private set; }

        public bool Deletetion { get; private set; }

        public FrmTroopsOrder(IEnumerable<string> invalidNames, IEnumerable<TroopsTemplate> troopsTemplates, Troops ownTroops, TroopsOrder troopsOrderToEdition = null)
        {
            InitializeComponent();

            _invalidNames = invalidNames;
            _troopsTemplates = troopsTemplates;
            _ownTroops = ownTroops;

            _editionMode = troopsOrderToEdition != null;

            TroopsOrder = _editionMode ? troopsOrderToEdition : new TroopsOrder();

            CbxTroopsTemplate.Items.AddRange(_troopsTemplates.Select(tt => tt.Name).ToArray());

            if (_editionMode)
            {
                BtnDeletion.Visible = true;

                TbxName.Text = troopsOrderToEdition.Name;

                CbxTroopsTemplate.SelectedItem = troopsOrderToEdition.TroopsTemplate.Name;

                LbxCoordinates.Items.AddRange(troopsOrderToEdition.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}").ToArray());

                DtpckExecutionDate.Value = troopsOrderToEdition.ExecutionDate;

                CkbxEveryday.Checked = troopsOrderToEdition.Everyday;

                UpdateRequiredTroops();
            }
            else
            {
                CbxTroopsTemplate.SelectedIndex = 0;
            }

            BtnOk.Text = troopsOrderToEdition != null ? "Edit" : "Add";
        }

        private void FrmTroopsOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = (Keys)e.KeyChar;

            if (key == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (key == Keys.Enter)
            {
                BtnCancel_MouseClick(BtnOk, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            }
        }

        private void BtnDeletion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Deletetion = true;

                DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnOk_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //if (!_editionMode)
                //{
                //    TroopsOrder = new TroopsOrder();
                //}

                if (string.IsNullOrEmpty(TbxName.Text))
                {
                    MessageBox.Show("Incorrect name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TroopsOrder = null;
                    return;
                }

                if ((!_editionMode) && _invalidNames.Contains(TbxName.Text))
                {
                    MessageBox.Show($"Troops order with name of \"{TbxName.Text}\" already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TroopsOrder = null;
                    return;
                }

                List<Point> coordinates = null;

                try
                {
                    coordinates = GetCoordinates().ToList();
                }
                catch
                {
                    MessageBox.Show("Incorrect villages coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TroopsOrder.Name = TbxName.Text;
                TroopsOrder.TroopsTemplate = _troopsTemplates.Single(tt => tt.Name == CbxTroopsTemplate.Text);
                TroopsOrder.VillagesCoordinates = coordinates;
                TroopsOrder.ExecutionDate = DtpckExecutionDate.Value;
                TroopsOrder.Everyday = CkbxEveryday.Checked;

                DialogResult = DialogResult.OK;
            }
        }

        private void BtnDeleteCoordinates_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedCoordinates = LbxCoordinates.SelectedItem;

            LbxCoordinates.Items.Remove(selectedCoordinates);
        }

        private void BtnAddCoordinate_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var coordinates = new Point(Convert.ToInt32(TbxCoordinateX.Text), Convert.ToInt32(TbxCoordinateY.Text));

                if (LbxCoordinates.Items.Cast<string>().Any(c => c == $"{coordinates.X}|{coordinates.Y}"))
                {
                    MessageBox.Show("Coordinates are already in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LbxCoordinates.Items.Add($"{coordinates.X}|{coordinates.Y}");

                UpdateRequiredTroops();
            }
            catch
            {
                MessageBox.Show("Incorrect coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CbxTroopsTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            TroopsOrder.TroopsTemplate = _troopsTemplates.Single(tt => tt.Name == CbxTroopsTemplate.Text);

            UpdateRequiredTroops();
        }

        private void BtnShowTroopsTemplate_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedTroopsTemplate = _troopsTemplates.Single(tt => tt.Name == CbxTroopsTemplate.Text);

            using (var frmTroopsTemplate = new FrmTroopsTemplate(selectedTroopsTemplate))
            {
                frmTroopsTemplate.ShowDialog();
            }
        }

        private void BtnCheckRequiredTroops_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var requiredTroopsTemplate = new TroopsTemplate
                {
                    Name = "Troops required to perform order",
                    Troops = _requiredTroops
                };

                using (var frmTroopsTemplate = new FrmTroopsTemplate(requiredTroopsTemplate))
                {
                    frmTroopsTemplate.ShowDialog();
                } 
            }
        }

        private IEnumerable<Point> GetCoordinates()
        {
            var coordinatesStrings = LbxCoordinates.Items.Cast<string>();

            var coordinates = new List<Point>();

            foreach (var coordinatesString in coordinatesStrings)
            {
                var coordinateArray = coordinatesString.Split('|');

                var coordinate = new Point(Convert.ToInt32(coordinateArray[0]), Convert.ToInt32(coordinateArray[1]));

                coordinates.Add(coordinate);
            }

            return coordinates;
        }

        private void UpdateRequiredTroops()
        {
            var villageTargets = GetCoordinates();

            int villageTargetCount = villageTargets.Count();

            var activeTroops = TroopsOrder.TroopsTemplate.Troops;

            _requiredTroops = new Troops();

            for (int i = 0; i < villageTargetCount; i++)
            {
                _requiredTroops += activeTroops;
            }

            if ((_requiredTroops.Spearmen > _ownTroops.Spearmen) || (_requiredTroops.Swordmen > _ownTroops.Swordmen) || (_requiredTroops.Axemen > _ownTroops.Axemen) || (_requiredTroops.Bowmen > _ownTroops.Bowmen) ||
                (_requiredTroops.Scouts > _ownTroops.Scouts) || (_requiredTroops.LightCavalary > _ownTroops.LightCavalary) || (_requiredTroops.HorseArchers > _ownTroops.HorseArchers) || (_requiredTroops.HeavyCavalary > _ownTroops.HeavyCavalary) ||
                (_requiredTroops.Rams > _ownTroops.Rams) || (_requiredTroops.Catapultes > _ownTroops.Catapultes) ||
                (_requiredTroops.Knights > _ownTroops.Knights) || (_requiredTroops.Noblemen > _ownTroops.Noblemen))
            {
                LblRequiredTroopsStatus.ForeColor = Color.Red;
                LblRequiredTroopsStatus.Text = "Not enough troops";
            }
            else
            {
                LblRequiredTroopsStatus.ForeColor = Color.LimeGreen;
                LblRequiredTroopsStatus.Text = "Enough troops";
            }
        }
    }
}