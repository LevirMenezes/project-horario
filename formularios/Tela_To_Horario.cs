using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorarioSemanal.formularios
{
    public partial class Tela_To_Horario : Form
    {
        private Tela_Principal telaPrincipal;
        
        public Tela_To_Horario(Tela_Principal tela, bool alterar=false)
        {
            InitializeComponent();
            this.telaPrincipal = tela;
        }

        private void VoltarTelaPrincipal_Click(object sender, EventArgs e)
        {
            this.telaPrincipal.Visible = true;
            
            this.Close();
        }

        private void HorarioPeriodo1_Click(object sender, EventArgs e)
        {
            Horario_Turma horarioTurma = new Horario_Turma(this, "1");
            horarioTurma.Show();
            this.Visible = false;

            
        }

        private void HorarioPeriodo3_Click(object sender, EventArgs e)
        {
            Horario_Turma horarioTurma = new Horario_Turma(this, "3");
            horarioTurma.Show();
            this.Visible = false;
        }

        private void HorarioPeriodo5_Click(object sender, EventArgs e)
        {
            Horario_Turma horarioTurma = new Horario_Turma(this, "5");
            horarioTurma.Show();
            this.Visible = false;
        }
    }
}
