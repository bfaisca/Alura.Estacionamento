using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
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

        [Fact(Skip ="Teste ainda n�o implementado. Ignorar")]
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
                Proprietario = "Jos� Silva",
                Placa = "ZXC-8524",
                Cor = "Verde",
                Modelo = "Opala"
            };

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execu��o do Cleanup: Limpando os objetos.");
        }
    }
}