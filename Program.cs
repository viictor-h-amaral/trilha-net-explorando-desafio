using System.Text;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Seguranca;
Console.OutputEncoding = Encoding.UTF8;
//Console.BackgroundColor = ConsoleColor.Black;
//Console.ForegroundColor = ConsoleColor.Yellow;

{
	List<Reserva> reservas = new List<Reserva>();
	bool loopMenu = true;

	while (loopMenu){
		Console.Clear();
		Console.WriteLine(" --- ESCOLHA UMA OPÇÃO --- \n");
		Console.WriteLine("1 - Cadastrar Reserva");
		Console.WriteLine("2 - Listar Reservas");
		Console.WriteLine("3 - Buscar Reserva (visualização e edição)");
		Console.WriteLine("4 - Remover Reserva");
		Console.WriteLine("5 - Fechar Reserva");
		Console.WriteLine("6 - Encerrar Programa");
		string opcao = Console.ReadLine();

		switch(opcao){
			case "1":

				Reserva reserva = new Reserva(); //cria o objeto local reserva do tipo Reserva

				reserva.CadastrarSuite(); //faz todo o processo de selecionar e cadastrar suite

				Prosseguir();

				reserva.CadastrarHospedes(); //faz todo o processo de criacao e cadastramento de hospedes 

				Prosseguir();
				
				reserva.CadastrarDiasReservaddos();

				Prosseguir();

				Console.Clear();
				Console.WriteLine("Digite seu Usuário: ");
				string usuario = Console.ReadLine();
				Console.WriteLine("\n Digite sua Senha: ");
				bool senhaEhInteira = int.TryParse(Console.ReadLine(), out int senha);
				//verifica usuario e senha
				
				reservas.Add(reserva);

				break;

			case "2":
			
				Console.WriteLine("\n                        --- RESERVAS ---");
				if (reservas.Count == 0)
				{
					Console.WriteLine("                Nenhuma Reserva Cadastrada!");
				} 
				else
				{
					for (int i = 0; i < reservas.Count; i++) //inicia o loop para mostrar ao usuário todos os itens (que são do tipo reservas) da lista 'reservas'
					{
						Console.WriteLine("----------------------------------------------------");
						Console.WriteLine($"{i+1} - {Reserva.MostraReserva(reservas[i], true)}"); 
						//chama a função static 'MostraReserva' que recebe uma reserva e transoforma suas propriedades em texto para mostrar ao usuário
					}
				}
				
				Prosseguir();
				break;

			case "3":
				
				Console.WriteLine("\n --- BUSCA INICIADA --- \n Digite o nome de algum dos Hóspedes: ");
				string nomeHospedeABuscar = Console.ReadLine().ToUpper(); //pega o nome do hospede pelo qual se deseja fazer a busca
				(Reserva, bool) reservaRetornada = Reserva.BuscaReserva(reservas, nomeHospedeABuscar);
				
				if(reservaRetornada.Item2) //executa caso o item1 retornou realmente uma reserva
				{
					Reserva reservaDaBusca = reservaRetornada.Item1; //cria a reserva que receberá a reserva selecionada na função 'BuscaReserva'
					//o item1 retorna a reserva escolhida 
					Reserva.MostraReserva(reservaDaBusca, true);//Mostra para o usuário a reserva
					Reserva.AlterarReserva(reservaDaBusca);
				}
				else
				{
					Console.WriteLine(" ! Nenhuma Reserva Selecionada ! ");
				}
				
				Prosseguir();
				
				
				break;
				
			case "4":
				//pede para o usuário escolher umas das reservas (pelo nome de quem reservou, nome dos hóspedes, ou algo assim)
				//pede para o usuário a senha de acesso
				//deleta a reserva da lista reservas
				break;
			case "5":
				//remove a reserva da lista reservas e calcula valor a ser pago
				break;
			case "6":
				loopMenu = false;
				break;
			default:
				Console.WriteLine("Não entendi ... Tente Novamente!");
				break;
		}
				
	}

	Console.WriteLine("Encerrando programa ... ");
}


static void Prosseguir()
{
	Console.WriteLine("\nPresse uma Tecla para continuar ... ");
	Console.ReadLine(); //espera um input do usuario para continuar
}
