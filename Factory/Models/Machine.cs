using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
  [Table("machines")]
  public class Machine
  {
    public int MachineId { get; set; }

    public string Name { get; set; }

    public string Product { get; set; }

    public int CycleTime { get; set; }

    public int ItemsPerCycle { get; set; }

    public virtual IList<Engineer> Engineers { get; set; }
  }
}