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
            "C:/Windows/explorer.exe",
            "C:/Windows/notepad.exe",
            "C:/Windows/HelpPane.exe",
            "C:/Windows/notepad.exe"
        });


        // Config c = new Config();

        // Config cfg;

        public MaBar()
        {
            InitializeComponent();
            saveToJson();
            loadFromJson();
            createButtons();
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



        private void test(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Console.WriteLine(pb.Tag);
            try {
                Process.Start(cfg.getProgramList()[Int32.Parse(pb.Tag.ToString())]);
                Application.Exit();
            } catch (Exception ex)
            {
                Debug.WriteLine("could not start program" + ex);
            }
                
        }

        private void MaBar_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
