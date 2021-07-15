using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;
using System.Web.Script.Serialization;

namespace ZBFReader
{


    class Program
    {
        public static double zeroPhase { get; set; }
        public static int currentRadioButton { get; set; }

        static void Main(string[] args)
        {

            Form1 myForm = new Form1();

            System.Windows.Forms.Application.Run(myForm);

        }

        public static string getPopDirectory()
        {
            string popDirectory = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Zemax", "ZemaxRoot", "");

            // create directory if not exist
            Directory.CreateDirectory(Path.Combine(popDirectory, @"POP\images"));

            return Path.Combine(popDirectory, @"POP\images"); ;
        }

        public static void calculations(string pathSource, int currentRb)
        {
            string popDirectory = getPopDirectory();
            currentRadioButton = currentRb;

            

            try
            {
                System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
                stopWatch.Start();
                using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;

                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;

                    // header information
                    numBytesRead = 0;
                    double[] header = new double[17];
                    byte[] intByteHolder = new byte[4];
                    byte[] doubleByteHolder = new byte[8];

                    // read first five 4-byte integers
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            intByteHolder[j] = bytes[numBytesRead];
                            numBytesRead++;
                        }
                        header[i] = BitConverter.ToInt32(intByteHolder, 0);
                    }

                    // skip over 4 integers which are currently unused
                    numBytesRead = numBytesRead + 4 * 4;

                    // read next twelve 8-byte doubles
                    for (int i = 5; i < 17; i++)
                    {
                        for (int j = 0; j <= 7; j++)
                        {
                            doubleByteHolder[j] = bytes[numBytesRead];
                            numBytesRead++;
                        }
                        header[i] = BitConverter.ToDouble(doubleByteHolder, 0);
                    }

                    // skip over 8 doubles which are currently unused
                    numBytesRead = numBytesRead + 8 * 8;

                    int nx = (int)header[1];
                    int ny = (int)header[2];
                    double del_x = header[5];
                    double del_y = header[6];

                    eField x_field = new eField(nx, ny, del_x, del_y, bytes, numBytesRead);
                    numBytesRead = x_field.lastByteRead;        // move pointer for binary file
                    double time_01 = (double)stopWatch.ElapsedMilliseconds / 1000;

                    string baseFileName = Path.GetFileNameWithoutExtension(pathSource);
                    string fileName;
                    // create BMP from irradiance and phase
                    fileName = Path.Combine(popDirectory, baseFileName + "_irradiance.bmp");
                    CreateImage(x_field.irradiance, x_field.minIrradiance, x_field.maxIrradiance, fileName, nx, ny, del_x, del_y);
                    fileName = Path.Combine(popDirectory, baseFileName + "_phase.bmp");
                    CreateImage(x_field.phase, x_field.minPhase, x_field.maxPhase, fileName, nx, ny, del_x, del_y);

                    // reads Ey values if polarization is turned on
                    if (header[3] == 1)
                    {
                        eField y_field = new eField(nx, ny, del_x, del_y, bytes, numBytesRead);

                        fileName = Path.Combine(popDirectory, baseFileName + "_y_irradiance.bmp");
                        CreateImage(y_field.irradiance, y_field.minIrradiance, y_field.maxIrradiance, fileName, nx, ny, del_x, del_y);
                        fileName = Path.Combine(popDirectory, baseFileName + "_y_phase.bmp");
                        CreateImage(y_field.phase, y_field.minPhase, y_field.maxPhase, fileName, nx, ny, del_x, del_y);
                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }

        

