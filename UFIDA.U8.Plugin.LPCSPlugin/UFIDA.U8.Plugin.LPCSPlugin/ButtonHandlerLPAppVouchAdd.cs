using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U8.UAP.UI.Runtime.Model;
using System.Windows.Forms;

namespace UFIDA.U8.Plugin.LPCSPlugin
{
  /// <summary>
  /// </summary>
  class ButtonHandlerLPAppVouchAdd:IButtonEventHandler
  {
    private string connectionString;
    //表头实体标识
    private string entityHeaderID = "lp001_0001_E001";
    //表体实体标识
    private string entityBodyID = "lp001_0001_E002";

    public ButtonHandlerLPAppVouchAdd(string connectionString)
    {
      this.connectionString = connectionString;
    }

    #region IButtonEventHandler Members

    public string Excute(VoucherProxy ReceiptObject, string PreExcuteResult)
    {
      return null;
    }

    public string Excuted(VoucherProxy ReceiptObject, string PreExcuteResult)
    {
      ReceiptObject.Businesses[this.entityHeaderID].Cells["cPersonCode"].ReadOnly = true;
      ReceiptObject.Businesses[this.entityHeaderID].Cells["cCusCode"].ReadOnly = true;
      ReceiptObject.Businesses[this.entityHeaderID].Cells["cDepCode"].ReadOnly = true;
      ReceiptObject.Businesses[this.entityBodyID].AllowUIAddRow = false;
      return null;
    }

    public string Excuting(VoucherProxy ReceiptObject)
    {
      return null;
    }

    #endregion
  }
}
