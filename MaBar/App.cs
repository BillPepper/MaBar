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
        string configFile = @"config.json";
        Config config;
        bool editModeActive = false;

        public MaBar()
        {
            InitializeComponent();

            if (checkConfig())
            {
                loadConfig();
                setupWindow();
                createButtons();
                setColor(255, config.colors[0], config.colors[1], config.colors[2]);
            } else
            {
                createNewConfig();
            }
        }

        private void setupWindow()
        {
            int width = config.applications.Length * config.iconSize + 16; //add 16px for the editMode button
            int height = config.iconSize;
            this.Top = config.topPos;
            this.Size = new Size(width, height );
        }

        private bool checkConfig()
        {
            if (!File.Exists(configFile))
            {
                return false;
            }
            return true;
        }

        private void createNewConfig()
        {
            DialogResult missingConfig = MessageBox.Show("The config file is missing, should one be generated?", "Missing Config", MessageBoxButtons.YesNo);
            if (missingConfig == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Sorry, this function is not ready yet :(");
            }
        }

        private void loadConfig()
        {
            {
                try
                {
                    StreamReader sr = new StreamReader(configFile);
                    this.config = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not load config" + e);
                }
            }
        }

        private void saveConfig()
        {
            try
            {
                StreamWriter sw = new StreamWriter(configFile);
                sw.Write(JsonConvert.SerializeObject(this.config));
                sw.Close();
            } catch (Exception e)
            {
                MessageBox.Show("Could not save config" + e);
            }
            
        }

        private void setColor(int a, int r, int g, int b)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    c.BackColor = Color.FromArgb(a, r, g, b);
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
                    pb.SizeMode = PictureBoxSizeMode.CenterImage;
                    pb.Click += new System.EventHandler(this.handleButtonClick);
                    this.Controls.Add(pb);
                }
            } catch (Exception e)
            {
                MessageBox.Show("could not create buttons" + e);
            }

            // move editMode button to the end of the apps
            btn_editMode.Location = new Point(config.applications.Length * config.iconSize, 0);
            btn_editMode.Size = new Size(16, config.iconSize);
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
            setColor(255, 100, 100, 100);
            if (!this.editModeActive)
            {
                this.editModeActive = true;
                this.TopMost = true;
                this.Size = new Size (this.Size.Width, config.iconSize + 20);
                this.Top = config.topPos - 20;
            } else
            {
                saveConfig();
                this.editModeActive = false;
                this.Size = new Size(this.Size.Width, config.iconSize);
                this.Top = config.topPos;
            }
        }

        private void MaBar_DragEnter(object sender, DragEventArgs e)
        {
            if (editModeActive)
            {
                string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                label_editMode.Text = "Add: " + FileList[0].ToString();
            }
        }

        private void MaBar_DragLeave(object sender, EventArgs e)
        {
            label_editMode.Text = "Click the Icons to remove or drag new ones in";
        }
    }
}
