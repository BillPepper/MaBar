﻿namespace MaBar
{
    partial class MaBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaBar));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_editMode = new System.Windows.Forms.Button();
            this.label_editMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_editMode
            // 
            this.btn_editMode.Location = new System.Drawing.Point(0, 0);
            this.btn_editMode.Name = "btn_editMode";
            this.btn_editMode.Size = new System.Drawing.Size(16, 39);
            this.btn_editMode.TabIndex = 1;
            this.btn_editMode.Text = ":";
            this.btn_editMode.UseVisualStyleBackColor = true;
            this.btn_editMode.Click += new System.EventHandler(this.toggleEditMode);
            // 
            // label_editMode
            // 
            this.label_editMode.AutoSize = true;
            this.label_editMode.ForeColor = System.Drawing.SystemColors.Control;
            this.label_editMode.Location = new System.Drawing.Point(0, 42);
            this.label_editMode.Name = "label_editMode";
            this.label_editMode.Size = new System.Drawing.Size(223, 13);
            this.label_editMode.TabIndex = 2;
            this.label_editMode.Text = "Click the Icons to remove or drag new ones in";
            // 
            // MaBar
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(128, 59);
            this.Controls.Add(this.label_editMode);
            this.Controls.Add(this.btn_editMode);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaBar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MaBar";
            this.Deactivate += new System.EventHandler(this.MaBar_Deactivate);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MaBar_DragEnter);
            this.DragLeave += new System.EventHandler(this.MaBar_DragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_editMode;
        private System.Windows.Forms.Label label_editMode;
    }
}

