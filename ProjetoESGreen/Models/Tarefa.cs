using System;

namespace ProjetoESGreen.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Pendente,
        EmAndamento,
        Concluido
    }
}
