using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCPixelArt
{
    public partial class Form1 : Form
    {
        public Form2 previewForm;

        public Form1()
        {
            InitializeComponent();
            imageWell.AllowDrop = true;
            imageWell.DragEnter += imageWell_DragEnter;
            imageWell.DragDrop += imageWell_DragDrop;
            previewForm = new Form2();
            previewForm.FormClosing += previewForm_FormClosing;
        }

        private void previewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            previewForm.Hide();
            e.Cancel = true;
        }

        private void imageWell_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;

        }

        private void imageWell_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Image newImage;
            try
            {
                newImage = Image.FromFile(files[0]);
                if (newImage != null)
                {
                    if (this.Controls.Contains(instructLabel))
                    {
                        this.Controls.Remove(instructLabel);
                    }
                    if (previewButton.Enabled == false) previewButton.Enabled = true;
                    imageWell.Image = newImage;
                    sizeSlider.Minimum = 10;
                    sizeSlider.Maximum = imageWell.Image.Width;
                    sizeSlider.Value = 10;
                    this.sizeSlider_Scroll(null, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("exceptions: " + ex.ToString());
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            previewButton.Enabled = false;
            int fractionWidth = sizeSlider.Value;
            int fractionHeight = (sizeSlider.Value * imageWell.Image.Height) / imageWell.Image.Width;
            ImageLogic imageLogic = new ImageLogic(imageWell.Image);

            Task<Image> backgroundImageLoad = new Task<Image>(() => 
            {
                Image newImage = imageLogic.CreatePreview(fractionWidth, fractionHeight);
                return newImage;
            });
            backgroundImageLoad.ContinueWith((antecedent) =>
            {
                progressBar.Visible = false;
                previewButton.Enabled = true;
                Image resultImage = antecedent.Result;
                previewForm.SetImage(resultImage);
                previewForm.SetCheckBox(false);
                previewForm.woolIndeces = imageLogic.lastWoolIndeces.ToArray();
                if (previewForm.Visible == false)
                {
                    previewForm.Show();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

            backgroundImageLoad.Start();            
        }

        private void sizeSlider_Scroll(object sender, EventArgs e)
        {
            int fractionHeight = (sizeSlider.Value * imageWell.Image.Height) / imageWell.Image.Width;
            sizeLabel.Text = sizeSlider.Value.ToString() + " x " + fractionHeight.ToString();
        }

        /***TESTER***/
        private void SaveFile(Image image)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }
    }
}
