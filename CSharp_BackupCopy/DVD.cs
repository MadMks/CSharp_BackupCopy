﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    class DVD : Storage
    {
        private int _speedReading;
        private int _speedRecord;
        // Тип: односторонний (4Гб) или двухсторонний (9Гб)
        private DiskType _diskType;
        private double _memory;

        public DVD() { }
        public DVD(string name, string model) : base(name, model) { }
        public DVD(string name, string model, int speedRead, int speedRec, DiskType diskType) 
            : base(name, model)
        {
            _speedReading = speedRead;
            _speedRecord = speedRec;
            _diskType = diskType;
            _memory = (_diskType == DiskType.eOneSide ? 4.7 : 4.7 * 2);
        }

        public override double GettingTheAmountOfMemory()
        {
            return _memory;
        }

        public override void CopyingDataToTheDevice(WorkPC workPC)
        {
            int numberOfFiles = PlacedFiles(workPC.FileSize);

            for (int i = 0; i < numberOfFiles; i++)
            {
                BusyMemory += workPC.FileSize;
                workPC.TotalSizeOfFiles -= workPC.FileSize;
            }
        }

        public override double FreeMemoryOnTheDevice()
        {
            return _memory - BusyMemory;
        }

        public override void GettingFullInformationAboutTheDevice()
        {
            WriteLine(this);
            WriteLine($" Занято: {BusyMemory} Gb" +
                $"\n Свободно: {FreeMemoryOnTheDevice()} Gb");
        }

        public override int PlacedFiles(int fileSize)
        {
            return (int)(4.7 / fileSize) * (int)_diskType;
        }

        public override int RecordingTime()
        {
            return _speedRecord * 60;
        }

        public override int ReadingTime()
        {
            return _speedReading * 60;
        }

        public override Storage Add()
        {
            string name;
            string model;
            int speedRead;
            int speedRec;
            DiskType diskType;
            int tempType;

            Write(" Введите название: ");
            name = ReadLine();
            Write(" Введите модель: ");
            model = ReadLine();
            Write(" Введите скорость (чтения): ");
            speedRead = Convert.ToInt32(ReadLine());
            Write(" Введите скорость (записи): ");
            speedRec = Convert.ToInt32(ReadLine());

            do
            {
                WriteLine(" Введите тип диска: ");
                WriteLine("  1 - 4,7 Gb\n  2 - 9,0 Gb");
                Write(" Тип: ");
                tempType = Convert.ToInt32(ReadLine());

                if (tempType < 1 || tempType > 2)
                {
                    Design.Red();
                    WriteLine("\n [err] Недопустимый тип диска." +
                        "\n - Повторите ввод!\n");
                    Design.Default();
                }   
            } while (tempType < 1 || tempType > 2);

            diskType = (DiskType)tempType;

            return new DVD(name, model, speedRead, speedRec, diskType);
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\n Скорость чтения: {_speedReading} Mb/s" 
                + $"\n Скорость записи: {_speedRecord} Mb/s"
                + $"\n Объем памяти: {_memory} Gb";
        }
    }
}