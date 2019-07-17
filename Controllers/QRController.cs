using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

public class QRController : Controller
{
    public ActionResult Index()
    {
        QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("Encode edilecek metin", QRCoder.QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        
        var bitmapBytes = BitmapToBytes(qrCodeImage);
        return File(bitmapBytes, "image/jpeg");
    }

    private static byte[] BitmapToBytes(Bitmap img)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}