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
        private int _diskType;

        public DVD() { }
        public DVD(string name, string model) : base(name, model) { }
        public DVD(string name, string model, int speedRead, int speedRec, int diskType) 
            : base(name, model)
        {
            _speedReading = speedRead;
            _speedRecord = speedRec;
            _diskType = diskType;
        }

        public override int GettingTheAmountOfMemory()
        {
            return _diskType;
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

        public override int FreeMemoryOnTheDevice()
        {
            return _diskType - BusyMemory;
        }

        public override void GettingFullInformationAboutTheDevice()
        {
            WriteLine(this);
            WriteLine($" Занято: {BusyMemory} Gb" +
                $"\n Свободно: {FreeMemoryOnTheDevice()} Gb");
        }

        public override int PlacedFiles(int fileSize)
        {
            throw new NotImplementedException();
        }

        public override int RecordingTime()
        {
            throw new NotImplementedException();
        }

        public override int ReadingTime()
        {
            throw new NotImplementedException();
        }

        public override Storage Add()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\n Скорость чтения: {_speedReading} Mb/s\n Скорость записи: {_speedRecord}" + 
                $"\n Объем памяти: {_diskType} Gb";
        }
    }
}
