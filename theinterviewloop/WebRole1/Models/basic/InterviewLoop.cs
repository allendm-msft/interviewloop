using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    /// <summary>
    /// A round of interviews for a "single" candidate
    /// </summary>
    [Table("Interview")]
    public class InterviewLoop
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InterviewLoopId { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        [ForeignKey("Interview")]
        public int[] InterviewIds { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public string StartDate { get; set; }
        [DataType(DataType.Date)]
        public string EndDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ScheduledBy { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }


        public virtual Company Company { get; set; }
        public virtual Interviewer Interviewer { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}