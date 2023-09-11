using System.Windows.Forms;

namespace Hanoi_Towers
{
    public partial class Form1 : Form
    {

        Pila p1, p2, p3, paux;
        int intentos = 0;

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.LightGray;
            panel2.BackColor = Color.LightGray;
            panel3.BackColor = Color.LightGray;

        }


        private void MueveFicha(Pila pPilaorigen, Pila pPiladestino, ListBox pListboxOrigen, ListBox pListboxDestino, Panel panelOrigen, Panel panelDestino)
        {
            if (pPilaorigen.Ver() != null)
            {
                if (pPiladestino.Ver() != null)
                {
                    if (int.Parse(pPilaorigen.Ver().ID) < int.Parse(pPiladestino.Ver().ID))
                    {
                        pPiladestino.Apilar(pPilaorigen.Desapilar().ID);
                    }
                }
                else
                {
                    pPiladestino.Apilar(pPilaorigen.Desapilar().ID);
                }
                intentos++;
                Mostrar(pPilaorigen, pListboxOrigen, panelOrigen);
                Mostrar(pPiladestino, pListboxDestino, panelDestino);
                ControlaGanador();
            }
        }








        private void Mostrar(Pila pPila, ListBox pListbox, Panel pPanel)
        {
            // Limpiar ListBox y Panel para una nueva visualización
            pListbox.Items.Clear();
            pPanel.Controls.Clear();

            // Inicializar posición de dibujo para el Panel
            int yPosition = pPanel.Height - 20;

            List<string> ids = new List<string>();

            // Desapilar elementos para mostrar en ListBox
            while (pPila.Ver() != null)
            {
                Nodo naux = pPila.Desapilar();
                ids.Add(naux.ID);
                paux.Apilar(naux.ID);
            }

            // Dibujar los discos en el orden correcto en el panel y repoblar el ListBox
            for (int i = ids.Count - 1; i >= 0; i--)
            {
                // Dibuja el disco en el panel
                int diskWidth = int.Parse(ids[i]) * 20;  // El tamaño del disco se basa en su valor
                int xPosition = (pPanel.Width - diskWidth) / 2;  // Centrar el disco en el panel

                System.Windows.Forms.Label disk = new System.Windows.Forms.Label();
                disk.SetBounds(xPosition, yPosition, diskWidth, 15);
                disk.BackColor = System.Drawing.Color.Red;  // Color del disco

                pPanel.Controls.Add(disk);

                yPosition -= 20;  // Subir la posición para el siguiente disco

                // Agregar al ListBox en el orden correcto
                pListbox.Items.Insert(0, ids[i]);  // Inserta el elemento al inicio
            }

            // Restaurar elementos a la pila original desde la lista de ids
            for (int i = 0; i < ids.Count; i++)
            {
                pPila.Apilar(ids[i]);
            }

            // Actualizar contador de intentos
            label2.Text = intentos.ToString();
        }



        private void button7_Click(object sender, EventArgs e)
        {
            MueveFicha(p3, p2, listBox3, listBox2, panel3, panel2);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MueveFicha(p1, p2, listBox1, listBox2, panel1, panel2);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MueveFicha(p1, p3, listBox1, listBox3, panel1, panel3);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MueveFicha(p2, p1, listBox2, listBox1, panel2, panel1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MueveFicha(p2, p3, listBox2, listBox3, panel2, panel3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MueveFicha(p3, p1, listBox3, listBox1, panel3, panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiaCrea();
            // Cargamos la primera pila con los discos que indica el usuario
            for (int x = (int)numericUpDown1.Value; x > 0; x--)
            {
                p1.Apilar(x.ToString());
            }
            // Mostramos la pila en un ListBox y en un Panel
            intentos = 0;
            Mostrar(p1, listBox1, panel1);
            Mostrar(p2, listBox2, panel2);
            Mostrar(p3, listBox3, panel3);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ControlaGanador()
        {
            if ((p1.Ver() == null && p2.Ver() == null) || (p1.Ver() == null && p3.Ver() == null))
            {
                MessageBox.Show("Ganador !!!");
                LimpiaCrea();
            }
        }


        private void LimpiaCrea()
        {
            // Creamos las pilas
            p1 = new Pila(); p2 = new Pila(); p3 = new Pila(); paux = new Pila();
            // Limpiamos los listboxs
            listBox1.Items.Clear(); listBox2.Items.Clear(); listBox3.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }




    public class Pila
    {
        Nodo CU;

        public Pila()
        {
            CU = new Nodo();  //nodo centinela ultimo
        }

        public void Apilar(string pID)
        {
            Nodo aux = new Nodo(pID);
            if (CU.SIGUIENTE == null)
            {
                CU.SIGUIENTE = aux;

            }
            else
            {
                aux.SIGUIENTE = CU.SIGUIENTE;
                CU.SIGUIENTE = aux;
            }
        }

        public Nodo Desapilar()
        {
            Nodo aux = CU.SIGUIENTE;
            if (aux != null)
            {
                CU.SIGUIENTE = aux.SIGUIENTE;
                aux.SIGUIENTE = null;
            }
            return aux;


        }

        public Nodo Ver()
        {
            Nodo aux = CU.SIGUIENTE;
            if (aux != null)
            {
                aux = new Nodo(CU.SIGUIENTE.ID);
            }
            return aux;
        }











    }

    public class Nodo
    {
        public string ID { get; set; }

        public Nodo SIGUIENTE { get; set; }

        public Nodo(string pID = "")
        {
            ID = pID; SIGUIENTE = null;

        }
    }
}