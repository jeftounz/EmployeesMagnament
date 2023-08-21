using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EmployeesMagnament.BLL;

namespace EmployeesMagnament.DAL
{
    class dalDepartment
    {

        dalConection con;

        public dalDepartment()
        {
            con = new dalConection();
        }

        public bool add(DepartmentBLL oDepartmentBLL)
        {
           return con.ComandsWithoutReturnOfData("INSERT INTO Departments(department_name) VALUES('"+oDepartmentBLL.Department+"')");
        }


        public DataSet showDepartments() 
        {
            SqlCommand sentence = new SqlCommand("SELECT * FROM Departments");

            return con.ExecuteSentence(sentence);

        }

    }
}
