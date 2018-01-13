using System;
using static System.Console;
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
            //for (int i = 0; i < storage.Length; i++)
            //{

            //}
            /* or */
            while (workPC.TotalSizeOfFiles != 0)
            {
                foreach (Storage item in storage)
                {
                    item.CopyingDataToTheDevice(workPC);
                }
            }
            WriteLine();
            // TODO
            // копирование на HoumPC
        }
        // Расчет времени необходимого для копирования.
        public static void CopyTime(WorkPC workPC, Storage[] storage)
        {
            int recordingTime = 0;
            int readingTime = 0;
            int files;
            int totalSizeOfFiles = workPC.TotalSizeOfFiles;

            while (totalSizeOfFiles != 0)
            {
                foreach (Storage item in storage)
                {
                    files = item.PlacedFiles(workPC.FileSize);
                    recordingTime += ((workPC.FileSize * files) * 1024) / item.RecordingTime();

                    readingTime += ((workPC.FileSize * files) * 1024) / item.ReadingTime();

                    // Отнимаем от общего размера, размер вмещающихся файлов.
                    totalSizeOfFiles =
                        totalSizeOfFiles - (workPC.FileSize * files);
                }
            }

            WriteLine($" Время копирования на носители: {recordingTime}");
            WriteLine($" Время чтения с носителей: {readingTime}");
            WriteLine(" Общее время копирования на другой пк: "
                + $"{recordingTime + readingTime}");

            //return recordingTime;
        }
        // Расчет необходимого количества носителей информации
        // представленных типов для переноса информации.
        public static void NumberOfStorage(WorkPC workPC, Storage[] storage)
        {
            int totalSizeOfFiles = workPC.TotalSizeOfFiles;
            int files;  // TODO полиморфизм для files !!!
            int[] arr = new int[storage.Length];

            while (totalSizeOfFiles != 0) {
                for (int i = 0; i < storage.Length; i++)
                {
                    // TODO полиморфизм для files !!!

                    // Узнаем кол-во файлов вмещающихся на носитель.
                    //files = storage[i].GettingTheAmountOfMemory() / workPC.FileSize;
                    files = storage[i].PlacedFiles(workPC.FileSize);
                    // Отнимаем от общего размера, размер вмещающихся файлов.
                    totalSizeOfFiles =
                        totalSizeOfFiles - (workPC.FileSize * files);


                    if (files > 0)
                    {
                        arr[i]++;
                    }
                }
            }


            for (int i = 0; i < storage.Length; i++)
            {
                WriteLine($" Количество {storage[i].Name}: {arr[i]}");
            }

            // если есть флешка, то флешек нужно
            // ...
        }
    }
}
