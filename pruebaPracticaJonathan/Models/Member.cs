using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace pruebaPracticaJonathan.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id {  get; set; }
        [StringLength(500)]
        public string name { get; set; }
        
    }
}
