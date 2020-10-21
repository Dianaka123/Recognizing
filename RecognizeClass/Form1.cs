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

namespace RecognizeClass
{
    public partial class Form1 : Form
    {
        private static readonly Zond[] Zonds = new Zond[] { 
            new Zond { StartPoint = new PointF(0.2f, 0.2f), EndPoint = new PointF(0.2f, 0.9f) },
            new Zond { StartPoint = new PointF(0.1f, 0.2f), EndPoint = new PointF(0.9f, 0.2f) }
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

                char? recognitionResult = RecognitionRoutines.TryRecognizeClass(openedBitmap, RecognitionDictionary, Zonds);
                RecognitionResultLabel.Text = recognitionResult.HasValue ? 
                    recognitionResult.Value.ToString() : string.Empty;
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
