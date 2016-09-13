using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class calculadora : Form
    {
        /// <summary>
        /// al crearse la calculadora se ingresan los operadoresen el 
        /// </summary>
        public calculadora()
        {
            InitializeComponent();

            this.cmbOperacion.Items.Add("+");
            this.cmbOperacion.Items.Add("-");
            this.cmbOperacion.Items.Add("*");
            this.cmbOperacion.Items.Add("/");
        }
        /// <summary>
        /// Metodo del btnLimpiar, al presionarlo se llama almetodo limpiar()que borra los valores ingresados en los label y cuadros de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
         }
        /// <summary>
        /// Metodo que se ejecuta al pesionar el boton = , inicializa los numeros y llama a la clase operar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 =new Numero(this.txtNumero1.Text);
            Numero num2 = new Numero(this.txtNumero2.Text);
            Calculadora operar = new Calculadora();
            string operador = operar.Validar(this.cmbOperacion.Text);

            double resp = operar.Operar(num1,num2, operador);

            this.lblResultado.Text = "Resultado: " + resp.ToString();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblResultado_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Borra los valores ingresados en los label y cuadros de texto
        /// </summary>
        public void Limpiar()
        {
            this.lblResultado.Text = " ";
            this.cmbOperacion.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = ""; 
        }


  
    }
}
