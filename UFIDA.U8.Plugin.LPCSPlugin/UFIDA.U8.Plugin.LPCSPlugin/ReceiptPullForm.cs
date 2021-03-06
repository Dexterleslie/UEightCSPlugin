﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.Plugin.LPCSPlugin.DB;
using UFIDA.U8.UAP.UI.Runtime.Model;
using UFIDA.U8.Plugin.LPCSPlugin.DL;

namespace UFIDA.U8.Plugin.LPCSPlugin
{
  /// <summary>
  /// 拉单窗体
  /// </summary>
  public partial class ReceiptPullForm : Form
  {
    //表头实体标识
    private string entityHeaderID = "lp001_0001_E001";
    //表体实体标识
    private string entityBodyID = "lp001_0001_E002";

    private VoucherProxy voucherProxy;

    private Business businessHeader;
    private Business businessBody;

    private Connection connection;
    private DALU8Exch dalExch;
    //public ReceiptPullForm(ConnectionMediatorBase mediator,VoucherProxy voucherProxy)
    //{
    //  if (mediator == null)
    //    throw new ArgumentNullException();
    //  InitializeComponent();
    //  this.InitConnection(mediator);
    //  this.LoadDGVMainData();
    //  this.voucherProxy = voucherProxy;
    //  this.businessHeader = this.voucherProxy.Businesses[this.entityHeaderID];
    //  this.businessBody = this.voucherProxy.Businesses[this.entityBodyID];
    //}

    private string connectionString = null;

    private DataTable originDataTable;
    public ReceiptPullForm(string connectionString, VoucherProxy voucherProxy)
    {
      //if (mediator == null)
      //  throw new ArgumentNullException();
      InitializeComponent();
      this.connectionString = connectionString;
      this.connection = new Connection(this.connectionString);
      this.LoadDGVMainData();
      this.voucherProxy = voucherProxy;
      this.businessHeader = this.voucherProxy.Businesses[this.entityHeaderID];
      this.businessBody = this.voucherProxy.Businesses[this.entityBodyID];
      this.dalExch = new DALU8Exch(this.connectionString);
    }

    ///// <summary>
    ///// 初始化数据库连接对象
    ///// </summary>
    //private void InitConnection()
    //{
    //  this.connection = new Connection(mediator);
    //}

    /// <summary>
    /// 加载主表数据到DataGridViewMain
    /// </summary>
    private void LoadDGVMainData()
    {
      string sql = @"lp_proc_pull_appvouch";
      DataTable tableMain = this.connection.Query(sql);
      this.dgvMain.DataSource = tableMain;
      this.originDataTable = tableMain.Copy();

      this.dgvMain.Columns["ufts"].Visible = false;
      foreach(DataGridViewColumn column in this.dgvMain.Columns)
      {
        string columnName = column.Name;
        if (!"选择".Equals(columnName))
        {
          column.ReadOnly = true;
        }
        else column.ReadOnly = false;
      }
      this.dgvDetail.DataSource = null;

      this.dgvMain.Columns["ID"].Visible = false;
      this.InitFilterComponents();
    }

    class InternalEntry
    {
      public string fieldName;
      public ComboBox comboBox;
      public InternalEntry(string fieldName, ComboBox comboBox)
      {
        this.fieldName = fieldName;
        this.comboBox = comboBox;
      }
    }

    private void InitFilterComponents()
    {
      List<InternalEntry> entries = new List<InternalEntry>();
      entries.Add(new InternalEntry("销售订单号",this.cbSoCode));
      entries.Add(new InternalEntry("销售类型", this.cbSoType));
      entries.Add(new InternalEntry("客户编码", this.cbCusCode));
      entries.Add(new InternalEntry("客户", this.cbCusName));
      entries.Add(new InternalEntry("销售部门编码", this.cbDepCode));
      entries.Add(new InternalEntry("销售部门", this.cbDepName));
      entries.Add(new InternalEntry("业务员编码", this.cbPsnCode));
      entries.Add(new InternalEntry("业务员", this.cbPsnName));

      foreach (InternalEntry entry in entries)
      {
        string fieldName = entry.fieldName;
        ComboBox comboBox = entry.comboBox;
        List<string> vals = new List<string>();
        foreach (DataRow row in this.originDataTable.Rows)
        {
          object obj = row[fieldName];
          if (obj != null)
          {
            string fieldVal = obj.ToString();
            if (!vals.Contains(fieldVal)&&!string.IsNullOrEmpty(fieldVal))
              vals.Add(fieldVal);
          }
        }

        comboBox.Items.Clear();
        foreach (string val in vals)
          comboBox.Items.Add(val);
      }
    }

