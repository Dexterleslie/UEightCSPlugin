namespace UFIDA.U8.Plugin.LPCSPlugin
{
  partial class ReceiptPullForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptPullForm));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.cbSoCode = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.dgvMain = new System.Windows.Forms.DataGridView();
      this.dgvDetail = new System.Windows.Forms.DataGridView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
      this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
      this.tsBtnOk = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.cbCusCode = new System.Windows.Forms.ComboBox();
      this.cbCusName = new System.Windows.Forms.ComboBox();
      this.cbSoType = new System.Windows.Forms.ComboBox();
      this.cbDepName = new System.Windows.Forms.ComboBox();
      this.cbDepCode = new System.Windows.Forms.ComboBox();
      this.cbPsnName = new System.Windows.Forms.ComboBox();
      this.cbPsnCode = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.dgvDetail);
      this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer1.Size = new System.Drawing.Size(654, 460);
      this.splitContainer1.SplitterDistance = 247;
      this.splitContainer1.TabIndex = 0;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.dtpEnd);
      this.splitContainer2.Panel1.Controls.Add(this.dtpStart);
      this.splitContainer2.Panel1.Controls.Add(this.label9);
      this.splitContainer2.Panel1.Controls.Add(this.label10);
      this.splitContainer2.Panel1.Controls.Add(this.cbPsnName);
      this.splitContainer2.Panel1.Controls.Add(this.cbPsnCode);
      this.splitContainer2.Panel1.Controls.Add(this.label7);
      this.splitContainer2.Panel1.Controls.Add(this.label8);
      this.splitContainer2.Panel1.Controls.Add(this.cbSoType);
      this.splitContainer2.Panel1.Controls.Add(this.cbDepName);
      this.splitContainer2.Panel1.Controls.Add(this.cbDepCode);
      this.splitContainer2.Panel1.Controls.Add(this.cbCusName);
      this.splitContainer2.Panel1.Controls.Add(this.cbCusCode);
      this.splitContainer2.Panel1.Controls.Add(this.cbSoCode);
      this.splitContainer2.Panel1.Controls.Add(this.label6);
      this.splitContainer2.Panel1.Controls.Add(this.label5);
      this.splitContainer2.Panel1.Controls.Add(this.label4);
      this.splitContainer2.Panel1.Controls.Add(this.label3);
      this.splitContainer2.Panel1.Controls.Add(this.label2);
      this.splitContainer2.Panel1.Controls.Add(this.label1);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.dgvMain);
      this.splitContainer2.Size = new System.Drawing.Size(654, 247);
      this.splitContainer2.SplitterDistance = 121;
      this.splitContainer2.TabIndex = 0;
      // 
      // cbSoCode
      // 
      this.cbSoCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbSoCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbSoCode.FormattingEnabled = true;
      this.cbSoCode.Location = new System.Drawing.Point(77, 8);
      this.cbSoCode.Name = "cbSoCode";
      this.cbSoCode.Size = new System.Drawing.Size(125, 20);
      this.cbSoCode.TabIndex = 7;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(232, 34);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(59, 12);
      this.label6.TabIndex = 6;
      this.label6.Text = "销售部门:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(208, 11);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(83, 12);
      this.label5.TabIndex = 5;
      this.label5.Text = "销售部门编码:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(232, 58);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 12);
      this.label4.TabIndex = 4;
      this.label4.Text = "销售类型:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 58);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(59, 12);
      this.label3.TabIndex = 3;
      this.label3.Text = "客户名称:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(24, 11);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 12);
      this.label2.TabIndex = 2;
      this.label2.Text = "订单号:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 34);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "客户编码:";
      // 
      // dgvMain
      // 
      this.dgvMain.AllowUserToAddRows = false;
      this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvMain.Location = new System.Drawing.Point(0, 0);
      this.dgvMain.MultiSelect = false;
      this.dgvMain.Name = "dgvMain";
      this.dgvMain.RowTemplate.Height = 23;
      this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvMain.Size = new System.Drawing.Size(654, 122);
      this.dgvMain.TabIndex = 0;
      this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
      // 
      // dgvDetail
      // 
      this.dgvDetail.AllowUserToAddRows = false;
      this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvDetail.Location = new System.Drawing.Point(0, 0);
      this.dgvDetail.Name = "dgvDetail";
      this.dgvDetail.RowTemplate.Height = 23;
      this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvDetail.Size = new System.Drawing.Size(654, 209);
      this.dgvDetail.TabIndex = 1;
      this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSearch,
            this.tsBtnCancel,
            this.tsBtnOk,
            this.toolStripButton1});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(654, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsBtnSearch
      // 
      this.tsBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSearch.Image")));
      this.tsBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnSearch.Name = "tsBtnSearch";
      this.tsBtnSearch.Size = new System.Drawing.Size(33, 22);
      this.tsBtnSearch.Text = "查询";
      this.tsBtnSearch.Click += new System.EventHandler(this.tsBtnSearch_Click);
      // 
      // tsBtnCancel
      // 
      this.tsBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCancel.Image")));
      this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnCancel.Name = "tsBtnCancel";
      this.tsBtnCancel.Size = new System.Drawing.Size(33, 22);
      this.tsBtnCancel.Text = "取消";
      // 
      // tsBtnOk
      // 
      this.tsBtnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsBtnOk.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOk.Image")));
      this.tsBtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnOk.Name = "tsBtnOk";
      this.tsBtnOk.Size = new System.Drawing.Size(33, 22);
      this.tsBtnOk.Text = "确定";
      this.tsBtnOk.Click += new System.EventHandler(this.tsBtnOk_Click);
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
      this.toolStripButton1.Text = "刷新";
      this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
      // 
      // cbCusCode
      // 
      this.cbCusCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbCusCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbCusCode.FormattingEnabled = true;
      this.cbCusCode.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbCusCode.Location = new System.Drawing.Point(77, 31);
      this.cbCusCode.Name = "cbCusCode";
      this.cbCusCode.Size = new System.Drawing.Size(125, 20);
      this.cbCusCode.TabIndex = 8;
      // 
      // cbCusName
      // 
      this.cbCusName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbCusName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbCusName.FormattingEnabled = true;
      this.cbCusName.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbCusName.Location = new System.Drawing.Point(77, 55);
      this.cbCusName.Name = "cbCusName";
      this.cbCusName.Size = new System.Drawing.Size(125, 20);
      this.cbCusName.TabIndex = 9;
      // 
      // cbSoType
      // 
      this.cbSoType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbSoType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbSoType.FormattingEnabled = true;
      this.cbSoType.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbSoType.Location = new System.Drawing.Point(297, 55);
      this.cbSoType.Name = "cbSoType";
      this.cbSoType.Size = new System.Drawing.Size(125, 20);
      this.cbSoType.TabIndex = 12;
      // 
      // cbDepName
      // 
      this.cbDepName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbDepName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbDepName.FormattingEnabled = true;
      this.cbDepName.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbDepName.Location = new System.Drawing.Point(297, 31);
      this.cbDepName.Name = "cbDepName";
      this.cbDepName.Size = new System.Drawing.Size(125, 20);
      this.cbDepName.TabIndex = 11;
      // 
      // cbDepCode
      // 
      this.cbDepCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbDepCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbDepCode.FormattingEnabled = true;
      this.cbDepCode.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbDepCode.Location = new System.Drawing.Point(297, 8);
      this.cbDepCode.Name = "cbDepCode";
      this.cbDepCode.Size = new System.Drawing.Size(125, 20);
      this.cbDepCode.TabIndex = 10;
      // 
      // cbPsnName
      // 
      this.cbPsnName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbPsnName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbPsnName.FormattingEnabled = true;
      this.cbPsnName.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbPsnName.Location = new System.Drawing.Point(507, 31);
      this.cbPsnName.Name = "cbPsnName";
      this.cbPsnName.Size = new System.Drawing.Size(125, 20);
      this.cbPsnName.TabIndex = 16;
      // 
      // cbPsnCode
      // 
      this.cbPsnCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cbPsnCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbPsnCode.FormattingEnabled = true;
      this.cbPsnCode.Items.AddRange(new object[] {
            "11",
            "22",
            "33"});
      this.cbPsnCode.Location = new System.Drawing.Point(507, 8);
      this.cbPsnCode.Name = "cbPsnCode";
      this.cbPsnCode.Size = new System.Drawing.Size(125, 20);
      this.cbPsnCode.TabIndex = 15;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(430, 11);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(71, 12);
      this.label7.TabIndex = 14;
      this.label7.Text = "业务员编码:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(430, 35);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(47, 12);
      this.label8.TabIndex = 13;
      this.label8.Text = "业务员:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(208, 84);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(11, 12);
      this.label9.TabIndex = 18;
      this.label9.Text = "-";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(12, 84);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(59, 12);
      this.label10.TabIndex = 17;
      this.label10.Text = "订单日期:";
      // 
      // dtpStart
      // 
      this.dtpStart.Location = new System.Drawing.Point(77, 80);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(125, 21);
      this.dtpStart.TabIndex = 19;
      // 
      // dtpEnd
      // 
      this.dtpEnd.Location = new System.Drawing.Point(225, 80);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.Size = new System.Drawing.Size(125, 21);
      this.dtpEnd.TabIndex = 20;
      // 
      // ReceiptPullForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(654, 485);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.toolStrip1);
      this.Name = "ReceiptPullForm";
      this.Text = "ReceiptPickerForm";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.DataGridView dgvMain;
    private System.Windows.Forms.DataGridView dgvDetail;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsBtnOk;
    private System.Windows.Forms.ToolStripButton tsBtnSearch;
    private System.Windows.Forms.ToolStripButton tsBtnCancel;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbSoCode;
    private System.Windows.Forms.ComboBox cbCusName;
    private System.Windows.Forms.ComboBox cbCusCode;
    private System.Windows.Forms.ComboBox cbSoType;
    private System.Windows.Forms.ComboBox cbDepName;
    private System.Windows.Forms.ComboBox cbDepCode;
    private System.Windows.Forms.ComboBox cbPsnName;
    private System.Windows.Forms.ComboBox cbPsnCode;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
  }
}