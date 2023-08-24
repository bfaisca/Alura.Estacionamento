using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System.Numerics;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado!");

            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Arrange - Cenario
            veiculo.Acelerar(10);
            // Assert - Verificar Resultado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]

        public void TestaVeiculoFrearComParametro10()
        {
            // Arrange - Cenario
            // Act - Metodo
            veiculo.Frear(10);
            // Assert - Verificar Resultado
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TesteTipoVeiculoComValorDefault()
        {
            // Arrange - Cenario
            // Act - Metodo
            // Assert - Verificar Resultado
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip ="Teste ainda não implementado. Ignorar")]
        public void TesteValidaNomeProprietarioDoVeiculo()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            veiculo = new Veiculo
            {
                Proprietario = "José Silva",
                Placa = "ZXC-8524",
                Cor = "Verde",
                Modelo = "Opala"
            };

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);
        }

        [Fact]
        public void TestaNomeProprietarioComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "AB";

            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
                );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF8000";

            //Act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
                );

            Assert.Equal("O 4° caractere deve ser um hífen",mensagem.Message);
        }

        [Fact]
        public void TestaMensagemDeExcecaoUltimosCaracteresPlaca()
        {
            //Arrange
            string placaFormatoErrado = "ASD-955U";

            //Act
            Assert.Throws<FormatException>(
              //Act
              () => new Veiculo().Placa = placaFormatoErrado
          );

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}