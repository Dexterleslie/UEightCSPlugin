using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.Plugin.LPCSPlugin.DB.SqlServer
{
  /// <summary>
  /// Sql server 数据库连接信息媒介
  /// </summary>
  public class SqlServerConnectionMediator :ConnectionMediatorBase
  {
    public SqlServerConnectionMediator(string host, string database,
      string user, string password) :base(host,database,user,password)
    {

    }

    public override string GetConnectionString()
    {
      string formatString = "data source={0};database={1};user id={2};password={3}";
      string connectionString = string.Format(formatString, this.Host, this.Database, this.User, this.Password);
      return connectionString;
    }
  }
}