        public static void CreateImage(double[,] data, double min, double max, string fileName, int nx, int ny, double del_x, double del_y)
        {
            int v_lookup;

            double range = max - min;
            byte v;

            Bitmap bm = new Bitmap(data.GetLength(0), data.GetLength(1));
            BitmapData bd = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // This is much faster than calling Bitmap.SetPixel() for each pixel.
            unsafe
            {
                // default false color
                byte[] r = new byte[64] { 128, 143, 159, 175, 191, 207, 223, 239, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 239, 223, 207, 191, 175, 159, 143, 128, 112, 96, 80, 64, 48, 32, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                byte[] g = new byte[64] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 16, 32, 48, 64, 80, 96, 112, 128, 143, 159, 175, 191, 207, 223, 239, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 239, 223, 207, 191, 175, 159, 143, 128, 112, 96, 80, 64, 48, 32, 16, 0, 0, 0, 0, 0, 0, 0, 0 };
                byte[] b = new byte[64] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 16, 32, 48, 64, 80, 96, 112, 128, 143, 159, 175, 191, 207, 223, 239, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 239, 223, 207, 191, 175, 159, 143 };

                if (currentRadioButton == 1)
                {
                    // inverse false color
                    r = new byte[64] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 16, 32, 48, 64, 80, 96, 112, 128, 143, 159, 175, 191, 207, 223, 239, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 239, 223, 207, 191, 175, 159, 143, 128 };
                    g = new byte[64] { 0, 0, 0, 0, 0, 0, 0, 0, 16, 32, 48, 64, 80, 96, 112, 128, 143, 159, 175, 191, 207, 223, 239, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 239, 223, 207, 191, 175, 159, 143, 128, 112, 96, 80, 64, 48, 32, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    b = new byte[64] { 143, 159, 175, 191, 207, 223, 239, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 239, 223, 207, 191, 175, 159, 143, 128, 112, 96, 80, 64, 48, 32, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                }
                else if (currentRadioButton == 2)
                {
                    // gray scale
                    r = new byte[64] { 252, 248, 244, 240, 236, 232, 228, 224, 220, 216, 212, 208, 204, 200, 196, 192, 188, 184, 180, 176, 172, 168, 164, 160, 156, 152, 148, 144, 140, 136, 132, 128, 124, 120, 116, 112, 108, 104, 100, 96, 92, 88, 84, 80, 76, 72, 68, 64, 60, 56, 52, 48, 44, 40, 36, 32, 28, 24, 20, 16, 12, 8, 4, 0 };
                    g = new byte[64] { 252, 248, 244, 240, 236, 232, 228, 224, 220, 216, 212, 208, 204, 200, 196, 192, 188, 184, 180, 176, 172, 168, 164, 160, 156, 152, 148, 144, 140, 136, 132, 128, 124, 120, 116, 112, 108, 104, 100, 96, 92, 88, 84, 80, 76, 72, 68, 64, 60, 56, 52, 48, 44, 40, 36, 32, 28, 24, 20, 16, 12, 8, 4, 0 };
                    b = new byte[64] { 252, 248, 244, 240, 236, 232, 228, 224, 220, 216, 212, 208, 204, 200, 196, 192, 188, 184, 180, 176, 172, 168, 164, 160, 156, 152, 148, 144, 140, 136, 132, 128, 124, 120, 116, 112, 108, 104, 100, 96, 92, 88, 84, 80, 76, 72, 68, 64, 60, 56, 52, 48, 44, 40, 36, 32, 28, 24, 20, 16, 12, 8, 4, 0 };
                }
                else if (currentRadioButton == 3)
                {
                    // inverse gray scale
                    r = new byte[64] { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 144, 148, 152, 156, 160, 164, 168, 172, 176, 180, 184, 188, 192, 196, 200, 204, 208, 212, 216, 220, 224, 228, 232, 236, 240, 244, 248, 252 };
                    g = new byte[64] { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 144, 148, 152, 156, 160, 164, 168, 172, 176, 180, 184, 188, 192, 196, 200, 204, 208, 212, 216, 220, 224, 228, 232, 236, 240, 244, 248, 252 };
                    b = new byte[64] { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 144, 148, 152, 156, 160, 164, 168, 172, 176, 180, 184, 188, 192, 196, 200, 204, 208, 212, 216, 220, 224, 228, 232, 236, 240, 244, 248, 252 };
                }

                byte* ptr = (byte*)bd.Scan0;
                for (int j = 0; j < bd.Height; j++)
                {
                    for (int i = 0; i < bd.Width; i++)
                    {
                        v = (byte)(255 * (data[i, bd.Height - 1 - j] - min) / range);
                        v_lookup = (int)Math.Ceiling(((double)v + 1) / 4) - 1;
                        ptr[0] = r[v_lookup];
                        ptr[1] = g[v_lookup];
                        ptr[2] = b[v_lookup];
                        ptr[3] = (byte)255;
                        ptr += 4;
                    }
                    ptr += (bd.Stride - (bd.Width * 4));
                }
            }

            bm.UnlockBits(bd);
            bm.Save(fileName);

            Image image1 = Image.FromFile(fileName);
            ImageConverter converter = new ImageConverter();
            byte[] myImage = (byte[])converter.ConvertTo(image1, typeof(byte[]));
            string jpgFileName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".jpg");
            using (Image image = Image.FromStream(new MemoryStream(myImage)))
            {
                image.Save(jpgFileName, ImageFormat.Jpeg);
            }

            // delete bitmap
            image1.Dispose();
            bm.Dispose();
            File.Delete(fileName);

