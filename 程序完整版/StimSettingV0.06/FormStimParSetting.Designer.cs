namespace StimSettingV0._06
{
    partial class FormStimParSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStimParSetting));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewLeftchujiao = new System.Windows.Forms.DataGridView();
            this.参数名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参数值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.说明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewRightchujiao = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewLeftweixu = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewRightweixu = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartWave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonLeftForward = new System.Windows.Forms.Button();
            this.buttonRightForward = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeftchujiao)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRightchujiao)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeftweixu)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRightweixu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWave)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1102, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(68, 28);
            this.toolStripButtonOpen.Text = "打开";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpenFile_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(68, 28);
            this.toolStripButtonSave.Text = "保存";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSaveFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1102, 179);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewLeftchujiao);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1094, 149);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "左触角";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLeftchujiao
            // 
            this.dataGridViewLeftchujiao.AllowUserToAddRows = false;
            this.dataGridViewLeftchujiao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLeftchujiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeftchujiao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.参数名,
            this.参数值,
            this.单位,
            this.说明});
            this.dataGridViewLeftchujiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLeftchujiao.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewLeftchujiao.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewLeftchujiao.Name = "dataGridViewLeftchujiao";
            this.dataGridViewLeftchujiao.RowTemplate.Height = 30;
            this.dataGridViewLeftchujiao.Size = new System.Drawing.Size(1090, 145);
            this.dataGridViewLeftchujiao.TabIndex = 7;
            this.dataGridViewLeftchujiao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // 参数名
            // 
            this.参数名.HeaderText = "参数名";
            this.参数名.Name = "参数名";
            // 
            // 参数值
            // 
            this.参数值.HeaderText = "参数值";
            this.参数值.Name = "参数值";
            // 
            // 单位
            // 
            this.单位.HeaderText = "单位";
            this.单位.Name = "单位";
            // 
            // 说明
            // 
            this.说明.HeaderText = "说明";
            this.说明.Name = "说明";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewRightchujiao);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1094, 149);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "右触角";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRightchujiao
            // 
            this.dataGridViewRightchujiao.AllowUserToAddRows = false;
            this.dataGridViewRightchujiao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRightchujiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRightchujiao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewRightchujiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRightchujiao.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewRightchujiao.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRightchujiao.Name = "dataGridViewRightchujiao";
            this.dataGridViewRightchujiao.RowTemplate.Height = 30;
            this.dataGridViewRightchujiao.Size = new System.Drawing.Size(1090, 145);
            this.dataGridViewRightchujiao.TabIndex = 8;
            this.dataGridViewRightchujiao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "参数名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "参数值";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "单位";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "说明";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewLeftweixu);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1094, 149);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "左尾须";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLeftweixu
            // 
            this.dataGridViewLeftweixu.AllowUserToAddRows = false;
            this.dataGridViewLeftweixu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLeftweixu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeftweixu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridViewLeftweixu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLeftweixu.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLeftweixu.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewLeftweixu.Name = "dataGridViewLeftweixu";
            this.dataGridViewLeftweixu.RowTemplate.Height = 30;
            this.dataGridViewLeftweixu.Size = new System.Drawing.Size(1094, 149);
            this.dataGridViewLeftweixu.TabIndex = 8;
            this.dataGridViewLeftweixu.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "参数名";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "参数值";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "单位";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "说明";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewRightweixu);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1094, 149);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "右尾须";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRightweixu
            // 
            this.dataGridViewRightweixu.AllowUserToAddRows = false;
            this.dataGridViewRightweixu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRightweixu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRightweixu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dataGridViewRightweixu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRightweixu.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRightweixu.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRightweixu.Name = "dataGridViewRightweixu";
            this.dataGridViewRightweixu.RowTemplate.Height = 30;
            this.dataGridViewRightweixu.Size = new System.Drawing.Size(1094, 149);
            this.dataGridViewRightweixu.TabIndex = 8;
            this.dataGridViewRightweixu.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "参数名";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "参数值";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "单位";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "说明";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // chartWave
            // 
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.IsSameFontSizeForAllAxes = true;
            chartArea3.Name = "ChartArea1";
            this.chartWave.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.DockedToChartArea = "ChartArea1";
            legend3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartWave.Legends.Add(legend3);
            this.chartWave.Location = new System.Drawing.Point(6, 231);
            this.chartWave.Margin = new System.Windows.Forms.Padding(2);
            this.chartWave.Name = "chartWave";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.MarkerSize = 4;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series3.Name = "参数波形";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartWave.Series.Add(series3);
            this.chartWave.Size = new System.Drawing.Size(773, 336);
            this.chartWave.TabIndex = 11;
            this.chartWave.Text = "chartWave";
            // 
            // buttonLeftForward
            // 
            this.buttonLeftForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLeftForward.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonLeftForward.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLeftForward.Location = new System.Drawing.Point(809, 429);
            this.buttonLeftForward.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeftForward.Name = "buttonLeftForward";
            this.buttonLeftForward.Size = new System.Drawing.Size(120, 77);
            this.buttonLeftForward.TabIndex = 2;
            this.buttonLeftForward.Text = "左前";
            this.buttonLeftForward.UseVisualStyleBackColor = false;
            this.buttonLeftForward.Click += new System.EventHandler(this.buttonLeftForward_Click);
            // 
            // buttonRightForward
            // 
            this.buttonRightForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRightForward.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonRightForward.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRightForward.Location = new System.Drawing.Point(947, 429);
            this.buttonRightForward.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRightForward.Name = "buttonRightForward";
            this.buttonRightForward.Size = new System.Drawing.Size(120, 77);
            this.buttonRightForward.TabIndex = 3;
            this.buttonRightForward.Text = "右前";
            this.buttonRightForward.UseVisualStyleBackColor = false;
            this.buttonRightForward.Click += new System.EventHandler(this.buttonLeftForward_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLeft.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonLeft.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLeft.Location = new System.Drawing.Point(809, 307);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(120, 77);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.Text = "左";
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeftForward_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRight.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonRight.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRight.Location = new System.Drawing.Point(947, 307);
            this.buttonRight.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(120, 77);
            this.buttonRight.TabIndex = 1;
            this.buttonRight.Text = "右";
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonLeftForward_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Location = new System.Drawing.Point(0, 576);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1102, 25);
            this.toolStrip2.TabIndex = 12;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // FormStimParSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 601);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRightForward);
            this.Controls.Add(this.buttonLeftForward);
            this.Controls.Add(this.chartWave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormStimParSetting";
            this.Text = "FormStimSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStimParSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormStimParSetting_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormStimParSetting_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeftchujiao)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRightchujiao)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeftweixu)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRightweixu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewLeftchujiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数值;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 说明;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewRightchujiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewLeftweixu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewRightweixu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWave;
        private System.Windows.Forms.Button buttonLeftForward;
        private System.Windows.Forms.Button buttonRightForward;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStrip toolStrip2;
    }
}