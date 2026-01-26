using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

public class Images
{
    public Images()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string SaveImage(string img, string folderName)
    {
        if (!string.IsNullOrEmpty(img))
        {
            var path = HttpContext.Current.Server.MapPath("~/Content/photos/" + folderName + "/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            string pic = Guid.NewGuid() + ".jpg";
            byte[] imageBytes = Convert.FromBase64String(img);

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);

            image.Save(path + pic);
            return "/Content/photos/" + folderName + "/" + pic;
        }
        else
            return null;
    }

    static System.Drawing.Image img;
    public static void Resize(string imgOpen, string imgSave, int width, int height)
    {
        img = System.Drawing.Image.FromFile(imgOpen);
        Bitmap b = new Bitmap(width, height);
        Graphics g = Graphics.FromImage((System.Drawing.Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        g.DrawImage(img, 0, 0, width, height);
        g.Dispose();
        img = (System.Drawing.Image)b;


        //Save Imgage
        string path = imgSave;
        Bitmap bImg = new Bitmap(img);
        long quality = 85L;

        EncoderParameter qualityParam =
            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

        // Jpeg image codec
        ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

        if (jpegCodec == null)
            return;

        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        img.Save(path, jpegCodec, encoderParams);
    }
    public static void Resize(System.Drawing.Image img, string imgSave, int width, int height)
    {
        Bitmap b = new Bitmap(width, height);
        Graphics g = Graphics.FromImage((System.Drawing.Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        g.DrawImage(img, 0, 0, width, height);
        g.Dispose();
        img = (System.Drawing.Image)b;


        //Save Imgage
        string path = imgSave;
        Bitmap bImg = new Bitmap(img);
        long quality = 85L;

        EncoderParameter qualityParam =
            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

        // Jpeg image codec
        ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

        if (jpegCodec == null)
            return;

        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        img.Save(path, jpegCodec, encoderParams);
    }
    private static ImageCodecInfo getEncoderInfo(string mimeType)
    {
        // Get image codecs for all image formats
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        // Find the correct image codec
        for (int i = 0; i < codecs.Length; i++)
            if (codecs[i].MimeType == mimeType)
                return codecs[i];
        return null;
    }
}