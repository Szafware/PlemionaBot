using Plemiona.Core.Models;
using Plemiona.DestopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmTroopsTemplate : Form
    {
        private readonly IEnumerable<string> _invalidNames;

        private readonly bool _editionMode;
        private readonly bool _readonlyMode;

        public TroopsTemplate TroopsTemplate { get; private set; }

        public bool Deletetion { get; private set; }

        public FrmTroopsTemplate(IEnumerable<string> invalidNames, TroopsTemplate troopsTemplateToEdition = null)
        {
            InitializeComponent();

            _invalidNames = invalidNames;
            TroopsTemplate = troopsTemplateToEdition;

            _editionMode = troopsTemplateToEdition != null;

            if (troopsTemplateToEdition != null)
            {
                BtnDeletion.Visible = true;

                FillData(troopsTemplateToEdition);
            }

            BtnOk.Text = troopsTemplateToEdition != null ? "Edit" : "Add";
        }

        public FrmTroopsTemplate(TroopsTemplate readonlyTroopsTemplateToShow)
        {
            InitializeComponent();

            _readonlyMode = true;

            FillData(readonlyTroopsTemplateToShow);

            TbxName.ReadOnly = true;

            TbxSpearmen.ReadOnly = true;
            TbxSwordmen.ReadOnly = true;
            TbxAxemen.ReadOnly = true;
            TbxBowmen.ReadOnly = true;
            TbxScouts.ReadOnly = true;
            TbxLightCavalary.ReadOnly = true;
            TbxHorseArchers.ReadOnly = true;
            TbxHeavyCavalary.ReadOnly = true;
            TbxRams.ReadOnly = true;
            TbxCatapults.ReadOnly = true;
            TbxKnights.ReadOnly = true;
            TbxNoblemen.ReadOnly = true;

            BtnDeletion.Visible = false;
            BtnCancel.Visible = false;

            BtnOk.Select();
        }

        private void FrmTroopsTemplate_KeyPress(object sender, KeyPressEventArgs e)
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
                if (_readonlyMode)
                {
                    DialogResult = DialogResult.OK;
                    return;
                }

                if (!_editionMode)
                {
                    TroopsTemplate = new TroopsTemplate();
                }

                if (string.IsNullOrEmpty(TbxName.Text))
                {
                    MessageBox.Show("Incorrect name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TroopsTemplate = null;
                    return;
                }

                if ((!_editionMode) && _invalidNames.Contains(TbxName.Text))
                {
                    MessageBox.Show($"Troops template with name of \"{TbxName.Text}\" already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TroopsTemplate = null;
                    return;
                }

                Troops troops = null;

                try
                {
                    troops = new Troops
                    {
                        Spearmen = Convert.ToInt32(TbxSpearmen.Text),
                        Swordmen = Convert.ToInt32(TbxSwordmen.Text),
                        Axemen = Convert.ToInt32(TbxAxemen.Text),
                        Bowmen = Convert.ToInt32(TbxBowmen.Text),
                        Scouts = Convert.ToInt32(TbxScouts.Text),
                        LightCavalary = Convert.ToInt32(TbxLightCavalary.Text),
                        HorseArchers = Convert.ToInt32(TbxHorseArchers.Text),
                        HeavyCavalary = Convert.ToInt32(TbxHeavyCavalary.Text),
                        Rams = Convert.ToInt32(TbxRams.Text),
                        Catapultes = Convert.ToInt32(TbxCatapults.Text),
                        Knights = Convert.ToInt32(TbxKnights.Text),
                        Noblemen = Convert.ToInt32(TbxNoblemen.Text)
                    };
                }
                catch
                {
                    MessageBox.Show("Some values are incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (troops.Spearmen < 0 || (troops.Swordmen < 0) || (troops.Axemen < 0) || (troops.Bowmen < 0) ||
                    (troops.Scouts < 0) || (troops.LightCavalary < 0) || (troops.HorseArchers < 0) || (troops.HeavyCavalary < 0) ||
                    (troops.Rams < 0) || (troops.Catapultes < 0) ||
                    (troops.Knights < 0) || (troops.Noblemen < 0))
                {
                    MessageBox.Show("Incorrect troops numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TroopsTemplate.Troops = troops;

                TroopsTemplate.Name = TbxName.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private void FillData(TroopsTemplate troopsTemplate)
        {
            TbxName.Text = troopsTemplate.Name;

            TbxSpearmen.Text = troopsTemplate.Troops.Spearmen.ToString();
            TbxSwordmen.Text = troopsTemplate.Troops.Swordmen.ToString();
            TbxAxemen.Text = troopsTemplate.Troops.Axemen.ToString();
            TbxBowmen.Text = troopsTemplate.Troops.Bowmen.ToString();
            TbxScouts.Text = troopsTemplate.Troops.Scouts.ToString();
            TbxLightCavalary.Text = troopsTemplate.Troops.LightCavalary.ToString();
            TbxHorseArchers.Text = troopsTemplate.Troops.HorseArchers.ToString();
            TbxHeavyCavalary.Text = troopsTemplate.Troops.HeavyCavalary.ToString();
            TbxRams.Text = troopsTemplate.Troops.Rams.ToString();
            TbxCatapults.Text = troopsTemplate.Troops.Catapultes.ToString();
            TbxKnights.Text = troopsTemplate.Troops.Knights.ToString();
            TbxNoblemen.Text = troopsTemplate.Troops.Noblemen.ToString();
        }
    }
}