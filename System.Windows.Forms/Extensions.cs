using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Windows.Forms
{
    public static class Extensions
    {
        public static void SafeDrawString(this Graphics dc, string s,
            Font font,
            Brush brush,
            RectangleF layoutRectangle,
            StringFormat format)
        {
            var text = s;

            if (!RuntimeInformation.IsOSPlatform((OSPlatform.Windows)))
            {
                text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(s));
            }
            
            dc.DrawString (text, font,
                brush,
                layoutRectangle, format);
        }

        public static void SafeDrawString(this Graphics dc, string s, Font font, Brush brush, RectangleF layoutRectangle)
        {
            var text = s;

            if (!RuntimeInformation.IsOSPlatform((OSPlatform.Windows)))
            {
                text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(s));
            }

            dc.DrawString(text, font,
                brush,
                layoutRectangle);
        }

        public static void SafeDrawString(this Graphics dc, string s, Font font, Brush brush, PointF point, StringFormat format)
        {
            var text = s;

            if (!RuntimeInformation.IsOSPlatform((OSPlatform.Windows)))
            {
                text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(s));
            }

            dc.DrawString(text, font,
                brush,
                point, format);
        }

        public static void SafeDrawString(this Graphics dc, string s, Font font, Brush brush, PointF point)
        {
            var text = s;

            if (!RuntimeInformation.IsOSPlatform((OSPlatform.Windows)))
            {
                text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(s));
            }

            dc.DrawString(text, font,
                brush,
                point);
        }

        public static void SafeDrawString(this Graphics dc, string s, Font font, Brush brush, float x, float y, StringFormat format)
        {
            var text = s;

            if (!RuntimeInformation.IsOSPlatform((OSPlatform.Windows)))
            {
                text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(s));
            }

            dc.DrawString(text, font,
                brush,
                x, y, format);
        }

        public static void SafeDrawString(this Graphics dc, string s, Font font, Brush brush, float x, float y)
        {
            var text = s;

            if (!RuntimeInformation.IsOSPlatform((OSPlatform.Windows)))
            {
                text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(s));
            }

            dc.DrawString(text, font,
                brush,
                x, y);
        }
    }
}