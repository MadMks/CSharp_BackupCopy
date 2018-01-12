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

            //WriteLine(storage);
            //WriteLine(new string('_', 36) + '\n');

            //WriteLine(storage.GettingTheAmountOfMemory());
            //WriteLine(new string('_', 36) + '\n');

            //storage.FreeMemoryOnTheDevice();
            //WriteLine(new string('_', 36) + '\n');

            storage.GettingFullInformationAboutTheDevice();
            Design.Line();
            WriteLine(workPC);
            Design.Line();
            storage.CopyingDataToTheDevice(workPC);
            Design.Line();
            WriteLine(workPC);
            Design.Line();
            storage.GettingFullInformationAboutTheDevice();
        }

        static void TotalMemory(/* передаю ... */)
        {

        }

    }
}
