using blogTimofeeva.Domain.Model;
using blogTimofeeva.Domain.Model.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogTimofeeva.Domain.DB
{
    /// <summary>
    /// Контекст базы данных blogTimofeeva
    /// </summary>
    public class BlogDbContext: IdentityDbContext<User, IdentityRole<int>, int>
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="options"></param>
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public override DbSet<User> Users { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public DbSet<Employee> Employee { get; private set; }

        /// <summary>
        /// Пост блога
        /// </summary>
        public DbSet<BlogPost> BlogPosts { get; private set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Employee)
                .WithOne()
                .HasForeignKey<User>("EmployeeId")
                .IsRequired(true);
                x.HasIndex("EmployeeId").IsUnique(true);
            });

            #region Employee

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees");
                EntityId(b);
                b.Property(x => x.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                b.Property(x => x.Surname)
                    .HasColumnName("Surname")
                    .IsRequired();
                b.Ignore(x => x.Fullname);
            });

            #endregion

            #region BlogPost
            modelBuilder.Entity<BlogPost>(b =>
            {
                b.ToTable("BlogPosts");
                EntityId(b);
                b.Property(x => x.Created)
                    .HasColumnName("Created")
                    .IsRequired();
                b.Property(x => x.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                b.Property(x => x.Data)
                    .HasColumnName("Data")
                    .IsRequired();
                b.HasOne(x => x.Owner)
                    .WithMany()
                    .IsRequired();
            });

            #endregion

        }

        /// <summary>
        /// Описание идентификатора сущности модели
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="builder">Построитель модели данных</param>
        private static void EntityId<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(x => x.Id)
                .HasAnnotation("Npgsql:Serial", true);
        }
    }
}
