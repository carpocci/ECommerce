using System.ComponentModel.DataAnnotations;

namespace Business.Dto;

public class DtoProdotto : ProdottoPrimarykey
{
    public string Nome { get; set; } = null!;

    public long Quantità { get; set; } = 0;
}

public class CreateProdotto
{
    [Required]
    public string Nome { get; set; } = null!;


    [Required]
    public long Quantità { get; set; } = 0;
}

public class ReadProdotto
{
    public string? Nome { get; set; }

    public long? Quantità { get; set; }
}

public class UpdateProdotto : ProdottoPrimarykey
{
    public string? Nome { get; set; }

    public long? Quantità { get; set; }
}

public class DeleteProdotto : ProdottoPrimarykey
{

}


public abstract class ProdottoPrimarykey
{
    [Required]
    public long Id { get; set; } = 0;
}