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


        public Storage(string name, string model)
        {
            Name = name;
            Model = model;
        }


        public abstract int GettingTheAmountOfMemory();    // TODO int !?
        public abstract void CopyingDataToTheDevice(WorkPC workPC);
        public abstract void FreeMemoryOnTheDevice();   // TODO int !?
        public abstract void GettingFullInformationAboutTheDevice();

        public override string ToString()
        {
            return $" Name: {Name}\n Model: {Model}";
        }
    }


    class Flash : Storage
    {
        int _speed_USB_3;   // TODO свойство !?
        int _memory;        // TODO свойство !?

        public int BusyMemory { get; set; }
        public int FreeMemory { get; set; }

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
            FreeMemory = _memory;
        }

        // Получение объема памяти.
        public override int GettingTheAmountOfMemory()
        {
            return _memory;
        }
        // Копирование данных(файлов/папок) на устройство.
        public override void CopyingDataToTheDevice(WorkPC workPc) // передаю файлы
        {
            // Узнаем сколько файлов вмещается на флешку.
            int numberOfFiles = _memory / workPc.FileSize;

            Write($" Копирование: ");

            for (int i = 0; i < numberOfFiles; i++)
            {
                WriteLine("#");

                BusyMemory += workPc.FileSize;
                workPc.TotalSizeOfFiles -= workPc.FileSize;
            }
        }
        // Получение информации о свободном объеме памяти на устройстве.
        public override void FreeMemoryOnTheDevice()
        {
            WriteLine($" Free memory: {FreeMemory} Gb");
        }
        // Получение общей/полной информации об устройстве.
        public override void GettingFullInformationAboutTheDevice()
        {
            WriteLine(this);
            WriteLine($"\n Busy memory: {BusyMemory} Gb\n Free memory: {FreeMemory} Gb");
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\n Speed: {_speed_USB_3} Mb/s\n Memory: {_memory} Gb";
        }
    }
}
