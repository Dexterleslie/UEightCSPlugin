using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper;
using UFIDA.U8.Plugin.LPCSPlugin.EntityModel.SA;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using UFIDA.U8.Plugin.LPCSPlugin.DB;
using UFIDA.U8.Plugin.LPCSPlugin.DB.SqlServer;

namespace UFIDA.U8.Plugin.LPCSPlugin
{
  /// <summary>
  /// 
  /// </summary>
  static class Program
  {
    static void Main()
    {
      string host = "(local)";
      string database = "UFDATA_001_2012";
      string user = "sa";
      string password = "1";
      ConnectionMediatorBase mediator = new SqlServerConnectionMediator(host,database,user,password);
      //Application.Run(new ReceiptPullForm(mediator));
    }
  }
}
