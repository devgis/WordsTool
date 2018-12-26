namespace WordsTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAnalyze = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.CWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProunce_US = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProunce_UK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCSV = new System.Windows.Forms.CheckBox();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.Controls.Add(this.panel1, 1, 0);
            this.tlpMain.Controls.Add(this.dgvList, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCSV);
            this.panel1.Controls.Add(this.btAnalyze);
            this.panel1.Controls.Add(this.btOpen);
            this.panel1.Controls.Add(this.tbPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 24);
            this.panel1.TabIndex = 0;
            // 
            // btAnalyze
            // 
            this.btAnalyze.Location = new System.Drawing.Point(299, 0);
            this.btAnalyze.Name = "btAnalyze";
            this.btAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btAnalyze.TabIndex = 2;
            this.btAnalyze.Text = "分析保存";
            this.btAnalyze.UseVisualStyleBackColor = true;
            this.btAnalyze.Click += new System.EventHandler(this.btAnalyze_Click);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(217, 0);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 1;
            this.btOpen.Text = "打开";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(3, 0);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(207, 23);
            this.tbPath.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CWord,
            this.CProunce_US,
            this.CProunce_UK,
            this.cTrans});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(8, 33);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(784, 414);
            this.dgvList.TabIndex = 1;
            this.dgvList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvList_RowPostPaint);
            // 
            // CWord
            // 
            this.CWord.DataPropertyName = "word";
            this.CWord.HeaderText = "Word";
            this.CWord.Name = "CWord";
            this.CWord.ReadOnly = true;
            // 
            // CProunce_US
            // 
            this.CProunce_US.DataPropertyName = "prounce_us";
            this.CProunce_US.HeaderText = "Prounce_US";
            this.CProunce_US.Name = "CProunce_US";
            this.CProunce_US.ReadOnly = true;
            // 
            // CProunce_UK
            // 
            this.CProunce_UK.DataPropertyName = "prounce_uk";
            this.CProunce_UK.HeaderText = "Prounce_UK";
            this.CProunce_UK.Name = "CProunce_UK";
            this.CProunce_UK.ReadOnly = true;
            // 
            // cTrans
            // 
            this.cTrans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTrans.DataPropertyName = "trans";
            this.cTrans.HeaderText = "Trans";
            this.cTrans.Name = "cTrans";
            this.cTrans.ReadOnly = true;
            // 
            // cbCSV
            // 
            this.cbCSV.AutoSize = true;
            this.cbCSV.Checked = true;
            this.cbCSV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCSV.Location = new System.Drawing.Point(383, 1);
            this.cbCSV.Name = "cbCSV";
            this.cbCSV.Size = new System.Drawing.Size(69, 21);
            this.cbCSV.TabIndex = 3;
            this.cbCSV.Text = "输出csv";
            this.cbCSV.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordsTool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAnalyze;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProunce_US;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProunce_UK;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTrans;
        private System.Windows.Forms.CheckBox cbCSV;
    }
}

