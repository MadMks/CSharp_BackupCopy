using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    class Flash : Storage
    {
        private int _speed_USB_3;
        private int _memory;

        public Flash() { }
        public Flash(string name, string model) : base(name, model) { }
        public Flash(string name, string model, int speed, int memory) : base(name, model)
        {
            _speed_USB_3 = speed;
            _memory = memory;
        }


        public override double GettingTheAmountOfMemory()
        {
            return _memory; // нет потери данных.
        }
        
        public override void CopyingDataToTheDevice(WorkPC workPc)
        {
            // Узнаем сколько файлов вмещается на флешку.
            int numberOfFiles = PlacedFiles(workPc.FileSize);

            for (int i = 0; i < numberOfFiles; i++)
            {
                BusyMemory += workPc.FileSize;
                workPc.TotalSizeOfFiles -= workPc.FileSize;

                // Если файлов больше нет.
                if (workPc.TotalSizeOfFiles == 0)
                {
                    return;
                }
            }
        }
        
        public override double FreeMemoryOnTheDevice()
        {
            return _memory - BusyMemory;    // нет потери данных.
        }
        
        public override void GettingFullInformationAboutTheDevice()
        {
            WriteLine(this);
            WriteLine($" Занято: {BusyMemory} Gb" +
                $"\n Свободно: {FreeMemoryOnTheDevice()} Gb");
        }


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

        public override string ToString()
        {
            return base.ToString() +
                $"\n Скорость: {_speed_USB_3} Mb/s\n Объем памяти: {_memory} Gb";
        }



    }
}