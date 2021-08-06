using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
  [Table("engineers")]
  public class Engineer
  {
    public int EngineerId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Machine> Machines { get; set; }
  }
}