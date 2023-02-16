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


namespace HorarioSemanal.formularios
{
    public partial class Tela_Cadastro : Form
    {
        private SQLiteDB db;
        private Tela_To_Horario telaIntermediaria;
        private string periodo;
        public Tela_Cadastro(Tela_To_Horario tela, string periodo)
        {
            InitializeComponent();
            this.telaIntermediaria = tela;
            this.periodo = periodo;
            MostraSegunda(periodo);
            MostraTerca(periodo);
            MostraQuarta(periodo);
            MostraQuinta(periodo);
            MostraSexta(periodo);



        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.telaIntermediaria.Visible = true;

            this.Close();
        }

        private void MostraSegunda(string periodo, bool salvar = false)
        {

            try
            {
                if (salvar == false)
                {
                    this.db = new SQLiteDB();
                    List<SQLiteDB.Horarios> hour = this.db.GetHorario("segunda", periodo);
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
                                TxtSeg1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSeg1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSeg1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                            }
                            else if (c == 1)
                            {
                                TxtSeg2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSeg2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSeg2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 2)
                            {
                                TxtSeg3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSeg3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSeg3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 3)
                            {
                                TxtSeg4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSeg4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSeg4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }

                            c++;

                        }

                    }

                }
                else
                {
                    this.db = new SQLiteDB();


                    this.db.AtualizaHorario("segunda", periodo, "1", TxtSeg1.Text, AmbSeg1.Text, ProfSeg1.Text);
                    TxtSeg1.Text = "";

                    TxtSeg2.Text = "";

                    TxtSeg3.Text = "";

                    TxtSeg4.Text = "";





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

        private void MostraTerca(string periodo, bool salvar = false)
        {
            try
            {
                if (!salvar)
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
                                TxtTer1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfTer1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbTer1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                            }
                            else if (c == 1)
                            {
                                TxtTer2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfTer2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbTer2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 2)
                            {
                                TxtTer3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfTer3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbTer3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 3)
                            {
                                TxtTer4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfTer4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbTer4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }

                            c++;

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
        private void MostraQuarta(string periodo, bool salvar = false)
        {

            try
            {
                if (!salvar)
                {
                    this.db = new SQLiteDB();
                    List<SQLiteDB.Horarios> hour = this.db.GetHorario("quarta", periodo);
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
                                TxtQua1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQua1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQua1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                            }
                            else if (c == 1)
                            {
                                TxtQua2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQua2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQua2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 2)
                            {
                                TxtQua3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQua3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQua3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 3)
                            {
                                TxtQua4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQua4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQua4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }

                            c++;

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
        private void MostraQuinta(string periodo, bool salvar = false)
        {

            try
            {
                if (!salvar)
                {
                    this.db = new SQLiteDB();
                    List<SQLiteDB.Horarios> hour = this.db.GetHorario("quinta", periodo);
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
                                TxtQui1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQui1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQui1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                            }
                            else if (c == 1)
                            {
                                TxtQui2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQui2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQui2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 2)
                            {
                                TxtQui3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQui3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQui3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 3)
                            {
                                TxtQui4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfQui4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbQui4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }

                            c++;

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


        private void MostraSexta(string periodo, bool salvar = false)
        {

            try
            {
                if (!salvar)
                {
                    this.db = new SQLiteDB();
                    List<SQLiteDB.Horarios> hour = this.db.GetHorario("sexta", periodo);
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
                                TxtSex1.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSex1.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSex1.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;

                            }
                            else if (c == 1)
                            {
                                TxtSex2.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSex2.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSex2.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 2)
                            {
                                TxtSex3.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSex3.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSex3.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }
                            else if (c == 3)
                            {
                                TxtSex4.Text = this.db.GetNomeDisciplina(h.disciplina_id).Nome;
                                ProfSex4.Text = this.db.GetNomeDocente(h.docente_id).Nome;
                                AmbSex4.Text = this.db.GetNomeAmbiente(h.ambiente_id).Nome;
                            }

                            c++;

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




    }
}
