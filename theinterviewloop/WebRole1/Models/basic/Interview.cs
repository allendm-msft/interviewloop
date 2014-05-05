using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    /// <summary>
    /// One interview
    /// </summary>
    [Table("Interview")]
    public class Interview
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InterviewId { get; set; }
        [ForeignKey("Interviewer")]
        public int InterviewerId { get; set; }
        [ForeignKey("QuestionAnswer")]
        public int[] QuestionAnswerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.DateTime)]
        public TimeSpan Duration { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }

        public virtual Interviewer Interviewer { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
    }
}