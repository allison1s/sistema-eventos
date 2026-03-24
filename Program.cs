using pim;
using System.ComponentModel.Design;
using System.Text.Json;
using System.IO;

List<Evento> eventos = new List<Evento>();
List<Participante> participantes = new List<Participante>();
List<Inscricao> inscricoes = new List<Inscricao>();

if (File.Exists("eventos.json"))
{
    string json = File.ReadAllText("eventos.json");
    eventos = JsonSerializer.Deserialize<List<Evento>>(json);
}
string opcao;

do
{
    Console.WriteLine("1 - Cadastrar evento");
    Console.WriteLine("2 - Listar eventos");
    Console.WriteLine("3 - Cadastrar participante");
    Console.WriteLine("4 - Inscrever participante em evento");
    Console.WriteLine("5 - Listar inscrições");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha: ");
    opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Evento novoEvento = new Evento();

        Console.Write("Nome do evento: ");
        novoEvento.Nome = Console.ReadLine();

        Console.Write("Data do evendo: ");
        novoEvento.Data = DateTime.Parse(Console.ReadLine());

        eventos.Add(novoEvento);
    }

    else if (opcao == "2")
    {
        Console.WriteLine("\nEventos cadastrados: ");

        foreach (Evento e in eventos)
        {
            Console.WriteLine($"Nome: {e.Nome} | Data: {e.Data}");
        }
    }

    else if (opcao == "3")
    {
        Participante p = new Participante();

        Console.Write("Nome do participante: ");
        p.Nome = Console.ReadLine();

        participantes.Add(p);

        Console.WriteLine("Participante cadastrado!");
    }

    else if (opcao == "4")
    {
        Console.WriteLine("Escolha um evento:");

        for (int i = 0; i < eventos.Count; i++)
        {
            Console.WriteLine($"{i} - {eventos[i].Nome}");
        }

        int eventoIndex = int.Parse(Console.ReadLine());

        Console.WriteLine("Escolha um participante:");

        for (int i = 0; i < participantes.Count; i++)
        {
            Console.WriteLine($"{i} - {participantes[i].Nome}");
        }

        int participanteIndex = int.Parse(Console.ReadLine());

        Inscricao insc = new Inscricao();
        insc.Evento = eventos[eventoIndex];
        insc.Participante = participantes[participanteIndex];

        inscricoes.Add(insc);

        Console.WriteLine("Inscrição realizada!");
    }

    else if (opcao == "5")
    {
        foreach (Inscricao i in inscricoes)
        {
            Console.WriteLine($"Participante: {i.Participante.Nome} | Evento: {i.Evento.Nome}");
        }
    }

} while (opcao != "0");

string jsonFinal = JsonSerializer.Serialize(eventos);
File.WriteAllText("eventos.json", jsonFinal);
