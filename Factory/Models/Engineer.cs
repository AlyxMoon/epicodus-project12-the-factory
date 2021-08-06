using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
  [Table("engineers")]
  public class Engineer
  {
    public int Id { get; set; }

    public int Product { get; set; }

    public int CycleTime { get; set; }

    public int ItemsPerCycle { get; set; }

    public virtual ICollection<Machine> Machines { get; set; }
  }
}