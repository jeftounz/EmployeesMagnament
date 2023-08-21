using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmployeesMagnament.DAL
{
    class dalConection
    {
        private string conectionString = "Data Source=DESKTOP-PGPP075\\SQLEXPRESS; Initial Catalog=dbSystem; Integrated Security=True";
        SqlConnection con;

        public SqlConnection establishConnection() 
        {
            this.con= new SqlConnection(this.conectionString);
            return this.con;

        }

        /*This is for INSERT, DELETE AND UPDATE*/
        public bool ComandsWithoutReturnOfData(string strcomand)
        {
            try
            {
               
                SqlCommand comand = new SqlCommand();

                comand.CommandText = strcomand;
                comand.Connection = this.establishConnection();
                con.Open();
                comand.ExecuteNonQuery();
                con.Close();

                return true;

            }
            catch
            {
                return false;
            }

        }



        /*SELECT (RETURN OF DATA)*/

        public DataSet ExecuteSentence(SqlCommand sqlCom)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                SqlCommand command = new SqlCommand();
                command = sqlCom;
                command.Connection=establishConnection();
                adapter.SelectCommand = command;
                con.Open();
                adapter.Fill(DS);
                con.Close();

                return DS;

            }
            catch
            {
                return DS;
            }

        }




    }

}
