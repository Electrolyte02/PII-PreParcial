using CarpinteriaApp.datos;
using RecetasSLN.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultar : Form
    {
        IServicio gestor;
        public FrmConsultar()
        {
            InitializeComponent();
            gestor = new Servicio.Implementacion.Servicio();
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            CargarCombo();
        }

        private void CargarCombo()
        {
            cboClientes.Items.AddRange(gestor.ObtenerClientes().ToArray());
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> lParams = new List<Parametro>();
            if (cboClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Elegir un cliente!");
                return;
            }
            if (dtpDesde.Value>dtpHasta.Value)
            {
                MessageBox.Show("Debe Ingresar fechas validas! la fecha desde es mayor que la fecha hasta");
                return;
            }
            if (dtpHasta.Value>DateTime.UtcNow)
            {
                MessageBox.Show("Debe Ingresar fecha maxima valida!");
                return;
            }
            ClienteDTO cliente = (ClienteDTO)cboClientes.SelectedItem;
            lParams.Add(new Parametro("@cliente", cliente.Id));
            lParams.Add(new Parametro("@fecha_desde",dtpDesde.Value));
            lParams.Add(new Parametro("@fecha_hasta",dtpHasta.Value));
            List<PedidoDTO> lPedidos = gestor.ObtenerPedidos(lParams);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?","Salir",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Completar...
        }
    }
}
