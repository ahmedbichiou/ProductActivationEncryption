using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class connection
    {
        public string getConn()
        {
            string connectionSTR = @"SERVER = .\SQLEXPRESS ; DATABASE = LicenceDB ; Trusted_Connection=True";
            return connectionSTR;
        }
       

    }
}
