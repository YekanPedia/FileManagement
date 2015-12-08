

namespace YekanPedia.FileManagement.Proxy.Extension
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;

    public static class ImageCropper
    {
        public static bool Crop(string _img, string img, int width, int height, int x, int y)
        {
            try
            {
                using (Image OriginalImage = Image.FromFile(_img))
                {
                    using (Bitmap bmp = new Bitmap(width, height))
                    {
                        bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);
                        using (Graphics Graphic = Graphics.FromImage(bmp))
                        {
                            Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Graphic.DrawImage(OriginalImage, new Rectangle(0, 0, width, height), x, y, width, height, GraphicsUnit.Pixel);
                            MemoryStream ms = new MemoryStream();
                            bmp.Save(ms, OriginalImage.RawFormat);
                            if (File.Exists(img))
                                File.Delete(img);
                            File.WriteAllBytes(img, ms.GetBuffer());
                            return true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}