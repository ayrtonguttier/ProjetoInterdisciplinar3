namespace ProjInter3.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
    }
}
