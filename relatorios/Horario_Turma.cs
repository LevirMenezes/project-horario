using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexao;
using HorarioSemanal.formularios;

namespace HorarioSemanal
{

    public partial class Horario_Turma : Form
    {

        private Tela_To_Horario telaIntermediaria;
        List<Label> Segunda;
        List<Label> Terca;
        List<Label> Quarta;
        List<Label> Quinta;
        List<Label> Sexta;
        SQLiteDB db = new SQLiteDB();
        public Horario_Turma(Tela_To_Horario tela, string periodo)
        {
            InitializeComponent();
            this.telaIntermediaria = tela;
            Segunda = new List<Label>() { this.Segunda1, this.Segunda2, this.Segunda3, this.Segunda4 };
            Terca = new List<Label>() { this.Terca1, this.Terca2, this.Terca3, this.Terca4 };
            Quarta = new List<Label>() { this.Quarta1, this.Quarta2, this.Quarta3, this.Quarta4 };
            Quinta = new List<Label>() { this.Quinta1, this.Quinta2, this.Quinta3, this.Quinta4 };
            Sexta = new List<Label>() { this.Sexta1, this.Sexta2, this.Sexta3, this.Sexta4 };
            
            

            MostraSegunda(periodo);
            MostraTerca(periodo);
            MostraQuarta(periodo);
            MostraQuinta(periodo);
            MostraSexta(periodo);


        }

        private void MostraSegunda(string periodo)
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("segunda",periodo);
            if (hour.Count > 0)
            {
                int c = 0;

                foreach (var h in hour)
                {
                    if (c == 4)
                    {
                        break;
                    }

                    Segunda[c].Text = db.GetDisciplina(h.disciplina_id);
                    c++;

                }

            }
        }
        private void MostraTerca(string periodo)
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("terca",periodo);
            if (hour.Count > 0)
            {
                int c = 0;

                foreach (var h in hour)
                {
                    if (c == 4)
                    {
                        break;
                    }

                    Terca[c].Text = db.GetDisciplina(h.disciplina_id);
                    c++;

                }

            }
        }
        private void MostraQuarta(string periodo)
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("quarta", periodo);
            if (hour.Count > 0)
            {
                int c = 0;

                foreach (var h in hour)
                {
                    if (c == 4)
                    {
                        break;
                    }

                    Quarta[c].Text = db.GetDisciplina(h.disciplina_id);
                    c++;

                }

            }
        }
        private void MostraQuinta(string periodo)
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("quinta", periodo);
            if (hour.Count > 0)
            {
                int c = 0;

                foreach (var h in hour)
                {
                    if (c == 4)
                    {
                        break;
                    }

                    Quinta[c].Text = db.GetDisciplina(h.disciplina_id);
                    c++;

                }

            }
        }
        private void MostraSexta(string periodo)
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("sexta", periodo);
            if (hour.Count > 0)
            {
                int c = 0;

                foreach (var h in hour)
                {
                    if (c == 4)
                    {
                        break;
                    }

                    Sexta[c].Text = db.GetDisciplina(h.disciplina_id);
                    c++;

                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void VoltarHorario_Click_1(object sender, EventArgs e)
        {
            this.telaIntermediaria.Visible = true;
            
            this.Close();
        }
    }
}
