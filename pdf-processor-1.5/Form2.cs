using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace pdf_processor_1._5
{
    public partial class Form2 : Form
    {
        List<string> InFiles = new List<string>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Select more PDFs";

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select PDF";
            openDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                InFiles.Add(openDialog.FileName);

                textBox1.Text = $"PDF Count: {InFiles.Count}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string OutFile = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                OutFile = saveDialog.FileName;

                using (FileStream stream = new FileStream(OutFile, FileMode.Create))
                using (Document doc = new Document())
                using (PdfCopy pdf = new PdfCopy(doc, stream))
                {
                    doc.Open();

                    PdfReader reader = null;
                    PdfImportedPage page = null;

                    InFiles.ForEach(file =>
                    {
                        reader = new PdfReader(file);

                        for (int i = 0; i < reader.NumberOfPages; i++)
                        {
                            page = pdf.GetImportedPage(reader, i + 1);
                            pdf.AddPage(page);
                        }

                        pdf.FreeReader(reader);
                        reader.Close();
                    });
                }
            }

            this.Close();
        }
    }
}
