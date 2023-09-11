using Microsoft.VisualBasic;

namespace PilaLIFO
{
    public partial class Form1 : Form
    {
        Pila P;

        public Form1()
        {
            InitializeComponent();
            P = new Pila();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Mostrar(Pila pPila)
        {
            listBox1.Items.Clear();

            //declaro e instancio pila auxiliar
            Pila pilaAux = new Pila();
            //desapilar el nodo de la pila original y lo apunto con auxNodo
            Nodo auxNodo = pPila.Desapilar();

            while (auxNodo != null)
            {
                //muestro el id del nodo desapilado en el listbox
                listBox1.Items.Add(auxNodo.ID);

                //apilo en la pila auxiliar el nodo desapilado de la pila original
                pilaAux.Apilar(auxNodo.ID);

                //desapilo el proximo nodo
                auxNodo = pPila.Desapilar();


            }
            //restituyo la pila original
            auxNodo = pilaAux.Desapilar();
            while (auxNodo != null)
            {
                //apilo en la pila original el nodo despapilado
                pPila.Apilar(auxNodo.ID);

                //desapilo el proximo nodo 
                auxNodo = pilaAux.Desapilar();


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            var id = Interaction.InputBox("ID: ");
            P.Apilar(id);
            Mostrar(P);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Nodo auxNodo = P.Desapilar();

            if (auxNodo == null) throw new Exception("No hay mas nodos pa desapilar");

            Mostrar(P);
            MessageBox.Show(auxNodo.ID);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Nodo auxNodo = P.Ver();
                if (auxNodo == null) throw new Exception("No hay mas nodos para ver ");
                MessageBox.Show(auxNodo.ID);


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    public class Pila
    {
        Nodo NCP; 

        public Pila()
        {
            NCP = new Nodo();
            NCP.SIGUIENTE = null;
        }

        public void Apilar(string pId)
        {
            if (NCP.SIGUIENTE == null)
            {
                NCP.SIGUIENTE = new Nodo(pId);


            }
            else
            {
                Nodo aux = new Nodo(pId, NCP.SIGUIENTE);
                NCP.SIGUIENTE = aux;

            }

        }


        public Nodo Desapilar()
        {
            if (NCP.SIGUIENTE == null)
            {
                return NCP.SIGUIENTE;
            }
            else
            {
                Nodo aux = NCP.SIGUIENTE;
                NCP.SIGUIENTE = aux.SIGUIENTE;
                aux.SIGUIENTE = null;
                return aux;
            }

        }

        public Nodo Ver()
        {
            if (NCP.SIGUIENTE == null)
            {
                return NCP.SIGUIENTE;
            }
            else
            {
                return new Nodo(NCP.SIGUIENTE.ID);
            }


        }

    }

    public class Nodo
    {
        public string ID { get; set; }

        public Nodo SIGUIENTE { get; set; }

        public Nodo(string pID = "", Nodo pSIGUIENTE = null)
        {
            ID = pID;   SIGUIENTE = pSIGUIENTE;

        }

        


    }
}