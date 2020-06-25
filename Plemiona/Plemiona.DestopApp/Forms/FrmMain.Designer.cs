namespace Plemiona.DestopApp.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.PnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.GridTroopsTemplates = new System.Windows.Forms.DataGridView();
            this.ColumnTroopsTypesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsTypesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAddTroopsAction = new System.Windows.Forms.Button();
            this.GridTroopsActions = new System.Windows.Forms.DataGridView();
            this.ColumnTroopsActionsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsVillages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsExecutionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsEveryday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnTroopsActionExecute = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnAddTroopsTemplate = new System.Windows.Forms.Button();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsActions)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.ColumnCount = 1;
            this.PnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlMain.Controls.Add(this.GridTroopsTemplates, 0, 1);
            this.PnlMain.Controls.Add(this.BtnAddTroopsAction, 0, 2);
            this.PnlMain.Controls.Add(this.GridTroopsActions, 0, 3);
            this.PnlMain.Controls.Add(this.BtnAddTroopsTemplate, 0, 0);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.RowCount = 5;
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.PnlMain.Size = new System.Drawing.Size(725, 684);
            this.PnlMain.TabIndex = 0;
            // 
            // GridTroopsTemplates
            // 
            this.GridTroopsTemplates.AllowUserToAddRows = false;
            this.GridTroopsTemplates.AllowUserToDeleteRows = false;
            this.GridTroopsTemplates.AllowUserToResizeRows = false;
            this.GridTroopsTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridTroopsTemplates.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTroopsTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridTroopsTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTroopsTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTroopsTypesNumber,
            this.ColumnTroopsTypesName});
            this.GridTroopsTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTroopsTemplates.EnableHeadersVisualStyles = false;
            this.GridTroopsTemplates.Location = new System.Drawing.Point(3, 53);
            this.GridTroopsTemplates.Name = "GridTroopsTemplates";
            this.GridTroopsTemplates.ReadOnly = true;
            this.GridTroopsTemplates.RowHeadersVisible = false;
            this.GridTroopsTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridTroopsTemplates.Size = new System.Drawing.Size(719, 169);
            this.GridTroopsTemplates.TabIndex = 1;
            this.GridTroopsTemplates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTroopsTemplates_CellClick);
            this.GridTroopsTemplates.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridTroopsTemplates_CellMouseDoubleClick);
            this.GridTroopsTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridTroopsTemplates_KeyDown);
            // 
            // ColumnTroopsTypesNumber
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnTroopsTypesNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnTroopsTypesNumber.FillWeight = 10F;
            this.ColumnTroopsTypesNumber.HeaderText = "";
            this.ColumnTroopsTypesNumber.Name = "ColumnTroopsTypesNumber";
            this.ColumnTroopsTypesNumber.ReadOnly = true;
            // 
            // ColumnTroopsTypesName
            // 
            this.ColumnTroopsTypesName.HeaderText = "Name";
            this.ColumnTroopsTypesName.Name = "ColumnTroopsTypesName";
            this.ColumnTroopsTypesName.ReadOnly = true;
            // 
            // BtnAddTroopsAction
            // 
            this.BtnAddTroopsAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddTroopsAction.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnAddTroopsAction.Location = new System.Drawing.Point(3, 245);
            this.BtnAddTroopsAction.Name = "BtnAddTroopsAction";
            this.BtnAddTroopsAction.Size = new System.Drawing.Size(176, 27);
            this.BtnAddTroopsAction.TabIndex = 3;
            this.BtnAddTroopsAction.Text = "Add troops action";
            this.BtnAddTroopsAction.UseVisualStyleBackColor = true;
            this.BtnAddTroopsAction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnAddTroopsAction_MouseClick);
            // 
            // GridTroopsActions
            // 
            this.GridTroopsActions.AllowUserToAddRows = false;
            this.GridTroopsActions.AllowUserToDeleteRows = false;
            this.GridTroopsActions.AllowUserToResizeRows = false;
            this.GridTroopsActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridTroopsActions.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTroopsActions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridTroopsActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTroopsActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTroopsActionsNumber,
            this.ColumnTroopsActionsName,
            this.ColumnTroopsActionsVillages,
            this.ColumnTroopsActionsExecutionDate,
            this.ColumnTroopsActionsEveryday,
            this.ColumnTroopsActionExecute});
            this.GridTroopsActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTroopsActions.EnableHeadersVisualStyles = false;
            this.GridTroopsActions.Location = new System.Drawing.Point(3, 278);
            this.GridTroopsActions.Name = "GridTroopsActions";
            this.GridTroopsActions.ReadOnly = true;
            this.GridTroopsActions.RowHeadersVisible = false;
            this.GridTroopsActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridTroopsActions.Size = new System.Drawing.Size(719, 169);
            this.GridTroopsActions.TabIndex = 4;
            this.GridTroopsActions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTroopsActions_CellClick);
            this.GridTroopsActions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTroopsActions_CellContentClick);
            this.GridTroopsActions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridTroopsActions_CellMouseDoubleClick);
            this.GridTroopsActions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridTroopsActions_KeyDown);
            // 
            // ColumnTroopsActionsNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnTroopsActionsNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnTroopsActionsNumber.FillWeight = 20F;
            this.ColumnTroopsActionsNumber.HeaderText = "";
            this.ColumnTroopsActionsNumber.Name = "ColumnTroopsActionsNumber";
            this.ColumnTroopsActionsNumber.ReadOnly = true;
            // 
            // ColumnTroopsActionsName
            // 
            this.ColumnTroopsActionsName.HeaderText = "Name";
            this.ColumnTroopsActionsName.Name = "ColumnTroopsActionsName";
            this.ColumnTroopsActionsName.ReadOnly = true;
            // 
            // ColumnTroopsActionsVillages
            // 
            this.ColumnTroopsActionsVillages.HeaderText = "Villages";
            this.ColumnTroopsActionsVillages.Name = "ColumnTroopsActionsVillages";
            this.ColumnTroopsActionsVillages.ReadOnly = true;
            // 
            // ColumnTroopsActionsExecutionDate
            // 
            this.ColumnTroopsActionsExecutionDate.HeaderText = "Date";
            this.ColumnTroopsActionsExecutionDate.Name = "ColumnTroopsActionsExecutionDate";
            this.ColumnTroopsActionsExecutionDate.ReadOnly = true;
            // 
            // ColumnTroopsActionsEveryday
            // 
            this.ColumnTroopsActionsEveryday.FillWeight = 70F;
            this.ColumnTroopsActionsEveryday.HeaderText = "Everyday";
            this.ColumnTroopsActionsEveryday.Name = "ColumnTroopsActionsEveryday";
            this.ColumnTroopsActionsEveryday.ReadOnly = true;
            // 
            // ColumnTroopsActionExecute
            // 
            this.ColumnTroopsActionExecute.FillWeight = 50F;
            this.ColumnTroopsActionExecute.HeaderText = "Run";
            this.ColumnTroopsActionExecute.Name = "ColumnTroopsActionExecute";
            this.ColumnTroopsActionExecute.ReadOnly = true;
            // 
            // BtnAddTroopsTemplate
            // 
            this.BtnAddTroopsTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddTroopsTemplate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnAddTroopsTemplate.Location = new System.Drawing.Point(3, 20);
            this.BtnAddTroopsTemplate.Name = "BtnAddTroopsTemplate";
            this.BtnAddTroopsTemplate.Size = new System.Drawing.Size(173, 27);
            this.BtnAddTroopsTemplate.TabIndex = 0;
            this.BtnAddTroopsTemplate.Text = "Add troops template";
            this.BtnAddTroopsTemplate.UseVisualStyleBackColor = true;
            this.BtnAddTroopsTemplate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnAddTroopsTemplate_MouseClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 684);
            this.Controls.Add(this.PnlMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Plemiona Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsActions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PnlMain;
        private System.Windows.Forms.DataGridView GridTroopsTemplates;
        private System.Windows.Forms.Button BtnAddTroopsTemplate;
        private System.Windows.Forms.Button BtnAddTroopsAction;
        private System.Windows.Forms.DataGridView GridTroopsActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsVillages;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsExecutionDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTroopsActionsEveryday;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTroopsActionExecute;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsTypesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsTypesName;
    }
}