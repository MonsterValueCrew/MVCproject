using Bytes2you.Validation;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MonsterValueCrew.Services
{
    public class ImageService : IImageService
    {
        public byte[] ImageToByteArray(Image imageIn)
        {
            Guard.WhenArgument(imageIn, "imageIn").IsNull().Throw();
            //MemoryStream memoryStream = new MemoryStream();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                imageIn.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
            
        }

        public string ByteArrayToImageUrl(byte[] byteArrayIn)
        {
            Guard.WhenArgument(byteArrayIn, "byteArrayIn").IsNull().Throw();
            string base64String = Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
            string resultUrl = "data:image/jpg;base64," + base64String;
            return resultUrl;
        }

        public Image GetImage(string path)
        {
            Guard.WhenArgument(path, "path").IsNullOrEmpty().Throw();
            return Image.FromFile(path);
        }

        public byte[] GetByteArrayFromStream(Stream inputStream)
        {
            Guard.WhenArgument(inputStream, "inputStream").IsNull().Throw();
            //MemoryStream target = new MemoryStream();
            using (MemoryStream target = new MemoryStream())
            {
                inputStream.CopyTo(target);
                byte[] data = target.ToArray();
                return data;
            }
        }
    }
}
