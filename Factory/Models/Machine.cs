using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
  [Table("machines")]
  public class Machine
  {
    public int Id { get; set; }

    public int Product { get; set; }

    public int CycleTime { get; set; }

    public int ItemsPerCycle { get; set; }

    public virtual ICollection<Engineer> Engineers { get; set; }
  }
}