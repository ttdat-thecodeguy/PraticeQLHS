using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760029_ConnectDatabase
{

    public partial class Form1 : Form
    {
        Connection connectionClass = new Connection();
        public Form1()
        {
            InitializeComponent();         
            btnRead.Click += BtnRead_Click;
            btnWrite.Click += BtnWrite_Click;
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            //open to connect
            connectionClass.open();
            WriteForm frm = new WriteForm();
            frm.ShowDialog();         
            List<hocsinh> lst = frm.lst;
            //open cmd
            if (lst.Count > 0)
            {
                string sqlInsertStudent = "Insert Into hocsinh(Ma,HoTen,NgaySinh,DiaChi,Toan,Van) values('" + lst[0].code + "','" + lst[0].name + "','" + lst[0].datebirth + "','" + lst[0].addr + "'," + lst[0].math + "," + lst[0].lit + ")";
                SqlCommand command = new SqlCommand(sqlInsertStudent, connectionClass.getConnect());
                command.ExecuteNonQuery();
            }
            //close after done
            connectionClass.close();
        }
        public List<hocsinh> ListRead= new List<hocsinh>();
        private void BtnRead_Click(object sender, EventArgs e)
        {
            //open to connect        
            
            ReadFrm frm = new ReadFrm();
            frm.ShowDialog();
            connectionClass.close();         
        }

       
    }
}
