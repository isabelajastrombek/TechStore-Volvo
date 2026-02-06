namespace TechStore.Application.Services;

using TechStore.Domain.Entities;
public class PagamentoService {
    public Cartao GerarTokenSimulado(string numeroCompletoCartao, int clienteId, string cpfCartao, string dataExpiracao, string tipoCartao, string apelidoCartao, string nomeNoCartao) {
        
        string ultimosDigitos = numeroCompletoCartao.Substring(numeroCompletoCartao.Length - 4);
        
        return new Cartao {
            IdCliente = clienteId,
            NumeroMascarado = $"**** **** **** {ultimosDigitos}",
            CpfCartao = cpfCartao,
            DataExpiracao = dataExpiracao,
            TipoCartao = tipoCartao,
            ApelidoCartao = apelidoCartao,
            NomeNoCartao = nomeNoCartao,

            TokenPagamento = "TOK_" + Guid.NewGuid().ToString().ToUpper(), 
        };
    }
}