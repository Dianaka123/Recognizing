using RecognizeClass.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RecognizeClass.Processing
{
    public class RecognitionRoutines
    {
        public static char? TryRecognizeClassDistance(Bitmap bitmap, IDictionary<char, IList<RecognitionInfo>> recognitionInfos, IList<Zond> zonds)
        {
            IDictionary<Zond, int> zondsCrossCount = GetCrossCount(bitmap, zonds);

            double minDistance = double.MaxValue;
            char? result = default;

            foreach (KeyValuePair<char, IList<RecognitionInfo>> dictionaryPair in recognitionInfos)
            {
                IList<RecognitionInfo> infos = dictionaryPair.Value;
                double squaredDistance = zonds.Sum(zond =>
                {
                    int crossCount = zondsCrossCount[zond];
                    double average = infos.Average(info => info.ZondCrossDictionary[zond]);
                    double diff = average - crossCount;
                    return diff * diff;
                });
                double distance = Math.Sqrt(squaredDistance);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    result = dictionaryPair.Key;
                }
            }

            return result;
        }


        public static char? TryRecognizeClass(Bitmap bitmap, IDictionary<char, IList<RecognitionInfo>> recognitionInfos, IEnumerable<Zond> zonds)
        {
            IDictionary<Zond, int> zondsCrossCount = GetCrossCount(bitmap, zonds);
            
            foreach (KeyValuePair<char, IList<RecognitionInfo>> dictionaryPair in recognitionInfos)
            {
                foreach (RecognitionInfo recognitionInfo in dictionaryPair.Value)
                {
                    foreach (Zond zond in zonds)
                    {
                        int crossCount = zondsCrossCount[zond];
                        int expectedCrossCount = recognitionInfo.ZondCrossDictionary[zond];
                        if (crossCount != expectedCrossCount)
                        {
                            goto ClassLoopEnd;
                        }
                    }
                    return dictionaryPair.Key;
                }
                ClassLoopEnd:;
            }
            return null;
        }

        public static RecognitionInfo GetClassInfo(Bitmap bitmap, char predefinedClass, IEnumerable<Zond> zonds)
        {
            IDictionary<Zond, int> zondsCrossCount = GetCrossCount(bitmap, zonds);
            return new RecognitionInfo
            { 
                Class = predefinedClass,
                ZondCrossDictionary = zondsCrossCount
            };
        }

        public static IDictionary<Zond, int> GetCrossCount(Bitmap bitmap, IEnumerable<Zond> zonds)
        {
            PointF ConvertToAbsolute(PointF point) => 
                new PointF(point.X * (bitmap.Width - 1), point.Y * (bitmap.Height - 1));

            var result = new Dictionary<Zond, int>();
            foreach (Zond zond in zonds)
            {
                PointF absoluteStartPoint = ConvertToAbsolute(zond.StartPoint);
                PointF absoluteEndPoint = ConvertToAbsolute(zond.EndPoint);

                float diffX = absoluteEndPoint.X - absoluteStartPoint.X;
                float diffY = absoluteEndPoint.Y - absoluteStartPoint.Y;
                float length = (float)Math.Sqrt(diffX * diffX + diffY * diffY);
                int stepCount = (int)Math.Ceiling(length);

                float stepX = diffX / stepCount;
                float stepY = diffY / stepCount;

                int counter = 0;
                bool isIn = false;
                for (int i = 0; i < stepCount; i++)
                {
                    int x = (int)(absoluteStartPoint.X + stepX * i);
                    int y = (int)(absoluteStartPoint.Y + stepY * i);
                    Color color = bitmap.GetPixel(x, y);
                    float brightness = color.GetBrightness();
                    if (isIn && brightness > 0.5f)
                    {
                        isIn = false;
                    } else if (!isIn && brightness <= 0.5f)
                    {
                        isIn = true;
                        counter++;
                    }
                }
                result.Add(zond, counter);
            }
            return result;
        }
    }
}
