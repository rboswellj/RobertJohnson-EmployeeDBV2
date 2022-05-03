using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace RobertJohnson_EmployeeDBV2
{
    class DatabaseConnection
    {
        private string sql_string;
        private string strCon;
        SqlDataAdapter da_1;

        public string Sql
        {

            set
            {
                sql_string = value;
            }

        }

        public string Connection_string
        {
            set { strCon = value; }
        }

        public System.Data.DataSet GetConnection
        {
            get { return MyDataSet(); }
        }

        private System.Data.DataSet MyDataSet()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            da_1 = new SqlDataAdapter(sql_string, con);
            System.Data.DataSet dat_set = new System.Data.DataSet();
            da_1.Fill(dat_set, "Table_Data_1");
            con.Close();
            return dat_set;
        }

        public void UpdateDatabase(System.Data.DataSet ds)
        {
            // Need to set up CommandBuilder to update DB
            SqlCommandBuilder cb = new SqlCommandBuilder(da_1);
            cb.DataAdapter.Update(ds.Tables[0]);
        }
    }
}
