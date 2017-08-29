using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Grafica : Form
    {
        private float resx1;
        private float resx2;
        private int gradosig;
        private float resx3;
        private float inx;
        private bool solucion;
        private Boolean reverse;

        private List<float> puntas;
        Timer timer = new Timer();
        private List<string> grados;
        SqlConnection con;
        private int id_evaluacion;
        private int i = 0;
        private bool lastLine;
        private int cantidadGrados;
        private List<Label> labels;
        private Label l;
        private List<Label> labels1;
        string text;
        private List<float> resultadosporcat;
        private List<string> resultadosporcattexto;
        public Grafica(int cantidadGrados, float x, float y, float z, List<string> grados,List<float>resultadoporcat, List<string> resultadosporcattexto)
        {
            InitializeComponent();
            resx1 = x;
            this.resultadosporcat = resultadoporcat;
            this.resultadosporcattexto = resultadosporcattexto;
            solucion = false;
            labels = new List<Label>();
            labels1 = new List<Label>();
            this.grados = grados;
            //for (int i = 0; i < grados.Count; i++)
            //{
            //    Label l = new Label();
            //    l.Text = grados[i];
            //    if(i == 0)
            //    l.Location = new Point(i/(grados.Count-1)*pictureBox1.Size.Width,0);
            //    else
            //        l.Location = new Point(i / (grados.Count - 1) * pictureBox1.Size.Width-45, 0);
            //    l.Size = new Size(55,50);
            //    this.Controls.Add(l);
            //}
            gradosig = 0;
            puntas = new List<float>();
            label1.BackColor = Color.Red;
            label2.BackColor = Color.Blue;
            label3.BackColor = Color.Green;
            label4.BackColor = Color.Yellow;
            label5.BackColor = Color.Orange;
            label6.BackColor = Color.Purple;
            label7.BackColor = Color.DeepPink;
            label8.BackColor = Color.Crimson;
            label9.BackColor= Color.Coral;
            label10.BackColor=Color.DarkGoldenrod;
            label11.BackColor = Color.Brown;




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
            labels1.Add(label17);
            labels1.Add(label19);
            labels1.Add(label21);
            labels1.Add(label23);
            labels1.Add(label25);
            labels1.Add(label26);
            labels1.Add(label24);
            labels1.Add(label22);
            labels1.Add(label20);
            labels1.Add(label18);
            labels1.Add(label16);
            label12.Font = new Font(label12.Font.FontFamily, 11);
            label13.Font = new Font(label12.Font.FontFamily, 11);
            label14.Font = new Font(label12.Font.FontFamily, 11);
            label15.Font = new Font(label12.Font.FontFamily, 11);

            for (int i = 0; i < labels.Count; i++)
            {
                labels.ElementAt(i).Visible = false;
                labels1.ElementAt(i).Visible = false;
                labels1.ElementAt(i).Font = new Font(labels1.ElementAt(i).Font.FontFamily,15);
                labels.ElementAt(i).Font = new Font(labels.ElementAt(i).Font.FontFamily, 12);
            }

            for (int j = 0; j < grados.Count; j++)
            {
                labels.ElementAt(j).Visible = true;
                labels1.ElementAt(j).Visible = true;

                labels.ElementAt(j).Text = "  ";
                labels1.ElementAt(j).Text = grados[j];
                labels.ElementAt(j).Width = 55;
            }
            resx2 = y;
            resx3 = z;
            reverse = false;
            this.cantidadGrados = cantidadGrados;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 300;
            timer.Enabled = false;
            inx = 0;
            lastLine = false;


        }
        private void picturebox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        public void set_id_evalucion(int id)
        {
            id_evaluacion = id;
        }

        private void Timer_Tick(object sender, EventArgs p)
        {
            List<float> posiciongrados = new List<float>();
            int inz = i;
            if (reverse)
                inz += 2;

         
            Pen cPen = null;
            switch (inz)
            {
                case 0:
                    cPen = new Pen(Color.Red, 2f);
                    break;
                case 2:
                    cPen = new Pen(Color.Blue, 2f);
                    break;
                case 4:
                    cPen = new Pen(Color.Green, 2f);
                    break;
                case 6:
                    cPen = new Pen(Color.Yellow, 2f);
                    break;
                case 8:
                    cPen = new Pen(Color.Orange, 2f);
                    break;
                case 10:
                    cPen = new Pen(Color.Purple, 2f);
                    break;
                case 12:
                    cPen = new Pen(Color.DeepPink, 2f);
                    break;
                case 14:
                    cPen = new Pen(Color.Crimson, 2f);
                    break;
                case 16:
                    cPen = new Pen(Color.Coral, 2f);
                    break;
                case 18:
                    cPen = new Pen(Color.DarkGoldenrod, 2f);
                    break;
                case 20:
                    cPen = new Pen(Color.Brown, 2f);
                    break;

                default:
                    cPen = new Pen(Color.PowderBlue, 2f);
                    break;
            }
            Graphics e = pictureBox1.CreateGraphics();
            IList<PointF> P;
            if (lastLine)
            {
                e.DrawLine(
                    cPen,
                     new PointF(inx * pictureBox1.Size.Width, 0),
                     new PointF(inx * pictureBox1.Size.Width, pictureBox1.Size.Height ));
                lastLine = false;
                solucion = true;
                Label lf= new Label();
                lf.Size = new System.Drawing.Size(2, 2);
                lf.AutoSize = true;
                lf.Text = grados.ElementAt(grados.Count - 1);
                lf.Left = (int)(inx * pictureBox1.Size.Width-30);
                posiciongrados.Add((int)inx * pictureBox1.Size.Width );
                this.Controls.Add(lf);
                return;
            }
            if (solucion)
            {
                List<float>distancias = new List<float>();
                for (int j = 0; j < puntas.Count; j++)
                {
                    distancias.Add(Math.Abs(resx2 - puntas.ElementAt(j)));
                }
                string nearest = "";
                distancias.Sort();
                for (int w = 0; w < grados.Count; w++)
                {
                    float valor = (float)w / (grados.Count-1);
                    if (valor - distancias.ElementAt(0) == resx2 ||
                        valor + distancias.ElementAt(0) == resx2)
                    {
                        nearest = grados[w];
                        break;
                    }
                }
               l = new Label();
                l.Text =  nearest+ " "+resx2.ToString();
                l.Left =(int)(resx2*pictureBox1.Size.Width-20);
                text = nearest;
                for (int o = 0; o < posiciongrados.Count; o++)
                {
                    //if (posiciongrados.ElementAt(o) + 20 == l.Size.Width ||
                    //    posiciongrados.ElementAt(o) + 20 == l.Size.Width)
                    //{
                    //    Label lo = new Label();
                    //    lo.Text = "fuck";
                    //}
                }
                label13.Text = resx2.ToString();
               this.Controls.Add(l);
                e.DrawLine(
                    new Pen(Color.Black, 3f),
                    new PointF(resx1 * pictureBox1.Size.Width, pictureBox1.Size.Height ), new PointF(resx2 * pictureBox1.Size.Width, 0));
                e.DrawLine(
                        new Pen(Color.Black, 3f),
                        new PointF(resx2 * pictureBox1.Size.Width, 0), new PointF(resx3 * pictureBox1.Size.Width, pictureBox1.Size.Height));
                timer.Enabled = false;

              
                     
              
               return;
            }
            if (!reverse)
            {
                P = calcular_puntos(cantidadGrados);

            }
            else
            {
                P = calcular_puntos_reverse(cantidadGrados);
            }

            e.DrawLine(
                    cPen,
                    new PointF(P.ElementAt(i).X * pictureBox1.Size.Width, P.ElementAt(i).Y * pictureBox1.Size.Height ), new PointF((float)P.ElementAt(i + 1).X * pictureBox1.Size.Width, P.ElementAt(i + 1).Y * pictureBox1.Size.Height ));
            Label la = new Label();
            la.Size = new System.Drawing.Size(2, 2);
            la.AutoSize = true;
            if (gradosig < cantidadGrados-1)
            {
                la.Text = grados.ElementAt(gradosig);
              

            }
            la.Left = (int)(P.ElementAt(i).X * pictureBox1.Size.Width);
            posiciongrados.Add((int)P.ElementAt(i).X * pictureBox1.Size.Width);
            this.Controls.Add(la);
            gradosig++;
            i += 2;
            if (i >= P.Count)
            {
                if (reverse)
                {

                    lastLine = true;
                    i -= 2;
                    return;

                }
                inx = (float)P.ElementAt(P.Count - 1).X;
                reverse = true;

                i = 0;
            }




        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.DrawLine(
            new Pen(Color.Red, 2f),
            new Point(0, 0),
            new Point(0, pictureBox1.Size.Height));
            e.Graphics.DrawLine(
               new Pen(Color.Black, 2f),
               new Point(0, pictureBox1.Size.Height),
               new Point(pictureBox1.Size.Width, pictureBox1.Size.Height));
            timer.Enabled = true;

        }

        private IList<PointF> calcular_puntos(int n_indicadores)
        {
            IList<PointF> puntos = new List<PointF>();

            for (int i = 0; i < n_indicadores - 1; i++)
            {

                if (i == 0)
                {
                    puntos.Add(new PointF(0, 0));
                }
                else
                {
                    puntos.Add(new PointF((float)i /(n_indicadores-1), 0));
                }
                puntos.Add(new PointF((float)(i + 1) / (n_indicadores-1), 1));
               
            }
           
            return puntos;
        }

        private IList<PointF> calcular_puntos_reverse(int n_indicadores)
        {
            IList<PointF> puntos = new List<PointF>();
            puntas.Add(0);
            for (int i = 1; i < n_indicadores; i++)
            {

                puntos.Add(new PointF((float)i / (n_indicadores-1), 0));
               
                    if (puntas.ElementAt(puntas.Count-1) != (float)i / (n_indicadores - 1)) 
                      puntas.Add((float) i/(n_indicadores - 1));
                
                puntos.Add(new PointF((float)(i - 1) / (n_indicadores-1), 1));

            }
            return puntos;
        }


        private void Grafica_Load(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                // Draw next line and...

                g.DrawLine(new Pen(Color.Red, 2f), new Point(0, 0), new Point(pictureBox1.Size.Width, pictureBox1.Size.Height));

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CambioRangos r = new CambioRangos(grados, resx2, l, text, label15);
            r.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportToBmp(@System.IO.Directory.GetCurrentDirectory()+"\\imagen.jpg");
            if (label15.Text != "")
            {
                Terminos_y_resultado tr = new Terminos_y_resultado(resultadosporcat, resultadosporcattexto, resx2,
                    float.Parse(label15.Text));
                tr.ShowDialog();
            }
            else
            {
                Terminos_y_resultado tr = new Terminos_y_resultado(resultadosporcat, resultadosporcattexto, resx2,
                    0);
                tr.ShowDialog();
            }
            
        }
        public void ExportToBmp(string path)
        {
            using (var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height))
            {
                pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
                ImageFormat imageFormat = null;

                var extension = Path.GetExtension(path);
                switch (extension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".jpeg":
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    default:
                        throw new NotSupportedException("File extension is not supported");
                }

                bitmap.Save(path, imageFormat);
            }
        }

        private void nuevaEvaluacion_Click(object sender, EventArgs e)
        {
            EmpleadosComboBox emp = new EmpleadosComboBox(con,id_evaluacion);
            emp.MdiParent = this.MdiParent;
            emp.Show();
            this.Close();
        }

        public void set_con(SqlConnection con)
        {
            this.con = con;
        }
    }
}
