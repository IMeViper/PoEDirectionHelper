namespace PoeDirectionHelper
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.zoneWatcher = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zoneWatcher
            // 
            this.zoneWatcher.Tick += new System.EventHandler(this.ReadNewLines_Timer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "P1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OverlayMap_MouseDoubleClick);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseUp);
            // 
            // noteLabel
            // 
            this.noteLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noteLabel.BackColor = System.Drawing.Color.Black;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.noteLabel.ForeColor = System.Drawing.Color.Silver;
            this.noteLabel.Location = new System.Drawing.Point(0, 85);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(128, 13);
            this.noteLabel.TabIndex = 3;
            this.noteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.noteLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OverlayMap_MouseDoubleClick);
            this.noteLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseDown);
            this.noteLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseMove);
            this.noteLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(128, 98);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.Text = "PoEDirectionHelper";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer zoneWatcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label noteLabel;
    }
}