    //private void dgvMain_SelectionChanged(object sender, EventArgs e)
    //{
    //  string cSoCode = this.GetDGVMainSelectingRowCellValue("销售订单号");
    //  this.LoadDGVDetailData(cSoCode);
    //}
    private bool ifDetailRowExists(DataRow row)
    {
      if (row == null)
        return true;

      string cSoCode = row["销售订单号"].ToString();
      DataTable eTable = (DataTable)this.dgvDetail.DataSource;
      foreach(DataRow row1 in eTable.Rows)
      {
        string tmpSoCode = row1["销售订单号"].ToString();
        if (tmpSoCode.Equals(cSoCode))
          return true;
      }
      return false;
    }

    /// <summary>
    /// 加载子表数据到DataGridViewDetail
    /// </summary>
    /// <param name="code"></param>
    private void AddDGVDetailData(string code)
    {
      string sql = @"lp_proc_pull_appvouchs @cSoCode='{0}'";
      sql = string.Format(sql, code);
      DataTable table = this.connection.Query(sql);
      if (this.dgvDetail.DataSource == null)
      {
        this.dgvDetail.DataSource = table;
        //return;
      }

      DataTable eTable = (DataTable)this.dgvDetail.DataSource;
      foreach (DataRow row in table.Rows)
      {
        if(!this.ifDetailRowExists(row))
         eTable.ImportRow(row);
      }

      foreach (DataGridViewColumn column in this.dgvDetail.Columns)
      {
        string columnName = column.Name;
        if (!"选择".Equals(columnName))
          column.ReadOnly = true;
        else column.ReadOnly = false;
      }

      this.dgvDetail.Columns["ID"].Visible = false;
      this.dgvDetail.Columns["autoid"].Visible = false;
    }

    /// <summary>
    /// 加载子表数据到DataGridViewDetail
    /// </summary>
    /// <param name="code"></param>
    private void RemoveDGVDetailData(string code)
    {
      DataTable eTable = (DataTable)this.dgvDetail.DataSource;
      if (eTable == null) return;
      DataTable table = eTable.Clone();

      //List<int> ll = new List<int>();
      //int counter=0;
      foreach (DataRow row in eTable.Rows)
      {
        string cSoCode = row["销售订单号"].ToString();
        if (!cSoCode.Equals(code))
          table.ImportRow(row);
      }
      this.dgvDetail.DataSource = table;
    }

    /// <summary>
    /// 获取DataGridViewMain 现在选定的Row
    /// </summary>
    private DataGridViewRow GetDGVMainSelectingRow()
    {
      DataGridViewSelectedRowCollection rowCollection = this.dgvMain.SelectedRows;
      if (rowCollection == null || rowCollection.Count <= 0)
        return null;
      return rowCollection[0];
    }

    /// <summary>
    /// 获取DataGridViewDetail 现在选定的Row
    /// </summary>
    private DataGridViewRow GetDGVDetailSelectingRow()
    {
      DataGridViewSelectedRowCollection rowCollection = this.dgvDetail.SelectedRows;
      if (rowCollection == null || rowCollection.Count <= 0)
        return null;
      return rowCollection[0];
    }

    /// <summary>
    /// 获取DataGridViewMain选定Row的指定列ColumnName值
    /// </summary>
    /// <param name="columnName"></param>
    /// <returns></returns>
    private string GetDGVMainSelectingRowCellValue(string columnName)
    {
      if (string.IsNullOrEmpty(columnName))
        throw new ArgumentNullException("columnName");
      DataGridViewRow row = this.GetDGVMainSelectingRow();
      if (row == null)
        return null;
      string cellValue = row.Cells[columnName].Value.ToString();
      return cellValue;
    }

    /// <summary>
    /// 获取DataGridViewDetail选定Row的指定列ColumnName值
    /// </summary>
    /// <param name="columnName"></param>
    /// <returns></returns>
    private string GetDGVDetailSelectingRowCellValue(string columnName)
    {
      if (string.IsNullOrEmpty(columnName))
        throw new ArgumentNullException("columnName");
      DataGridViewRow row = this.GetDGVDetailSelectingRow();
      if (row == null)
        return null;
      string cellValue = row.Cells[columnName].Value.ToString();
      return cellValue;
    }

