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
            this.PnlTabs = new System.Windows.Forms.TabControl();
            this.TabTroopsTemplates = new System.Windows.Forms.TabPage();
            this.PnlTroopsTemplates = new System.Windows.Forms.TableLayoutPanel();
            this.GridTroopsTemplates = new System.Windows.Forms.DataGridView();
            this.ColumnTroopsTypesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsTypesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAddTroopsTemplate = new System.Windows.Forms.Button();
            this.TabTroopsOrders = new System.Windows.Forms.TabPage();
            this.PnlTroopsOrders = new System.Windows.Forms.TableLayoutPanel();
            this.BtnAddTroopsOrders = new System.Windows.Forms.Button();
            this.GridTroopsOrders = new System.Windows.Forms.DataGridView();
            this.ColumnTroopsActionsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsVillages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsExecutionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTroopsActionsEveryday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnTroopsActionExecute = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TbxDiagnostics = new System.Windows.Forms.RichTextBox();
            this.PnlMain.SuspendLayout();
            this.PnlTabs.SuspendLayout();
            this.TabTroopsTemplates.SuspendLayout();
            this.PnlTroopsTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsTemplates)).BeginInit();
            this.TabTroopsOrders.SuspendLayout();
            this.PnlTroopsOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.ColumnCount = 1;
            this.PnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlMain.Controls.Add(this.PnlTabs, 0, 1);
            this.PnlMain.Controls.Add(this.TbxDiagnostics, 0, 2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.RowCount = 3;
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.PnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.PnlMain.Size = new System.Drawing.Size(725, 684);
            this.PnlMain.TabIndex = 0;
            // 
            // PnlTabs
            // 
            this.PnlTabs.Controls.Add(this.TabTroopsTemplates);
            this.PnlTabs.Controls.Add(this.TabTroopsOrders);
            this.PnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabs.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PnlTabs.Location = new System.Drawing.Point(3, 53);
            this.PnlTabs.Name = "PnlTabs";
            this.PnlTabs.SelectedIndex = 0;
            this.PnlTabs.Size = new System.Drawing.Size(719, 437);
            this.PnlTabs.TabIndex = 5;
            // 
            // TabTroopsTemplates
            // 
            this.TabTroopsTemplates.Controls.Add(this.PnlTroopsTemplates);
            this.TabTroopsTemplates.Location = new System.Drawing.Point(4, 32);
            this.TabTroopsTemplates.Name = "TabTroopsTemplates";
            this.TabTroopsTemplates.Padding = new System.Windows.Forms.Padding(3);
            this.TabTroopsTemplates.Size = new System.Drawing.Size(711, 401);
            this.TabTroopsTemplates.TabIndex = 0;
            this.TabTroopsTemplates.Text = "Troops Templates";
            this.TabTroopsTemplates.UseVisualStyleBackColor = true;
            // 
            // PnlTroopsTemplates
            // 
            this.PnlTroopsTemplates.ColumnCount = 1;
            this.PnlTroopsTemplates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlTroopsTemplates.Controls.Add(this.GridTroopsTemplates, 0, 1);
            this.PnlTroopsTemplates.Controls.Add(this.BtnAddTroopsTemplate, 0, 0);
            this.PnlTroopsTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTroopsTemplates.Location = new System.Drawing.Point(3, 3);
            this.PnlTroopsTemplates.Name = "PnlTroopsTemplates";
            this.PnlTroopsTemplates.RowCount = 2;
            this.PnlTroopsTemplates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PnlTroopsTemplates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.PnlTroopsTemplates.Size = new System.Drawing.Size(705, 395);
            this.PnlTroopsTemplates.TabIndex = 0;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.GridTroopsTemplates.Location = new System.Drawing.Point(3, 42);
            this.GridTroopsTemplates.Name = "GridTroopsTemplates";
            this.GridTroopsTemplates.ReadOnly = true;
            this.GridTroopsTemplates.RowHeadersVisible = false;
            this.GridTroopsTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridTroopsTemplates.Size = new System.Drawing.Size(699, 350);
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
            // BtnAddTroopsTemplate
            // 
            this.BtnAddTroopsTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddTroopsTemplate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnAddTroopsTemplate.Location = new System.Drawing.Point(3, 9);
            this.BtnAddTroopsTemplate.Name = "BtnAddTroopsTemplate";
            this.BtnAddTroopsTemplate.Size = new System.Drawing.Size(173, 27);
            this.BtnAddTroopsTemplate.TabIndex = 0;
            this.BtnAddTroopsTemplate.Text = "Add troops template";
            this.BtnAddTroopsTemplate.UseVisualStyleBackColor = true;
            this.BtnAddTroopsTemplate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnAddTroopsTemplate_MouseClick);
            // 
            // TabTroopsOrders
            // 
            this.TabTroopsOrders.Controls.Add(this.PnlTroopsOrders);
            this.TabTroopsOrders.Location = new System.Drawing.Point(4, 32);
            this.TabTroopsOrders.Name = "TabTroopsOrders";
            this.TabTroopsOrders.Padding = new System.Windows.Forms.Padding(3);
            this.TabTroopsOrders.Size = new System.Drawing.Size(711, 401);
            this.TabTroopsOrders.TabIndex = 1;
            this.TabTroopsOrders.Text = "Troops Orders";
            this.TabTroopsOrders.UseVisualStyleBackColor = true;
            // 
            // PnlTroopsOrders
            // 
            this.PnlTroopsOrders.ColumnCount = 1;
            this.PnlTroopsOrders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlTroopsOrders.Controls.Add(this.BtnAddTroopsOrders, 0, 0);
            this.PnlTroopsOrders.Controls.Add(this.GridTroopsOrders, 0, 1);
            this.PnlTroopsOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTroopsOrders.Location = new System.Drawing.Point(3, 3);
            this.PnlTroopsOrders.Name = "PnlTroopsOrders";
            this.PnlTroopsOrders.RowCount = 2;
            this.PnlTroopsOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PnlTroopsOrders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.PnlTroopsOrders.Size = new System.Drawing.Size(705, 395);
            this.PnlTroopsOrders.TabIndex = 0;
            // 
            // BtnAddTroopsOrders
            // 
            this.BtnAddTroopsOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddTroopsOrders.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnAddTroopsOrders.Location = new System.Drawing.Point(3, 9);
            this.BtnAddTroopsOrders.Name = "BtnAddTroopsOrders";
            this.BtnAddTroopsOrders.Size = new System.Drawing.Size(176, 27);
            this.BtnAddTroopsOrders.TabIndex = 3;
            this.BtnAddTroopsOrders.Text = "Add troops order";
            this.BtnAddTroopsOrders.UseVisualStyleBackColor = true;
            this.BtnAddTroopsOrders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnAddTroopsAction_MouseClick);
            // 
            // GridTroopsOrders
            // 
            this.GridTroopsOrders.AllowUserToAddRows = false;
            this.GridTroopsOrders.AllowUserToDeleteRows = false;
            this.GridTroopsOrders.AllowUserToResizeRows = false;
            this.GridTroopsOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridTroopsOrders.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTroopsOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridTroopsOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTroopsOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTroopsActionsNumber,
            this.ColumnTroopsActionsName,
            this.ColumnTroopsActionsVillages,
            this.ColumnTroopsActionsExecutionDate,
            this.ColumnTroopsActionsEveryday,
            this.ColumnTroopsActionExecute});
            this.GridTroopsOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTroopsOrders.EnableHeadersVisualStyles = false;
            this.GridTroopsOrders.Location = new System.Drawing.Point(3, 42);
            this.GridTroopsOrders.Name = "GridTroopsOrders";
            this.GridTroopsOrders.ReadOnly = true;
            this.GridTroopsOrders.RowHeadersVisible = false;
            this.GridTroopsOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridTroopsOrders.Size = new System.Drawing.Size(699, 350);
            this.GridTroopsOrders.TabIndex = 4;
            this.GridTroopsOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTroopsActions_CellClick);
            this.GridTroopsOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTroopsActions_CellContentClick);
            this.GridTroopsOrders.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridTroopsActions_CellMouseDoubleClick);
            this.GridTroopsOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridTroopsActions_KeyDown);
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
            // TbxDiagnostics
            // 
            this.TbxDiagnostics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxDiagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbxDiagnostics.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TbxDiagnostics.Location = new System.Drawing.Point(10, 503);
            this.TbxDiagnostics.Margin = new System.Windows.Forms.Padding(10);
            this.TbxDiagnostics.Name = "TbxDiagnostics";
            this.TbxDiagnostics.ReadOnly = true;
            this.TbxDiagnostics.Size = new System.Drawing.Size(705, 171);
            this.TbxDiagnostics.TabIndex = 6;
            this.TbxDiagnostics.Text = "";
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
            this.PnlTabs.ResumeLayout(false);
            this.TabTroopsTemplates.ResumeLayout(false);
            this.PnlTroopsTemplates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsTemplates)).EndInit();
            this.TabTroopsOrders.ResumeLayout(false);
            this.PnlTroopsOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTroopsOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PnlMain;
        private System.Windows.Forms.TabControl PnlTabs;
        private System.Windows.Forms.TabPage TabTroopsTemplates;
        private System.Windows.Forms.TableLayoutPanel PnlTroopsTemplates;
        private System.Windows.Forms.DataGridView GridTroopsTemplates;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsTypesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsTypesName;
        private System.Windows.Forms.Button BtnAddTroopsTemplate;
        private System.Windows.Forms.TabPage TabTroopsOrders;
        private System.Windows.Forms.TableLayoutPanel PnlTroopsOrders;
        private System.Windows.Forms.Button BtnAddTroopsOrders;
        private System.Windows.Forms.DataGridView GridTroopsOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsVillages;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTroopsActionsExecutionDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTroopsActionsEveryday;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTroopsActionExecute;
        private System.Windows.Forms.RichTextBox TbxDiagnostics;
    }
}