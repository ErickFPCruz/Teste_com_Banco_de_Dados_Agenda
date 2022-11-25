using Teste_com_Banco_de_Dados_Agenda.testeBD;

Console.WriteLine("\nContatos\n");

var db = new AgendaTesteContext();

var listaDeContatos = db.Contato.ToList();

foreach (var contato in listaDeContatos)
{
    Console.WriteLine($"O contato {contato.Id} se chama {contato.Nome}");
}