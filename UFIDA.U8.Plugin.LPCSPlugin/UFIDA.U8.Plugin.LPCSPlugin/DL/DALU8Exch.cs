using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.Plugin.LPCSPlugin.DB;

namespace UFIDA.U8.Plugin.LPCSPlugin.DL
{
    public class DALU8Exch
    {
        private string connStr;
        private Connection connection;

        public DALU8Exch(string connStr)
        {
            this.connStr = connStr;
            //this.db = new DB(this.connStr);
            this.connection = new Connection(this.connStr);
        }

        public string getNameByCode(string code)
        {
            string sql = "select cexch_name from foreigncurrency where cexch_code = '" + code + "'";
            string cExchName = this.connection.GetString(sql);
            return cExchName;
        }

        public string getCodeByName(string name)
        {
          string sql = "select cexch_code from foreigncurrency where cexch_name = '" + name + "'";
          string ret = this.connection.GetString(sql);
          return ret;
        }

        public float getNflatByName(string name)
        {
            //string sql = "select top 1 nFlat from exch where cexch_name='"+name+"' order by iperiod desc,itype desc";
            //float val = this.connection.getFloat(sql);
            //if ("»À√Ò±“".Equals(name)||val ==0f)
            //    val = 1f;
            //return val;
          return 0;
        }
    }
}
