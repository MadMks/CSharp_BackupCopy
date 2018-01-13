using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    static class Calculations
    {
        // Расчет общего количества памяти всех устройств.
        public static int TotalDeviceMemory(Storage[] storage)
        {
            int totalMemory = 0;

            foreach (Storage item in storage)
            {
                totalMemory += item.GettingTheAmountOfMemory();
            }

            return totalMemory;
        }
        // Копирование информации на устройства.
        public static void CopyingInfo(/*bool from,*/ WorkPC workPC, Storage[] storage)    // TODO abs class PC
        {
            for (int i = 0; i < storage.Length; i++)
            {

            }
            /* or */
            foreach (Storage item in storage)
            {
                item.CopyingDataToTheDevice(workPC);
            }

            // TODO
            // копирование на HoumPC
        }
        // Расчет времени необходимого для копирования.
        public static int CopyTime(WorkPC workPC, Storage[] storage)
        {
            /* code */

            return 0;   // TODO re
        }
        // Расчет необходимого количества носителей информации
        // представленных типов для переноса информации.
        public static void NumberOfStorage(WorkPC workPC, Storage[] storage)
        {

            // если есть флешка, то флешек нужно
            // ...
        }
    }
}
