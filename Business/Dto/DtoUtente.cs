using System.ComponentModel.DataAnnotations;

namespace Business.Dto;

public class DtoUtente : UtentePrimarykey
{
    public string Username { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;
}

public class CreateUtente
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Nome { get; set; } = null!;

    [Required]
    public string Cognome { get; set; } = null!;
}

public class ReadUtente
{
    public string? Username { get; set; }

    public string? Nome { get; set; }

    public string? Cognome { get; set; }
}

public class UpdateUtente : UtentePrimarykey
{
    public string? Username { get; set; }

    public string? Nome { get; set; }

    public string? Cognome { get; set; }
}

public class DeleteUtente : UtentePrimarykey
{

}


public abstract class UtentePrimarykey
{
    [Required]
    public long Id { get; set; } = 0;
}