
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


        public bool AtualizaHorario(string dia, string periodo, string tempo, string nomeDisciplina="", string nomeAmbiente="", string nomeDocente = "")
        {
           
            var db = new SQLiteConnection(dbPath);
            try
            {
                var existeHorario = db.Query<Horarios>(@"SELECT * FROM Horarios
WHERE dia_semana = '?' AND periodo = '?' AND tempo = '?';", dia, periodo, tempo).FirstOrDefault();
                if (existeHorario != null)
                {

                    if (VerificaExisteDisciplina(nomeDisciplina))
                    {
                        
                        existeHorario.disciplina_id = GetIdDisciplina(nomeDisciplina);
                        if (VerificaExisteAmbiente(nomeAmbiente))
                        {

                            existeHorario.ambiente_id = GetIdAmbiente(nomeAmbiente);
                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }
                        }
                        else
                        {
                            SQLiteDB.Ambiente ambiente = new SQLiteDB.Ambiente();
                            ambiente.Nome = nomeAmbiente;
                            db.Insert(ambiente);
                            existeHorario.ambiente_id = GetIdAmbiente(nomeAmbiente);
                            
                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }

                        }
                        

                    }
                    else
                    {
                        SQLiteDB.Disciplina disciplina = new SQLiteDB.Disciplina();
                        disciplina.Nome = nomeDisciplina;
                        db.Insert(disciplina);
                        existeHorario.disciplina_id = GetIdDisciplina(nomeDisciplina);
                        if (VerificaExisteAmbiente(nomeAmbiente))
                        {

                            existeHorario.ambiente_id = GetIdAmbiente(nomeAmbiente);
                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }
                        }
                        else
                        {
                            SQLiteDB.Ambiente ambiente = new SQLiteDB.Ambiente();
                            ambiente.Nome = nomeAmbiente;
                            db.Insert(ambiente);
                            existeHorario.ambiente_id = GetIdAmbiente(nomeAmbiente);

                            if (VerificaExisteDocente(nomeDocente))
                            {
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }
                            else
                            {

                                SQLiteDB.Docente docente = new SQLiteDB.Docente();
                                docente.Nome = nomeDocente;
                                db.Insert(docente);
                                existeHorario.docente_id = GetIdDocente(nomeDocente);
                            }

                        }

                    }
                    




                    db.RunInTransaction(() =>
                    {
                        db.Update(existeHorario);
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

        public void InsertSegunda()
        {
            var db = new SQLiteConnection(dbPath);
            db.Query<Disciplina>("DROP TABLE IF EXISTS Disciplina");
            db.Query<Docente>("DROP TABLE IF EXISTS Docente");
            db.Query<Ambiente>("DROP TABLE IF EXISTS Ambiente");
            db.CreateTable<Disciplina>();
            db.CreateTable<Docente>();
            db.CreateTable<Ambiente>();
            #region disciplina
            Disciplina d = new Disciplina();
            d.Nome = "Analise e Desenvolvimento de Sistemas";
            db.Insert(d);
            var DisciplinaTB = db.Table<Disciplina>();
            int IdDisci = 0;
            foreach (var disc in DisciplinaTB)
            {
                if (disc.Nome == "Analise e Desenvolvimento de Sistemas")
                {
                    IdDisci = disc.Id;
                }

            }
            #endregion

            #region Ambiente
            Ambiente ambiente = new Ambiente();
            ambiente.Nome = "Laboratorio 3";
            db.Insert(ambiente);
            var AmbienteTB = db.Table<Ambiente>();
            int IdAmbiente = 0;
            foreach (var amb in AmbienteTB)
            {
                if (amb.Nome == "Laboratorio 3")
                {
                    IdAmbiente = amb.Id;
                }

            }
            #endregion


            #region Docente
            Docente doc = new Docente();
            doc.Nome = "Prof. Leandro";
            db.Insert(doc);
            var DocenteTB = db.Table<Docente>();
            int IdDoc = 0;
            foreach (var docente in DocenteTB)
            {
                if (docente.Nome == "Prof. Leandro")
                {
                    IdDoc = docente.Id;
                }

            }
            #endregion


            if (IdDoc != 0 && IdDisci != 0 && IdAmbiente != 0)
            {
                Horarios s1 = new Horarios();
                s1.DiaSemana = "segunda";
                s1.Periodo = "1";
                s1.Tempo = "1";
                s1.disciplina_id = IdDisci;
                s1.docente_id = IdDoc;
                s1.ambiente_id = IdAmbiente;

                Horarios s2 = new Horarios();
                s2.DiaSemana = "segunda";
                s2.Periodo = "1";
                s2.Tempo = "2";
                s2.disciplina_id = IdDisci;
                s2.docente_id = IdDoc;
                s2.ambiente_id = IdAmbiente;

                Horarios s3 = new Horarios();
                s3.DiaSemana = "segunda";
                s3.Periodo = "1";
                s3.Tempo = "3";
                s3.disciplina_id = IdDisci;
                s3.docente_id = IdDoc;
                s3.ambiente_id = IdAmbiente;

                Horarios s4 = new Horarios();
                s4.DiaSemana = "segunda";
                s4.Periodo = "1";
                s4.Tempo = "4";
                s4.disciplina_id = IdDisci;
                s4.docente_id = IdDoc;
                s4.ambiente_id = IdAmbiente;

                db.Insert(s1);
                db.Insert(s2);
                db.Insert(s3);
                db.Insert(s4);

            }

        }

        public void InsertTerca()
        {
            var db = new SQLiteConnection(dbPath);

            #region disciplina
            Disciplina d = new Disciplina();
            d.Nome = "Logica de Programacão";
            db.Insert(d);
            var DisciplinaTB = db.Table<Disciplina>();
            int IdDisci = 0;
            foreach (var disc in DisciplinaTB)
            {
                if (disc.Nome == "Logica de Programacão")
                {
                    IdDisci = disc.Id;
                }

            }
            #endregion

            #region Ambiente

            var AmbienteTB = db.Table<Ambiente>();
            int IdAmbiente = 0;
            foreach (var amb in AmbienteTB)
            {
                if (amb.Nome == "Laboratorio 3")
                {
                    IdAmbiente = amb.Id;
                }

            }
            #endregion


            #region Docente
            Docente doc = new Docente();
            doc.Nome = "Profa. Elisângela";
            db.Insert(doc);
            var DocenteTB = db.Table<Docente>();
            int IdDoc = 0;
            foreach (var docente in DocenteTB)
            {
                if (docente.Nome == "Profa. Elisângela")
                {
                    IdDoc = docente.Id;
                }

            }
            #endregion


            if (IdDoc != 0 && IdDisci != 0 && IdAmbiente != 0)
            {
                Horarios t1 = new Horarios();
                t1.DiaSemana = "terca";
                t1.Periodo = "1";
                t1.Tempo = "1";
                t1.disciplina_id = IdDisci;
                t1.docente_id = IdDoc;
                t1.ambiente_id = IdAmbiente;

                Horarios t2 = new Horarios();
                t2.DiaSemana = "terca";
                t2.Periodo = "1";
                t2.Tempo = "2";
                t2.disciplina_id = IdDisci;
                t2.docente_id = IdDoc;
                t2.ambiente_id = IdAmbiente;

                Horarios t3 = new Horarios();
                t3.DiaSemana = "terca";
                t3.Periodo = "1";
                t3.Tempo = "3";
                t3.disciplina_id = IdDisci;
                t3.docente_id = IdDoc;
                t3.ambiente_id = IdAmbiente;

                Horarios t4 = new Horarios();
                t4.DiaSemana = "terca";
                t4.Periodo = "1";
                t4.Tempo = "4";
                t4.disciplina_id = IdDisci;
                t4.docente_id = IdDoc;
                t4.ambiente_id = IdAmbiente;

                db.Insert(t1);
                db.Insert(t2);
                db.Insert(t3);
                db.Insert(t4);

            }

        }

        public void InsertQuarta()
        {
            var db = new SQLiteConnection(dbPath);

            #region disciplina
            Disciplina d = new Disciplina();
            d.Nome = "Banco de Dados";
            db.Insert(d);
            var DisciplinaTB = db.Table<Disciplina>();
            int IdDisci = 0;
            foreach (var disc in DisciplinaTB)
            {
                if (disc.Nome == "Banco de Dados")
                {
                    IdDisci = disc.Id;
                }

            }
            #endregion

            #region Ambiente


            var AmbienteTB = db.Table<Ambiente>();
            int IdAmbiente = 0;
            foreach (var amb in AmbienteTB)
            {
                if (amb.Nome == "Laboratorio 3")
                {
                    IdAmbiente = amb.Id;
                }

            }
            #endregion


            #region Docente
            Docente doc = new Docente();
            doc.Nome = "Profa. Sabrina";
            db.Insert(doc);
            var DocenteTB = db.Table<Docente>();
            int IdDoc = 0;
            foreach (var docente in DocenteTB)
            {
                if (docente.Nome == "Profa. Sabrina")
                {
                    IdDoc = docente.Id;
                }

            }
            #endregion


            if (IdDoc != 0 && IdDisci != 0 && IdAmbiente != 0)
            {
                Horarios qua1 = new Horarios();
                qua1.DiaSemana = "quarta";
                qua1.Periodo = "1";
                qua1.Tempo = "1";
                qua1.disciplina_id = IdDisci;
                qua1.docente_id = IdDoc;
                qua1.ambiente_id = IdAmbiente;

                Horarios qua2 = new Horarios();
                qua2.DiaSemana = "quarta";
                qua2.Periodo = "1";
                qua2.Tempo = "2";
                qua2.disciplina_id = IdDisci;
                qua2.docente_id = IdDoc;
                qua2.ambiente_id = IdAmbiente;

                Horarios qua3 = new Horarios();
                qua3.DiaSemana = "quarta";
                qua3.Periodo = "1";
                qua3.Tempo = "3";
                qua3.disciplina_id = IdDisci;
                qua3.docente_id = IdDoc;
                qua3.ambiente_id = IdAmbiente;

                Horarios qua4 = new Horarios();
                qua4.DiaSemana = "quarta";
                qua4.Periodo = "1";
                qua4.Tempo = "4";
                qua4.disciplina_id = IdDisci;
                qua4.docente_id = IdDoc;
                qua4.ambiente_id = IdAmbiente;

                db.Insert(qua1);
                db.Insert(qua2);
                db.Insert(qua3);
                db.Insert(qua4);

            }

        }

        public void InsertQuinta()
        {
            var db = new SQLiteConnection(dbPath);

            #region disciplina
            Disciplina d = new Disciplina();
            d.Nome = "Sistemas Operacionais";
            db.Insert(d);
            var DisciplinaTB = db.Table<Disciplina>();
            int IdDisci = 0;
            foreach (var disc in DisciplinaTB)
            {
                if (disc.Nome == "Sistemas Operacionais")
                {
                    IdDisci = disc.Id;
                }

            }
            #endregion

            #region Ambiente


            var AmbienteTB = db.Table<Ambiente>();
            int IdAmbiente = 0;
            foreach (var amb in AmbienteTB)
            {
                if (amb.Nome == "Laboratorio 3")
                {
                    IdAmbiente = amb.Id;
                }

            }
            #endregion


            #region Docente
            Docente doc = new Docente();
            doc.Nome = "Prof. Fernando";
            db.Insert(doc);
            var DocenteTB = db.Table<Docente>();
            int IdDoc = 0;
            foreach (var docente in DocenteTB)
            {
                if (docente.Nome == "Prof. Fernando")
                {
                    IdDoc = docente.Id;
                }

            }
            #endregion


            if (IdDoc != 0 && IdDisci != 0 && IdAmbiente != 0)
            {
                Horarios qui1 = new Horarios();
                qui1.DiaSemana = "quinta";
                qui1.Periodo = "1";
                qui1.Tempo = "1";
                qui1.disciplina_id = IdDisci;
                qui1.docente_id = IdDoc;
                qui1.ambiente_id = IdAmbiente;

                Horarios qui2 = new Horarios();
                qui2.DiaSemana = "quinta";
                qui2.Periodo = "1";
                qui2.Tempo = "2";
                qui2.disciplina_id = IdDisci;
                qui2.docente_id = IdDoc;
                qui2.ambiente_id = IdAmbiente;

                Horarios qui3 = new Horarios();
                qui3.DiaSemana = "quinta";
                qui3.Periodo = "1";
                qui3.Tempo = "3";
                qui3.disciplina_id = IdDisci;
                qui3.docente_id = IdDoc;
                qui3.ambiente_id = IdAmbiente;

                Horarios qui4 = new Horarios();
                qui4.DiaSemana = "quinta";
                qui4.Periodo = "1";
                qui4.Tempo = "4";
                qui4.disciplina_id = IdDisci;
                qui4.docente_id = IdDoc;
                qui4.ambiente_id = IdAmbiente;

                db.Insert(qui1);
                db.Insert(qui2);
                db.Insert(qui3);
                db.Insert(qui4);

            }

        }

        public void InsertSexta()
        {
            var db = new SQLiteConnection(dbPath);

            #region disciplina
            Disciplina d = new Disciplina();
            d.Nome = "Educação Física";
            db.Insert(d);
            var DisciplinaTB = db.Table<Disciplina>();
            int IdDisci = 0;
            foreach (var disc in DisciplinaTB)
            {
                if (disc.Nome == "Educação Física")
                {
                    IdDisci = disc.Id;
                }

            }
            #endregion

            #region Ambiente


            var AmbienteTB = db.Table<Ambiente>();
            int IdAmbiente = 0;
            foreach (var amb in AmbienteTB)
            {
                if (amb.Nome == "Laboratorio 3")
                {
                    IdAmbiente = amb.Id;
                }

            }
            #endregion


            #region Docente
            Docente doc = new Docente();
            doc.Nome = "Profa. Iranira";
            db.Insert(doc);
            var DocenteTB = db.Table<Docente>();
            int IdDoc = 0;
            foreach (var docente in DocenteTB)
            {
                if (docente.Nome == "Profa. Iranira")
                {
                    IdDoc = docente.Id;
                }

            }
            #endregion


            if (IdDoc != 0 && IdDisci != 0 && IdAmbiente != 0)
            {
                Horarios sex1 = new Horarios();
                sex1.DiaSemana = "sexta";
                sex1.Periodo = "1";
                sex1.Tempo = "1";
                sex1.disciplina_id = IdDisci;
                sex1.docente_id = IdDoc;
                sex1.ambiente_id = IdAmbiente;

                Horarios sex2 = new Horarios();
                sex2.DiaSemana = "sexta";
                sex2.Periodo = "1";
                sex2.Tempo = "2";
                sex2.disciplina_id = IdDisci;
                sex2.docente_id = IdDoc;
                sex2.ambiente_id = IdAmbiente;

                Horarios sex3 = new Horarios();
                sex3.DiaSemana = "sexta";
                sex3.Periodo = "1";
                sex3.Tempo = "3";
                sex3.disciplina_id = IdDisci;
                sex3.docente_id = IdDoc;
                sex3.ambiente_id = IdAmbiente;

                Horarios sex4 = new Horarios();
                sex4.DiaSemana = "sexta";
                sex4.Periodo = "1";
                sex4.Tempo = "4";
                sex4.disciplina_id = IdDisci;
                sex4.docente_id = IdDoc;
                sex4.ambiente_id = IdAmbiente;

                db.Insert(sex1);
                db.Insert(sex2);
                db.Insert(sex3);
                db.Insert(sex4);

            }

        }

        public List<Horarios> GetHorario(string nome, string periodo)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Horarios>().ToList();
            List<Horarios> lista = new List<Horarios>();
            if (table.Count > 0)
            {
                foreach (var horario in table)
                {
                    if (horario.DiaSemana == nome && horario.Periodo == periodo)
                    {
                        lista.Add(horario);
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


