using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Charsoogh
{
    public partial class TestCaseView : UserControl
    {
        public TestCaseView()
        {
            InitializeComponent();
        }

        public TestCaseView(string directory, bool expected, bool userDecision)
        {
            InitializeComponent();
            List<string> files = new List<string>(Directory.GetFiles(directory));
            files.Sort(new Comparison<string>((string item1, string item2) => {
                return Convert.ToInt32(Path.GetFileNameWithoutExtension(item1)).CompareTo(
                    Convert.ToInt32(Path.GetFileNameWithoutExtension(item2))
                    );
                }));
            foreach (string file in files)
            {
                resultPanel.Controls.Add(new PictureBox() { ImageLocation = file, Dock = DockStyle.Top, SizeMode = PictureBoxSizeMode.Zoom, Height = 210 });
            }
            userCheckBox.Checked = userDecision;
            expectedCheckbox.Checked = expected;
        }
    }
}