    private bool GetDGVMainSelectingRowCellValueAsBool(string columnName)
    {
      string cellValue = this.GetDGVMainSelectingRowCellValue(columnName);
      bool b = false;
      bool.TryParse(cellValue,out b);
      return b;
    }

    private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      
    }

    private DataRow FindDetailDataRow(DataGridViewRow dgvRow)
    {
      string autoid = dgvRow.Cells["autoid"].Value.ToString();
      DataTable table = ((DataTable)this.dgvDetail.DataSource);
      DataRow retRow = table.NewRow();
      foreach (DataRow row in table.Rows)
      {
        string currentAutoID = row["autoid"].ToString();
        if (autoid.Equals(currentAutoID))
          retRow = row;
      }
      return retRow;
    }

    //private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    //{
      
    //}

    private void tsBtnOk_Click(object sender, EventArgs e)
    {
      //没有已审核单据
      if (this.dgvMain.DataSource == null || ((DataTable)this.dgvMain.DataSource).Rows.Count <= 0)
      {
        MessageBox.Show("没有已审核的销售订单");
        return;
      }

      //至少选择一销售订单
      bool flag = false;
      DataTable tableMain = (DataTable)this.dgvMain.DataSource;
      foreach (DataRow row in tableMain.Rows)
      {
        if (Boolean.Parse(row["选择"].ToString()))
        {
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        MessageBox.Show("至少选择一销售订单");
        return;
      }

      //请购单子表没有选中任何记录 
      flag = false;
      DataTable tempDt = (DataTable)this.dgvDetail.DataSource;
      //if (tempDt == null || tempDt.Rows.Count == 0)
      //{
      //  MessageBox.Show("请选择销售订单");
      //  return;
      //}

      List<string> idS = new List<string>();
      //判断单据是否被修改过
      for (int i = 0; i < tempDt.Rows.Count; i++)
      {
        DataRow dr = tempDt.Rows[i];
        //获取所有子表AUTOID
        string ID = dr["销售订单号"].ToString();
        //string sql = "select ID from pu_appVouch id= '" + ID + "'";
        if (!idS.Contains(ID))
          idS.Add(ID);
      }
      //判断单据表头是否被修改过
      DataTable dtHeader = (DataTable)this.dgvMain.DataSource;
      for (int i = 0; i < dtHeader.Rows.Count; i++)
      {
        DataRow dr = dtHeader.Rows[i];
        string ID = dr["销售订单号"].ToString();

        if (idS.Contains(ID))
        {
          string sTmpUfts = dr["ufts"].ToString();
          string sql = "select convert(nchar,convert(money,ufts),2) as ufts from so_somain where csocode = '" + ID + "'";
          string sUfts = this.connection.GetString(sql);
          if (!sTmpUfts.Equals(sUfts))
          {
            string cCode = dr["销售订单号"].ToString();
            MessageBox.Show("销售订单号[" + cCode + "]被修改过或者删除，请点击查询按钮进行刷新");
            return;
          }
        }
      }

      DataRow firstHeaderRow = null;

      foreach(DataRow row in dtHeader.Rows)
      {
        bool isSelect = Convert.ToBoolean(row["选择"]);
        if (isSelect)
        {
          firstHeaderRow = row;
          break;
        }
      }

      if (firstHeaderRow == null)
        return;
      string dDate = DateTime.Now.ToString("yyyy-MM-dd");

      //设置表头数据
      //string cCode1 = "001";
      string cCurrencyName = firstHeaderRow["币种"].ToString();
      string cCurrencyCode = this.dalExch.getCodeByName(cCurrencyName);
      string iExchRate = firstHeaderRow["汇率"].ToString();
      string iTaxRate = firstHeaderRow["税率"].ToString();
      string cPersonCode = firstHeaderRow["业务员编码"].ToString();
      string cPersonName = firstHeaderRow["业务员"].ToString();
      string cDepCode = firstHeaderRow["销售部门编码"].ToString();
      string cDepName = firstHeaderRow["销售部门"].ToString();
      string cCusCode = firstHeaderRow["客户编码"].ToString();
      string cCusName = firstHeaderRow["客户"].ToString();

      //this.businessHeader.Cells["cCode"].Value = cCode1;
      this.businessHeader.Cells["cExchCode"].Value = cCurrencyCode;
      this.businessHeader.Cells["cexch_name"].Value = cCurrencyName;
      this.businessHeader.Cells["nFlat"].Value = iExchRate;
      this.businessHeader.Cells["iTaxRate"].Value = iTaxRate;
      this.businessHeader.Cells["cPersonCode"].Value = cPersonCode;
      this.businessHeader.Cells["cPersonCode_cPersonName"].Value = cPersonName;
      this.businessHeader.Cells["cDepCode"].Value = cDepCode;
      this.businessHeader.Cells["cDepCode_cDepName"].Value = cDepName;
      this.businessHeader.Cells["cCusCode"].Value = cCusCode;
      this.businessHeader.Cells["cCusCode_cCusAbbName"].Value = cCusName;
      this.businessHeader.Cells["dDate"].Value = dDate;

      this.businessBody.Clear();
      for (int i = 0; i < tempDt.Rows.Count; i++)
      {
        DataRow row = tempDt.Rows[i];
        object obj = tempDt.Rows[i]["选择"];
        bool ifSelected = false;
        if (obj != null && obj != System.DBNull.Value)
          ifSelected = Convert.ToBoolean(obj);
        if (ifSelected == true)
        {
          string cInvCode = row["存货编码"].ToString();
          string cInvName = row["存货"].ToString();
          float fQuantity = Convert.ToSingle(row["数量"].ToString());
          string cSoCode = row["销售订单号"].ToString();
          string cSoID = row["ID"].ToString();
          string cSoAutoID = row["autoid"].ToString();
          string cInvStd = row["规格型号"].ToString();
          string cComUnitCode = row["主计量单位编码"].ToString();
          string cComUnitName = row["主计量单位"].ToString();
          //string iQuotedPrice = row["报价"].ToString();
          //float iTaxUnitPrice = Convert.ToSingle(row["原币含税单价"].ToString());
          //string iUnitPrice = row["原币无税单价"].ToString();
          //string iMoney = row["原币无税金额"].ToString();
          //string iTax = row["原币税额"].ToString();
          //string iSum = row["原币价税合计"].ToString();
          //string iNatUnitPrice = row["本币无税单价"].ToString();
          //string iNatMoney = row["本币无税金额"].ToString();
          //string iNatTax = row["本币税额"].ToString();
          //string iNatSum = row["本币价税合计"].ToString();
          iTaxRate = row["税率"].ToString();

          this.businessBody.AddRow();
          string currentPKValue = this.businessBody.CurrentPKValue;
          this.businessBody.Rows[currentPKValue].Cells["cInvDisCode"].Value = cInvCode;
          this.businessBody.Rows[currentPKValue].Cells["cInvCode"].Value = cInvCode;
          this.businessBody.Rows[currentPKValue].Cells["cInvCode_cInvName"].Value = cInvName;
          this.businessBody.Rows[currentPKValue].Cells["cSoCode"].Value = cSoCode;
          this.businessBody.Rows[currentPKValue].Cells["cSoID"].Value = cSoID;
          this.businessBody.Rows[currentPKValue].Cells["cSoAutoID"].Value = cSoAutoID;
          this.businessBody.Rows[currentPKValue].Cells["cInvStd"].Value = cInvStd;
          this.businessBody.Rows[currentPKValue].Cells["cComUnitCode"].Value = cComUnitName;
          this.businessBody.Rows[currentPKValue].Cells["fQuantity"].Value = fQuantity.ToString();
          //this.businessBody.Rows[currentPKValue].Cells["iUnitPrice"].Value = iUnitPrice;
          //this.businessBody.Rows[currentPKValue].Cells["iMoney"].Value = iMoney;
          //this.businessBody.Rows[currentPKValue].Cells["iTax"].Value = iTax;
          //this.businessBody.Rows[currentPKValue].Cells["iSum"].Value = iSum;
          this.businessBody.Rows[currentPKValue].Cells["iPerTaxRate"].Value = iTaxRate;
          //this.businessBody.Rows[currentPKValue].Cells["iNatUnitPrice"].Value = iNatUnitPrice;
          //this.businessBody.Rows[currentPKValue].Cells["iNatMoney"].Value = iNatMoney;
          //this.businessBody.Rows[currentPKValue].Cells["iNatTax"].Value = iNatTax;
          //this.businessBody.Rows[currentPKValue].Cells["iNatSum"].Value = iNatSum;
          //this.businessBody.Rows[currentPKValue].Cells["iQuotedPrice"].Value = iQuotedPrice;
          //this.businessBody.Rows[currentPKValue].Cells["iTaxUnitPrice"].Value = iTaxUnitPrice.ToString();
        }
      }
      this.businessBody.Cells["cInvCode"].ReadOnly = true;
      this.businessBody.Cells["fQuantity"].ReadOnly = true;
      this.businessBody.Cells["cSoCode"].ReadOnly = true;
      this.Close();
    }

    private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      this.dgvMain.CommitEdit(DataGridViewDataErrorContexts.Commit);
      string cSoCode = this.GetDGVMainSelectingRowCellValue("销售订单号");
      bool isSelected = this.GetDGVMainSelectingRowCellValueAsBool("选择");
      string cSPersonCode = this.GetDGVMainSelectingRowCellValue("业务员编码");
      string cSDepCode = this.GetDGVMainSelectingRowCellValue("销售部门编码");
      if (isSelected)
      {
        //验证业务员和部门一致
        DataTable dtMain = (DataTable)this.dgvMain.DataSource;
        if (dtMain != null)
        {
          foreach (DataRow row in dtMain.Rows)
          {
            if (Boolean.Parse(row["选择"].ToString()))
            {
              string cPersonCode = row["业务员编码"].ToString();
              string cDepCode = row["销售部门编码"].ToString();
              if (!cSPersonCode.Equals(cPersonCode) || !cSDepCode.Equals(cDepCode))
              {
                MessageBox.Show("请选择业务员和部门一致的销售订单");
                this.GetDGVMainSelectingRow().Cells["选择"].Value = false;
                return;
              }
            }
          }
        }
        this.AddDGVDetailData(cSoCode);
      }
      else
        this.RemoveDGVDetailData(cSoCode);
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      this.LoadDGVMainData();
    }

