using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelli;

[Table("Acquisti", Schema = "dbo")]
public class Acquisto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } = 0;

    public long IdUtente { get; set; } = 0;

    public long IdProdotto { get; set; } = 0;

    public long Quantità { get; set; } = 0;

    public Utente? Utente { get; set; }
    public Prodotto? Prodotto { get; set; }

    public override string ToString()
    {
        return $"""{this.Utente?.Username} ha acquistato {this.Quantità} {this.Prodotto?.Nome}.""";
    }
}