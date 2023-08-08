using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {

        [Fact]
        public void TesteValidaFaturamento()
        {

            //Arrange
            var estacionamento = new Patio();

            var veiculo = new Veiculo
            {
                Proprietario = "Brendo Faisca",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Vermelho",
                Modelo = "Corolla",
                Placa = "jlk-8000"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act

            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Jose Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("Maria Souza", "XYZ-5678", "Azul", "Fiesta")]
        [InlineData("Carlos Santos", "QWE-1234", "Branco", "Corsa")]
        [InlineData("Ana Oliveira", "JKL-9876", "Vermelho", "Civic")]
        public void ValidaFaturamentoVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();

            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }
    }
}