            // finally, now we can set the EXIF properties
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/71d8de37-f52d-4faa-887a-793f8041110a/managing-general-exif-info-with-imagesetpropertyitem?forum=netfxbcl
            // https://msdn.microsoft.com/en-us/library/system.drawing.imaging.propertyitem.type(v=vs.110).aspx

            
            var jpeg = new JpegMetadataAdapter(jpgFileName);
            jpeg.Metadata.Comment = new JavaScriptSerializer().Serialize(new jpgJSON(nx, ny, del_x, del_y, min, max, currentRadioButton));
            jpeg.Save();
        }


    }

    public class jpgJSON
    {
        /*
        private int _nx;
        private int _ny;
        private double _del_x;
        private double _del_y;
        private double _min;
        private double _max;

        public double min
        {
            get { return _min; }
            set { _min = value; }
        }
        public double max
        {
            get { return _max; }
            set { _max = value; }
        }

        public int nx
        {
            get { return _nx; }
            set { _nx = value; }
        }
        public int ny
        {
            get { return _ny; }
            set { _ny = value; }
        }
        public double del_x
        {
            get { return _del_x; }
            set { _del_x = value; }
        }
        public double del_y
        {
            get { return _del_y; }
            set { _del_y = value; }
        }
        */
        public int nx { get; set; }
        public int ny { get; set; }
        public double del_x { get; set; }
        public double del_y { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public int cm { get; set; }

        public jpgJSON()
        {

        }

        public jpgJSON(int nx_val, int ny_val, double del_x_val, double del_y_val, double min_val, double max_val, int cm_val)
        {
            nx = nx_val;
            ny = ny_val;
            del_x = del_x_val;
            del_y = del_y_val;
            min = min_val;
            max = max_val;
            cm = cm_val;
        }
    }


    public class eField
    {
        public double[,] real;
        public double[,] imaginary;
        public double[,] irradiance;
        public double[,] phase;
        public double minIrradiance = 9e9;
        public double maxIrradiance = -9e9;
        public double minPhase = -1 * Math.PI;
        public double maxPhase = +1 * Math.PI;
        public int lastByteRead = -1;


        // constructor
        public eField(int nx, int ny, double del_x, double del_y, byte[] bytes, int numBytesRead)
        {
            real = new double[nx, ny];
            imaginary = new double[nx, ny];
            irradiance = new double[nx, ny];
            phase = new double[nx, ny];
            byte[] doubleByteHolder = new byte[8];
            double minRelativeIrradiance = Program.zeroPhase;

            int factor = 1;
            if (nx == 32) factor = 1;
            if (nx == 64) factor = 1;
            if (nx == 128) factor = 1;

            for (int i = 0; i < nx * factor; i++)
            {
                for (int j = 0; j < ny * factor; j++)
                {
                    int ii = j;
                    int jj = i;
                    // real
                    for (int k = 0; k <= 7; k++)
                    {
                        doubleByteHolder[k] = bytes[numBytesRead];
                        numBytesRead++;
                    }
                    real[ii, jj] = BitConverter.ToDouble(doubleByteHolder, 0);

                    // imaginary
                    for (int k = 0; k <= 7; k++)
                    {
                        doubleByteHolder[k] = bytes[numBytesRead];
                        numBytesRead++;
                    }
                    imaginary[ii, jj] = BitConverter.ToDouble(doubleByteHolder, 0);

                    // calculate irradiance and phase

                    irradiance[ii, jj] = (real[ii, jj] * real[ii, jj] + imaginary[ii, jj] * imaginary[ii, jj]) / (del_x * del_y);

                    if (irradiance[ii, jj] >= minRelativeIrradiance)
                    {
                        phase[ii, jj] = Math.Atan2(imaginary[ii, jj], real[ii, jj]);
                    }

                    // saves min/max values
                    if (irradiance[ii, jj] < minIrradiance) minIrradiance = irradiance[ii, jj];
                    if (irradiance[ii, jj] > maxIrradiance) maxIrradiance = irradiance[ii, jj];
                    if (phase[ii, jj] < minPhase) minPhase = phase[ii, jj];
                    if (phase[ii, jj] > maxPhase) maxPhase = phase[ii, jj];
                }
            }

            lastByteRead = numBytesRead;
        }
    }

    public class JpegMetadataAdapter
    {
        // https://stackoverflow.com/questions/1755185/how-to-add-comments-to-a-jpeg-file-using-c-sharp

        private readonly string path;
        private BitmapFrame frame;
        public readonly BitmapMetadata Metadata;

        public JpegMetadataAdapter(string path)
        {
            this.path = path;
            //frame = getBitmapFrame(path);

            BitmapDecoder decoder = null;
            using (Stream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            }
            frame = decoder.Frames[0];

            Metadata = (BitmapMetadata)frame.Metadata.Clone();
        }

        public void Save()
        {
            SaveAs(path);
        }

        public void SaveAs(string path)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(frame, frame.Thumbnail, Metadata, frame.ColorContexts));
            using (Stream stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite))
            {
                encoder.Save(stream);
            }
        }

        private BitmapFrame getBitmapFrame(string path)
        {
            BitmapDecoder decoder = null;
            //using (Stream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            //{
            //    decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            //}
            return decoder.Frames[0];
        }
    }
}
