using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;

namespace pdf_processor_1._5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);

            string file = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select PDF";
            openDialog.Filter = "PDF File (*.pdf)|*.pdf";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                file = openDialog.FileName;

                PdfReader reader = new PdfReader(file);

                PdfDictionary page = reader.GetPageN(n);
                PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
                int rotation =
                    rotate == null ? 90 : (rotate.IntValue + 90) % 360;

                page.Put(PdfName.ROTATE, new PdfNumber(rotation));
                string fileshort = file.Substring(0, file.Length - 4);

                PdfStamper stamper = new PdfStamper(reader, new FileStream(fileshort + "-rotated.pdf", FileMode.Create));
                stamper.Close();
                reader.Close();
            }
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}
