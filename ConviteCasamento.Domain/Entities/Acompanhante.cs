namespace ConviteCasamento.Domain.Entities
{
    public class Acompanhante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdConvidado { get; set; }
        public Convidado Convidado { get; set; }
        public bool? IndicaConfirmado { get; set; }
        public DateTime? DataConfirmacao { get; set; }
    }
}
