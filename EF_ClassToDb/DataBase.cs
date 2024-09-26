using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ClassToDb
{
    public class DataBase : DbContext
    {
        public DataBase()
        {
            //Database.EnsureDeleted(); //используется при пересоздании таблицы
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=192.168.200.13;userid=student;password=student;database=☻", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class Part
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;


        public List<Student> Responcible { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string TimeForMake { get; set; } = null!;
        public string Needs { get; set; } = null!;

        public List<Part> Parts { get; set; }
    }
}