using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AttendenceDTO
    {
        public int serialNumber { get; set; }
        public DateTime Attendance_date { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberID { get; set; }
    }
}
