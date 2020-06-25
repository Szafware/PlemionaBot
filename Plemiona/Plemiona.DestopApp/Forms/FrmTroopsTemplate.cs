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

                TbxName.Text = troopsTemplateToEdition.Name;

                TbxSpearmen.Text = troopsTemplateToEdition.Troops.Spearmen.ToString();
                TbxSwordmen.Text = troopsTemplateToEdition.Troops.Swordmen.ToString();
                TbxAxemen.Text = troopsTemplateToEdition.Troops.Axemen.ToString();
                TbxBowmen.Text = troopsTemplateToEdition.Troops.Bowmen.ToString();
                TbxScouts.Text = troopsTemplateToEdition.Troops.Scouts.ToString();
                TbxLightCavalary.Text = troopsTemplateToEdition.Troops.LightCavalary.ToString();
                TbxHorseArchers.Text = troopsTemplateToEdition.Troops.HorseArchers.ToString();
                TbxHeavyCavalary.Text = troopsTemplateToEdition.Troops.HeavyCavalary.ToString();
                TbxRams.Text = troopsTemplateToEdition.Troops.Rams.ToString();
                TbxCatapults.Text = troopsTemplateToEdition.Troops.Catapultes.ToString();
                TbxKnights.Text = troopsTemplateToEdition.Troops.Knights.ToString();
                TbxNoblemen.Text = troopsTemplateToEdition.Troops.Noblemen.ToString();
            }

            BtnOk.Text = troopsTemplateToEdition != null ? "Edit" : "Add";
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

                try
                {
                    TroopsTemplate.Troops = new Troops
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
                    MessageBox.Show("Incorrect troops numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TroopsTemplate.Name = TbxName.Text;

                DialogResult = DialogResult.OK;
            }
        }
    }
}