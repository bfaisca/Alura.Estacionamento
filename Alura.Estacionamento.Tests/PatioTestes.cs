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

        [Theory]
        [InlineData("Jose Silva", "ASD-1498", "Preto", "Gol")]
        public void TesteLocalizaVeiculoPatio(string proprietario, string placa, string cor, string modelo)
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

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }
        [Fact]
        public void TesteAlterarDadosVeiculo()
        {
            //Arrange 
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "José Silva",
                Placa = "ZXC-8524",
                Cor = "Verde",
                Modelo = "Opala"
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "José Silva",
                Placa = "ZXC-8524",
                Cor = "Preto",//Alterado
                Modelo = "Opala"
            };


            //ACT
            Veiculo alterado = estacionamento.alteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor,veiculoAlterado.Cor);
        }
    }
}
