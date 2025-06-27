using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Table
{
    public class Attendence
    {
        [Key]
        public int serialNumber { get; set; }
        [Required]
        public DateTime Attendance_date { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberID { get; set; }

        public virtual Member Member { get; set; }
    }
}
