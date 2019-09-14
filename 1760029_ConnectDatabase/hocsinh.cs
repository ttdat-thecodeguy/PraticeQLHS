using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760029_ConnectDatabase
{
    public class hocsinh
    {
       public string name;
       public string code;
       public DateTime datebirth;
       public float math;
       public float lit;
       public string addr;

        public hocsinh(string code , string name, DateTime dateofbirth, string addr, float math, float lit)
        {
            this.code = code;
            this.addr = addr;
            this.name = name;
            this.math = math;
            this.lit = lit;
        }
    }
}
