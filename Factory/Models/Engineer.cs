using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public class Engineer
    {
        public int EngineerId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string EngineerName { get; set; }
    }
}