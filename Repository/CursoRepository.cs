using System.Data;
using Ead2808.Models;
using Microsoft.Data.SqlClient;
using Ead2808.Data;

namespace Ead2808.Repository
{
    public class CursoRepository
    {
            public void Add(Curso curso)
            {
                using var conn = Db.GetConnection();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Curso (NomeCurso) VALUES (@NomeCurso)";
                cmd.AddParameter("@NomeCurso", curso.NomeCurso);
                cmd.ExecuteNonQuery();
            }
            
        public List<Curso> GetCursos()
        {
            var cursos = new List<Curso>();
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IdCurso, NomeCurso FROM Curso";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var curso = new Curso
                {
                    IdCurso = reader.GetInt32(0),
                    NomeCurso = reader.GetString(1)
                };
                cursos.Add(curso);
            }
            return cursos;
        }

    }
}