using FluentBlog.Data;
using FluentBlog.Models;

using var context = new BlogDataContext();

//context.Users.Add(
//   new User()
//   {
//       Name = "Gabriel Silva",
//       Email = "gabrielsilva7731@gmail.com",
//       Bio = "Systems Analyst Developer",
//       Image = "http://gabrielhs1357.com",
//       PasswordHash = "12345",
//       Slug = "gabriel-silva"
//   }
//);

var user = context.Users.First();

var post = new Post()
{
    Author = user,
    Body = "Meu artigo",
    Category = new Category()
    {
        Name = "Frontend",
        Slug = "frontend"
    },
    CreateDate = DateTime.Now,
    // LastUpdateDate = ,
    Slug = "meu-artigo",
    Summary = "Neste artigo vamos conferir...",
    // Tags = null,
    Title = "Meu artigo"
};

context.Posts.Add(post);

context.SaveChanges();

