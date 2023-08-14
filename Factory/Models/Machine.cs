using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public List<EngineerMachines> JoinEntities { get; set; }
    }
}