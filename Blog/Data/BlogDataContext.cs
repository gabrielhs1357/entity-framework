using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        // Normalmente é criado a propriedade com o nome da tabela no plural
        // Inicialmente só podemos fazer o CRUD dos modelos que tenham chave primária simples (e não composta), por isso comentamos o PostTags e UserRole
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<UserRole> UserRole { get; set; }

        // Override this method to configure the database (and other options) to be used
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=True");
            // Conseguimos ver o log / queries geradas pelo EF usando o LogTo
            // optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
