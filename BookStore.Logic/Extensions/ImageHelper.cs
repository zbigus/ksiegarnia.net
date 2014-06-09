using System.Drawing;
using System.IO;

namespace BookStore.Logic.Extensions
{
    public class ImageHelper
    {
        public static byte[] ImageToByte(Image img)
        {
            byte[] byteArray;
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static byte[] GetSimpleImage()
        {
            var bookAtt = Properties.Resources.ebook_gray_book;
            var attArray = ImageToByte(bookAtt);
            return attArray;
        }
    }
}
