using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkPC workPC = new WorkPC();

            // test
            Storage storage = new Flash("Transcend", "TX", 5, 8);


            User user = new User();
            user.AddStorage(storage);

            Calculations.TotalDeviceMemory()
        }
    }
}
