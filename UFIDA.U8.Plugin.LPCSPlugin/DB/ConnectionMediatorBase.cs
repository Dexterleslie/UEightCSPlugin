using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.Plugin.LPCSPlugin.DB
{
  public abstract class ConnectionMediatorBase
  {
    //data source=(local);database=UFDATA_001_2012;user id=sa;password=1
    private string host;
    private string database;
    private string user;
    private string password;

    #region Properties

    public string Host
    {
      get { return this.host; }
    }

    public string Database
    {
      get { return this.database; }
    }

    public string User
    {
      get { return this.user; }
    }

    public string Password
    {
      get { return this.password; }
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="database"></param>
    /// <param name="user"></param>
    /// <param name="password"></param>
    public ConnectionMediatorBase(string host, string database, string user, string password)
    {
      if(string.IsNullOrEmpty(host))
        throw new ArgumentNullException("host");
      if (string.IsNullOrEmpty(database))
        throw new ArgumentNullException("database");
      if (string.IsNullOrEmpty(user))
        throw new ArgumentNullException("user");

      this.host = host;
      this.database = database;
      this.user = user;
      this.password = password;
    }

    /// <summary>
    /// 获取连接数据库字符串
    /// </summary>
    /// <returns></returns>
    public abstract string GetConnectionString();
  }
}
