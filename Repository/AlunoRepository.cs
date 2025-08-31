using System.Data;
using Ead2808.Models;
using Microsoft.Data.SqlClient;
using Ead2808.Data;

namespace Ead2808.Repository
{
    public class AlunoRepository
    {
        public void Add(Aluno aluno)
        {
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Aluno (Nome, Email, DataNascimento) VALUES (@Nome, @Email, @DataNascimento)";
            cmd.AddParameter("@Nome", aluno.Nome);
            cmd.AddParameter("@Email", aluno.Email);
            cmd.AddParameter("@DataNascimento", aluno.DataNascimento, DbType.DateTime2);

            cmd.ExecuteNonQuery();
        }
        public List<Aluno> GetAlunos()
        {
            var alunos = new List<Aluno>();
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IdAluno, Nome, Email, DataNascimento FROM Aluno";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var aluno = new Aluno
                {
                    IdAluno = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    DataNascimento = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                };
                alunos.Add(aluno);
            }
            return alunos;
        }


        public IEnumerable<Aluno> GetAll()
        {
            var alunos = new List<Aluno>();
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IdAluno, Nome, Email, DataNascimento FROM Aluno";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var aluno = new Aluno
                {
                    IdAluno = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    DataNascimento = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                };
                alunos.Add(aluno);
            }
            return alunos;
        }

    }
}