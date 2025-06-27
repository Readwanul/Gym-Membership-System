using DAL.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class GymContext: DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(t => t.JoinedAt).HasColumnType("datetime2");


            modelBuilder.Entity<Attendence>()
                .Property(t => t.Attendance_date).HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }

    }
}
