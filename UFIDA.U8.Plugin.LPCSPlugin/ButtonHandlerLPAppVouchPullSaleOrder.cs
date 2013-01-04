using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U8.UAP.UI.Runtime.Model;
using System.Windows.Forms;

namespace UFIDA.U8.Plugin.LPCSPlugin
{
  /// <summary>
  /// LP请购单生单
  /// </summary>
  class ButtonHandlerLPAppVouchPullSaleOrder:IButtonEventHandler
  {
    private string connectionString;

    public ButtonHandlerLPAppVouchPullSaleOrder(string connectionString)
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
      ReceiptPullForm frm = new ReceiptPullForm(this.connectionString, ReceiptObject);
      frm.WindowState = FormWindowState.Maximized;
      frm.ShowDialog();
      //frm.Show();
      return null;
    }

    public string Excuting(VoucherProxy ReceiptObject)
    {
      return null;
    }

    #endregion
  }
}
