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
            p.ShowDrivers("xlsx");
            Console.Read();
        }
        private void ShowDrivers(string find)
        {
            var drivers = _gi.GetSystemDriverList();
            foreach (string a in drivers)
            {
                if(a.Contains(find))
                    Console.WriteLine(a);
            }
        }
    }
}
