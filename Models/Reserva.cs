namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite SuiteReserva { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes()
        {
            bool loopCadastroPessoas = true;
            while(loopCadastroPessoas){

                Console.WriteLine($"Primeiro mais último nome da pessoa a cadastrar ou '0' " + 
                                  $"para parar ({SuiteReserva.Capacidade} espaços na suíte): ");
                string nomeDigitado = Console.ReadLine();
                bool pararLoop = int.TryParse(nomeDigitado, out int i);

                if (pararLoop){
                    loopCadastroPessoas = false;
                    Console.WriteLine("Fim do Cadastro de Pessoas! ");
                    Console.Read();
                } 
                else if (nomeDigitado.Contains(" "))
                {
                    string[] nomeESobrenome = Console.Read().ToString().Split(" ", 2);
                    Pessoa hospede = new Pessoa(nome: nomeESobrenome[0], sobrenome: nomeESobrenome[1]);
                    Hospedes.Add(hospede);
                }
                else{
                    Pessoa hospede2 = new Pessoa(nome: nomeDigitado);
                    Hospedes.Add(hospede2);
                }
            }
        }

        public void CadastrarSuite(Suite tipoSuite)
        {
            SuiteReserva = tipoSuite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * SuiteReserva.ValorDiaria;
            if (DiasReservados >= 10){
                valor *= .9M;
            }
            return valor;
        }

    }
}