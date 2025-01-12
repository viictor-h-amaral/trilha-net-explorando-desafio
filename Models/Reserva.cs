using System.Text.RegularExpressions;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private List<Pessoa>_hospedes = [];
        //private Suite _suiteReserva;
        //private int _diasReservados;
        private Pessoa _quemFezAReserva;
        public List<Pessoa> Hospedes 
        { 
            get
            {
                return _hospedes;
            } 
            
            set
            {
                string padraoNome1 = "[a-zA-z]{2,}/s[a-zA-z]{2,}";
                string padraoNome2 = "[a-zA-Z]{2,}";
                foreach(Pessoa hospede in value){
                    bool nomeNoPadrao1 = Regex.IsMatch(hospede.NomeCompleto, padraoNome1, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
                    bool nomeNoPadrao2 = Regex.IsMatch(hospede.NomeCompleto, padraoNome2, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));

                }

                _hospedes = Hospedes;
            } 

        }
        public Suite SuiteReserva { get; set; }
        public int DiasReservados { get; set; }
        public Pessoa QuemFezAReserva 
        {
            get
            {
                return _quemFezAReserva;
            }
            set
            {
                this._quemFezAReserva = value;
            }
        }

        public Reserva() { }
        public void CadastrarHospedes()
        {
            bool loopCadastroPessoas = true;
            int vagasRestantesNaSuite = this.SuiteReserva.Capacidade;

            while(loopCadastroPessoas && vagasRestantesNaSuite > 0){

                bool apenasUmaVaga = vagasRestantesNaSuite == 1;
                bool primeiroCadastro = vagasRestantesNaSuite == this.SuiteReserva.Capacidade;
                if(primeiroCadastro)
                {
                    Console.WriteLine(" -- A RESERVA SERÁ NO NOME DA PRIMEIRA PESSOA CADASTRADA -- \n");
                }
                Console.WriteLine($"Primeiro mais último nome da pessoa a cadastrar ou '0' para parar ({vagasRestantesNaSuite} "+
                                  $"{(apenasUmaVaga ? "vaga" : "vagas")} na suíte): ");

                string nomeDigitado = Console.ReadLine();
                bool pararLoop = int.TryParse(nomeDigitado, out int i);
                
                if (pararLoop)
                {
                    loopCadastroPessoas = false;
                }
                else
                {
                    try
                    {
                        Pessoa hospede = new (nomeCompleto: nomeDigitado);
                        this.Hospedes.Add(hospede);
                        if(primeiroCadastro)
                            this.QuemFezAReserva = hospede;
                    } 
                    catch(Exception ex)
                    {
                        Console.WriteLine("Erro! : " + ex.Message);
                    }
                }
                vagasRestantesNaSuite = this.SuiteReserva.Capacidade - this.Hospedes.Count;
            }
            Console.WriteLine("\n -- Fim do Cadastro de Pessoas! -- ");
        }

        public void CadastrarSuite()
        {
            try
            {
                char tipoSuite = Suite.EscolherTipoSuite(); //define o tipo da Suite, A B ou C
                Suite tipoSuiteDaReserva = new Suite(tipoSuite); //cria o objeto local do tipo Suite com base no parametro char que é A, B ou C
                SuiteReserva = tipoSuiteDaReserva; //chama o set da propriedade SuiteReserva do objeto do tipo Reserva criado
                Console.WriteLine($"Suíte Cadastrada: Capacidade de {SuiteReserva.Capacidade} pessoas, Classe {SuiteReserva.Tipo}, Diária de {SuiteReserva.ValorDiaria:C}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro! : " + ex.Message);
            }
        }

        public void CadastrarDiasReservaddos(){
            bool loopDiasReservados = true;
            while(loopDiasReservados)
            {
                Console.WriteLine("Digite por quantos dias se deseja fazer a reserva: ");
                bool ehInteiro = int.TryParse(Console.ReadLine(), out int dias);
                try
                {
                    if(!ehInteiro)
                        throw new Exception("A quantidade de Dias deve ser inteira!");
                    DiasReservados = dias;
                    loopDiasReservados = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro! : " + ex.Message);
                }
            }
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

        /*public static Reserva BuscaReserva(List<Reserva> reservas, string nomeHospede){
            
            List<Reserva> reservasDaBusca = []; //cria uma nova lista de reservas que conterá as reservas encontradas na busca

            bool hospedeCadastrado = reservas.Any(x => x.Hospedes.Any(x => x.NomeCompleto == nomeHospede)); //verifica se há algum hospede com o nome informado
            Console.WriteLine($"{(hospedeCadastrado? "RESERVAS ENCONTRADAS" : "NENHUMA RESERVA")} COM O HÓSPEDE {nomeHospede.ToUpper()} " +
                              $"{(hospedeCadastrado? ": " : "!")} ");

            for(int i = 0, contadorListaBuscador = 0; i<reservas.Count; i++) //inicia o loop da busca
            {
                if(reservas[i].Hospedes.Any(x => x.NomeCompleto.ToUpper() == nomeHospede.ToUpper())) //caso exista hospede nessa reserva
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"{contadorListaBuscador+1} - {Reserva.MostraReserva(reservas[i])}");
                    reservasDaBusca.Add(reservas[i]); //adiciona essa reserva na nova lista de reservas
                    contadorListaBuscador++; //esse contador é utilizado para apresentar ao usuário o index da reserva que saiu da busca
                }
                
            }
            bool loopEscolhaReserva = true;
            do
            {   
                Console.WriteLine(" -- Digite o número da Reserva escolhida:  --");
                try
                {
                    int indexReserva = Convert.ToInt32(Console.ReadLine());
                    loopEscolhaReserva = false;
                    return reservasDaBusca[indexReserva-1];

                }
                catch (Exception ex) //input nao inteiro, fora do range da lista, ...
                {
                    Console.WriteLine($"Erro! : {ex.Message}. " +
                                      $"Tente novamente!");

                }
            } while(loopEscolhaReserva);

        }*/

        public static string MostraReserva(Reserva reserva)
        {
            string listaDeHospedes = String.Empty;

            foreach(Pessoa hospede in reserva.Hospedes){
                bool listaVazia = listaDeHospedes == string.Empty;
                listaDeHospedes = $"{listaDeHospedes}{(listaVazia ? "" : ", ")}{hospede.NomeCompleto}";
            }

            string suiteDaReserva = $"Classe {reserva.SuiteReserva.Tipo}, Diária de {reserva.SuiteReserva.ValorDiaria:C}, Capacidade de {reserva.SuiteReserva.Capacidade} pessoas.";

            string reservaTexto = $"HOSPEDES ({reserva.Hospedes.Count}): {listaDeHospedes}. \n" + 
                                  $"    SUÍTE:  {suiteDaReserva} \n" + 
                                  $"    DIAS RESERVADOS: {reserva.DiasReservados} dias";
            return reservaTexto;

        }

    }
}