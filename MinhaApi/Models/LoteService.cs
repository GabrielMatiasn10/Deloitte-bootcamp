using MinhaApi.Models;

namespace MinhaApi.Services
{
    public class LoteService
    {
        // -------------------------------------
        // 1) Classificação de qualidade
        // -------------------------------------
        public string ClassificarQualidade(LoteMinerio lote)
        {
            if (lote.TeorFe >= 65 && lote.Umidade <= 6 && lote.SiO2 <= 3)
                return "Premium";

            if (lote.TeorFe >= 62 && lote.Umidade <= 8)
                return "Padrão";

            return "Baixa";
        }

        // -------------------------------------
        // 2) Cálculo de preço por tonelada
        // -------------------------------------
        public decimal CalcularPrecoPorTonelada(LoteMinerio lote)
        {
            var qualidade = ClassificarQualidade(lote);

            return qualidade switch
            {
                "Premium" => 185.50m,
                "Padrão"  => 156.90m,
                "Baixa" => 98.00m
            };
        }

        public decimal CalcularValorTotal(LoteMinerio lote)
        {
            var preco = CalcularPrecoPorTonelada(lote);
            return preco * lote.Toneladas;
        }

        // -------------------------------------
        // 3) Histórico de movimentação
        // -------------------------------------
        public void RegistrarMovimentacao(LoteMinerio lote, string local, StatusLote novoStatus)
        {
            lote.Historico.Add(new HistoricoMovimentacao
            {
                Local = local,
                Status = novoStatus,
                Data = DateTime.UtcNow
            });

            lote.LocalizacaoAtual = local;
            lote.Status = novoStatus;
        }

        // -------------------------------------
        // 4) Avançar status do lote
        // -------------------------------------
        public void AvancarStatus(LoteMinerio lote)
        {
            var novoStatus = lote.Status switch
            {
                StatusLote.EmEstoque     => StatusLote.EmTransporte,
                StatusLote.EmTransporte  => StatusLote.Embarcado,
                StatusLote.Embarcado     => throw new InvalidOperationException("Lote já está embarcado."),
                _                        => throw new ArgumentOutOfRangeException(nameof(lote.Status))
            };

            RegistrarMovimentacao(
                lote,
                lote.LocalizacaoAtual,
                novoStatus
            );
        }

        // -------------------------------------
        // 5) Penalidade por umidade
        // -------------------------------------
        public decimal CalcularPenalidadeUmidade(LoteMinerio lote)
        {
            if (lote.Umidade <= 8)
                return 0m;

            var excesso = lote.Umidade - 8;
            return excesso * 1.50m * lote.Toneladas;
        }
    }
}