using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.Plugin.LPCSPlugin.DB;
using UFIDA.U8.UAP.UI.Runtime.Model;

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
      string sql = @"select 
convert(bit,0) as 选择,
ID,
csocode as 销售订单号,
saletype.cstcode as 销售类型编码,
cstname as 销售类型,
customer.ccuscode as 客户编码,
customer.ccusname as 客户,
department.cdepcode as 销售部门编码,
cdepname as 销售部门,
person.cpersoncode as 业务员编码,
cpersonname as 业务员,
ddate as 单据日期
from so_somain somain
left join saletype saletype on somain.cstcode = saletype.cstcode
left join customer customer on somain.ccuscode = customer.ccuscode
left join department department on somain.cdepcode = department.cdepcode
left join person person on somain.cpersoncode = person.cpersoncode";
      DataTable tableMain = this.connection.Query(sql);
      this.dgvMain.DataSource = tableMain;
      
      foreach(DataGridViewColumn column in this.dgvMain.Columns)
      {
        string columnName = column.Name;
        if (!"选择".Equals(columnName))
          column.ReadOnly = true;
        else column.ReadOnly = false;
      }
    }

    //private void dgvMain_SelectionChanged(object sender, EventArgs e)
    //{
    //  string cSoCode = this.GetDGVMainSelectingRowCellValue("销售订单号");
    //  this.LoadDGVDetailData(cSoCode);
    //}

    /// <summary>
    /// 加载子表数据到DataGridViewDetail
    /// </summary>
    /// <param name="code"></param>
    private void AddDGVDetailData(string code)
    {
      string sql = @"select 
convert(bit,1) as 选择,
autoid,
csocode 销售订单编号,
inv.cinvcode 存货编码,
inv.cinvname 存货,
dpredate 预发货日期,
iquantity 数量
from so_sodetails sodetail
left join inventory inv on sodetail.cinvcode = inv.cinvcode
where csocode = '{0}'";
      sql = string.Format(sql, code);
      DataTable table = this.connection.Query(sql);
      if (this.dgvDetail.DataSource == null)
      {
        this.dgvDetail.DataSource = table;
        return;
      }

      DataTable eTable = (DataTable)this.dgvDetail.DataSource;
      foreach (DataRow row in table.Rows)
      {
        eTable.ImportRow(row);
      }

      foreach (DataGridViewColumn column in this.dgvDetail.Columns)
      {
        string columnName = column.Name;
        if (!"选择".Equals(columnName))
          column.ReadOnly = true;
        else column.ReadOnly = false;
      }
    }

    /// <summary>
    /// 加载子表数据到DataGridViewDetail
    /// </summary>
    /// <param name="code"></param>
    private void RemoveDGVDetailData(string code)
    {
      DataTable eTable = (DataTable)this.dgvDetail.DataSource;
      DataTable table = eTable.Clone();

      //List<int> ll = new List<int>();
      //int counter=0;
      foreach (DataRow row in eTable.Rows)
      {
        string cSoCode = row["销售订单编号"].ToString();
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
      bool b = bool.Parse(cellValue);
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

    private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      string cSoCode = this.GetDGVMainSelectingRowCellValue("销售订单号");
      bool isSelected = this.GetDGVMainSelectingRowCellValueAsBool("选择");
      if (isSelected)
        this.AddDGVDetailData(cSoCode);
      else
        this.RemoveDGVDetailData(cSoCode);
    }

    private void tsBtnOk_Click(object sender, EventArgs e)
    {
      //请购单子表没有选中任何记录 
      bool flag = false;
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
        string ID = dr["csocode"].ToString();
        //string sql = "select ID from pu_appVouch id= '" + ID + "'";
        if (!idS.Contains(ID))
          idS.Add(ID);
      }
      //判断单据表头是否被修改过
      DataTable dtHeader = (DataTable)this.dgvMain.DataSource;
      for (int i = 0; i < dtHeader.Rows.Count; i++)
      {
        DataRow dr = dtHeader.Rows[i];
        string ID = dr["csocode"].ToString();

        if (idS.Contains(ID))
        {
          string sTmpUfts = dr["ufts"].ToString();
          string sql = "select convert(nchar,convert(money,ufts),2) as ufts from so_somain where csocode = '" + ID + "'";
          string sUfts = this.connection.GetString(sql);
          if (!sTmpUfts.Equals(sUfts))
          {
            string cCode = dr["销售订单编号"].ToString();
            MessageBox.Show("销售订单编号[" + cCode + "]被修改过或者删除，请点击查询按钮进行刷新");
            return;
          }
        }
      }

      //this.businessBody.Clear();
      //for (int i = 0; i < tempDt.Rows.Count; i++)
      //{
      //  DataRow row = tempDt.Rows[i];
      //  object obj = tempDt.Rows[i]["选择"];
      //  bool ifSelected = false;
      //  if (obj != null && obj != System.DBNull.Value)
      //    ifSelected = Convert.ToBoolean(obj);
      //  if (ifSelected == true)
      //  {
      //    string cPurAppCode = row["请购单编码"].ToString();
      //    string cPersonCode = row["业务员编码"].ToString();
      //    string cPersonName = this.dalPerson.getNameByCode(cPersonCode);
      //    string appVouchAutoID = row["autoID"].ToString();
      //    string cInvCode = this.dalPurAppVoucher.getInvCodeByAutoID(appVouchAutoID);
      //    string cInvName = this.dalInventory.getInventoryNameByInventoryCode(cInvCode);
      //    string cInvStd = this.dalInventory.getInvStdByInvCode(cInvCode);
      //    float iQuantity = Convert.ToSingle(row["数量"].ToString());//this.dalPurAppVoucher.getQuantityByAutoID(appVouchAutoID);
      //    float iNum = Convert.ToSingle(row["件数"].ToString());//this.dalPurAppVoucher.getNumByAutoID(appVouchAutoID);
      //    //税率
      //    float fTaxRate = Convert.ToSingle(row["税率"].ToString());
      //    string cComUnitCode = this.dalInventory.getComUnitCodeByInventoryCode(cInvCode);
      //    string cComUnitName = this.dalInventory.getComputationUnitNameByInventoryCode(cInvCode);
      //    float iOriCost = this.dalPurAppVoucher.getOriCostByAutoID(appVouchAutoID);
      //    float iOriSum = this.dalPurAppVoucher.getOriSumByAutoID(appVouchAutoID);
      //    DateTime dRequireDate = this.dalPurAppVoucher.getRequireDateByAutoID(appVouchAutoID);
      //    string cBusType = row["业务类型"].ToString();

      //    //换算率
      //    string fExchRate = row["换算率"].ToString();
      //    //自由项
      //    string cFree1 = row["材质"].ToString();
      //    string cFree2 = row["状态"].ToString();
      //    //备注
      //    string cRemark = row["备注"].ToString();
      //    this.businessBody.AddRow();
      //    string currentPKValue = this.businessBody.CurrentPKValue;

      //    this.businessBody.Rows[currentPKValue].Cells["cPurAppCode"].Value = cPurAppCode;
      //    this.businessBody.Rows[currentPKValue].Cells["cPersonCode"].Value = cPersonCode;
      //    this.businessBody.Rows[currentPKValue].Cells["cPersonName"].Value = cPersonName;
      //    this.businessBody.Rows[currentPKValue].Cells["appVouchAutoID"].Value = appVouchAutoID;
      //    this.businessBody.Rows[currentPKValue].Cells["cInvCode"].Value = cInvCode;
      //    this.businessBody.Rows[currentPKValue].Cells["cInvName"].Value = cInvName;
      //    this.businessBody.Rows[currentPKValue].Cells["cInvStd"].Value = cInvStd;
      //    this.businessBody.Rows[currentPKValue].Cells["fQuantity"].Value = iQuantity.ToString();
      //    this.businessBody.Rows[currentPKValue].Cells["fNum"].Value = iNum.ToString();
      //    this.businessBody.Rows[currentPKValue].Cells["fTaxRate"].Value = fTaxRate.ToString();
      //    this.businessBody.Rows[currentPKValue].Cells["cComUnitCode"].Value = cComUnitCode;
      //    this.businessBody.Rows[currentPKValue].Cells["cComUnitName"].Value = cComUnitName;
      //    this.businessBody.Rows[currentPKValue].Cells["iOriCost"].Value = iOriCost.ToString();
      //    this.businessBody.Rows[currentPKValue].Cells["iOriSum"].Value = iOriSum.ToString();
      //    this.businessBody.Rows[currentPKValue].Cells["dRequireDate"].Value = dRequireDate.ToString("yyyy-MM-dd");
      //    this.businessBody.Rows[currentPKValue].Cells["fExchRate"].Value = fExchRate.ToString();
      //    this.businessBody.Rows[currentPKValue].Cells["cFree1"].Value = cFree1;
      //    this.businessBody.Rows[currentPKValue].Cells["cFree2"].Value = cFree2;
      //    this.businessBody.Rows[currentPKValue].Cells["cBusType"].Value = cBusType;
      //    this.businessBody.Rows[currentPKValue].Cells["cRemark"].Value = cRemark;
      //  }
      //}
      this.Close();
    }
  }
}
