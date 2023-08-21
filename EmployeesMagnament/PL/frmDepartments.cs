using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesMagnament.BLL;
using EmployeesMagnament.DAL;



namespace EmployeesMagnament.PL
{
    public partial class frmDepartments : Form
    {
        dalDepartment oDalDepartment;

        public frmDepartments()
        {
            oDalDepartment = new dalDepartment();
            InitializeComponent();
            dgvDepartments.DataSource = oDalDepartment.showDepartments().Tables[0];
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Instruction to get the information from the GUI
            informationRecorder();
            MessageBox.Show("Conection ...");
            //Dal Department class , the object contain information froom the GUI 
            oDalDepartment.add(informationRecorder());
        }

        private DepartmentBLL informationRecorder() 
        {
            DepartmentBLL oDepartmentBLL = new DepartmentBLL();
            int ID = 0; int.TryParse(txtIdDepartment.Text, out ID) ;
            oDepartmentBLL.ID = ID;

            oDepartmentBLL.Department = txtDepartmentName.Text;

            return oDepartmentBLL;

        }

        private void select(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            txtIdDepartment.Text = dgvDepartments.Rows[index].Cells[0].Value.ToString();
            txtDepartmentName.Text = dgvDepartments.Rows[index].Cells[1].Value.ToString();
        }
    }
}
