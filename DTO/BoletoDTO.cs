using System.ComponentModel.DataAnnotations;

namespace ApiTesteTecnico
{
    public class BoletoDTO
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "O Nome do Pagador é Obrigatório!")]
        public string NomePagador { get; set; }

        [Required(ErrorMessage = @"O CPF/CNPJ do Pagador é Obrigatório!")]
        public string CPFCNPJPagador { get; set; }

        [Required(ErrorMessage = "O Nome do Beneficiário é Obrigatório!")]
        public string NomeBeneficiario { get; set; }

        [Required(ErrorMessage = @"O CPF/CNPJ do Beneficiário é Obrigatório!")]
        public string CPFCNPJBeneficiario { get; set; }

        [Required(ErrorMessage = "O Valor é Obrigatório!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A Data de Vencimento é Obrigatória!")]
        public DateTime DataVencimento { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "A identificação do Banco é Obrigatória!")]
        public int IdBanco { get; set; }  
    }
}
