using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace Charsoogh
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            Stopwatch watch = new Stopwatch();
            ImageProcessor.Output = new List<List<ImageProcessor.Image>>();
            List<ImageProcessor.Image> input = new List<ImageProcessor.Image>();
            List<bool> answer = new List<bool>();
            StreamReader reader = new StreamReader("config.txt");
            int lowTime = Convert.ToInt32(reader.ReadLine());
            int highTime = Convert.ToInt32(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                Bitmap bitmap = new Bitmap(/*Path.GetDirectoryName(Application.ExecutablePath) + "\\" + */reader.ReadLine());
                ImageProcessor.Image image = new ImageProcessor.Image() { UnmanagedImage = AForge.Imaging.UnmanagedImage.FromManagedImage(bitmap) };
                answer.Add ( Convert.ToBoolean(reader.ReadLine()));
                input.Add(image);
            }
            Shuffle(input, answer);
            watch.Start(); 
            List<bool> result = ImageProcessor.Process(input, answer);
            watch.Stop();
            string dir = DateTime.Now.ToString("hhmmss");
            Directory.CreateDirectory(dir);
            int dir_counter = 0;
            foreach (List<ImageProcessor.Image> images in ImageProcessor.Output)
            {
                Directory.CreateDirectory(Path.Combine(dir, dir_counter.ToString()));
                int file_counter = 0;
                foreach (ImageProcessor.Image image in images)
                {
                    image.UnmanagedImage.ToManagedImage().Save(Path.Combine(dir, dir_counter.ToString(), file_counter.ToString() + ".png"));
                    file_counter++;
                }
                dir_counter++;
            }
            long millis = watch.ElapsedMilliseconds;
            timeLabel.Text = watch.ElapsedMilliseconds.ToString();
            int counter = 0;
            int correct = 0;
            foreach (bool res in result)
            {
                horizontalPanel.Controls.Add(new TestCaseView(Path.Combine(dir, counter.ToString()), answer[counter], res) { Dock = DockStyle.Left });
                if (res == answer[counter])
                {
                    correct++;
                }
                counter++;
            }
            accuracyLabel.Text = (correct * 100 / answer.Count).ToString();
            scoreLabel.Text = Math.Max(0, ((8 * Math.Max(0, (correct - (float)answer.Count/2)) / ((float)answer.Count / 2)) - 2 * (Math.Min(Math.Max(millis, lowTime), highTime) - lowTime) / (float)400)).ToString();
            reader.Close();
        }

        private void Shuffle(List<ImageProcessor.Image> input, List<bool> answers)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < input.Count; i++)
            {
                bool tempb = answers[i];
                ImageProcessor.Image temp = input[i];
                input.RemoveAt(i);
                answers.RemoveAt(i);
                int index = rand.Next(0, input.Count);
                input.Insert(index, temp);
                answers.Insert(index, tempb);
            }
        }
    }
}
