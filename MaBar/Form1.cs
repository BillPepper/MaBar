using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MaBar
{
    public partial class MaBar : Form
    {
        Config cfg = new Config(42, new String[] {
            "D:/Tools/Ableton 9/Program/Ableton Live 9 Suite.exe",
            "D:/Tools/KeePass Password Safe 2/KeePass.exe",
            "D:/Tools/GIMP 2/bin/gimp-2.8.exe",
            // "C:/WINDOWS/system32/SnippingTool.exe",
            "D:/Tools/Notepad++/notepad++.exe",
            "D:/Programming/Microsoft VS Code/Code.exe",
            "D:/Programming/Visual Studio 2017/Common7/IDE/WDExpress.exe",
            "C:/Windows/System32/WindowsPowerShell/v1.0/powershell.exe",
            "C:/Program Files/VeraCrypt/VeraCrypt-x86.exe",
            "D:/Tools/Audacity/audacity.exe"
        });


        // Config c = new Config();

        // Config cfg;

        public MaBar()
        {
            InitializeComponent();
            saveToJson();
            loadFromJson();
            createButtons();
            setWindowPositon();
            this.Size = new System.Drawing.Size(cfg.getProgramList().Length * cfg.getIconSize(), cfg.getIconSize());
        }

        private void saveToJson()
        {
            /*
            string json = JsonConvert.SerializeObject(cfg.getProgramList());
            StreamWriter sw = new StreamWriter(@"testsave.txt");
            sw.Write(json);
            sw.Close();
            */

        }

        private void loadFromJson()
        {
            StreamReader sr = new StreamReader(@"testsave.txt");
            string json = sr.ReadToEnd();
            // cfg = JsonConvert.DeserializeObject<Config>(json);
        }

        private void createButtons()
        {
            try
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
                    pb.BackColor = Color.FromArgb(255, 27, 27, 27);
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                    pb.Click += new System.EventHandler(this.test);
                    this.Controls.Add(pb);
                }
            } catch (Exception e)
            {
                MessageBox.Show("could not load config" + e);
            }
        }

        private void setWindowPositon()
        {
            int w = SystemInformation.VirtualScreen.Width;
            int h = SystemInformation.VirtualScreen.Height;

            this.Top = 1010;

            Debug.WriteLine(w + " " + h);
        }

        private void test(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;
            PictureBox pb = (PictureBox)sender;
            Console.WriteLine(me);
            if (me.Button == MouseButtons.Right)
            {
                Debug.WriteLine("Right");
            }
            else
            {
                try
                {
                    Debug.WriteLine("Other");
                    //Process.Start(cfg.getProgramList()[Int32.Parse(pb.Tag.ToString())]);
                    //Application.Exit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("could not start program" + ex);
                }
            }
                
        }

        private void MaBar_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
