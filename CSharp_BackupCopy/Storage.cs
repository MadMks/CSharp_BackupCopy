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
        }

        // Получение объема памяти на носителе (max).
        public abstract int GettingTheAmountOfMemory();
        public abstract void CopyingDataToTheDevice(WorkPC workPC);
        public abstract int FreeMemoryOnTheDevice();
        public abstract void GettingFullInformationAboutTheDevice();

        public override string ToString()
        {
            return $" Name: {Name}\n Model: {Model}";
        }

        public abstract int PlacedFiles(int fileSize);

        public abstract int RecordingTime();
        public abstract int ReadingTime();

        public abstract Storage Add();
    }



    class Flash : Storage
    {
        private int _speed_USB_3;   // TODO свойство !?
        //public int Speed_USB_3 { get; set; }
        private int _memory;        // TODO свойство !?

        public Flash() { }
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
            int numberOfFiles = PlacedFiles(workPc.FileSize);

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

        public override int RecordingTime()
        {
            return _speed_USB_3 * 60;
        }
        public override int ReadingTime()
        {
            return _speed_USB_3 * 60;
        }


        //public static Storage Add()
        //{
        //    string name;
        //    string model;
        //    int speed;
        //    int memory;

        //    Write(" Введите название: ");
        //    name = ReadLine();
        //    Write(" Введите модель: ");
        //    model = ReadLine();
        //    Write(" Введите скорость (чтения/записи): ");
        //    speed = Convert.ToInt32(ReadLine());
        //    Write(" Введите объем памяти: ");
        //    memory = Convert.ToInt32(ReadLine());

        //    return new Flash(name, model, speed, memory);
        //}

        public override Storage Add()
        {
            string name;
            string model;
            int speed;
            int memory;

            Write(" Введите название: ");
            name = ReadLine();
            Write(" Введите модель: ");
            model = ReadLine();
            Write(" Введите скорость (чтения/записи): ");
            speed = Convert.ToInt32(ReadLine());
            Write(" Введите объем памяти: ");
            memory = Convert.ToInt32(ReadLine());

            return new Flash(name, model, speed, memory);
        }
    }
}
