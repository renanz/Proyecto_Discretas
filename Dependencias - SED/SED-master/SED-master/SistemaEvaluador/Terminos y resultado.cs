using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Novacode;

namespace SistemaEvaluador
{
    public partial class Terminos_y_resultado : Form
    {
        private List<float> results;
        private List<string> cats;
        private List<float> bigcats;
        private float indice;
        private float calif;
        public Terminos_y_resultado(List<float> results, List<string> cats, float indice, float calif)
        {
            InitializeComponent();
            this.results = results;
            this.cats = cats;
            this.bigcats = new List<float>();
            this.indice = indice;
            this.calif = calif;
        }

        private void Terminos_y_resultado_Load(object sender, EventArgs e)
        {
            float result = 0;
            int contador = 0;

            List<int> fin = new List<int>();
            for (int i = 0; i < cats.Count; i++)
            {

                if (i > 0)
                {
                    if (cats.ElementAt(i).Contains("--"))
                    {
                        contador++;
                    }
                    else
                    {
                        fin.Add(contador);
                        contador = 0;
                    }
                    if (i == cats.Count - 1)
                        fin.Add(contador);

                }
            }

            result = 0;
            int pos = 0;
            int parainsertar = 0;
            for (int i = 0; i < fin.Count; i++)
            {
                for (int j = 0; j < fin.ElementAt(i); j++)
                {
                    result += results.ElementAt(pos + j);
                }
                results.Insert(parainsertar, result);
                result = 0;
                if (pos == 0)
                    pos += fin.ElementAt(i) + 1;
                else
                    pos += fin.ElementAt(i);
                parainsertar += fin.ElementAt(i) + 1;

            }

            Resultadofinal.Text = indice.ToString();
            Idesempeño.Text = calif.ToString();
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 16);
            for (int i = 0; i < cats.Count; i++)
                richTextBox1.Text += cats.ElementAt(i) + ": " + results.ElementAt(i).ToString() + "\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @System.IO.Directory.GetCurrentDirectory() + "\\Doc";
            string headlineText = "Resultado";
            string paraOne = richTextBox1.Text;

            // A formatting object for our headline:


            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            // Insert the now text obejcts;

            Paragraph headline = doc.InsertParagraph(headlineText);
            headline.Color(Color.Black);
            headline.Font(new FontFamily("Tahoma"));
            headline.Bold();
            headline.Position(12D);
            headline.FontSize(18D);
            doc.InsertParagraph(paraOne, false, paraFormat);
            doc.AddImage(@System.IO.Directory.GetCurrentDirectory() + "\\imagen.jpg");
            // Save to the output directory:
            doc.Save();

            // Open in Word:
            Process.Start("WINWORD.EXE", fileName);
        }
    }
}
