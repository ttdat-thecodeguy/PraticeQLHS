using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760029_ConnectDatabase
{
    class Connection
    {
        
        private SqlConnection connectionProperty = null;
        /*
         * 
         * chương trình rảnh háng version v0.1
         * nhac sieu cam hung : https://www.youtube.com/watch?v=QDY4Gy_4eYw
         * author: truong thanh dat
         * id code:1760029
         * university: university of sience
         * see this project on my github: 
         */
        public string[] connection_string = new string[1] {
           "Data Source=(LocalDB)\\MSSQLLocalDB;" +
           "AttachDbFilename=|DataDirectory|\\qlhs.mdf;Integrated Security = true; Connect Timeout = 30"
    };
        public string presentConnectString = "";
        public void open()
        {
            if (connectionProperty == null)
                connectionProperty = new SqlConnection();
            if (connectionProperty != null)
            {
               for(int i = 0; i < connection_string.Length; i++)
                {
                    connectionProperty.ConnectionString = connection_string[i];
                    connectionProperty.Open();            
                    if(connectionProperty.State == ConnectionState.Open){
                        presentConnectString = connectionProperty.ConnectionString;
                        break;
                    }
                }
            }       
        }
        public SqlConnection getConnect(){
            return connectionProperty;
        }
        public void close()
        {
            if(connectionProperty != null && connectionProperty.State == System.Data.ConnectionState.Open){
                connectionProperty.Close();
            }
        }
    }
}
