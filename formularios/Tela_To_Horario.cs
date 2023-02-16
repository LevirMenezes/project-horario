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
        private bool alterar;

        public Tela_To_Horario(Tela_Principal tela, bool alterar = false)
        {
            InitializeComponent();
            this.telaPrincipal = tela;
            this.alterar = alterar;
        }

        private void VoltarTelaPrincipal_Click(object sender, EventArgs e)
        {
            this.telaPrincipal.Visible = true;

            this.Close();
        }

        private void HorarioPeriodo1_Click(object sender, EventArgs e)
        {
            if (!alterar)
            {
                // Se for clicado no botao de ver horario, irá trazer a variavel alterar = false.
                // Então se alterar=false e a condição do if for !alterar, nessa caso irá executar esse bloco de ações.
                Horario_Turma horarioTurma = new Horario_Turma(this, "1");
                horarioTurma.Show();
                this.Visible = false;

            }
            else
            {
                // Se for clicado no botao de alterar horario, irá trazer a variavel alterar = true.
                // Então se alterar=true e a condição do if for !alterar, nessa caso irá executar esse bloco de ações.
                Tela_Cadastro telaCadastro = new Tela_Cadastro(this, "1");
                telaCadastro.Show();
                this.Visible = false;
            }


        }

        private void HorarioPeriodo3_Click(object sender, EventArgs e)
        {
            if (!alterar)
            {
                // Se for clicado no botao de ver horario, irá trazer a variavel alterar = false.
                // Então se alterar=false e a condição do if for !alterar, nessa caso irá executar esse bloco de ações.
                Horario_Turma horarioTurma = new Horario_Turma(this, "3");
                horarioTurma.Show();
                this.Visible = false;

            }
            else
            {
                // Se for clicado no botao de alterar horario, irá trazer a variavel alterar = true.
                // Então se alterar=true e a condição do if for !alterar, nessa caso irá executar esse bloco de ações.
                Tela_Cadastro telaCadastro = new Tela_Cadastro(this, "3");
                telaCadastro.Show();
                this.Visible = false;
            }
        }

        private void HorarioPeriodo5_Click(object sender, EventArgs e)
        {
            if (!alterar)
            {
                // Se for clicado no botao de ver horario, irá trazer a variavel alterar = false.
                // Então se alterar=false e a condição do if for !alterar, nessa caso irá executar esse bloco de ações.
                Horario_Turma horarioTurma = new Horario_Turma(this, "5");
                horarioTurma.Show();
                this.Visible = false;

            }
            else
            {
                // Se for clicado no botao de alterar horario, irá trazer a variavel alterar = true.
                // Então se alterar=true e a condição do if for !alterar, nessa caso irá executar esse bloco de ações.
                Tela_Cadastro telaCadastro = new Tela_Cadastro(this, "5");
                telaCadastro.Show();
                this.Visible = false;
            }
        }
    }
}
