namespace VendendoPecas.Models
{
    public class VendasModel
    {
        public int Id { get; set; }
        public string Comprador { get; set; }
        public string Vendedor { get; set; }
        public string PecaVendida { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
