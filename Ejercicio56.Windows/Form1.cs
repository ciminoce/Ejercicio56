using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio56.Windows
{
    public partial class frmTemperaturas : Form
    {
        public frmTemperaturas()
        {
            InitializeComponent();
        }
        int cantidadIngresada = 0, cantidadSuperior15 = 0;
        double promedioTemperaturas = 0;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var celsius=double.Parse(txtCelsius.Text);
                if (celsius != 0)
                {

                    cantidadIngresada++;
                    promedioTemperaturas += celsius;
                    if (celsius > 15)
                    {
                        cantidadSuperior15++;
                    }
                    DataGridViewRow r = ConstuirFila();//obtengo la fila en blanco
                    SetearFila(r, celsius);//tengo la fila con datos
                    AgregarFila(r);//Agrego la fila a la grilla

                    MostrarInfoDatosIngresados();

                    InicializarControles();
                }
                else
                {
                    BloquearControles();
                    MessageBox.Show("Proceso finalizado");

                }
            }
        }

        private void MostrarInfoDatosIngresados()
        {
            txtCantTemperaturas.Text = cantidadIngresada.ToString();
            txtSuperiores15.Text= cantidadSuperior15.ToString();
            txtPromedio.Text = promedioTemperaturas.ToString();
        }

        private void InicializarControles()
        {
            txtCelsius.Clear();
            txtCelsius.Focus();
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, double celsius)
        {
            r.Cells[colCelsius.Index].Value= celsius;
            r.Cells[colFah.Index].Value = ConvertirCelsiusFah(celsius);
            r.Cells[colReaumur.Index].Value = ConvertirCelsiusReamur(celsius);
        }

        private DataGridViewRow ConstuirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void BloquearControles()
        {
            txtCelsius.Enabled= false;
            btnOK.Enabled= false;
            btnCancelar.Enabled = false;
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            errorProvider1.Clear();
            if (!double.TryParse(txtCelsius.Text, out double temp)){
                esValido = false;
                errorProvider1.SetError(txtCelsius, "Temperatura mal ingresada");
            }else if (!(temp>=-80 && temp <= 80))
            {
                esValido = false;
                errorProvider1.SetError(txtCelsius, "Temp fuera del rango permitido (-80,80)");
            }
            return esValido;
        }

        private  double ConvertirCelsiusFah(double celsius)
        {
            return 1.8 * celsius + 32;
        }

        private  double ConvertirCelsiusReamur(double celsius)
        {
            return 0.8 * celsius;
        }

    }
}
