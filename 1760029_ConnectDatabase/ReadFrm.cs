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
    public partial class ReadFrm : Form
    {
        Connection connectionClass = new Connection();
        List<hocsinh> ListRead = new List<hocsinh>();
        List<string> type = new List<string>();
        public ReadFrm()
        {
             InitializeComponent();
             btnPrevious.Click += BtnPrevious_Click;
             btnNext.Click += BtnNext_Click;
             btnUpdate.Click += BtnUpdate_Click;
             btnDelete.Click += BtnDelete_Click;


             ListRead = getList();
            getTextBox(i);
            
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            connectionClass.open();
            SqlCommand cmdRead = new SqlCommand("update hocsinh set Ma='"+txtCode.Text +"'," + "HoTen='" + txtFullName.Text + "'," + "NgaySinh='"  + txtDateOfBirth.Text + "'," + "DiaChi='"+txtAddr.Text+"',"+"Toan="+txtToan.Text + "," +"Van=" +txtLit.Text+ " where Ma='" + ListRead[i].code + "'",connectionClass.getConnect());
            SqlDataReader rd = cmdRead.ExecuteReader();
            ListRead.RemoveAt(i);
            ListRead.Add(new hocsinh(txtCode.Text, txtFullName.Text, DateTime.Parse(txtDateOfBirth.Text),
                txtAddr.Text, float.Parse(txtToan.Text), float.Parse(txtLit.Text)));
            if (i > 0)
                getTextBox(i--);
            else
                getTextBox(ListRead.Count - 1);
            
            getTextBox(i++);

            connectionClass.close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            connectionClass.open();
            SqlCommand cmdRead = new SqlCommand("delete from hocsinh where Ma=" + ListRead[i].code, connectionClass.getConnect());
            SqlDataReader rd = cmdRead.ExecuteReader();
            ListRead.RemoveAt(i);
            getTextBox(i--);
            connectionClass.close();    
        }      
        private List<hocsinh> getList()
        {
            connectionClass.open();
            List<hocsinh> ListRead = new List<hocsinh>();
            SqlCommand cmdRead = new SqlCommand("select * from hocsinh", connectionClass.getConnect());
            SqlDataReader rd = cmdRead.ExecuteReader();
            while (rd.Read())
            {
                string MaSo = rd.GetString(0);
                string FullName = rd.GetString(1);
                DateTime dateOfbirth = rd.GetDateTime(2);
                string addr = rd.GetString(3);
                float toan = (float)rd.GetDouble(4);
                float van = (float)rd.GetDouble(5);
                ListRead.Add(new hocsinh(MaSo, FullName, dateOfbirth, addr, toan, van));
            }//close after done
            connectionClass.close();
            return ListRead;
        }
        private void getTextBox(int i)
        {
            txtCode.Text = ListRead[i].code;
            txtFullName.Text = ListRead[i].name;
            txtDateOfBirth.Text = ListRead[i].datebirth.ToString();
            txtAddr.Text = ListRead[i].addr;
            txtLit.Text = ListRead[i].lit.ToString();
            txtToan.Text = ListRead[i].math.ToString();
        }
        int i = 0;
        private void BtnNext_Click(object sender, EventArgs e)
        {
           if(i < ListRead.Count -1)
            {
                i++;
                getTextBox(i);
            }
            else
            {
                i = 0;
                getTextBox(i);
            }
        }
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if(i > 0)
            {
                i--;
                getTextBox(i);
            }
            else
            {
                i = ListRead.Count-1;
                getTextBox(i);
            }
        }

        private void ReadFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
