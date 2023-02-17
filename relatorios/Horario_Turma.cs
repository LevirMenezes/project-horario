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
                            this.TxtSeg1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSeg1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSeg1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (h.Tempo == "2")
                        {
                            this.TxtSeg2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSeg2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSeg2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (h.Tempo == "3")
                        {
                            this.TxtSeg3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSeg3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSeg3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (h.Tempo == "4")
                        {
                            this.TxtSeg4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfSeg4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbSeg4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
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
                            this.TxtTer1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfTer1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbTer1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtTer2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfTer2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbTer2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtTer3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfTer3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbTer3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtTer4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfTer4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbTer4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
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
                            this.TxtQua1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQua1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQua1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtQua2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQua2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQua2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtQua3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQua3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQua3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtQua4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQua4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQua4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
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
                            this.TxtQui1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQui1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQui1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                        }
                        else if (c == 1)
                        {
                            this.TxtQui2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQui2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQui2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 2)
                        {
                            this.TxtQui3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQui3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQui3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                        }
                        else if (c == 3)
                        {
                            this.TxtQui4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                            this.ProfQui4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                            this.AmbQui4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
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
