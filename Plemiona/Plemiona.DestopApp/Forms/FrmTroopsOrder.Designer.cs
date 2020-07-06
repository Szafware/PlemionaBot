namespace Plemiona.DestopApp.Forms
{
    partial class FrmTroopsOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTroopsOrder));
            this.PnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.LblCoordinates = new System.Windows.Forms.Label();
            this.LblEveryday = new System.Windows.Forms.Label();
            this.LblExecutionDate = new System.Windows.Forms.Label();
            this.LblTroopsTemplate = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.TbxName = new System.Windows.Forms.TextBox();
            this.CbxTroopsTemplate = new System.Windows.Forms.ComboBox();
            this.PnlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDeletion = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LbxCoordinates = new System.Windows.Forms.ListBox();
            this.DtpckExecutionDate = new System.Windows.Forms.DateTimePicker();
            this.CkbxEveryday = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDeleteCoordinates = new System.Windows.Forms.Button();
            this.BtnAddCoordinate = new System.Windows.Forms.Button();
            this.TbxCoordinateY = new System.Windows.Forms.TextBox();
            this.TbxCoordinateX = new System.Windows.Forms.TextBox();
            this.PnlMain.SuspendLayout();
            this.PnlButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.ColumnCount = 2;
            this.PnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.PnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.PnlMain.Controls.Add(this.LblCoordinates, 0, 2);
            this.PnlMain.Controls.Add(this.LblEveryday, 0, 5);
            this.PnlMain.Controls.Add(this.LblExecutionDate, 0, 4);
            this.PnlMain.Controls.Add(this.LblTroopsTemplate, 0, 1);
            this.PnlMain.Controls.Add(this.LblName, 0, 0);
            this.PnlMain.Controls.Add(this.TbxName, 1, 0);
            this.PnlMain.Controls.Add(this.CbxTroopsTemplate, 1, 1);
            this.PnlMain.Controls.Add(this.PnlButtons, 0, 6);
            this.PnlMain.Controls.Add(this.LbxCoordinates, 1, 3);
            this.PnlMain.Controls.Add(this.DtpckExecutionDate, 1, 4);
            this.PnlMain.Controls.Add(this.CkbxEveryday, 1, 5);
            this.PnlMain.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.RowCount = 7;
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PnlMain.Size = new System.Drawing.Size(390, 354);
            this.PnlMain.TabIndex = 0;
            // 
            // LblCoordinates
            // 
            this.LblCoordinates.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblCoordinates.AutoSize = true;
            this.LblCoordinates.Location = new System.Drawing.Point(33, 93);
            this.LblCoordinates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.LblCoordinates.Name = "LblCoordinates";
            this.LblCoordinates.Size = new System.Drawing.Size(120, 13);
            this.LblCoordinates.TabIndex = 12;
            this.LblCoordinates.Text = "Add/Delete coordinates";
            // 
            // LblEveryday
            // 
            this.LblEveryday.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblEveryday.AutoSize = true;
            this.LblEveryday.Location = new System.Drawing.Point(60, 287);
            this.LblEveryday.Name = "LblEveryday";
            this.LblEveryday.Size = new System.Drawing.Size(93, 13);
            this.LblEveryday.TabIndex = 12;
            this.LblEveryday.Text = "Execute Everyday";
            // 
            // LblExecutionDate
            // 
            this.LblExecutionDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblExecutionDate.AutoSize = true;
            this.LblExecutionDate.Location = new System.Drawing.Point(90, 248);
            this.LblExecutionDate.Name = "LblExecutionDate";
            this.LblExecutionDate.Size = new System.Drawing.Size(63, 13);
            this.LblExecutionDate.TabIndex = 12;
            this.LblExecutionDate.Text = "Action Date";
            // 
            // LblTroopsTemplate
            // 
            this.LblTroopsTemplate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblTroopsTemplate.AutoSize = true;
            this.LblTroopsTemplate.Location = new System.Drawing.Point(66, 52);
            this.LblTroopsTemplate.Name = "LblTroopsTemplate";
            this.LblTroopsTemplate.Size = new System.Drawing.Size(87, 13);
            this.LblTroopsTemplate.TabIndex = 12;
            this.LblTroopsTemplate.Text = "Troops Template";
            // 
            // LblName
            // 
            this.LblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(118, 13);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 12;
            this.LblName.Text = "Name";
            // 
            // TbxName
            // 
            this.TbxName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxName.Location = new System.Drawing.Point(159, 9);
            this.TbxName.Name = "TbxName";
            this.TbxName.Size = new System.Drawing.Size(207, 20);
            this.TbxName.TabIndex = 0;
            this.TbxName.Text = "Attack";
            // 
            // CbxTroopsTemplate
            // 
            this.CbxTroopsTemplate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxTroopsTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxTroopsTemplate.FormattingEnabled = true;
            this.CbxTroopsTemplate.Location = new System.Drawing.Point(159, 48);
            this.CbxTroopsTemplate.Name = "CbxTroopsTemplate";
            this.CbxTroopsTemplate.Size = new System.Drawing.Size(207, 21);
            this.CbxTroopsTemplate.TabIndex = 1;
            // 
            // PnlButtons
            // 
            this.PnlButtons.ColumnCount = 3;
            this.PnlMain.SetColumnSpan(this.PnlButtons, 2);
            this.PnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PnlButtons.Controls.Add(this.BtnDeletion, 0, 0);
            this.PnlButtons.Controls.Add(this.BtnOk, 2, 0);
            this.PnlButtons.Controls.Add(this.BtnCancel, 1, 0);
            this.PnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlButtons.Location = new System.Drawing.Point(3, 316);
            this.PnlButtons.Name = "PnlButtons";
            this.PnlButtons.RowCount = 1;
            this.PnlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlButtons.Size = new System.Drawing.Size(384, 35);
            this.PnlButtons.TabIndex = 5;
            // 
            // BtnDeletion
            // 
            this.BtnDeletion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnDeletion.Location = new System.Drawing.Point(144, 6);
            this.BtnDeletion.Name = "BtnDeletion";
            this.BtnDeletion.Size = new System.Drawing.Size(75, 23);
            this.BtnDeletion.TabIndex = 11;
            this.BtnDeletion.Text = "Delete";
            this.BtnDeletion.UseVisualStyleBackColor = true;
            this.BtnDeletion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnDeletion_MouseClick);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnOk.Location = new System.Drawing.Point(306, 6);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 9;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnOk_MouseClick);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancel.Location = new System.Drawing.Point(225, 6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnCancel_MouseClick);
            // 
            // LbxCoordinates
            // 
            this.LbxCoordinates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxCoordinates.FormattingEnabled = true;
            this.LbxCoordinates.Location = new System.Drawing.Point(159, 120);
            this.LbxCoordinates.Name = "LbxCoordinates";
            this.LbxCoordinates.Size = new System.Drawing.Size(228, 112);
            this.LbxCoordinates.TabIndex = 6;
            // 
            // DtpckExecutionDate
            // 
            this.DtpckExecutionDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DtpckExecutionDate.CustomFormat = "";
            this.DtpckExecutionDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpckExecutionDate.Location = new System.Drawing.Point(159, 244);
            this.DtpckExecutionDate.Name = "DtpckExecutionDate";
            this.DtpckExecutionDate.Size = new System.Drawing.Size(207, 20);
            this.DtpckExecutionDate.TabIndex = 7;
            // 
            // CkbxEveryday
            // 
            this.CkbxEveryday.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CkbxEveryday.AutoSize = true;
            this.CkbxEveryday.Location = new System.Drawing.Point(159, 286);
            this.CkbxEveryday.Name = "CkbxEveryday";
            this.CkbxEveryday.Size = new System.Drawing.Size(15, 14);
            this.CkbxEveryday.TabIndex = 8;
            this.CkbxEveryday.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnDeleteCoordinates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddCoordinate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TbxCoordinateY, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.TbxCoordinateX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(156, 78);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 39);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // BtnDeleteCoordinates
            // 
            this.BtnDeleteCoordinates.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnDeleteCoordinates.Location = new System.Drawing.Point(3, 8);
            this.BtnDeleteCoordinates.Name = "BtnDeleteCoordinates";
            this.BtnDeleteCoordinates.Size = new System.Drawing.Size(48, 23);
            this.BtnDeleteCoordinates.TabIndex = 5;
            this.BtnDeleteCoordinates.Text = "Delete";
            this.BtnDeleteCoordinates.UseVisualStyleBackColor = true;
            this.BtnDeleteCoordinates.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnDeleteCoordinates_MouseClick);
            // 
            // BtnAddCoordinate
            // 
            this.BtnAddCoordinate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAddCoordinate.Location = new System.Drawing.Point(57, 8);
            this.BtnAddCoordinate.Name = "BtnAddCoordinate";
            this.BtnAddCoordinate.Size = new System.Drawing.Size(48, 23);
            this.BtnAddCoordinate.TabIndex = 4;
            this.BtnAddCoordinate.Text = "Add";
            this.BtnAddCoordinate.UseVisualStyleBackColor = true;
            this.BtnAddCoordinate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnAddCoordinate_MouseClick);
            // 
            // TbxCoordinateY
            // 
            this.TbxCoordinateY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxCoordinateY.Location = new System.Drawing.Point(159, 9);
            this.TbxCoordinateY.MaxLength = 3;
            this.TbxCoordinateY.Name = "TbxCoordinateY";
            this.TbxCoordinateY.Size = new System.Drawing.Size(42, 20);
            this.TbxCoordinateY.TabIndex = 3;
            this.TbxCoordinateY.Text = "Y";
            // 
            // TbxCoordinateX
            // 
            this.TbxCoordinateX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TbxCoordinateX.Location = new System.Drawing.Point(111, 9);
            this.TbxCoordinateX.MaxLength = 3;
            this.TbxCoordinateX.Name = "TbxCoordinateX";
            this.TbxCoordinateX.Size = new System.Drawing.Size(42, 20);
            this.TbxCoordinateX.TabIndex = 2;
            this.TbxCoordinateX.Text = "X";
            // 
            // FrmTroopsOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 354);
            this.Controls.Add(this.PnlMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTroopsOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Troops Orders";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTroopsOrder_KeyPress);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.PnlButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PnlMain;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TbxName;
        private System.Windows.Forms.Label LblTroopsTemplate;
        private System.Windows.Forms.ComboBox CbxTroopsTemplate;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TableLayoutPanel PnlButtons;
        private System.Windows.Forms.Button BtnDeletion;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ListBox LbxCoordinates;
        private System.Windows.Forms.Label LblExecutionDate;
        private System.Windows.Forms.Label LblEveryday;
        private System.Windows.Forms.CheckBox CkbxEveryday;
        private System.Windows.Forms.Label LblCoordinates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnDeleteCoordinates;
        private System.Windows.Forms.Button BtnAddCoordinate;
        private System.Windows.Forms.TextBox TbxCoordinateY;
        private System.Windows.Forms.TextBox TbxCoordinateX;
        private System.Windows.Forms.DateTimePicker DtpckExecutionDate;
    }
}