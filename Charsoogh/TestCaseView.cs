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
            foreach (string file in Directory.GetFiles(directory))
            {
                resultPanel.Controls.Add(new PictureBox() { ImageLocation = file, Dock = DockStyle.Top, SizeMode = PictureBoxSizeMode.Zoom, Height = 210 });
            }
            userCheckBox.Checked = userDecision;
            expectedCheckbox.Checked = expected;
        }
    }
}
