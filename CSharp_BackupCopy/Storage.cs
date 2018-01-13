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
        //protected string _name;
        //protected string _model;
        //protected string Name { get; set; } // TODO public
        //protected string Model { get; set; }    // TODO public
        public string Name { get; set; }
        public string Model { get; set; }
        public int BusyMemory { get; set; }
        //public int FreeMemory { get; set; }   // TODO delete

        public Storage(string name, string model)
        {
            Name = name;
            Model = model;
        }

        // Получение объема памяти на носителе (max).
        public abstract int GettingTheAmountOfMemory();    // TODO int !?
        public abstract void CopyingDataToTheDevice(WorkPC workPC); // TODO bool "from из" или на
        public abstract int FreeMemoryOnTheDevice();   // TODO int !?
        public abstract void GettingFullInformationAboutTheDevice();

        public override string ToString()
        {
            return $" Name: {Name}\n Model: {Model}";
        }

        public abstract int PlacedFiles(int fileSize);

        //public abstract int Time_MB_m();

        public abstract int RecordingTime();
        public abstract int ReadingTime();
    }


    class Flash : Storage
    {
        int _speed_USB_3;   // TODO свойство !?
        //public int Speed_USB_3 { get; set; }
        int _memory;        // TODO свойство !?

        

        public Flash(string name, string model) : base(name, model) {}
        public Flash(string name, string model, int speed) : base(name, model)
        {
            _speed_USB_3 = speed;
        }
        public Flash(string name, string model, int speed, int memory) : base(name, model)
        {
            _speed_USB_3 = speed;
            _memory = memory;
            BusyMemory = 0;
            //FreeMemory = _memory;     // TODO delete
        }

        // Получение объема памяти на носителе (max).
        public override int GettingTheAmountOfMemory()
        {
            return _memory;
        }
        // Копирование данных(файлов/папок) на устройство.
        public override void CopyingDataToTheDevice(WorkPC workPc) // передаю файлы
        {
            // Узнаем сколько файлов вмещается на флешку.
            //int numberOfFiles = _memory / workPc.FileSize;
            int numberOfFiles = PlacedFiles(workPc.FileSize);

            //Write($" Копирование: ");

            for (int i = 0; i < numberOfFiles; i++)
            {
                Write("#");

                BusyMemory += workPc.FileSize;
                workPc.TotalSizeOfFiles -= workPc.FileSize;
            }
        }
        // Получение информации о свободном объеме памяти на устройстве.
        public override int FreeMemoryOnTheDevice()
        {
            return _memory - BusyMemory;
        }
        // Получение общей/полной информации об устройстве.
        public override void GettingFullInformationAboutTheDevice()
        {
            WriteLine(this);
            WriteLine($"\n Busy memory: {BusyMemory} Gb" + 
                $"\n Free memory: {FreeMemoryOnTheDevice()} Gb");  
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\n Speed: {_speed_USB_3} Mb/s\n Memory: {_memory} Gb";
        }
        // TODO использоваь вместо files !!!
        public override int PlacedFiles(int fileSize)
        {
            return _memory / fileSize;
        }

        //public override int Time_MB_m()
        //{
        //    return _speed_USB_3 * 60;
        //}
        public override int RecordingTime()
        {
            return _speed_USB_3 * 60;
        }
        public override int ReadingTime()
        {
            return _speed_USB_3 * 60;
        }

    }
}
