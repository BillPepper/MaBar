using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaBar
{
    public partial class MaBar : Form
    {
        private String[] programList = new string[] {
            "C:/Windows/explorer.exe",
            "C:/Windows/notepad.exe",
            "C:/Windows/HelpPane.exe",
            "C:/Windows/IsUninst.exe",
            "C:/Windows/regedit.exe",
            "C:/Windows/splwow64.exe",
            "C:/Windows/write.exe",
            "C:/Windows/explorer.exe",
            "C:/Windows/notepad.exe",
            "C:/Windows/HelpPane.exe",
            "C:/Windows/IsUninst.exe",
            "C:/Windows/regedit.exe",
            "C:/Windows/splwow64.exe",
            "C:/Windows/write.exe"
        };
        private int iconSize = 42;

        public MaBar()
        {
            InitializeComponent();
            // setIcon();
            createButtons();
            this.Size = new System.Drawing.Size(programList.Length * iconSize, iconSize);
        }
        
        private void setIcon(int button, string path)
        {
            Icon ic = Icon.ExtractAssociatedIcon("C:/Windows/notepad.exe");
            //this.btn_one.Image = bla.ToBitmap();
        }

        private void createButtons()
        {
            for (int i = 0; i < programList.Length; i++)
            {
                PictureBox pb = new PictureBox();
                Point pos = new System.Drawing.Point(i * iconSize, 0);
                pb.Location = pos;
                pb.Name = "btn_" + i;
                pb.Size = new System.Drawing.Size(iconSize, iconSize);
                pb.Image = Icon.ExtractAssociatedIcon(programList[i]).ToBitmap();
                pb.BackColor = Color.Pink;
                pb.SizeMode = PictureBoxSizeMode.CenterImage;
                pb.Click += new System.EventHandler(this.test);
                this.Controls.Add(pb);
            }
        }



        private void test(object sender, EventArgs e)
        {
            Console.WriteLine("obj" + sender);
        }
    }
}
