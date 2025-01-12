using System.Text;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Seguranca;
Console.OutputEncoding = Encoding.UTF8;
Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.ForegroundColor = ConsoleColor.Black;

List<Reserva> reservas = new List<Reserva>();
bool loopMenu = true;
string opcao = String.Empty;

while (loopMenu){
    Console.Clear();
    Console.WriteLine("Escolha uma opção: ");
    Console.WriteLine("1 - Cadastrar Reserva");
    Console.WriteLine("2 - Listar Reservas");
    Console.WriteLine("3 - Abrir Reserva (visualização e edição)");
    Console.WriteLine("4 - Remover Reserva");
    Console.WriteLine("5 - Fechar Reserva");
    Console.WriteLine("6 - Encerrar Programa");
    opcao = Console.ReadLine();

    switch(opcao){
        case "1":
            Reserva reserva = new Reserva(); //cria o objeto local reserva do tipo Reserva

            reserva.CadastrarSuite(); //faz todo o processo de selecionar e cadastrar suite

            Console.WriteLine("Presse uma Tecla para continuar ... ");
            Console.Read(); //espera um input do usuario para continuar

            reserva.CadastrarHospedes(); //faz todo o processo de criacao e cadastramento de hospedes 

            Console.WriteLine("Presse uma Tecla para continuar ... ");
            Console.Read(); //espera um input do usuario para continuar
            
            reserva.CadastrarDiasReservaddos();

            Console.WriteLine("Presse uma Tecla para continuar ... ");
            Console.Read(); //espera um input do usuario para continuar
            

            Console.WriteLine("Digite seu Usuário: ");
            string usuario = Console.ReadLine();
            Console.WriteLine("Digite sua Senha: ");
            //verifica usuario e senha
            reservas.Add(reserva);

            break;

        case "2":
        
            Console.WriteLine("RESERVAS: ");
            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"{i+1} - {Reserva.MostraReserva(reservas[i])}");
            }
            Console.ReadLine();

            break;

        case "3":
            //pede para o usuário escolher umas das reservas (pelo nome de quem reservou, nome dos hóspedes, ou algo assim)
            //Mostra pro usuário a reserva
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
    