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
            //WorkPC workPC = new WorkPC();

            //Storage st = new Flash(); // test

            //Storage storage1 = new Flash("Transcend", "TX", 5, 8);
            //Storage storage2 = new Flash("Respect", "TX", 10, 4);
            ////WriteLine(st);
            //User user = new User();
            //user.AddStorage(storage1);
            //user.AddStorage(storage2);

            //Write(" Общее кол-во памяти всех устройств: ");
            //WriteLine(Calculations.TotalDeviceMemory(user.GetDevices()) + "\n");
            //Design.Line();

            //WriteLine(workPC);
            //Design.Line();

            //Calculations.NumberOfStorage(workPC, user.GetDevices());
            //Design.Line();
            //WriteLine(workPC);
            //Design.Line();


            //Calculations.CopyTime(workPC, user.GetDevices());
            //Design.Line();

            //Write(" Копируем все файлы: ");
            //Calculations.CopyingInfo(workPC, user.GetDevices());
            //WriteLine(workPC);

            //Menu menu = new Menu();
            
            User user = new User();
            WorkPC workPC = new WorkPC();
            Menu.Start(user, workPC);
            //Menu.AddUserStorage(user);
        }
    }
}
