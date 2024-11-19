using System.ComponentModel.DataAnnotations;

namespace RohitEFCoreDemo.Models
{
    public class SubjectModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
