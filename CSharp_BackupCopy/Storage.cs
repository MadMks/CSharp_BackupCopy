using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{


    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int BusyMemory { get; set; }

        public Storage() : this("no name", "no model") { }
        public Storage(string name, string model)
        {
            Name = name;
            Model = model;
            BusyMemory = 0;
        }

        // Получение объема памяти на носителе (max).
        public abstract double GettingTheAmountOfMemory();
        // Копирование данных(файлов/папок) на устройство.
        public abstract void CopyingDataToTheDevice(WorkPC workPC);
        // Получение информации о свободном объеме памяти на устройстве.
        public abstract double FreeMemoryOnTheDevice();
        // Получение общей/полной информации об устройстве.
        public abstract void GettingFullInformationAboutTheDevice();

        public override string ToString()
        {
            return $" Название: {Name}\n Модель: {Model}";
        }
        // Вмещаеться файлов.
        public abstract int PlacedFiles(int fileSize);

        public abstract int RecordingTime();
        public abstract int ReadingTime();

        public abstract Storage Add();
    }



}