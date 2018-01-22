using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{

    [Serializable]
    public class DownloadMoreThanExistsException : Exception
    {
        public DownloadMoreThanExistsException()
            :this(" Программа скачивает больше файлов, чем существует на ПК.\n") { }
        public DownloadMoreThanExistsException(string message)
            : base(message) { }
        public DownloadMoreThanExistsException(string message, Exception inner)
            : base(message, inner) { }
        protected DownloadMoreThanExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}