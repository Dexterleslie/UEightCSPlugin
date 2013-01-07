using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U8.UAP.UI.Runtime.Model;

namespace UFIDA.U8.Plugin.LPCSPlugin
{
    /// <summary>
    /// 兰浦采购申请单单据控制接口
    /// </summary>
    class ReceiptLPAppVouch : ReceiptPluginBase,IReceipt
    {
      #region IReceipt Members

      public override IButtonEventHandler GetButtonEventHandler(UFIDA.U8.UAP.UI.Runtime.Common.VoucherButtonArgs ButtonArgs, VoucherProxy voucherObject)
      {
        string connStr = voucherObject.LoginInfo.UFDataSqlConStr;
        string buttonKey = ButtonArgs.ButtonKey;
        if ("btnMakeVoucher".Equals(buttonKey))
          return new ButtonHandlerLPAppVouchPullSaleOrder(connStr);
        else if ("btnAddVoucher".Equals(buttonKey))
          return new ButtonHandlerLPAppVouchAdd(connStr);
        return null;
      }

      void IReceipt.CellChanged(UFIDA.U8.UAP.UI.Runtime.Common.CellChangeEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.CellChanging(UFIDA.U8.UAP.UI.Runtime.Common.CellChangeEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.CellDoubleClick(UFIDA.U8.UAP.UI.Runtime.Common.CellDoubleClickEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.CellEditing(UFIDA.U8.UAP.UI.Runtime.Common.CellSelectEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.CellSelected(UFIDA.U8.UAP.UI.Runtime.Common.CellSelectEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.ClickToolBarButton(UFIDA.U8.UAP.UI.Runtime.Common.ToolBarActionEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      System.Windows.Forms.Control IReceipt.CreateControl(BusinessProxy businessObject, VoucherProxy voucherObject, string ID)
      {
        throw new NotImplementedException();
      }

      void IReceipt.DataChecked(BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.DataChecking(BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.EditWindowFilled(UFIDA.U8.UAP.UI.Runtime.Common.IEditWindow view, System.Data.DataTable fillDataTable, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.EditWindowFilling(UFIDA.U8.UAP.UI.Runtime.Common.IEditWindow view, System.Data.DataTable fillDataTable, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.HeaderDoubleClick(UFIDA.U8.UAP.UI.Runtime.Common.HeaderDoubleClickEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.ReceiptLoaded(VoucherProxy ReceiptObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.ReceiptLoading(U8Login.clsLogin login, string Cardnumber, System.Data.DataSet ds, UFIDA.U8.UAP.UI.Runtime.Common.VoucherStateEnum state, UFIDA.U8.UAP.UI.Runtime.Common.ReceiptLoadingParas loadingParas)
      {
        throw new NotImplementedException();
      }

      void IReceipt.ReceiptUnLoaded(VoucherProxy ReceiptObject, UFIDA.U8.UAP.UI.Runtime.Common.VoucherButtonArgs exitCommand)
      {
        throw new NotImplementedException();
      }

      void IReceipt.ReceiptUnLoading(VoucherProxy ReceiptObject, UFIDA.U8.UAP.UI.Runtime.Common.VoucherButtonArgs exitCommand)
      {
        throw new NotImplementedException();
      }

      void IReceipt.ReferClosed(UFIDA.U8.UAP.UI.Runtime.Common.ReferCloseEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.ReferOpening(UFIDA.U8.UAP.UI.Runtime.Common.ReferOpenEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.RowAdded(UFIDA.U8.UAP.UI.Runtime.Common.RowChangeEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.RowAdding(UFIDA.U8.UAP.UI.Runtime.Common.RowChangeEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.RowChecked(UFIDA.U8.UAP.UI.Runtime.Common.RowCheckEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.RowChecking(UFIDA.U8.UAP.UI.Runtime.Common.RowCheckEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.RowDoubleClick(UFIDA.U8.UAP.UI.Runtime.Common.RowDoubleClickEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.RowSelected(UFIDA.U8.UAP.UI.Runtime.Common.RowSelectEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.RowSelecting(UFIDA.U8.UAP.UI.Runtime.Common.RowSelectEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.RowsDeleted(UFIDA.U8.UAP.UI.Runtime.Common.RowChangeEventArgs[] para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.RowsDeleting(UFIDA.U8.UAP.UI.Runtime.Common.RowChangeEventArgs[] para, BusinessProxy businessObject, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      void IReceipt.StateChanged(UFIDA.U8.UAP.UI.Runtime.Common.VoucherStateChangeEventArgs para, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      bool IReceipt.StateChanging(UFIDA.U8.UAP.UI.Runtime.Common.VoucherStateChangeEventArgs para, VoucherProxy voucherObject)
      {
        throw new NotImplementedException();
      }

      #endregion
    }
}
