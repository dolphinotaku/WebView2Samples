using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_GettingStarted
{

    public class DocPreview
    {
        public MemoryStream MemoryStream { get; set; }
        public byte[] ByteArray { get; set; }
        public bool isSupportedImage { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public DocPreview()
        {

        }
    }
}
