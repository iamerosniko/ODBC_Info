using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODBCInfoGetterPluggin;
using System.Data.Odbc;
using System.Data;
namespace ODBC_Info
{
    class Program
    {
        GetInfo _gi = new GetInfo();
        string excelPath = @"C:\Users\alverer\Desktop\Eros TImeTracker.xlsx";
        static void Main(string[] args)
        {
            Program p = new Program();
           
            p.ShowDrivers("");
            Console.Read();
        }
        private void ShowDrivers(string find)
        {
            var drivers = _gi.GetSystemDriverList();
            foreach (string a in drivers)
            {
                if (a.Contains(find))
                {
                   checkODBCConnection(a);
                }
            }
        }

        private Boolean checkODBCConnection(string odbcDriverStr)
        {
            OdbcConnection con = new OdbcConnection(@"Driver={"+odbcDriverStr+@"};Dbq="+@excelPath+";");
            var adapter = new OdbcDataAdapter("SELECT * FROM [March$]", con);
            var ds = new DataSet();
            int a;
            try
            {
                adapter.Fill(ds, "anyNameHere");
                a = ds.Tables[0].Rows.Count;
                if (a != -1)
                {
                    Console.WriteLine(odbcDriverStr);
                    Console.WriteLine(a);
                }
            }
            catch
            {
                a = -1;
            }
            return a!=-1? true : false;
        }
    }
}
