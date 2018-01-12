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

        public WorkPC()
        {
            TotalSizeOfFiles = 10;
            FileSize = 5;
        }

        public override string ToString()
        {
            return $" Total size of files on the working pc: {TotalSizeOfFiles}";
        }
    }
}
