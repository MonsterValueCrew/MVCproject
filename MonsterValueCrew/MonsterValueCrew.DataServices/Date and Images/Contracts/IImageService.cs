using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace MonsterValueCrew.Services
{
    public interface IImageService
    {
        byte[] ImageToByteArray(Image imageIn);

        byte[] GetByteArrayFromStream(Stream inputStream);

        string ByteArrayToImageUrl(byte[] byteArrayIn);

        Image GetImage(string path);
    }
}