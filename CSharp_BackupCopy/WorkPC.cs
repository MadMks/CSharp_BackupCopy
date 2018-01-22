using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    class WorkPC
    {
        public int TotalSizeOfFiles { get; set; }  
        public int FileSize { get; set; }

        public WorkPC() : this(0,0) { }
        public WorkPC(int fileSize, int totalSize)
        {
            FileSize = fileSize;
            TotalSizeOfFiles = totalSize;
        }

        public override string ToString()
        {
            return $" Размер файлов на ПК: {TotalSizeOfFiles}"
                + $"\n Размер одного файла: {FileSize}";
        }
    }

}