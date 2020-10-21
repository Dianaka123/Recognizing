using RecognizeClass.Data;
using System.Collections.Generic;
using System.Drawing;

namespace RecognizeClass.Processing
{
    public class DrawingRoutines
    {
        public static Bitmap DrawZonds(Bitmap bitmap, IEnumerable<Zond> zonds)
        {
            Point ConvertToAbsolute(PointF point) =>
                new Point((int)(point.X * bitmap.Width), (int)(point.Y * bitmap.Height));

            var result = new Bitmap(bitmap);
            using Graphics graphics = Graphics.FromImage(result);
            using Pen pen = new Pen(Color.Red, 1f);
            foreach (Zond zond in zonds)
            {
                PointF absoluteStartPoint = ConvertToAbsolute(zond.StartPoint);
                PointF absoluteEndPoint = ConvertToAbsolute(zond.EndPoint);
                graphics.DrawLine(pen, absoluteStartPoint, absoluteEndPoint);
            }
            return result;
        }
    }
}
