using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using System.Windows.Media.Imaging;

namespace ZBFReader
{
    public partial class Form1 : Form
    {
        private int _currentRadioButton;

        public int currentRadioButton
        {
            get { return _currentRadioButton; }
            set { _currentRadioButton = value; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void bRun_Click(object sender, EventArgs e)
        {
            string popDirectory = Program.getPopDirectory();



            //string fileToRun = @"C:\Users\michael.humphreys.ZEMAX\Documents\Zemax\POP\BEAMFILES\LENS_0256.ZBF";
            if (lbFilesRight.Items.Count > 0)
            {
                System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
                stopWatch.Start();
                lRunTime.Text = "";

                bRun.Enabled = false;
                string fileToRun;

                //foreach (var val in lbFilesRight.Items)
                //{
                //    fileToRun = (val as ListboxData).FullPath;
                //    Program.calculations(fileToRun, currentRadioButton);
                //}

                Parallel.ForEach(lbFilesRight.DataSource as List<ListboxData>,
                    new ParallelOptions { MaxDegreeOfParallelism = 2 },
                    val =>
                    {
                        fileToRun = val.FullPath;
                        Program.calculations(fileToRun, currentRadioButton);
                    });

                fileToRun = (lbFilesRight.Items[lbFilesRight.Items.Count - 1] as ListboxData).FullPath;
                refreshImage(fileToRun);
                tabControl1.SelectedIndex = 1;

                bRun.Enabled = true;

                double manual = (double)stopWatch.ElapsedMilliseconds / 1000;
                lRunTime.Text = manual.ToString("F2");

                turnOnColorbars();

            }
        }

        Dictionary<int, Bitmap> colorBar = new Dictionary<int, Bitmap>()
        {
            {0, ZBFViewer.Properties.Resources.zbf_color_bar },
            {1, ZBFViewer.Properties.Resources.zbf_color_bar_inverse },
            {2, ZBFViewer.Properties.Resources.zbf_color_bar_gray },
            {3, ZBFViewer.Properties.Resources.zbf_color_bar_gray_inverse }
        };

        private void turnOnColorbars()
        {
            pbIrradianceColorbar.Visible = true;
            pbPhaseColorbar.Visible = true;

            label_irradiance_min.Visible = true;
            label_irradiance_max.Visible = true;
            label_phase_min.Visible = true;
            label_phase_max.Visible = true;

            pbIrradianceColorbar.Image = colorBar[currentRadioButton];
            pbPhaseColorbar.Image = colorBar[currentRadioButton];
        }

        private void bView_Click(object sender, EventArgs e)
        {
            
            if (lbFilesRight.Items.Count > 0)
            {
                turnOnColorbars();

                var fileToRun = (lbFilesRight.Items[lbFilesRight.Items.Count - 1] as ListboxData).FullPath;
                refreshImage(fileToRun);
                tabControl1.SelectedIndex = 1;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(200, 200);

            Width = 867;
            tabControl1.Width = 792;

            zoomFactor = 1;

            refreshList();

            List<ListboxData> rightData = new List<ListboxData>();
            lbFilesRight.DisplayMember = "Text";
            lbFilesRight.DataSource = rightData;

            //pbIrradiance.ImageLocation = @"c:\temp\irradiance.bmp";
            //pbPhase.ImageLocation = @"c:\temp\phase.bmp";

            label_irradiance_x_neg.Text = "";
            label_irradiance_x_pos.Text = "";
            label_irradiance_y_neg.Text = "";
            label_irradiance_y_pos.Text = "";

            label_phase_x_neg.Text = "";
            label_phase_x_pos.Text = "";
            label_phase_y_neg.Text = "";
            label_phase_y_pos.Text = "";

            if (double.TryParse(tbZeroPhase.Text, out double phaseValue))
            {
                Program.zeroPhase = phaseValue;
            }

            Focus();
        }

        private void bFileRight_One_Click(object sender, EventArgs e)
        {
            moveFiles("right", "one");
        }

        private void bFileLeft_One_Click(object sender, EventArgs e)
        {
            moveFiles("left", "one");
        }
        private void bFileRight_All_Click(object sender, EventArgs e)
        {
            moveFiles("right", "all");
        }

        private void bFileLeft_All_Click(object sender, EventArgs e)
        {
            moveFiles("left", "all");
        }

        private void moveFiles(string direction = "right", string number = "one")
        {
            List<ListboxData> sourceData;
            List<ListboxData> targetData;
            ListBox.SelectedObjectCollection dataSelected;

            if (direction == "right")
            {
                sourceData = lbFilesLeft.DataSource as List<ListboxData>;
                targetData = lbFilesRight.DataSource as List<ListboxData>;
                if (number != "one")
                {
                    for (int i = 0; i < lbFilesLeft.Items.Count; i++)
                    {
                        lbFilesLeft.SetSelected(i, true);
                    }
                }
                dataSelected = (lbFilesLeft.SelectedItems);
            }
            else
            {
                sourceData = lbFilesRight.DataSource as List<ListboxData>;
                targetData = lbFilesLeft.DataSource as List<ListboxData>;
                if (number != "one")
                {
                    for (int i = 0; i < lbFilesRight.Items.Count; i++)
                    {
                        lbFilesRight.SetSelected(i, true);
                    }
                }
                dataSelected = (lbFilesRight.SelectedItems);
            }

            if (dataSelected.Count > 0)
            {
                int dex = 0;
                foreach (var val in dataSelected)
                {
                    targetData.Add(new ListboxData() { FullPath = (val as ListboxData).FullPath, Text = (val as ListboxData).Text, Value = dex });
                    dex++;
                    sourceData.Remove((val as ListboxData));
                    //sourceData.RemoveAt()


                }

                lbFilesLeft.DataSource = null;
                lbFilesRight.DataSource = null;

                lbFilesLeft.DisplayMember = "Text";
                lbFilesRight.DisplayMember = "Text";
                if (direction == "right")
                {

                    lbFilesLeft.DataSource = sourceData;
                    lbFilesRight.DataSource = targetData;
                }
                else
                {
                    lbFilesLeft.DataSource = targetData;
                    lbFilesRight.DataSource = sourceData;
                    lbFilesRight.Focus();
                }

                // renumber files on right
                targetData = lbFilesRight.DataSource as List<ListboxData>;


                dex = 0;
                foreach (var val in targetData)
                {
                    targetData[dex].Value = dex;
                    dex++;
                }


                


                lbFilesRight.DataSource = targetData;
            }

            bRun.Enabled = lbFilesRight.Items.Count > 0;


        }

        private void bPrev_Click(object sender, EventArgs e)
        {
            if (lbFilesRight.Items.Count == 0) return;

            string fullFile = (string)lCurrentFile.Tag;
            List<ListboxData> sourceData = lbFilesRight.DataSource as List<ListboxData>;

            int myIndex = sourceData.First(i => i.FullPath == fullFile).Value;
            string fileToRun;
            if (myIndex > 0)
            {
                var next = sourceData.First(i => i.Value == myIndex - 1);
                fileToRun = next.FullPath;
            }
            else
            {
                var next = sourceData.First(i => i.Value == lbFilesRight.Items.Count - 1);
                fileToRun = next.FullPath;
            }
            refreshImage(fileToRun);
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (lbFilesRight.Items.Count == 0) return;

            string fullFile = (string)lCurrentFile.Tag;
            List<ListboxData> sourceData = lbFilesRight.DataSource as List<ListboxData>;

            int myIndex = sourceData.First(i => i.FullPath == fullFile).Value;
            string fileToRun;
            if (myIndex < lbFilesRight.Items.Count - 1)
            {
                var next = sourceData.First(i => i.Value == myIndex + 1);
                fileToRun = next.FullPath;
            }
            else
            {
                var next = sourceData.First(i => i.Value == 0);
                fileToRun = next.FullPath;
            }
            refreshImage(fileToRun);
        }

        private void refreshImage(string fileToRun)
        {
            string popDirectory = Program.getPopDirectory();

            string baseFileName = Path.GetFileNameWithoutExtension(fileToRun);

            lCurrentFile.Text = Path.GetFileName(fileToRun);
            lCurrentFile.Tag = fileToRun;

            string fileName;
            var serializer = new JavaScriptSerializer();

            fileName = Path.Combine(popDirectory, baseFileName + "_irradiance.jpg");
            if (File.Exists(fileName))
            {
                // get calculated data
                var jpeg = new JpegMetadataAdapter(fileName);
                dynamic json = serializer.DeserializeObject(jpeg.Metadata.Comment);

                double x_half_width = ((int)json["nx"] * (double)json["del_x"]) / 2;
                double y_half_width = ((int)json["ny"] * (double)json["del_y"]) / 2;

                label_irradiance_x_neg.Text = (-x_half_width).ToString("0.00E0");
                label_irradiance_x_pos.Text = (x_half_width).ToString("0.00E0");
                label_irradiance_y_neg.Text = (-y_half_width).ToString("0.00E0");
                label_irradiance_y_pos.Text = (y_half_width).ToString("0.00E0");

                //label_irradiance_min.Text = ((double)json["min"]).ToString("0.00E0");
                label_irradiance_min.Text = "0.00E0";
                label_irradiance_max.Text = ((double)json["max"]).ToString("0.00E0");


                // display image
                using (Stream stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    Image image = Image.FromStream(stream);
                    pbIrradiance.Image = image;
                }

                // change colorbar
                pbIrradianceColorbar.Image = colorBar[json["cm"]];
            }
            else
            {
                pbIrradiance.Image = null;
            }
            fileName = Path.Combine(popDirectory, baseFileName + "_phase.jpg");
            if (File.Exists(fileName))
            {
                var jpeg = new JpegMetadataAdapter(fileName);
                dynamic json = serializer.DeserializeObject(jpeg.Metadata.Comment);

                double x_half_width = ((int)json["nx"] * (double)json["del_x"]) / 2;
                double y_half_width = ((int)json["ny"] * (double)json["del_y"]) / 2;

                label_phase_x_neg.Text = (-x_half_width).ToString("0.00E0");
                label_phase_x_pos.Text = (x_half_width).ToString("0.00E0");
                label_phase_y_neg.Text = (-y_half_width).ToString("0.00E0");
                label_phase_y_pos.Text = (y_half_width).ToString("0.00E0");

                // display image
                using (Stream stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    Image image = Image.FromStream(stream);
                    pbPhase.Image = image;
                }

                // change colorbar
                pbPhaseColorbar.Image = colorBar[json["cm"]];
            }
            else
            {
                pbPhase.Image = null;
            }

            // update zoom image
            if (Width > 1200)
            {
                zoomImage();
            }


        }

        public class ListboxData
        {
            public int Value { get; set; }
            public string FullPath { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                bNext.PerformClick();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                bPrev.PerformClick();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                tbClose.PerformClick();
            }
        }

        private void refreshList()
        {
            string popDirectory = Program.getPopDirectory();
            string[] defaultBeamfiles = Directory.GetFiles(Path.Combine(Path.GetFullPath(Path.Combine(popDirectory, @"..")), "BEAMFILES"), @"*.ZBF", SearchOption.TopDirectoryOnly);

            List<ListboxData> leftData = new List<ListboxData>();
            int dex = 0;
            foreach (string val in defaultBeamfiles)
            {
                leftData.Add(new ListboxData() { FullPath = val, Text = Path.GetFileName(val), Value = dex });
                dex++;
            }
            lbFilesLeft.DisplayMember = "Text";
            lbFilesLeft.DataSource = leftData;
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void rbFalseColor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFalseColor.Checked) currentRadioButton = 0;
        }

        private void rbFalseColorInverse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFalseColorInverse.Checked) currentRadioButton = 1;
        }

