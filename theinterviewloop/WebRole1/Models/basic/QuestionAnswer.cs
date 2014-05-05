using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRole1.Models
{
    /// <summary>
    /// Question asked and notes taken for that question and other details
    /// </summary>
    [Table("QuestionAnswer")]
    public class QuestionAnswer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Duration { get; set; }
        public int Rating { get; set; }
    }
}