using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    /// <summary>
    /// Interviewer details
    /// </summary>
    [Table("Interviewer")]
    public class Interviewer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InterviewerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public virtual Company Company { get; set; }
    }
}