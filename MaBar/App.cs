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
        string configFile = @"programlist.txt";
        Config config;
        bool editModeActive = false;

        public MaBar()
        {
            InitializeComponent();
            loadConfig();

            if (config != null)
            {
                createButtons();
            }
        }

        private void setupWindow()
        {
            setWindowPositon();
            this.Size = new Size(config.applications.Length * config.iconSize + 16, config.iconSize); //add 16px for the editMode button
        }

        private void loadConfig()
        {
            if (!File.Exists(configFile))
            {
                DialogResult missingConfig = MessageBox.Show("The config file is missing, should one be generated?", "Missing Config", MessageBoxButtons.YesNo);
                if (missingConfig == DialogResult.No)
                {
                    Application.Exit();
                }else
                {
                    MessageBox.Show("Sorry, this function is not ready yet :(");
                }
            } else
            {
                try
                {
                    StreamReader sr = new StreamReader(@"programlist.txt");
                    this.config = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
                    setupWindow();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not load config" + e);
                }
            }
        }

        private void createButtons()
        {
            try
            {
                for (int i = 0; i < config.applications.Length; i++)
                {
                    PictureBox pb = new PictureBox();
                    Point pos = new System.Drawing.Point(i * config.iconSize, 0);
                    pb.Location = pos;
                    pb.Name = "btn_" + i;
                    pb.Tag = i;
                    pb.Size = new System.Drawing.Size(config.iconSize, config.iconSize);
                    pb.Image = Icon.ExtractAssociatedIcon(config.applications[i]).ToBitmap();
                    if (config.colors.Length == 3)
                    {
                        pb.BackColor = Color.FromArgb(255, config.colors[0], config.colors[1], config.colors[2]);
                    } else
                    {
                        pb.BackColor = Color.FromArgb(255, 27, 27, 27);
                    }
                    
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                    pb.Click += new System.EventHandler(this.handleButtonClick);
                    this.Controls.Add(pb);
                }
            } catch (Exception e)
            {
                MessageBox.Show("could not load config" + e);
            }

            // move editMode button to the end of the apps
            btn_editMode.Location = new Point(config.applications.Length * config.iconSize, 0);
            btn_editMode.Size = new Size(16, config.iconSize);
        }

        private void setWindowPositon()
        {
            int w = SystemInformation.VirtualScreen.Width;
            int h = SystemInformation.VirtualScreen.Height;
            this.Top = config.topPos;
        }

        private void handleButtonClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;
            PictureBox pb = (PictureBox)sender;

            if (me.Button == MouseButtons.Left)
            {
                if (!editModeActive)
                {
                    try
                    {
                        Process.Start(config.applications[Int32.Parse(pb.Tag.ToString())]);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("could not start program" + ex);
                    }
                } else
                {
                    pb.BackColor = Color.OrangeRed;
                }
            }

        }

        private void MaBar_Deactivate(object sender, EventArgs e)
        {
            if (!editModeActive)
            {
                Application.Exit();
            }
        }

        private void toggleEditMode(object sender, EventArgs e)
        {
            if (!this.editModeActive)
            {
                this.editModeActive = true;
                this.TopMost = true;
                this.Size = new Size (this.Size.Width, config.iconSize + 20);
                this.Top = config.topPos - 20;
            } else
            {
                this.editModeActive = false;
                this.Size = new Size(this.Size.Width, config.iconSize);
                this.Top = config.topPos;
            }
        }
    }
}
