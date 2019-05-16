using System.IO;
using System.Linq;

namespace Vega.Common
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsAcceptedFileType(string fileName) {
            return AcceptedFileTypes.Contains(Path.GetExtension(fileName).ToLower());
        }
    }
}