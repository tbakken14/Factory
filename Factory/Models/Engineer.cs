using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Factory.Models
{
    public class Engineer
    {
        public int EngineerId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public List<EngineerMachines> JoinEntities { get; set; }
    }
}