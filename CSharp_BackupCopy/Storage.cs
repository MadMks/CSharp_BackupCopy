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

        public Storage() : this("no name", "no model") { }  // TODO Busy
        public Storage(string name, string model)   // TODO Busy
        {
            Name = name;
            Model = model;
            BusyMemory = 0; // TODO check правильная ли последовательность запуска!?
        }

        // Получение объема памяти на носителе (max).
        public abstract double GettingTheAmountOfMemory();
        public abstract void CopyingDataToTheDevice(WorkPC workPC);
        public abstract double FreeMemoryOnTheDevice();
        public abstract void GettingFullInformationAboutTheDevice();

        public override string ToString()
        {
            return $" Название: {Name}\n Модель: {Model}";
        }

        public abstract int PlacedFiles(int fileSize);

        public abstract int RecordingTime();
        public abstract int ReadingTime();

        public abstract Storage Add();
    }



}
