using System.ComponentModel.DataAnnotations;

namespace VendendoPecas.Models
{
    public class VendasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Comprador!")]
        public string Comprador { get; set; }

        [Required(ErrorMessage = "Digite o nome do Vendedor!")]
        public string Vendedor { get; set; }

        [Required(ErrorMessage = "Digite o nome da Peça Vendida!")]
        public string PecaVendida { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