        private void rbGrayScale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGrayScale.Checked) currentRadioButton = 2;
        }

        private void rbGrayScaleInverse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGrayScaleInverse.Checked) currentRadioButton = 3;
        }

        private string _currentPb;
        private double _zoomFactor;
        private double _mouseX;
        private double _mouseY;

        private string currentPb
        {
            get { return _currentPb; }
            set { _currentPb = value; }
        }

        private double zoomFactor
        {
            get { return _zoomFactor; }
            set { _zoomFactor = value; }
        }

        private double mouseX
        {
            get { return _mouseX; }
            set { _mouseX = value; }
        }

        private double mouseY
        {
            get { return _mouseY; }
            set { _mouseY = value; }
        }

        private void pbIrradiance_MouseMove(object sender, MouseEventArgs e)
        {
            if (Width > 1200)
            {
                currentPb = ((PictureBox)sender).Name;
                
                
                if (!pbIrradianceLocked)
                {
                    mouseX = e.X;
                    mouseY = e.Y;
                }
                zoomImage();
            }
        }

        private void pbPhase_MouseMove(object sender, MouseEventArgs e)
        {
            if (Width > 1200)
            {
                currentPb = ((PictureBox)sender).Name;
                if (!pbPhaseLocked)
                {
                    mouseX = e.X;
                    mouseY = e.Y;
                }
                zoomImage();
            }
        }

        private void zoomImage()
        {


            PictureBox picImage = (PictureBox)Controls.Find(currentPb, true)[0];


            int srcWidth = picImage.Image.Width;
            int srcHeight = picImage.Image.Height;
            int destWidth = picImage.Width;
            int destHeight = picImage.Height;
            double ratio = srcWidth / destWidth;

            // Create temporary bitmap
            Bitmap tempBitmap = new Bitmap(picImage.Width, picImage.Height, PixelFormat.Format24bppRgb);

            // Set the resolution of the bitmap to match the original resolution
            tempBitmap.SetResolution(picImage.Image.HorizontalResolution, picImage.Image.VerticalResolution);

            // Create a temporary Graphics object to work on the bitmap
            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            // Set the interpolation mode
            bmGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            int zoomWidth = (int)(pbZoom.Width * zoomFactor * ratio);
            int zoomHeight = (int)(pbZoom.Height * zoomFactor * ratio);
            int halfWidth = srcWidth / 2;
            int halfHeight = srcHeight / 2;

            // fill in picturebox back with edge '0' pixel when mousing at 1x
            Color pixelRGB = (new Bitmap(picImage.Image)).GetPixel(1, 1);
            bmGraphics.FillRectangle(new SolidBrush(Color.FromArgb(pixelRGB.R, pixelRGB.G, pixelRGB.B)), new Rectangle(0, 0, 256, 256));

            int x = (int)(mouseX);
            int y = (int)(mouseY);

            int ptx = (int)(srcWidth / 2 + (x - halfWidth) - zoomWidth / 2);
            int pty = (int)(srcHeight / 2 + (y - halfHeight) - zoomHeight / 2);

            ptx = srcWidth / 2 + (x * srcWidth / destWidth - halfWidth) - zoomWidth / 2;
            pty = srcHeight / 2 + (y * srcHeight / destHeight - halfHeight) - zoomHeight / 2;

            bmGraphics.DrawImage(picImage.Image,
               new Rectangle(0, 0, (int)(picImage.Width), (int)(picImage.Height)),
               new Rectangle(ptx, pty, (int)(zoomWidth), (int)(zoomHeight)),
               GraphicsUnit.Pixel);


            pbZoom.Image = tempBitmap;
        }

        

        private void pbIrradiance_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Width > 1200)
            {
                mouseWheel(e);
            }
        }

        private void pbPhase_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Width > 1200)
            {
                mouseWheel(e);
            }
        }

        private void mouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (zoomFactor < 1)
                {
                    zoomFactor *= 2;
                }
            }
            else if (e.Delta < 0)
            {
                if (zoomFactor > 0.03125)
                {
                    // only allow 32x zoom
                    zoomFactor /= 2;
                }
            }
            label_zoomFactor.Text = "Zoom Factor: " + (1 / zoomFactor).ToString("0") + "x";
            zoomImage();
        }

        private void bZoom_Click(object sender, EventArgs e)
        {
            if (Width < 1200)
            {
                Width = 1222;
                tabControl1.Width = 1142;
                bZoom.Text = "Unzoom";
                pbIrradiance.Cursor = Cursors.Cross;
                pbPhase.Cursor = Cursors.Cross;
            }
            else
            {

                Width = 867;
                tabControl1.Width = 792;
                bZoom.Text = "Zoom";
                pbIrradiance.Cursor = Cursors.Default;
                pbPhase.Cursor = Cursors.Default;
            }
        }

        private void tbZeroPhase_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(tbZeroPhase.Text, out double phaseValue))
            {
                Program.zeroPhase = phaseValue;
            }

        }

        private bool pbIrradianceLocked { get; set; }
        private bool pbPhaseLocked { get; set; }

        private void pbIrradiance_Click(object sender, EventArgs e)
        {
            pbIrradianceLocked = !pbIrradianceLocked;
            if (pbIrradianceLocked)
            {
                pbIrradiance.Cursor = Cursors.Default;
            }
            else
            {
                pbIrradiance.Cursor = Cursors.Cross;
            }
        }

        private void pbPhase_Click(object sender, EventArgs e)
        {
            pbPhaseLocked = !pbPhaseLocked;
            if (pbPhaseLocked)
            {
                pbPhase.Cursor = Cursors.Default;
            }
            else
            {
                pbPhase.Cursor = Cursors.Cross;
            }
        }
    }
}
