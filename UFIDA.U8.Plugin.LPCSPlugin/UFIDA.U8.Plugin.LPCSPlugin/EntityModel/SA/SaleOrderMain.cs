using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.Plugin.LPCSPlugin.EntityModel.SA
{
  /// <summary>
  /// 销售订单主表
  /// </summary>
  public class SaleOrderMain
  {
    /// <summary>
    /// 销售订单ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 销售订单号
    /// </summary>
    public string SoCode { get; set; }
    /// <summary>
    /// 客户编码
    /// </summary>
    public string CustomerCode { get; set; }
    /// <summary>
    /// 销售类型编码
    /// </summary>
    public string SaleTypeCode { get; set; }
    /// <summary>
    /// 单据日期
    /// </summary>
    public DateTime CreateDateTime { get; set; }
    /// <summary>
    /// 部门编码 
    /// </summary>
    public string DepartmentCode { get; set; }
  }
}
