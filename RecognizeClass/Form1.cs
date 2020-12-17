using RecognizeClass.Data;
using RecognizeClass.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RecognizeClass
{
    public partial class Form1 : Form
    {
        private static readonly Zond[] Zonds = new[] {
            new Zond { StartPoint = new PointF(0.5f, 0f), EndPoint = new PointF(0.5f, 1f) },
            new Zond { StartPoint = new PointF(0.3f, 0.6f), EndPoint = new PointF(1f, 0.6f) }
        };

        private static readonly Color[] Colors = new Color[]
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow,
            Color.Aqua
        };

        private static readonly Dictionary<char, IList<RecognitionInfo>> RecognitionDictionary = 
            new Dictionary<char, IList<RecognitionInfo>>();

        public Form1()
        {    
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ImageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using Bitmap openedBitmap = Bitmap.FromFile(ImageOpenFileDialog.FileName) as Bitmap;
                RecognitionPictureBox.Image = DrawingRoutines.DrawZonds(openedBitmap, Zonds);

                char? recognitionResult = RecognitionRoutines.TryRecognizeClassDistance(openedBitmap, RecognitionDictionary, Zonds);
                RecognitionResultLabel.Text = recognitionResult.HasValue ? 
                    recognitionResult.Value.ToString() : string.Empty;

                var crossCount = RecognitionRoutines.GetCrossCount(openedBitmap, Zonds);
                UpdateChart(chart2, (crossCount[Zonds[0]], crossCount[Zonds[1]], recognitionResult.Value));
            }
        }

        private void UpdateChart(Chart chart, (int x, int y, char resultClass)? additional = null)
        {
            chart.Series.Clear();

            var classSeries = new Dictionary<char, (double x, double y)>();
                
            int index = 0;
            foreach (KeyValuePair<char, IList<RecognitionInfo>> pair in RecognitionDictionary)
            {
                IList<RecognitionInfo> infos = pair.Value;

                var x = infos.Average(info => info.ZondCrossDictionary[Zonds[0]]);
                var y = infos.Average(info => info.ZondCrossDictionary[Zonds[1]]);

                var series = new Series();
                series.ChartType = SeriesChartType.Bubble;
                series.MarkerSize = 8;
                series.Points.AddXY(x, y);
                series.LegendText = pair.Key.ToString();

                chart.Series.Add(series);

                classSeries.Add(pair.Key, (x, y));

                index++;
            }

            if (additional.HasValue)
            {
                var value = additional.Value;

                var markerSeries = new Series();
                markerSeries.ChartType = SeriesChartType.Bubble;
                markerSeries.MarkerSize = 25;
                markerSeries.Points.AddXY(value.x, value.y);
                markerSeries.Color = Color.Black;
                markerSeries.LegendText = "New";
                markerSeries.MarkerStyle = MarkerStyle.Star5;
                chart.Series.Add(markerSeries);

                var data = classSeries[value.resultClass];

                var lineSeries = new Series();
                lineSeries.ChartType = SeriesChartType.Line;
                lineSeries.Points.AddXY(value.x, value.y);
                lineSeries.Points.AddXY(data.x, data.y);
                lineSeries.BorderWidth = 3;
                lineSeries.LegendText = "line";
                lineSeries.Color = Color.Black;
                chart.Series.Add(lineSeries);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 1)
            {
                return;
            }
            if (ImageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using Bitmap openedBitmap = Bitmap.FromFile(ImageOpenFileDialog.FileName) as Bitmap;
                LearningPictureBox.Image = DrawingRoutines.DrawZonds(openedBitmap, Zonds);

                char className = textBox1.Text[0];
                RecognitionInfo recognitionInfo = RecognitionRoutines.GetClassInfo(openedBitmap, className, Zonds);
                if (RecognitionDictionary.TryGetValue(className, out IList<RecognitionInfo> infoList)) 
                {
                    infoList.Add(recognitionInfo);
                } else
                {
                    RecognitionDictionary.Add(className, new List<RecognitionInfo> { recognitionInfo });
                }
                ResetClassInfoGrid();

                UpdateChart(chart1);
            }
        }

        private void ResetClassInfoGrid()
        {
            var stringBuilder = new StringBuilder();
            foreach (KeyValuePair<char, IList<RecognitionInfo>> pair in RecognitionDictionary)
            {
                foreach (RecognitionInfo recognitionInfo in pair.Value)
                {
                    stringBuilder.AppendLine($"Class name: {recognitionInfo.Class}:");

                    int zondIndex = 0;
                    foreach (KeyValuePair<Zond, int> zondInfo in recognitionInfo.ZondCrossDictionary)
                    {
                        stringBuilder.AppendLine($"\tZond {zondIndex}. Cross count: {zondInfo.Value}.");
                        zondIndex++;
                    }
                    stringBuilder.AppendLine();
                }
            }
            richTextBox1.Text = stringBuilder.ToString();
        }
    }
}
