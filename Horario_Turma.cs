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

namespace HorarioSemanal
{

    public partial class Horario_Turma : Form
    {

        private Tela_Principal telaPrincipal;
        List<Label> Segunda;
        List<Label> Terca;
        List<Label> Quarta;
        List<Label> Quinta;
        List<Label> Sexta;
        SQLiteDB db = new SQLiteDB();
        public Horario_Turma(Tela_Principal tela)
        {
            InitializeComponent();
            this.telaPrincipal = tela;
            Segunda = new List<Label>() { this.Segunda1, this.Segunda2, this.Segunda3, this.Segunda4 };
            Terca = new List<Label>() { this.Terca1, this.Terca2, this.Terca3, this.Terca4 };
            Quarta = new List<Label>() { this.Quarta1, this.Quarta2, this.Quarta3, this.Quarta4 };
            Quinta = new List<Label>() { this.Quinta1, this.Quinta2, this.Quinta3, this.Quinta4 };
            Sexta = new List<Label>() { this.Sexta1, this.Sexta2, this.Sexta3, this.Sexta4 };
            
            

            MostraSegunda();
            MostraTerca();
            MostraQuarta();
            MostraQuinta();
            MostraSexta();


        }

        private void MostraSegunda()
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("segunda");
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
        private void MostraTerca()
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("terca");
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
        private void MostraQuarta()
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("quarta");
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
        private void MostraQuinta()
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("quinta");
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
        private void MostraSexta()
        {
            List<SQLiteDB.Horarios> hour = db.GetHorario("sexta");
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



        private void button1_Click_1(object sender, EventArgs e)
        {
            this.telaPrincipal.Visible = true;
            this.telaPrincipal.button1.Visible = true;
            this.Close();
        }
    }
}
