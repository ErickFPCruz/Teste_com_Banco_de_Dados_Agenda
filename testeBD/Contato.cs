using System;
using System.Collections.Generic;

namespace Teste_com_Banco_de_Dados_Agenda.testeBD;

public partial class Contato
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Email { get; set; }

    public decimal? Telefone { get; set; }

    public string? FotoUrl { get; set; }
}
