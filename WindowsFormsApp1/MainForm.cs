using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using OverlayJson;

namespace PoeDirectionHelper
{
    public partial class MainForm : Form
    {
        string logPath = null;

        FileStream fileStream;
        StreamReader logStream;
        Regex zoneEntered;
        OverlayData[] zoneData;
        string currentDirectory;
        PictureBox[] listOfPictures = new PictureBox[10];
        private bool dragging = false;
        private Point pointClicked;
        private bool partTwo = false;
        string zoneName = null;

        public MainForm()
        {
            currentDirectory = Directory.GetCurrentDirectory();

            logPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\GrindingGearGames\Path of Exile", "InstallLocation", null);
            logPath = String.Format("{0}\\logs\\Client.txt", logPath);

            if (logPath == null)
                MessageBox.Show("Could not find Path of Exile folder.");

            // Initialize the app 
            InitializeComponent();
            InitializeStream();
            InitializeJsonOverlay();

            // Define the regex to scan ...
            zoneEntered = new Regex(@"You have entered (.*)\.", RegexOptions.IgnoreCase);
            zoneWatcher.Enabled = true;


        }
                
        private void InitializeJsonOverlay()
        {
            zoneData = OverlayData.FromJson(File.ReadAllText(String.Format("{0}\\Overlays\\{1}", currentDirectory, "overlay.json")));
        }

        private void InitializeStream()
        {
            fileStream = File.Open(logPath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.ReadWrite);
            logStream = new StreamReader(fileStream);
            
            // Move to the end of the file
            fileStream.Seek(-512, SeekOrigin.End);
        }
        
        private Tuple<string, object[]> FindZoneName(string zoneName)
        {
            bool firstHit = false;
            foreach (var region in zoneData)
                foreach (var zone in region.Zone)
                {
                    // if PartTwo is enabled, skip first entry...
                    if (zone.ZoneName.Equals(zoneName))
                    {
                        if (partTwo && !firstHit)
                        {
                            firstHit = true;
                        } else
                        {
                            return Tuple.Create(region.Region, zone.ZoneSeed);
                        }
                        
                    }
                }

            return Tuple.Create("", new object[0]);
        }

        private void ReadNewLines_Timer(object sender, EventArgs e)
        {
            // Read new line every 100 ms and detect zone...
            string line = logStream.ReadToEnd();
            string image = null;

            Match m = zoneEntered.Match(line);

            if (m.Success)
            {
                // New zone has been entered - update graphics. 
                zoneName = m.Groups[1].ToString();
                ClearMap();

                // Attempt to find a corresponding zoneName 
                Console.WriteLine("Player entered {0}", zoneName);

                var seedList = FindZoneName(zoneName);
                if (seedList.Item2.Length > 0)
                {
                    var seed_no = 0;
                    foreach (var seed in seedList.Item2)
                    {
                        
                        image = String.Format("{0}\\Overlays\\{1}\\{2}.png", currentDirectory, seedList.Item1, seed);
                        DrawMap(image, seed_no);

                        seed_no++;
                    }
                }
            }

        }

        private void ClearMap()
        {
            foreach (var item in listOfPictures)
                this.Controls.Remove(item);

            this.Height = 0;
            this.Width = 0;
        }

        private void DrawMap(string path, int seed)
        {

            listOfPictures[seed] = new PictureBox
            {
                Name = String.Format("pictureBox{0}", seed),
                Size = new Size(128, 72),
                Image = Image.FromFile(path),
                Cursor = Cursors.Hand,
                Location = new Point(128 * seed, 0)
                
            };
            listOfPictures[seed].MouseDown += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseDown);
            listOfPictures[seed].MouseUp += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseUp);
            listOfPictures[seed].MouseMove += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseMove);
            listOfPictures[seed].MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.overlayMap_MouseDoubleClick);

            this.Controls.Add(listOfPictures[seed]);

            this.Width = 128 * seed;
            this.Height = 72;
        }

        private void overlayMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            partTwo = !partTwo;
            if (partTwo) label1.Text = "P2";
            else label1.Text = "P1";

            // Redraw map 
            ClearMap();

            string image = null;
            var seedList = FindZoneName(zoneName);
            if (seedList.Item2.Length > 0)
            {
                var seed_no = 0;
                foreach (var seed in seedList.Item2)
                {

                    image = String.Format("{0}\\Overlays\\{1}\\{2}.png", currentDirectory, seedList.Item1, seed);
                    DrawMap(image, seed_no);

                    seed_no++;
                }
            }
        }

        private void overlayMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point pointMoveTo;
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);
                this.Location = pointMoveTo;
            }
        }

        private void overlayMap_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void overlayMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                pointClicked = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }
    }
}
