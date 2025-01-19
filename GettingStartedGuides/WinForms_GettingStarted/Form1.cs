using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WinForms_GettingStarted
{
    public partial class Form1 : Form
    {

        private const long kilMaxImageSizePixel = 9000000;
        private float igCurrZoom;
        private const int kiiMinZoom = 1;
        private const int kiiMaxZoom = 800;
        private const int kiiZoomStep = 10;
        private float[] kigZoomSteps;

        private const int kiiObjectPadding = 40;
        private const int kiiNormalLeft = 4320;
        private const int kiiNormalTop = 675;
        private const int kiiReadOnlyLeft = 10;
        private const int kiiReadOnlyTop = 675;
        private const int kiiImageListLeft = 90;
        private const int kiiImageListTop = 585;
        private const int kiiThumbnailMaxDimension = 100;
        private const int kiiMaxImageSizeInKB = 1024;
        private const int kiiMaxImageThumbnailSizeInKB = 50;
        private const int kiiMaxImageDetailsHeight = 2935;
        private const int kiiMinImageDetailsHeight = 195;

        private long lastX;
        private long lastY;

        private long ilOriHeight;
        private long ilOriWidth;

        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            test();
        }

        private void test()
        {
            radioButton1.Text = "ygsfiuh_asbdsf_219853732_dhgk@hdgfdskuhgds.com";
            radioButton2.Text = "asbfc_gffdh_4325gbfx_fdg547_thhs@hdgfdskuhgds.com";

            label2.Text = "ygsfiuh_asbdsf_219853732_dhgk@hdgfdskuhgds.com";
            label3.Text = "asbfc_gffdh_4325gbfx_fdg547_thhs@hdgfdskuhgds.com";

            label4.Text = "ygsfiuh_asbdsf_219853732_dhgk@hdgfdskuhgds.com";
            label5.Text = "asbfc_gffdh_4325gbfx_fdg547_thhs@hdgfdskuhgds.com";

            label2.BackColor = Color.Yellow;
            label3.BackColor = Color.Yellow;
            label4.BackColor = Color.Yellow;
            label5.BackColor = Color.Yellow;

            tableLayoutPanel2.BackColor = Color.AliceBlue;
            tableLayoutPanel3.BackColor = Color.AliceBlue;
            tableLayoutPanel4.BackColor = Color.AliceBlue;
        }

        private void InitControl()
        {
            kigZoomSteps = new float[16];
            kigZoomSteps[0] = 1;
            kigZoomSteps[1] = 6.25f;
            kigZoomSteps[2] = 8.33f;
            kigZoomSteps[3] = 12.5f;
            kigZoomSteps[4] = 25;
            kigZoomSteps[5] = 33;
            kigZoomSteps[6] = 50;
            kigZoomSteps[7] = 58;
            kigZoomSteps[8] = 66.67f;
            kigZoomSteps[9] = 100;
            kigZoomSteps[10] = 175;
            kigZoomSteps[11] = 200;
            kigZoomSteps[12] = 300;
            kigZoomSteps[13] = 400;
            kigZoomSteps[14] = 600;
            kigZoomSteps[15] = 800;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.OpenPDFPreview();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.OpenImagePreview();
        }

        private void OpenPDFPreview()
        {
            DocPreview tupleObj = new DocPreview();

            // read file
            tupleObj = this.GetPdf();

            frmDocumentPreview frmDocumentPreview = new frmDocumentPreview(tupleObj, false);
            frmDocumentPreview.ShowDialog();
        }
        private void OpenImagePreview()
        {
            DocPreview tupleObj = new DocPreview();
            tupleObj.isSupportedImage = true;

            frmDocumentPreview frmDocumentPreview = new frmDocumentPreview(tupleObj, true);
            frmDocumentPreview.ShowDialog();
        }

        /// <summary>
        /// pretend read pdf from binary from DB
        /// read in memoryStream
        /// </summary>
        protected DocPreview GetPdf()
        {
            DocPreview tupleObj = new DocPreview();
            tupleObj.isSupportedImage = false;

            string filePath = this.GetDuumyPdfPath();

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //    {
            //        byte[] bytes = new byte[file.Length];
            //        file.Read(bytes, 0, (int)file.Length);
            //        ms.Write(bytes, 0, (int)file.Length);

            //        tupleObj.MemoryStream = ms;
            // MemoryStream will be closed out of using, assign byteArray as alternative 
            //        tupleObj.ByteArray = bytes;
            //    }
            //}

            MemoryStream ms = new MemoryStream();
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);

                // this not work because I guess the FileStream also closed out of using
                //file.CopyTo(ms);

                tupleObj.MemoryStream = ms;
            }


            return tupleObj;
        }

        public string GetDuumyPdfPath()
        {
            //This will give us the full name path of the executable file:
            //i.e. C:\Program Files\MyApplication\MyApplication.exe
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //This will strip just the working path name:
            //C:\Program Files\MyApplication
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

            string filePath = $"{strWorkPath}\\sample\\15MB.fitness_guildlines090519.pdf";

            return filePath;
        }
    }
}
