using HorarioSemanal.formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorarioSemanal
{
    public partial class Tela_Principal : Form
    {
        public Tela_Principal()
        {
            InitializeComponent();
            
        }

        

        private void VerHorario_Click(object sender, EventArgs e)
        {
            Tela_To_Horario tela_to_horario = new Tela_To_Horario(this);
            tela_to_horario.Show();
            this.Visible = false;

        }

        private void AlterarHorario_Click(object sender, EventArgs e)
        {
            Tela_To_Horario tela_to_horario = new Tela_To_Horario(this, true);
            tela_to_horario.Show();
            this.Visible = false;
        }
    }
}
