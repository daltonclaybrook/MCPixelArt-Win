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
    public partial class Form2 : Form
    {
        public int[] woolIndeces;
        private PixelationBox pixelBox;

        public Form2()
        {
            InitializeComponent();
            pixelBox = new PixelationBox();
            pixelBox.Location = new Point(12, 12);
            pixelBox.Size = new Size(614, 390);
            pixelBox.BorderStyle = BorderStyle.Fixed3D;
            pixelBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pixelBox);
        }

        public void SetImage(Image image) 
        {
            pixelBox.Image = image;
        }

        public void SetCheckBox(bool isChecked)
        {
            airCheckBox.Checked = isChecked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Schematic schematic = new Schematic();
            Size size = new Size(pixelBox.Image.Width, pixelBox.Image.Height);
            byte[] byteArray = schematic.CreateSchematic(woolIndeces, size, airCheckBox.Checked);

            if (byteArray != null)
            {
                SaveFile(byteArray);
            }
            else
            {
                Console.WriteLine("Byte array is null");
            }
        }

        private void SaveFile(byte[] byteArray)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "MCEdit Schematic|*.schematic";
            saveFileDialog1.Title = "Save a Schematic File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    // Open file for reading
                    System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                    // Writes a block of bytes to this stream using data from a byte array.
                    fs.Write(byteArray, 0, byteArray.Length);

                    // close file stream
                    fs.Close();
                }
                catch (Exception _Exception)
                {
                    // Error
                    Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                }
            }
        }
    }
}
