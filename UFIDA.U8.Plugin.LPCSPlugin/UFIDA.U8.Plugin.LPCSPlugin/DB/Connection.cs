using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UFIDA.U8.Plugin.LPCSPlugin.DB
{
  /// <summary>
  /// 数据库连接对象
  /// </summary>
  public class Connection
  {
    //private ConnectionMediatorBase mediator;

    //public Connection(ConnectionMediatorBase mediator)
    //{
    //  if (mediator == null)
    //    throw new ArgumentNullException("mediator");
    //  this.mediator = mediator;
    //}

    private string connectionString = null;
    public Connection(string connectionString)
    {
      if (connectionString == null)
         throw new ArgumentNullException("connectionString");
       this.connectionString = connectionString;
    }

    //public ConnectionMediatorBase ConnectionMediator
    //{
    //  get
    //  {
    //    return this.mediator;
    //  }
    //}

    public IDbConnection CreateDbConnection()
    {
      //string connectionString = this.mediator.GetConnectionString();
      if (string.IsNullOrEmpty(connectionString))
        return null;
      IDbConnection con = new SqlConnection(connectionString);
      return con;
    }

    public DataSet QueryForDataSet(string sql, IDataParameter[] parameters)
    {
      if (string.IsNullOrEmpty(sql))
        throw new ArgumentNullException("sql");
      IDbConnection con = this.CreateDbConnection();
      if (con == null)
        return null;

      IDbCommand cmd = new SqlCommand();
      cmd.Connection = con;
      cmd.CommandText = sql;
      cmd.CommandType = CommandType.Text;
      if (parameters != null)
      {
        //cmd.Parameters = parameters;
        foreach (IDataParameter param in parameters)
          cmd.Parameters.Add(param);
      }

      //IDbDataAdapter adapter = new SqlDataAdapter(cmd);
      IDbDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      return ds;
    }

    public DataTableCollection QueryForTableCollection(string sql, IDataParameter[] parameters)
    {
      DataSet ds = this.QueryForDataSet(sql,parameters);
      DataTableCollection tableCollection = ds.Tables;
      return tableCollection;
    }

    /// <summary>
    /// 执行没有参数select SQL
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public DataTable Query(string sql)
    {
      DataTable table = this.Query(sql, null);
      return table;
    }

    /// <summary>
    /// 执行带参数select SQL
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public DataTable Query(string sql, IDataParameter[] parameters)
    {
      DataTableCollection tableCollection = this.QueryForTableCollection(sql, parameters);
      if (tableCollection == null)
        return null;
      if (tableCollection.Count <= 0)
        return null;
      DataTable table = tableCollection[0];
      return table;
    }

    public string GetString(string sql)
    {
      DataTable table = this.Query(sql);
      if (table == null || table.Rows.Count <= 0)
        return null;
      string str = table.Rows[0][0].ToString();
      return str;
    }
  }
}
