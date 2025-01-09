using System.Text;
using DesafioProjetoHospedagem.Models;

/*onsole.OutputEncoding = Encoding.UTF8;
/
// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reservaA = new Reserva(diasReservados: 5);
reservaA.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reservaA.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reservaA.CalcularValorDiaria()}");
*/
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
    opcao = Console.ReadLine();

    switch(opcao){
        case "1":
            Reserva reserva = new Reserva();
            char classeSuite = Suite.TiposSuites();
            Suite tipoSuite = new Suite(classeSuite);
            reserva.CadastrarSuite(tipoSuite);
            Console.WriteLine("\n");
            Console.Read();
            reserva.CadastrarHospedes();
            Console.WriteLine("Digite seu Usuário: ");
            string user = Console.Read().ToString();
            Console.WriteLine("Digite sua Senha: ");
            string key = Console.Read().ToString();
            reservas.Add(reserva);
            break;
        case "2":
            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine("Reservas: ");
                Console.WriteLine($"{i+1} - Hospedes: {reservas[i].Hospedes} , Suite {reservas[i].SuiteReserva}, "+
                                  $"{reservas[i].DiasReservados} dias");
            }
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
    