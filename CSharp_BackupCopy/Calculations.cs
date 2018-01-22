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
        public static void TotalDeviceMemory(Storage[] storage)
        {
            double totalMemory = 0;

            foreach (Storage item in storage)
            {
                totalMemory += item.GettingTheAmountOfMemory();
            }

            Write(" Общее кол-во памяти всех устройств: ");
            WriteLine(totalMemory + " Gb\n");
        }



        // Копирование информации на устройства.
        public static void CopyingInfo(WorkPC workPC, Storage[] storage)
        {
            WriteLine(" До копирования:\n" + workPC);
            Design.Line();

            if (storage.Length == 0)    // если нет носителей.
            {
                Design.Blue();
                WriteLine(" --> Нет носителей на которые можно скопировать информацию.");
                Design.Default();
                return;
            }
            else if (FileIsPlaced(workPC.FileSize, storage))    // если файл вмещаеться.
            {
                Design.Green();
                WriteLine(" >> Копирование.");
                Design.Default();
            }
            else
            {
                Design.Blue();
                WriteLine(" --> Файлы не вмещаються на данные носители.");
                Design.Default();
                return;
            }
           
            // Копирование.
            while (workPC.TotalSizeOfFiles != 0)
            {
                foreach (Storage item in storage)
                {
                    item.CopyingDataToTheDevice(workPC);

                    // После каждого копирования на носитель, нужно скачать
                    // с него записанную информацию:
                    // имитируем скачивание приравниванием к "0".
                    item.BusyMemory = 0;    // освободили носитель.

                    // Если все скопировали.
                    if (workPC.TotalSizeOfFiles == 0)
                    {
                        break;
                    }
                }

                if (workPC.TotalSizeOfFiles < 0)
                {
                    throw new DownloadMoreThanExistsException();
                }
            }

            // Файлов на пк больше нет - значит размер файла можно приравнять к 0.
            // (P.S. Соответственно на носителе в переменной можно хранить размер одного файла).
            workPC.FileSize = 0;
            
            WriteLine("\n После копирования:\n" + workPC);
            Design.Line();
        }



        // Расчет времени необходимого для копирования.
        public static void CopyTime(WorkPC workPC, Storage[] storage)
        {
            int recordingTime = 0;
            int readingTime = 0;
            int files;
            int totalSizeOfFiles = workPC.TotalSizeOfFiles;

            if (storage.Length == 0)    // если нет носителей.
            {
                Design.Blue();
                WriteLine(" --> Время рассчитать невозможно.");
                WriteLine(" --> Нет носителей на которые можно скопировать информацию.");
                Design.Default();
                return;
            }
            else if (!FileIsPlaced(workPC.FileSize, storage))
            {
                Design.Blue();
                WriteLine(" --> Файлы не вмещаються на данные носители.");
                Design.Default();
                return;
            }

            // Пока не посчитаем время копирования всех файлов.
            while (totalSizeOfFiles != 0)
            {

                foreach (Storage item in storage)
                {
                    files = item.PlacedFiles(workPC.FileSize);

                    // Если файлов осталось меньше чем вмещаеться на носитель.
                    if ((totalSizeOfFiles / workPC.FileSize) < files)
                    {
                        // то запомним сколько осталось файлов.
                        files = totalSizeOfFiles / workPC.FileSize;
                    }

                    // Если кол-во файлов = 0,
                    // то переходим к следующему носителю.
                    if (files == 0)
                    {
                        continue;
                    }
                    recordingTime += ((workPC.FileSize * files) * 1024) / item.RecordingTime();
                    readingTime += ((workPC.FileSize * files) * 1024) / item.ReadingTime();
                    // Отнимаем от общего размера, размер вмещающихся файлов.
                    totalSizeOfFiles =
                        totalSizeOfFiles - (workPC.FileSize * files);

                    if (totalSizeOfFiles == 0)
                    {
                        break;
                    }
                }

                if (totalSizeOfFiles < 0)
                {
                    throw new DownloadMoreThanExistsException();
                }

            }

            WriteLine($" Время копирования на носители: {recordingTime} мин");
            WriteLine($" Время чтения с носителей: {readingTime} мин");
            WriteLine(" Общее время копирования на другой пк: "
                + $"{recordingTime + readingTime} мин");

        }



        // Расчет необходимого количества носителей информации
        // представленных типов для переноса информации.
        public static void NumberOfStorage(WorkPC workPC, Storage[] storage)
        {
            int totalSizeOfFiles = workPC.TotalSizeOfFiles;
            int files;
            int[] arr = new int[storage.Length];

            if (storage.Length == 0)    // если нет носителей.
            {
                Design.Blue();
                WriteLine(" --> Необходимое количество рассчитать невозможно.");
                WriteLine(" --> Нет носителей на которые можно скопировать информацию.");
                Design.Default();
                return;
            }
            else if (!FileIsPlaced(workPC.FileSize, storage))
            {
                Design.Blue();
                WriteLine(" --> Файлы не вмещаються на данные носители.");
                Design.Default();
                return;
            }
   
            while (totalSizeOfFiles != 0) {
                for (int i = 0; i < storage.Length; i++)
                {

                    // Узнаем кол-во файлов вмещающихся на носитель.
                    files = storage[i].PlacedFiles(workPC.FileSize);

                    // Если файлов осталось меньше чем вмещаеться на носитель.
                    if ((totalSizeOfFiles / workPC.FileSize) < files)
                    {
                        // то запомним сколько осталось файлов.
                        files = totalSizeOfFiles / workPC.FileSize;
                    }

                    // Если кол-во файлов = 0,
                    // то переходим к следующему носителю.
                    if (files == 0)
                    {
                        continue;
                    }
                    // Отнимаем от общего размера, размер вмещающихся файлов.
                    totalSizeOfFiles =
                        totalSizeOfFiles - (workPC.FileSize * files);

                    // Если вмещается больше чем 0 файлов.
                    if (files > 0)
                    {
                        arr[i]++;
                    }

                    if (totalSizeOfFiles == 0)
                    {
                        break;
                    }
                }

                if (totalSizeOfFiles < 0)
                {
                    throw new DownloadMoreThanExistsException();
                }

            }

            for (int i = 0; i < storage.Length; i++)
            {
                WriteLine($" Количество {storage[i].Name}: {arr[i]}");
            }

        }



        // Файл вмещаеться на один из носителей.
        public static bool FileIsPlaced(int fileSize, Storage[] storage)
        {
            foreach (Storage item in storage)
            {
                // Если файл не влазит.
                if (item.PlacedFiles(fileSize) == 0)
                {
                    continue;   // проверяем след. носитель.
                }
                else
                {
                    return true;
                }
            }
            return false;   // файл не влез ни на один носитель.
        }



    }
}