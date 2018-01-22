using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{


    class HDD : Storage
    {
        private int _speed_USB_2;
        private int _numberOfPartitions;    // кол-во разделов.
        private int _sizeOfPartitions;      // объем разделов.

        public HDD() { }
        public HDD(string name, string model) : base(name, model) { }
        public HDD(string name, string model, int speed, int numbPart, int sizePart)
            : base(name, model)
        {
            _speed_USB_2 = speed;
            _numberOfPartitions = numbPart;
            _sizeOfPartitions = sizePart;
        }

        public override double GettingTheAmountOfMemory()
        {
            return _numberOfPartitions * _sizeOfPartitions; // нет потери данных.
        }

        public override void CopyingDataToTheDevice(WorkPC workPC)
        {
            int numberOfFiles = PlacedFiles(workPC.FileSize);

            for (int i = 0; i < numberOfFiles; i++)
            {
                BusyMemory += workPC.FileSize;
                workPC.TotalSizeOfFiles -= workPC.FileSize;

                // Если файлов больше нет.
                if (workPC.TotalSizeOfFiles == 0)
                {
                    return;
                }
            }
        }

        public override double FreeMemoryOnTheDevice()
        {
            return GettingTheAmountOfMemory() - BusyMemory; // нет потери данных.
        }

        public override void GettingFullInformationAboutTheDevice()
        {
            WriteLine(this);
            WriteLine($" Занято: {BusyMemory} Gb" +
                $"\n Свободно: {FreeMemoryOnTheDevice()} Gb");
        }

        public override int PlacedFiles(int fileSize)   // на все разделы.
        {
            return (_sizeOfPartitions / fileSize) * _numberOfPartitions;
        }

        public override int RecordingTime()
        {
            return _speed_USB_2 * 60;
        }

        public override int ReadingTime()
        {
            return _speed_USB_2 * 60;
        }

        public override Storage Add()
        {
            string name;
            string model;
            int speed;
            int numberPartition;
            int sizePartition;

            Write(" Введите название: ");
            name = ReadLine();
            Write(" Введите модель: ");
            model = ReadLine();
            Write(" Введите скорость (чтения/записи): ");
            speed = Convert.ToInt32(ReadLine());
            Write(" Введите кол-во разделов: ");
            numberPartition = Convert.ToInt32(ReadLine());
            Write(" Введите объем одного раздела: ");
            sizePartition = Convert.ToInt32(ReadLine());

            return new HDD(name, model, speed, numberPartition, sizePartition);
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\n Скорость (чтения/записи): {_speed_USB_2} Mb/s"
                + $"\n Кол-во разделов: {_numberOfPartitions} шт"
                + $"\n Объем разделов: {_sizeOfPartitions} Gb";
        }



    }
}