using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace pdf_processor_1._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadCustom(string thm)
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

            string[] lines = File.ReadAllLines(strWorkPath + "/" + thm + ".txt");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Image";
            openDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                source = openDialog.FileName;

                string output = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save";
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    output = saveDialog.FileName;

                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(source);

                    using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (Document doc = new Document(image))
                        {
                            using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                            {
                                doc.Open();
                                image.SetAbsolutePosition(0, 0);
                                writer.DirectContent.AddImage(image);
                                doc.Close();
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Choose PDF";
            openDialog.Filter = "PDF File (*.pdf)|*.pdf";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                file = openDialog.FileName;

                PdfReader reader = new PdfReader(file);
                string fileshort = file.Substring(0, file.Length - 4);

                string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C {strWorkPath}\\gs9.53.3\\bin\\gswin64c.exe -sDEVICE=pdfwrite -dCompatibilityLevel=1.4 -dPDFSETTINGS=/ebook -dNOPAUSE -dQUIET -dBATCH -sOutputFile={fileshort + "-compressed.pdf"} {file}";
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