    private void tsBtnSearch_Click(object sender, EventArgs e)
    {
      string cSoCode = this.cbSoCode.Text;
      string cCusCode = this.cbCusCode.Text;
      string cCusName = this.cbCusName.Text;
      string cDepCode = this.cbDepCode.Text;
      string cDepName = this.cbDepName.Text;
      string cPersonCode = this.cbPsnCode.Text;
      string cPersonName = this.cbPsnName.Text;
      string cSoType = this.cbSoType.Text;

      string filterString=" (1=1) ";
      if (!string.IsNullOrEmpty(cSoCode))
        filterString += string.Format(" and 销售订单号='{0}' ", cSoCode);
      if(!string.IsNullOrEmpty(cCusCode))
        filterString += string.Format(" and 客户编码='{0}' ", cCusCode);
      if (!string.IsNullOrEmpty(cCusName))
        filterString += string.Format(" and 客户='{0}' ", cCusName);
      if (!string.IsNullOrEmpty(cDepCode))
        filterString += string.Format(" and 销售部门编码='{0}' ", cDepCode);
      if (!string.IsNullOrEmpty(cDepName))
        filterString += string.Format(" and 销售部门='{0}' ", cDepName);
      if (!string.IsNullOrEmpty(cPersonCode))
        filterString += string.Format(" and 业务员编码='{0}' ", cPersonCode);
      if (!string.IsNullOrEmpty(cPersonName))
        filterString += string.Format(" and 业务员='{0}' ", cPersonName);
      if (!string.IsNullOrEmpty(cSoType))
        filterString += string.Format(" and 销售类型='{0}' ", cSoType);

      string startDate = this.dtpStart.Value.ToString("yyyy-MM-dd");
      string endDate = this.dtpEnd.Value.ToString("yyyy-MM-dd");
      filterString += string.Format(" and (单据日期 >= '{0}' and 单据日期<= '{1}')", startDate, endDate);

      DataRow[] rows=this.originDataTable.Select(filterString);
      DataTable table = this.originDataTable.Clone();
      foreach (DataRow row in rows)
      {
        table.ImportRow(row);
      }
      this.dgvMain.DataSource = table;
    }
  }
}
