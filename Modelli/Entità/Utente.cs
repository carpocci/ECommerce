using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelli;

[Table("Utenti", Schema = "dbo")]
public class Utente
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Nome { get; set; } = string.Empty;

    public string Cognome { get; set; } = string.Empty;

    public List<Acquisto> ListaAcquisti { get; set; } = new List<Acquisto>();

    public override string ToString()
    {
        return $"{this.Id}: {this.Username} ==> {this.Nome} {this.Cognome}";
    }


}