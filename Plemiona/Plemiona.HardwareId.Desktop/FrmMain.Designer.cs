namespace Plemiona.HardwareId.Desktop
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnGetHardwareId = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TbxPlemionaKey = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetHardwareId
            // 
            this.BtnGetHardwareId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGetHardwareId.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnGetHardwareId.Location = new System.Drawing.Point(21, 8);
            this.BtnGetHardwareId.Name = "BtnGetHardwareId";
            this.BtnGetHardwareId.Size = new System.Drawing.Size(102, 34);
            this.BtnGetHardwareId.TabIndex = 0;
            this.BtnGetHardwareId.Text = "Generate Id";
            this.BtnGetHardwareId.UseVisualStyleBackColor = true;
            this.BtnGetHardwareId.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnGetHardwareId_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.TbxPlemionaKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnGetHardwareId, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 50);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TbxPlemionaKey
            // 
            this.TbxPlemionaKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbxPlemionaKey.Location = new System.Drawing.Point(147, 3);
            this.TbxPlemionaKey.Multiline = true;
            this.TbxPlemionaKey.Name = "TbxPlemionaKey";
            this.TbxPlemionaKey.ReadOnly = true;
            this.TbxPlemionaKey.Size = new System.Drawing.Size(426, 44);
            this.TbxPlemionaKey.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 50);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plemiona Key Generator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGetHardwareId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TbxPlemionaKey;
    }
}

