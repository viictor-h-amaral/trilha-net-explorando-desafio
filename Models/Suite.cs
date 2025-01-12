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
                    Tipo = "Executiva";
                    Capacidade = 6;
                    ValorDiaria = 1200.00M;
                    break;
                case 'B':
                case 'b':
                    Tipo = "Conforto";
                    Capacidade = 4;
                    ValorDiaria = 800.00M;
                    break;
                case 'C':
                case 'c':
                    Tipo = "Econômica";
                    Capacidade = 2;
                    ValorDiaria = 350.00M;
                    break;
                default:
                    Tipo = "NONE";
                    Capacidade = 0;
                    ValorDiaria = 0M;
                    break;
            }
        }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Tipo = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        private string _tipo;
        private int _capacidade;
        private decimal _valorDiaria;

        public string Tipo 
        { 
            get
            {
                return this._tipo;
            }
            set
            {
                if (value == "Econômica" || value == "Conforto" || value == "Executiva")
                    this._tipo = value.ToUpper();
                else 
                    throw new Exception("Suite.Set.Tipo: Tipo inválido de suíte");
            }
        }
        public int Capacidade 
        {
            get
            {
                return this._capacidade;
            }
            set
            {
                if (value > 0)
                    this._capacidade = value;
                else 
                    throw new Exception("Suite.Set.Capacidade: Capacidade deve ser um inteiro positivo!");
            }
        }
        public decimal ValorDiaria 
        {
            get
            {
                return this._valorDiaria;
            }
            set
            {
                if (value > 0)
                    this._valorDiaria = value;
                else 
                    throw new Exception("Suite.Set.ValorDiaria: Valor da Diária deve ser um número positivo!");
            }
        }
        public static char EscolherTipoSuite(){
            char tipoSuite = ' ';
            bool loopEscolhaSuite = true;

            while(loopEscolhaSuite){

                Console.WriteLine("\n Escolha seu tipo de suíte: ");
                Console.WriteLine("A : Classe Executiva");
                Console.WriteLine("B : Classe Conforto");
                Console.WriteLine("C : Classe Econômica");
                    
                try
                {
                    tipoSuite = Convert.ToChar(Console.ReadLine().ToUpper());
                    if(tipoSuite == 'A' || tipoSuite == 'B' || tipoSuite == 'C')
                    {
                        loopEscolhaSuite = false;
                    } 
                    else 
                    {
                        throw new Exception("Sua escolha deve estar em um de nossos três planos!");
                    }
                }
                catch(System.FormatException)
                {
                    Console.WriteLine($"Erro! : Sua escolha deve ser um caracter apenas.");
                }
                catch(Exception ex){
                    Console.WriteLine($"Erro! : {ex.Message}");
                }

            }
            return tipoSuite;
        }
    }
}