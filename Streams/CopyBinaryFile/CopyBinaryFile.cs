namespace CopyBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            var imagePath = "../../totti_10.jpg";
            var destinationPath = "../../result.jpg";
            using (var source = new FileStream(imagePath, FileMode.Open))
            {
                using (var destination = new FileStream(destinationPath, FileMode.Create))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }                            
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
