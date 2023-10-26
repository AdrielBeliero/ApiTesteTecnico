using System.ComponentModel.DataAnnotations;

namespace ApiTesteTecnico
{
    public class BancoDTO
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "O Nome do Banco é Obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Código do Banco é Obrigatório!")]
        public string CodigoBanco { get; set; }

        [Required(ErrorMessage = "O Percentual de Juros Obrigatório!")]
        public decimal PercentualJuros { get; set; }
    }
}
