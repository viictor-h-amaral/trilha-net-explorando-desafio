using System.Text.RegularExpressions;
using System.Globalization;
using System.Formats.Tar;

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
			Console.Clear();
			bool loopCadastroPessoas = true;
			int vagasRestantesNaSuite = this.SuiteReserva.Capacidade;

			while(loopCadastroPessoas && vagasRestantesNaSuite > 0)
			{

				bool apenasUmaVaga = vagasRestantesNaSuite == 1;
				bool primeiroCadastro = vagasRestantesNaSuite == this.SuiteReserva.Capacidade;
				if(primeiroCadastro)
				{
					Console.WriteLine("                      -- INICIO DO CADASTRO DE HÓSPEDES DA RESERVA -- \n");
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
			Console.WriteLine("\n                      -- Fim do Cadastro de Pessoas! -- ");
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

		public void CadastrarDiasReservaddos()
		{
			while(true)
			{
				Console.WriteLine("Digite por quantos dias se deseja fazer a reserva: ");
				bool ehInteiro = int.TryParse(Console.ReadLine(), out int dias);
				try
				{
					if(!ehInteiro)
					{
						throw new Exception("A quantidade de Dias deve ser inteira!");
					}
					DiasReservados = dias;
					return;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Erro! : " + ex.Message);
				}
			}
		}

		public int QuantidadeHospedes()
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

		public static (Reserva, bool) BuscaReserva(List<Reserva> reservas, string nomeHospede){
			
			List<Reserva> reservasDaBusca = []; //cria uma nova lista de reservas que conterá as reservas encontradas na busca

			bool hospedeCadastrado = reservas.Any(x => x.Hospedes.Any(x => x.NomeCompleto.Contains(nomeHospede)));
			Console.WriteLine($"{(hospedeCadastrado? "RESERVAS ENCONTRADAS" : "NENHUMA RESERVA")} COM O HÓSPEDE {nomeHospede.ToUpper()} " +
							  $"{(hospedeCadastrado? ": " : "!")} ");

			for(int i = 0, contadorListaBuscador = 0; i<reservas.Count; i++) //inicia o loop da busca
			{
				if(reservas[i].Hospedes.Any(x => x.NomeCompleto.Contains(nomeHospede))) //caso exista hospede nessa reserva
				{
					Console.WriteLine("----------------------------------------------------------------------------");
					Console.WriteLine($"{contadorListaBuscador+1} - {Reserva.MostraReserva(reservas[i], true)}");
					reservasDaBusca.Add(reservas[i]); //adiciona essa reserva na nova lista de reservas
					contadorListaBuscador++; //esse contador é utilizado para apresentar ao usuário o index da reserva que saiu da busca
				}
				
			}
			if(!hospedeCadastrado)
			{
				Reserva reservaNula = new();
				return (reservaNula, false);
			}
			while (true)
			{   
				Console.WriteLine("\n -- Digite o número da Reserva Escolhida ou '0' para Voltar ao Menu:  --");
				try
				{
					int indexReserva = Convert.ToInt32(Console.ReadLine());
					if(indexReserva == 0)
					{
						Reserva reservaNula = new();
						return(reservaNula, false);
					}
					Reserva reservaEscolhida = reservasDaBusca[indexReserva-1];
					return (reservaEscolhida, true);
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Erro! : Escolha um índice válido!");
				}
				catch (FormatException)
				{
					Console.WriteLine("Erro! : Índice deve ser um inteiro!");
				}
				catch (Exception ex) //input nao inteiro, fora do range da lista, ...
				{
					Console.WriteLine($"Erro! : {ex.Message}." +
									  $" Tente novamente!");
				}
			}
		}

		public static string MostraReserva(Reserva reserva, bool todaAReserva)
		{
			string listaDeHospedes = String.Empty;

			foreach(Pessoa hospede in reserva.Hospedes)
			{
				bool listaVazia = listaDeHospedes == string.Empty;
				listaDeHospedes = $"{listaDeHospedes}{(listaVazia ? "" : ", ")}{hospede.NomeCompleto}";
			}
			if(!todaAReserva)
			{
				return listaDeHospedes;
			}
			string suiteDaReserva = $"Classe {reserva.SuiteReserva.Tipo}, Diária de {reserva.SuiteReserva.ValorDiaria:C}, Capacidade de {reserva.SuiteReserva.Capacidade} pessoas.";

			string reservaTexto = $"HOSPEDES ({reserva.Hospedes.Count}): {listaDeHospedes}. \n" + 
								  $"    SUÍTE:  {suiteDaReserva} \n" + 
								  $"    DIAS RESERVADOS: {reserva.DiasReservados} dias.";
			return reservaTexto;

		}

		public static void AlterarReserva(Reserva reserva)
		{
			while (true){
				Console.Clear();
				Console.WriteLine(" --- ESCOLHA UMA OPÇÃO DE ALTERAÇÃO --- \n");
				Console.WriteLine("1 - Adicionar Hóspede");
				Console.WriteLine("2 - Remover Hóspede");
				Console.WriteLine("3 - Listar Hóspedes");
				Console.WriteLine("4 - Alterar Suíte");
				Console.WriteLine("5 - Alterar Dias Reservados");
				Console.WriteLine("6 - Voltar ao Menu");
				string opcao = Console.ReadLine();

				switch(opcao){
					case "1":
						Console.WriteLine("\n Digite o nome do Hóspede a ser adicionado ou '0' para parar: ");
						string nomeHospedeParaAdicionar = Console.ReadLine();
						if(!int.TryParse(nomeHospedeParaAdicionar, out int i)) //caso o que fora digitado não seja um número
						{
							try
							{
								Pessoa hospedeParaAdicionar = new Pessoa(nomeCompleto: nomeHospedeParaAdicionar);
								reserva.Hospedes.Add(hospedeParaAdicionar);
								Console.WriteLine($"Hóspede '{hospedeParaAdicionar}' cadastrado com Sucesso!");
							}
							catch(Exception ex)
							{
								Console.WriteLine($"Erro! : {ex.Message}. Tente Novamente ...");
							}
						}
						break;
						
					case "2":
						Console.WriteLine("\n Digite o nome do Hóspede a ser removido ou '0' para parar: ");
						string nomeHospedeParaRemover = Console.ReadLine();
						if(!int.TryParse(nomeHospedeParaRemover, out int j)) //caso o que fora digitado não seja um número
						{
							try
							{
								Pessoa hospedeParaRemover = new Pessoa(nomeCompleto: nomeHospedeParaRemover);
								reserva.Hospedes.Remove(hospedeParaRemover);
								Console.WriteLine($"Hóspede '{hospedeParaRemover}' removido com Sucesso!");
							}
							catch(Exception ex)
							{
								Console.WriteLine($"Erro! : {ex.Message}. Tente Novamente ...");
							}
						}
						break;
					
					case "3":
						Console.WriteLine(" --- HÓSPEDES --- ");
						
						string listaDeHospedes = Reserva.MostraReserva(reserva, false);
						Console.WriteLine($"({reserva.Hospedes.Count}) {listaDeHospedes}");
						
						break;
				}
			}
		}
	}
}