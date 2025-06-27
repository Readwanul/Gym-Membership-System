using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Table
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [ForeignKey("Plan")]
        public int PlanId { get; set; }
        [Required]
        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public string Membership_status { get; set; } // Active, Inactive, Suspended
        public DateTime JoinedAt { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual Plan Plan { get; set; }

    }
}
