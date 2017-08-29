using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SistemaEvaluador
{
    public partial class Rangos : Form
    {
        private List<Label> labels;
        private List<TextBox> textBoxs;
        private List<string> grados;
        private float resul;
        private Label l;
        private string text;
        private Label cal;
        public Rangos(List<string> grados,float resul, Label l, string text, Label calificacion)
        {
           this.labels = new List<Label>();
            this.grados = grados;
            this.l = l;
            this.cal = calificacion;
            this.resul = resul;
            this.text = text;
            this.textBoxs = new List<TextBox>();
            InitializeComponent();
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);
            labels.Add(label13);
            labels.Add(label14);
            labels.Add(label15);
            labels.Add(label16);
            textBoxs.Add(textBox1);
            textBoxs.Add(textBox2);
            textBoxs.Add(textBox3);
            textBoxs.Add(textBox4);
            textBoxs.Add(textBox5);
            textBoxs.Add(textBox6);
            textBoxs.Add(textBox7);
            textBoxs.Add(textBox8);
            textBoxs.Add(textBox9);
            textBoxs.Add(textBox10);
            textBoxs.Add(textBox11);
            textBoxs.Add(textBox12);
            textBoxs.Add(textBox13);
            textBoxs.Add(textBox14);
            textBoxs.Add(textBox15);
            textBoxs.Add(textBox16);
            for (int i = 0; i < labels.Count; i++)
            {
                labels.ElementAt(i).Visible = false;
            }
            for (int i = 0; i < textBoxs.Count; i++)
            {
                textBoxs.ElementAt(i).Visible = false;
            }

            asignarGrados();
        }

        private void asignarGrados()
        {
            for (int i = 0; i < grados.Count; i++)
            {
                labels.ElementAt(i).Text = grados.ElementAt(i);
                labels.ElementAt(i).Visible = true;
            }
            for (int i = 0; i < grados.Count*2; i++)
            {
                textBoxs.ElementAt(i).Visible = true;
            }
            for (int i = 9; i < grados.Count; i++)
            {
                labels.ElementAt(i).Visible = true;
            }
        }
        private void Rangos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<float>resultados = new List<float>();
            for (int i = 0; i < grados.Count-1; i++)
            {
                resultados.Add((float)1/(grados.Count+(grados.Count-2))+(float)1/(grados.Count-1)*i);
            }

            float n = 0;
            string texto = text;
            for (int i = 0; i < grados.Count; i++)
            {
               
                    if ( i== 0 && resul<resultados.ElementAt(i) && resul>0)
                    {
                        n = ((2*(grados.Count)) - 2)*(int.Parse(textBoxs.ElementAt(i+1).Text)-int.Parse(textBoxs.ElementAt(i).Text))* resul/((2*i)+1);
                        break;
                    }


                    if (i!= grados.Count-1 && resul < resultados.ElementAt(i))
                    {
                      n = ((float)((int.Parse(textBoxs.ElementAt(i*2+1).Text) - int.Parse(textBoxs.ElementAt(i*2).Text)) *(grados.Count -1)* resul) + int.Parse(textBoxs.ElementAt(i*2).Text) - (float)((int.Parse(textBoxs.ElementAt(i*2+1).Text) - int.Parse(textBoxs.ElementAt(i*2).Text)) * (grados.Count - 1)*((2*i)-1))/((2*grados.Count)-2));
                        break;
                    }
                    else if (i == grados.Count-1 && resul>resultados.ElementAt(i-1) && resul<1)
                    {
                        n = ((((int.Parse(textBoxs.ElementAt(i*2+1).Text) - int.Parse(textBoxs.ElementAt(i*2).Text)) * ((2*grados.Count) - 2) * resul))/((2*grados.Count)-(2*i)-1) + int.Parse(textBoxs.ElementAt(i*2).Text) - (float)((int.Parse(textBoxs.ElementAt(i*2+1).Text) - int.Parse(textBoxs.ElementAt(i*2).Text)) * ((2 * i) - 1)) / ((2 * grados.Count) - (2 * i) - 1));
                        break;
                    }
                
            }
            this.l.Text = texto+" "+ n.ToString();
            this.cal.Text = n.ToString();
            this.Close();
            
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
