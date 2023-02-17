
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conexao

{
    public partial class SQLiteDB
    {
        //database path
        private readonly string dbPath = Path.Combine(@"C:\Users\tipvh003\Source\Repos\HorarioSemanal\Banco", "myhorario.db");
        public SQLiteDB()
        {
            try
            {
                //Creating database, if it doesn't already exist 
                if (!File.Exists(dbPath))
                {
                    var db = new SQLiteConnection(dbPath);

                    #region drops
                    db.Query<Docente>("DROP TABLE IF EXISTS Docente;");
                    db.Query<Ambiente>("DROP TABLE IF EXISTS Ambiente;");
                    db.Query<Disciplina>("DROP TABLE IF EXISTS Disciplina;");
                    db.Query<Horarios>("DROP TABLE IF EXISTS Horarios;");
                    #endregion

                    #region creates

                    db.CreateTable<Docente>();
                    db.CreateTable<Ambiente>();
                    db.CreateTable<Disciplina>();
                    db.CreateTable<Horarios>();

                    #endregion

                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        public void FechaConexao()
        {
            var db = new SQLiteConnection(dbPath);
            db.Close();

        }


        public bool AtualizaHorario(string dia, string periodo, string tempo, string nomeDisciplina = "", string nomeAmbiente = "", string nomeDocente = "")
        {

            var db = new SQLiteConnection(dbPath);
            try
            {
                var existeHorario = GetHorario(dia, periodo, tempo);
                if (existeHorario.Count > 0)
                {

                    if (VerificaExisteDisciplina(nomeDisciplina))
                    {

                        existeHorario[0].disciplina_id = GetIdDisciplina(nomeDisciplina);
                        if (VerificaExisteAmbiente(nomeAmbiente))
                        {

                            existeHorario[0].ambiente_id = GetIdAmbiente(nomeAmbiente);
                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }
                        }
                        else
                        {
                            SQLiteDB.Ambiente ambiente = new SQLiteDB.Ambiente();
                            ambiente.Nome = nomeAmbiente;
                            db.Insert(ambiente);
                            existeHorario[0].ambiente_id = GetIdAmbiente(nomeAmbiente);

                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }

                        }


                    }
                    else
                    {
                        SQLiteDB.Disciplina disciplina = new SQLiteDB.Disciplina();
                        disciplina.Nome = nomeDisciplina;
                        db.Insert(disciplina);
                        existeHorario[0].disciplina_id = GetIdDisciplina(nomeDisciplina);
                        if (VerificaExisteAmbiente(nomeAmbiente))
                        {

                            existeHorario[0].ambiente_id = GetIdAmbiente(nomeAmbiente);
                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }
                        }
                        else
                        {
                            SQLiteDB.Ambiente ambiente = new SQLiteDB.Ambiente();
                            ambiente.Nome = nomeAmbiente;
                            db.Insert(ambiente);
                            existeHorario[0].ambiente_id = GetIdAmbiente(nomeAmbiente);

                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario[0].docente_id = GetIdDocente(nomeDocente);
                            }

                        }

                    }





                    db.RunInTransaction(() =>
                    {
                        db.Update(existeHorario[0]);
                    });
                    return true;
                }
                return false;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Aviso de Erro", e.Message);
                return false;
            }
            finally
            {
                FechaConexao(); // fecha conexão com o banco

            }

        }

        public void NovoHorario(string diaSemana, string periodo, string tempo, string nomeDisciplina, string nomeAmbiente, string nomeDocente)
        {
            var db = new SQLiteConnection(dbPath);

            #region disciplina
            int IdDisci = GetIdDisciplina(nomeDisciplina);
            if (IdDisci == 0)
            {
                Disciplina d = new Disciplina();
                d.Nome = nomeDisciplina;
                db.Insert(d);
                IdDisci = GetIdDisciplina(nomeDisciplina);

            }
            #endregion

            #region Ambiente

            int IdAmbiente = GetIdAmbiente(nomeAmbiente);
            if (IdAmbiente == 0)
            {
                Ambiente ambiente = new Ambiente();
                ambiente.Nome = nomeAmbiente;
                db.Insert(ambiente);
                IdAmbiente = GetIdAmbiente(nomeAmbiente);
            }

            #endregion


            #region Docente
            int IdDoc = GetIdDocente(nomeDocente);
            if (IdDoc == 0)
            {
                Docente doc = new Docente();
                doc.Nome = nomeDocente;
                db.Insert(doc);
                IdDoc = GetIdDocente(nomeDocente);

            }
            
            #endregion


            if (IdDoc != 0 && IdDisci != 0 && IdAmbiente != 0)
            {
                Horarios HorarioTempo = new Horarios();
                HorarioTempo.DiaSemana = diaSemana;
                HorarioTempo.Periodo = periodo;
                HorarioTempo.Tempo = tempo;
                HorarioTempo.disciplina_id = IdDisci;
                HorarioTempo.docente_id = IdDoc;
                HorarioTempo.ambiente_id = IdAmbiente;

               

                db.Insert(HorarioTempo);
               

            }

        }

        public List<Horarios> GetHorario(string nome, string periodo, string tempo = "")
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Horarios>().ToList();
            List<Horarios> lista = new List<Horarios>();

            if (table.Count > 0)
            {
                foreach (var horario in table)
                {
                    if (string.IsNullOrWhiteSpace(tempo))
                    {
                        if (horario.DiaSemana == nome && horario.Periodo == periodo)
                        {
                            lista.Add(horario);
                        }

                    }
                    else
                    {
                        if (horario.DiaSemana == nome && horario.Periodo == periodo && horario.Tempo == tempo)
                        {
                            lista.Add(horario);
                        }
                    }
                }

            }
            return lista;

        }


        public bool VerificaExisteDisciplina(string nome)
        {
            var db = new SQLiteConnection(dbPath);

            var existeDisciplina = db.Query<Disciplina>("select * from Disciplina where nome = ?", nome).FirstOrDefault();
            if (existeDisciplina != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool VerificaExisteAmbiente(string nome)
        {
            var db = new SQLiteConnection(dbPath);

            var existeAmbiente = db.Query<Ambiente>("select * from Ambiente where nome = ?", nome).FirstOrDefault();
            if (existeAmbiente != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool VerificaExisteDocente(string nome)
        {
            var db = new SQLiteConnection(dbPath);

            var existeDocente = db.Query<Docente>("select * from Docente where nome = ?", nome).FirstOrDefault();
            if (existeDocente != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public int GetIdDisciplina(string nome)
        {
            var db = new SQLiteConnection(dbPath);
            var disci = db.Query<Disciplina>("select * from Disciplina where nome = ?", nome).FirstOrDefault();
            if (disci != null)
            {
                return disci.Id;
            }
            return 0;
        }

        public int GetIdAmbiente(string nome)
        {
            var db = new SQLiteConnection(dbPath);
            var ambient = db.Query<Ambiente>("select * from Ambiente where nome = ?", nome).FirstOrDefault();
            if (ambient != null)
            {
                return ambient.Id;
            }
            return 0;
        }

        public int GetIdDocente(string nome)
        {
            var db = new SQLiteConnection(dbPath);
            var doc = db.Query<Docente>("select * from Docente where nome = ?", nome).FirstOrDefault();
            if (doc != null)
            {
                return doc.Id;
            }
            return 0;
        }



        public Disciplina GetNomeDisciplina(int id)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Disciplina>().ToList();

            if (table.Count > 0)
            {
                foreach (Disciplina disc in table)
                {
                    if (disc.Id == id)
                    {
                        return disc;
                    }
                }

            }
            return null;

        }

        public Ambiente GetNomeAmbiente(int id)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Ambiente>().ToList();

            if (table.Count > 0)
            {
                foreach (Ambiente ambient in table)
                {
                    if (ambient.Id == id)
                    {
                        return ambient;
                    }
                }

            }
            return null;

        }

        public Docente GetNomeDocente(int id)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Docente>().ToList();

            if (table.Count > 0)
            {
                foreach (Docente doc in table)
                {
                    if (doc.Id == id)
                    {
                        return doc;
                    }
                }

            }
            return null;

        }



        [Table("Ambiente")]
        public class Ambiente
        {
            [PrimaryKey, AutoIncrement, Column("id")]
            public int Id { get; set; } = 55;
            [Column("nome"), MaxLength(30)]
            public string Nome { get; set; }

        }

        [Table("Disciplina")]
        public class Disciplina
        {
            [PrimaryKey, AutoIncrement, Column("id")]
            public int Id { get; set; } = 55;
            [Column("nome"), MaxLength(30)]
            public string Nome { get; set; }

        }

        [Table("Docente")]
        public class Docente
        {
            [PrimaryKey, AutoIncrement, Column("id")]
            public int Id { get; set; } = 55;
            [Column("nome"), MaxLength(30)]
            public string Nome { get; set; }

        }


        [Table("Horarios")]
        public class Horarios
        {
            [PrimaryKey, AutoIncrement, Column("id")]
            public int Id { get; set; }
            [Column("dia_semana"), MaxLength(30)]
            public string DiaSemana { get; set; }
            [Column("periodo"), MaxLength(30)]
            public string Periodo { get; set; }
            [Column("tempo"), MaxLength(30)]
            public string Tempo { get; set; }
            [Column("disciplina_id"), MaxLength(30)]
            public int disciplina_id { get; set; }
            [Column("docente_id"), MaxLength(30)]
            public int docente_id { get; set; }
            [Column("ambiente_id"), MaxLength(30)]
            public int ambiente_id { get; set; }

        }



    }

}


