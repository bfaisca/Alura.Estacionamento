using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes: IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;
        private Operador operador;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado!");

            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
        }

        [Fact]
        public void ValidaFaturamentoComAutomovel()
        {
            //Arrange

            operador = new Operador
            {
                Nome = "Vagner"
            };

            veiculo = new Veiculo
            {
                Proprietario = "Brendo Faisca",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Vermelho",
                Modelo = "Corolla",
                Placa = "jlk-8000"
            };

            estacionamento.OperadorPatio = operador;
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
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange

            operador = new Operador
            {
                Nome = "Jhonson"
            };

            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Jose Silva", "ASD-1498", "Preto", "Gol")]
        public void TesteLocalizaVeiculoNoPatioComIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange

            operador = new Operador
            {
                Nome = "Paulo"
            };

            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("#### Ticket Estacionamento Faisca###", consultado.Ticket);
        }
        [Fact]
        public void TesteAlterarDadosVeiculo()
        {
            //Arrange 

            operador = new Operador
            {
                Nome = "Carlos"
            };

            veiculo = new Veiculo
            {
                Proprietario = "José Silva",
                Placa = "ZXC-8524",
                Cor = "Verde",
                Modelo = "Opala"
            };

            estacionamento.OperadorPatio = operador;
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

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}
