namespace ConviteCasamento.Domain.Entities
{
    public class Convidado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IndicaAcompanhante { get; set; }
        public bool? IndicaConfirmado { get; set; }
        public DateTime? DataConfirmacao { get; set; }
        public int? QuantidadeAcompanhantes { get; set; }
        public string CodigoAcesso { get; set; } // 🔹 Código único para acesso

        // Relacionamento
        public List<Acompanhante> Acompanhantes { get; set; } = new();
    }
}
