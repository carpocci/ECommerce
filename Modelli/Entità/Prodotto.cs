using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelli;

[Table("Prodotti", Schema = "dbo")]
public class Prodotto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } = 0;

    public string Nome { get; set; } = string.Empty;

    public long Quantità { get; set; } = 0;

    public List<Acquisto> ListaAcquisti { get; set; } = new List<Acquisto>();

    public override string ToString()
    {
        return $"{this.Id}: {this.Nome}, qnt. {this.Quantità}";
    }
}