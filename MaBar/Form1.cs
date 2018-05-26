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
        /*
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
        */

        

        Config cfg = new Config(42, new String[] {
            "C:/Windows/explorer.exe",
            "C:/Windows/notepad.exe",
            "C:/Windows/HelpPane.exe",
            "C:/Windows/notepad.exe"
        });

        public MaBar()
        {
            InitializeComponent();
            createButtons();
            this.Size = new System.Drawing.Size(cfg.getProgramList().Length * cfg.getIconSize(), cfg.getIconSize());
        }

        private void createButtons()
        {
            for (int i = 0; i < cfg.getProgramList().Length; i++)
            {
                PictureBox pb = new PictureBox();
                Point pos = new System.Drawing.Point(i * cfg.getIconSize(), 0);
                pb.Location = pos;
                pb.Name = "btn_" + i;
                pb.Tag = i;
                pb.Size = new System.Drawing.Size(cfg.getIconSize(), cfg.getIconSize());
                pb.Image = Icon.ExtractAssociatedIcon(cfg.getProgramList()[i]).ToBitmap();
                pb.BackColor = Color.Pink;
                pb.SizeMode = PictureBoxSizeMode.CenterImage;
                pb.Click += new System.EventHandler(this.test);
                this.Controls.Add(pb);
            }
        }



        private void test(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Console.WriteLine(pb.Tag);
            try {
                Process.Start(cfg.getProgramList()[Int32.Parse(pb.Tag.ToString())]);
            } catch (Exception ex)
            {
                Debug.WriteLine("could not start program" + ex);
            }
                
        }
    }
}
