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
using static Conexao.SQLiteDB;


namespace HorarioSemanal.formularios
{
    public partial class Tela_Cadastro : Form
    {
        private SQLiteDB db;
        private Tela_To_Horario telaIntermediaria;
        private string Periodo;
        public Tela_Cadastro(Tela_To_Horario tela, string periodo)
        {
            InitializeComponent();
            this.telaIntermediaria = tela;
            this.Periodo = periodo;
            NumPeriodo.Text = periodo;
            MostraSegunda(Periodo);
            MostraTerca(Periodo);
            MostraQuarta(Periodo);
            MostraQuinta(Periodo);
            MostraSexta(Periodo);



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

                    string diaSemana = "segunda";

                    
                    
                    bool AlterBancoSeg1 = this.db.AtualizaHorario(diaSemana, periodo, "1", TxtSeg1.Text, AmbSeg1.Text, ProfSeg1.Text);
                    if (!AlterBancoSeg1)
                    {
                        db.NovoHorario(diaSemana, periodo, "1", TxtSeg1.Text, AmbSeg1.Text, ProfSeg1.Text);
                    }

                    bool AlterBancoSeg2 = this.db.AtualizaHorario(diaSemana, periodo, "2", TxtSeg2.Text, AmbSeg2.Text, ProfSeg2.Text);
                    if (!AlterBancoSeg2)
                    {
                        db.NovoHorario(diaSemana, periodo, "2", TxtSeg2.Text, AmbSeg2.Text, ProfSeg2.Text);
                    }

                    bool AlterBancoSeg3 = this.db.AtualizaHorario(diaSemana, periodo, "3", TxtSeg3.Text, AmbSeg3.Text, ProfSeg3.Text);
                    if (!AlterBancoSeg3)
                    {
                        db.NovoHorario(diaSemana, periodo, "3", TxtSeg3.Text, AmbSeg3.Text, ProfSeg3.Text);
                    }

                    bool AlterBancoSeg4 = this.db.AtualizaHorario(diaSemana, periodo, "4", TxtSeg4.Text, AmbSeg4.Text, ProfSeg4.Text);
                    if (!AlterBancoSeg4)
                    {
                        db.NovoHorario(diaSemana, periodo, "4", TxtSeg4.Text, AmbSeg4.Text, ProfSeg4.Text);




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
                else
                {
                    this.db = new SQLiteDB();
                    string diaSemana = "terca";

                    bool AlterBancoTer1 = this.db.AtualizaHorario(diaSemana, periodo, "1", TxtTer1.Text, AmbTer1.Text, ProfTer1.Text);
                    if (!AlterBancoTer1)
                    {
                        db.NovoHorario(diaSemana, periodo, "1", TxtTer1.Text, AmbTer1.Text, ProfTer1.Text);
                    }

                    bool AlterBancoTer2 = this.db.AtualizaHorario(diaSemana, periodo, "2", TxtTer2.Text, AmbTer2.Text, ProfTer2.Text);
                    if (!AlterBancoTer2)
                    {
                        db.NovoHorario(diaSemana, periodo, "2", TxtTer2.Text, AmbTer2.Text, ProfTer2.Text);
                    }

                    bool AlterBancoTer3 = this.db.AtualizaHorario(diaSemana, periodo, "3", TxtTer3.Text, AmbTer3.Text, ProfTer3.Text);
                    if (!AlterBancoTer3)
                    {
                        db.NovoHorario(diaSemana, periodo, "3", TxtTer3.Text, AmbTer3.Text, ProfTer3.Text);
                    }

                    bool AlterBancoTer4 = this.db.AtualizaHorario(diaSemana, periodo, "4", TxtTer4.Text, AmbTer4.Text, ProfTer4.Text);
                    if (!AlterBancoTer4)
                    {
                        db.NovoHorario(diaSemana, periodo, "4", TxtTer4.Text, AmbTer4.Text, ProfTer4.Text);
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
                else
                {
                    this.db = new SQLiteDB();
                    string diaSemana = "quarta";

                    bool AlterBancoQua1 = this.db.AtualizaHorario(diaSemana, periodo, "1", TxtQua1.Text, AmbQua1.Text, ProfQua1.Text);
                    if (!AlterBancoQua1)
                    {
                        db.NovoHorario(diaSemana, periodo, "1", TxtQua1.Text, AmbQua1.Text, ProfQua1.Text);
                    }

                    bool AlterBancoQua2 = this.db.AtualizaHorario(diaSemana, periodo, "2", TxtQua2.Text, AmbQua2.Text, ProfQua2.Text);
                    if (!AlterBancoQua2)
                    {
                        db.NovoHorario(diaSemana, periodo, "2", TxtQua2.Text, AmbQua2.Text, ProfQua2.Text);
                    }

                    bool AlterBancoQua3 = this.db.AtualizaHorario(diaSemana, periodo, "3", TxtQua3.Text, AmbQua3.Text, ProfQua3.Text);
                    if (!AlterBancoQua3)
                    {
                        db.NovoHorario(diaSemana, periodo, "3", TxtQua3.Text, AmbQua3.Text, ProfQua3.Text);
                    }

                    bool AlterBancoQua4 = this.db.AtualizaHorario(diaSemana, periodo, "4", TxtQua4.Text, AmbQua4.Text, ProfQua4.Text);
                    if (!AlterBancoQua4)
                    {
                        db.NovoHorario(diaSemana, periodo, "4", TxtQua4.Text, AmbQua4.Text, ProfQua4.Text);
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
                else
                {
                    this.db = new SQLiteDB();
                    string diaSemana = "quinta";
                    

                    bool AlterBancoQui1 = this.db.AtualizaHorario(diaSemana, periodo, "1", TxtQui1.Text, AmbQui1.Text, ProfQui1.Text);
                    if (!AlterBancoQui1)
                    {
                        db.NovoHorario(diaSemana, periodo, "1", TxtQui1.Text, AmbQui1.Text, ProfQui1.Text);
                    }

                    bool AlterBancoQui2 = this.db.AtualizaHorario(diaSemana, periodo, "2", TxtQui2.Text, AmbQui2.Text, ProfQui2.Text);
                    if (!AlterBancoQui2)
                    {
                        db.NovoHorario(diaSemana, periodo, "2", TxtQui2.Text, AmbQui2.Text, ProfQui2.Text);
                    }

                    bool AlterBancoQui3 = this.db.AtualizaHorario(diaSemana, periodo, "3", TxtQui3.Text, AmbQui3.Text, ProfQui3.Text);
                    if (!AlterBancoQui3)
                    {
                        db.NovoHorario(diaSemana, periodo, "3", TxtQui3.Text, AmbQui3.Text, ProfQui3.Text);
                    }

                    bool AlterBancoQui4 = this.db.AtualizaHorario(diaSemana, periodo, "4", TxtQui4.Text, AmbQui4.Text, ProfQui4.Text);
                    if (!AlterBancoQui4)
                    {
                        db.NovoHorario(diaSemana, periodo, "4", TxtQui4.Text, AmbQui4.Text, ProfQui4.Text);
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
                else
                {
                    this.db = new SQLiteDB();
                    string diaSemana = "sexta";

                    bool AlterBancoSex1 = this.db.AtualizaHorario(diaSemana, periodo, "1", TxtSex1.Text, AmbSex1.Text, ProfSex1.Text);
                    if (!AlterBancoSex1) 
                    {
                        db.NovoHorario(diaSemana, periodo, "1", TxtSex1.Text, AmbSex1.Text, ProfSex1.Text);
                    }

                    bool AlterBancoSex2 = this.db.AtualizaHorario(diaSemana, periodo, "2", TxtSex2.Text, AmbSex2.Text, ProfSex2.Text);
                    if (!AlterBancoSex2)
                    {
                        db.NovoHorario(diaSemana, periodo, "2", TxtSex2.Text, AmbSex2.Text, ProfSex2.Text);
                    }

                    bool AlterBancoSex3 = this.db.AtualizaHorario(diaSemana, periodo, "3", TxtSex3.Text, AmbSex3.Text, ProfSex3.Text);
                    if (!AlterBancoSex3)
                    {
                        db.NovoHorario(diaSemana, periodo, "3", TxtSex3.Text, AmbSex3.Text, ProfSex3.Text);
                    }

                    bool AlterBancoSex4 = this.db.AtualizaHorario(diaSemana, periodo, "4", TxtSex4.Text, AmbSex4.Text, ProfSex4.Text);

                    if (!AlterBancoSex4)
                    {
                        db.NovoHorario(diaSemana, periodo, "4", TxtSex4.Text, AmbSex4.Text, ProfSex4.Text);
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

        private void Btn_SalvarCadastro_Click(object sender, EventArgs e)
        {
            MostraSegunda(Periodo, true);
            MostraTerca(Periodo, true);
            MostraQuarta(Periodo, true);
            MostraQuinta(Periodo, true);
            MostraSexta(Periodo, true);
            this.telaIntermediaria.Visible = true;
            this.Close();
        }
    }
}
