namespace Ead2808.Models
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; } 
    }
}