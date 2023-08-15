using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {

        [Fact(DisplayName ="Teste Nº1")]
        [Trait("Funcionalidade","Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            // Arrange - Cenario
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            // Assert - Verificar Resultado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste Nº2")]
        [Trait("Funcionalidade", "Frear")]

        public void TestaVeiculoFrear()
        {
            // Arrange - Cenario
            var veiculo = new Veiculo();
            // Act - Metodo
            veiculo.Frear(10);
            // Assert - Verificar Resultado
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TesteTipoVeiculo()
        {
            // Arrange - Cenario
            var veiculo = new Veiculo();
            // Act - Metodo
            // Assert - Verificar Resultado
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip ="Teste ainda não implementado. Ignorar")]
        public void TesteValidaNomeProprietario()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TesteDadosVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo
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

    }
}