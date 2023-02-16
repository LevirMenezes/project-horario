using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private SQLiteDB db;
        private string Periodo;
        public Horario_Turma(Tela_To_Horario tela, string periodo)
        {
            InitializeComponent();
            this.telaIntermediaria = tela;

            this.Periodo = periodo;


            


        }

        private void MostraSegunda(string periodo)
        {
            try
            {
                this.db = new SQLiteDB();

                List<SQLiteDB.Horarios> hour = db.GetHorario("segunda", periodo);
                if (hour.Count > 0)
                {
                    

                    foreach (var h in hour)
                    {
                       
                        if (h.Tempo == "1")
                        {
                            this.TxtSex1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (h.Tempo == "2")
                        {
                            this.TxtSex2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (h.Tempo == "3")
                        {
                            this.TxtSex3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (h.Tempo == "4")
                        {
                            this.TxtSex4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                       

                    }

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Aviso de Erro", e.Message);
            }
            finally
            {
                this.db.FechaConexao(); // fecha conexão com o banco
            }

        }
        private void MostraTerca(string periodo)
        {
            try
            {
                this.db = new SQLiteDB();

                List<SQLiteDB.Horarios> hour = db.GetHorario("terca", periodo);
                if (hour.Count > 0)
                {
                    int c = 0;

                    foreach (var h in hour)
                    {
                        if (c == 4)
                        {
                            break;
                        }
                        else if (c == 0)
                        {
                            this.TxtSex1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtSex2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtSex3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtSex4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        c++;

                    }

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Aviso de Erro", e.Message);
            }
            finally
            {
                this.db.FechaConexao(); // fecha conexão com o banco
            }

        }
        private void MostraQuarta(string periodo)
        {
            try
            {
                this.db = new SQLiteDB();

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
                        else if (c == 0)
                        {
                            this.TxtSex1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtSex2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtSex3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtSex4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        c++;

                    }

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Aviso de Erro", e.Message);
            }
            finally
            {
                this.db.FechaConexao(); // fecha conexão com o banco
            }

        }
        private void MostraQuinta(string periodo)
        {
            try
            {
                this.db = new SQLiteDB();

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
                        else if (c == 0)
                        {
                            this.TxtSex1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtSex2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtSex3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtSex4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        c++;

                    }

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Aviso de Erro", e.Message);
            }
            finally
            {
                this.db.FechaConexao(); // fecha conexão com o banco
            }

        }
        private void MostraSexta(string periodo)
        {
            try
            {
                this.db = new SQLiteDB();

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
                        else if (c == 0)
                        {
                            this.TxtSex1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtSex2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtSex3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtSex4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSex4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSex4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }

                        c++;

                    }

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Aviso de Erro", e.Message);
            }
            finally
            {
                this.db.FechaConexao(); // fecha conexão com o banco
            }

        }

        private void VoltarHorario_Click_1(object sender, EventArgs e)
        {
            this.telaIntermediaria.Visible = true;

            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            MostraSegunda(Periodo);
            MostraTerca(Periodo);
            MostraQuarta(Periodo);
            MostraQuinta(Periodo);
            MostraSexta(Periodo);
        }
    }
}
