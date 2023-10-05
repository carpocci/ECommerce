using System.ComponentModel.DataAnnotations;

namespace Business.Dto;

public class DtoAcquisto : AcquistoPrimarykey
{
    public long IdUtente { get; set; } = 0;

    public long IdProdotto { get; set; } = 0;

    public long Quantità { get; set; } = 0;
}

public class CreateAcquisto
{
    [Required]
    public long IdUtente { get; set; } = 0;


    [Required]
    public long IdProdotto { get; set; } = 0;


    [Required]
    public long Quantità { get; set; } = 0;
}

public class ReadAcquisto
{
    public long? IdUtente { get; set; }

    public long? IdProdotto { get; set; }

    public long? Quantità { get; set; }
}

public class UpdateAcquisto : AcquistoPrimarykey
{
    public long? IdUtente { get; set; }

    public long? IdProdotto { get; set; }

    public long? Quantità { get; set; }
}

public class DeleteAcquisto : AcquistoPrimarykey
{

}


public abstract class AcquistoPrimarykey
{
    [Required]
    public long Id { get; set; } = 0;
}