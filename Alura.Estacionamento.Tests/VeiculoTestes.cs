using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {

        [Fact]
        public void TestaVeiculoAcelerar()
        {
            // Arrange - Cenario
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            // Assert - Verificar Resultado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
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


    }
}