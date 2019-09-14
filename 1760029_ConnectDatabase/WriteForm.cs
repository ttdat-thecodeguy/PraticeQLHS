using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760029_ConnectDatabase
{
    public partial class WriteForm : Form
    {
        public List<hocsinh> lst= new List<hocsinh>();
        Connection connect = new Connection();
        public WriteForm()
        {
            InitializeComponent();
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            connect.open();
            SqlCommand commandRead = new SqlCommand("select * from thamso", connect.getConnect());
            SqlDataReader rd = commandRead.ExecuteReader();            
            int minAge = 0, maxAge = 0;
            while (rd.Read())
            {
                minAge = rd.GetInt32(0);
                maxAge = rd.GetInt32(1);
            }
            DateTime dateOfBirth = DateTime.Parse(txtDateOfBirth.Text);
            int RealAge = DateTime.Now.Year - dateOfBirth.Year;
            if (RealAge >= minAge && RealAge <= maxAge)
                lst.Add(new hocsinh(txtCode.Text, txtName.Text,dateOfBirth, txtaddr.Text,float.Parse(txtMath.Text),float.Parse(txtLit.Text)));
            else
            {
                if (RealAge > maxAge)
                    MessageBox.Show("Học sinh Này không được nhập học vì lớn tuổi");
                else
                    MessageBox.Show("Học sinh này không được nhập học vì nhỏ hơn tuổi quy định");
            }
            this.Close();
        }
    }
}
