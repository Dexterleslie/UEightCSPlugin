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
      this.dgvMain = new System.Windows.Forms.DataGridView();
      this.dgvDetail = new System.Windows.Forms.DataGridView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsBtnOk = new System.Windows.Forms.ToolStripButton();
      this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
      this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
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
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.dgvMain);
      this.splitContainer2.Size = new System.Drawing.Size(654, 247);
      this.splitContainer2.SplitterDistance = 91;
      this.splitContainer2.TabIndex = 0;
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
      this.dgvMain.Size = new System.Drawing.Size(654, 152);
      this.dgvMain.TabIndex = 0;
      this.dgvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellValueChanged);
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
            this.tsBtnOk});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(654, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
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
      // tsBtnSearch
      // 
      this.tsBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSearch.Image")));
      this.tsBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnSearch.Name = "tsBtnSearch";
      this.tsBtnSearch.Size = new System.Drawing.Size(33, 22);
      this.tsBtnSearch.Text = "查询";
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
  }
}