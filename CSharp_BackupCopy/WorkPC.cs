using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    class WorkPC    // TODO хранить инфо на Storage
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

    class User
    {
        Storage[] _storage;

        public User()
        {
            _storage = new Storage[0];
        }

        public void AddStorage(Storage storage)
        {
            Array.Resize(ref _storage, _storage.Length + 1);
            _storage[_storage.Length - 1] = storage;
        }
    }
}
