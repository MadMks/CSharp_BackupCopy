using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{


    class Design
    {

        // Линия.
        public static void Line()
        {
            Console.WriteLine(new string('_', 36) + '\n');
        }

        // Цвета.
        public static void Default()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void Blue()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }


    }
}