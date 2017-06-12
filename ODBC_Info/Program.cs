using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODBCInfoGetterPluggin;
namespace ODBC_Info
{
    class Program
    {
        GetInfo _gi = new GetInfo();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDrivers();
            Console.Read();
        }
        private void ShowDrivers()
        {
            var drivers = _gi.GetSystemDriverList();
            foreach (var a in drivers)
            {
                Console.WriteLine(a);
            }
        }
    }
}
