using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi.Models
{
    public enum StatusLote
    {
        EmEstoque = 0,
        EmTransporte = 1,
        Embarcado = 2
    }

    public class LoteMinerio
    {
        public int Id { get; set; }

        public string CodigoLote { get; set; } = ""; 
        public string MinaOrigem { get; set; } = ""; 

        // Definindo precisão: total de 18 dígitos, sendo 2 após a vírgula
        [Column(TypeName = "numeric(18,2)")]
        public decimal TeorFe { get; set; } 
        
        [Column(TypeName = "numeric(18,2)")]
        public decimal Umidade { get; set; } 

        [Column(TypeName = "numeric(18,2)")]
        public decimal? SiO2 { get; set; } 

        [Column(TypeName = "numeric(18,2)")]
        public decimal? P { get; set; } 

        [Column(TypeName = "numeric(18,2)")]
        public decimal Toneladas { get; set; } 

        public DateTime DataProducao { get; set; } 
        public StatusLote Status { get; set; } 
        public string LocalizacaoAtual { get; set; } = ""; 
    }
}