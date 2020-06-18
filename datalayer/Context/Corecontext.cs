using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using datalayer.Entities.User;
using datalayer.Entities.Wallet;
using datalayer.Entities.Permission;
using datalayer.Entities.Course;
using datalayer.Entities.Order;
using System.Linq;

namespace datalayer.Context
{
   public class Corecontext:DbContext
    {

        public Corecontext(DbContextOptions<Corecontext> options):base(options)
        {

        }



        #region User
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User_Role> User_Roles { get; set; }

        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }


        #endregion

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<WalletType> WalletTypes { get; set; }


        #endregion

        #region permission
        public DbSet<Permission> Permission { get; set; }

        public DbSet<RolePermission> RolePermission { get; set; }


        #endregion

        #region Course

        public DbSet<CourseGroup> CourseGroup { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEpisode> CourseEpisodes { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseStatus> CourseStatuses { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }

        #endregion

        #region Order

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Discount> Discounts { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
              .SelectMany(t => t.GetForeignKeys())
              .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.isDelete);
           

            modelBuilder.Entity<CourseGroup>().HasQueryFilter(u => !u.isDelete);
            

            modelBuilder.Entity<Role>().HasQueryFilter(u => !u.isDelete);





            base.OnModelCreating(modelBuilder);

        }


    }
}
