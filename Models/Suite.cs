using System.Linq.Expressions;

namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(char tipoSuite){
            switch(tipoSuite){
                case 'A':
                case 'a':
                    TipoSuite = "Executiva";
                    Capacidade = 6;
                    ValorDiaria = 1200.00M;
                    break;
                case 'B':
                case 'b':
                    TipoSuite = "Conforto";
                    Capacidade = 4;
                    ValorDiaria = 800.00M;
                    break;
                case 'C':
                case 'c':
                    TipoSuite = "Econômica";
                    Capacidade = 2;
                    ValorDiaria = 350.00M;
                    break;
                default:
                    TipoSuite = "NONE";
                    Capacidade = 0;
                    ValorDiaria = 0M;
                    break;
            }
        }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public static char TiposSuites(){
            char tipoSuite = ' ';
            bool loopEscolhaSuite = true;

            while(loopEscolhaSuite){

                Console.WriteLine("Escolha seu tipo de suíte: ");
                Console.WriteLine("A : Classe Executiva");
                Console.WriteLine("B : Classe Conforto");
                Console.WriteLine("C : Classe Econômica");
                    
                try{
                    tipoSuite = Convert.ToChar(Console.ReadLine().ToUpper());
                    if(tipoSuite == 'A' || tipoSuite == 'B' || tipoSuite == 'C'){
                        Console.WriteLine($"Ótimo! Suíte {tipoSuite} escolhida.");
                        loopEscolhaSuite = false;
                    } else {
                        throw new Exception("Sua escolha deve estar em um de nossos três planos!");
                    }
                }
                catch(Exception ex){
                    Console.WriteLine($"Erro! : {ex.Message}");
                }

            }
            return tipoSuite;
        }
    }
}