using Plemiona.DestopApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmTroopsAction : Form
    {
        private readonly IEnumerable<string> _invalidNames;
        private readonly IEnumerable<TroopsTemplate> _troopsTemplates;

        private readonly bool _editionMode;

        public TroopsAction TroopsAction { get; private set; }

        public bool Deletetion { get; private set; }

        public FrmTroopsAction(IEnumerable<string> invalidNames, IEnumerable<TroopsTemplate> troopsTemplates, TroopsAction troopsActionToEdition = null)
        {
            InitializeComponent();

            _invalidNames = invalidNames;
            _troopsTemplates = troopsTemplates;
            TroopsAction = troopsActionToEdition;

            _editionMode = troopsActionToEdition != null;

            CbxTroopsTemplate.Items.AddRange(_troopsTemplates.Select(tt => tt.Name).ToArray());
            CbxTroopsTemplate.SelectedIndex = 0;

            if (troopsActionToEdition != null)
            {
                BtnDeletion.Visible = true;

                TbxName.Text = troopsActionToEdition.Name;

                CbxTroopsTemplate.SelectedItem = troopsActionToEdition.TroopsTemplate.Name;

                LbxCoordinates.Items.AddRange(troopsActionToEdition.VillagesCoordinates.Select(vc => $"{vc.X}|{vc.Y}").ToArray());

                DtpckExecutionDate.Value = troopsActionToEdition.ExecutionDate;

                CkbxEveryday.Checked = troopsActionToEdition.Everyday;
            }

            BtnOk.Text = troopsActionToEdition != null ? "Edit" : "Add";
        }

        private void FrmTroopsAction_KeyPress(object sender, KeyPressEventArgs e)
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
                if (!_editionMode)
                {
                    TroopsAction = new TroopsAction();
                }

                if (string.IsNullOrEmpty(TbxName.Text))
                {
                    MessageBox.Show("Incorrect name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TroopsAction = null;
                    return;
                }

                if ((!_editionMode) && _invalidNames.Contains(TbxName.Text))
                {
                    MessageBox.Show($"Troops action with name of \"{TbxName.Text}\" already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TroopsAction = null;
                    return;
                }

                var coordinates = new List<Point>();

                try
                {
                    var coordinatesStrings = LbxCoordinates.Items.Cast<string>();

                    foreach (var coordinatesString in coordinatesStrings)
                    {
                        var coordinateArray = coordinatesString.Split('|');

                        var coordinate = new Point(Convert.ToInt32(coordinateArray[0]), Convert.ToInt32(coordinateArray[1]));

                        coordinates.Add(coordinate);
                    }
                }
                catch
                {
                    MessageBox.Show("Incorrect villages coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TroopsAction.Name = TbxName.Text;
                TroopsAction.TroopsTemplate = _troopsTemplates.Single(tt => tt.Name == CbxTroopsTemplate.Text);
                TroopsAction.VillagesCoordinates = coordinates;
                TroopsAction.ExecutionDate = DtpckExecutionDate.Value;
                TroopsAction.Everyday = CkbxEveryday.Checked;

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

                LbxCoordinates.Items.Add($"{coordinates.X}|{coordinates.Y}");
            }
            catch
            {
                MessageBox.Show("Incorrect coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}