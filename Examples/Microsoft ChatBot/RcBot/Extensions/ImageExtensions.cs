using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace RcBot.Extensions
{
    public static class ImageExtensions
    {        
        /// <summary>
        /// Lit l'image en byte
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static byte[] GetImage(this string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        /// <summary>
        /// Transforme l'objet image en bytes
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        private static Image BytesToImage(this byte[] imageBytes)
        {
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        /// <summary>
        /// Transform the url string into an scaled image (Used for thumbnail)
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Base64</returns>
        public static string TransformUrlToScaledImage(this string url)
        {
            string base64String = string.Empty;
            byte[] binaryImage = url.GetImage();
            Image image = binaryImage.BytesToImage();

            using (MemoryStream ms = new MemoryStream(binaryImage, 0, binaryImage.Length))
            {
                using (Image img = Image.FromStream(ms))
                {
                    int h = image.Height / 4;
                    int w = image.Width / 4;

                    using (Bitmap b = new Bitmap(img, new Size(w, h)))
                    {
                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            // Converti l'objet Image to byte[]
                            if(url.EndsWith("png"))
                                b.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                            else
                                b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);

                            // Converti byte[] en un string de base64
                            base64String = Convert.ToBase64String(ms2.ToArray());
                        }
                    }
                }

                
                return base64String;
            }
        }
    }
}