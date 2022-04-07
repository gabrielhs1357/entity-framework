using Blog.Data;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

#region Alterando um subconjunto
var post = context
            .Posts
            .Include(x => x.Author)
            .Include(x => x.Category)
            .OrderByDescending(x => x.LastUpdateDate)
            .FirstOrDefault();

post.Author.Name = "Teste";

context.Posts.Update(post);
#endregion

#region Include
// Sempre colocar na ordem: Include -> Where -> Order -> ToList
// var posts = context
//             .Posts
//             .AsNoTracking()
// .Include(x => x.Author) // Include = Inner Join
// .OrderByDescending(x => x.LastUpdateDate)
// .ToList();

// foreach (var post in posts)
// Usar o Nullable em propriedades que podem ser nulas
// Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
#endregion

#region Subconjunto
// var user = new User()
// {
//     Name = "Gabriel Henrique da Silva",
//     Slug = "gabrielhs1357",
//     Email = "gabrielhs1357@gmail.com",
//     Bio = "C# / .NET / Azure",
//     Image = "https://balta.io",
//     PasswordHash = "123456789"
// };

// var category = new Category()
// {
//     Name = "Backend",
//     Slug = "backend"
// };

// var post = new Post()
// {
//     Author = user,
//     Category = category,
//     Body = "<p>Hello world</p>",
//     Slug = "comecando-com-ef-core",
//     Summary = "Neste artigo vamos aprender EF core",
//     Title = "Começando com EF Core",
//     CreateDate = DateTime.Now,
//     LastUpdateDate = DateTime.Now
// };

// Nessa sequência, o EF automaticamente cria primeiro um User e uma Categoria no banco, então ele pega ambos os Ids gerados e os coloca nas chaves estrangeiras do Post, e então cria o Post
// context.Posts.Add(post);
#endregion

#region Create
// var tag = new Tag() { Name = ".NET", Slug = "dotnet" };
// context.Add(tag);
#endregion

#region Update
// Sempre que quiser atualizar um dado, não utilize o new, e sim pegue o dado do banco, dessa forma o EF irá realizar o update correto apenas do que foi alterado
// var tag = context.Tags.FirstOrDefault(x => x.Id == 4);
// tag.Name = "Node.js";
// tag.Slug = "nodejs";
// context.Update(tag);
#endregion

#region Delete
// var tag = context.Tags.FirstOrDefault(x => x.Id == 4);
// context.Remove(tag);
#endregion

#region Read All
// Apenas o context.Tags não faz a busca no banco, apenas será buscado no banco posteriormento quando a variável tags for utilizada de fato
// Para evitar isso, podemos usar context.Tags.ToList()
// Sempre devemos usar o ToList por último, dessa forma aplicamos todos os filtros no select e depois transformamos em lista, ao invés de dar um select em todos os itens e depois filtrar a lista em memória
// var tags = context.Tags.ToList();
#endregion

#region Read
// Disabling change tracking is useful for read-only scenarios because it avoids the overhead of setting up change tracking for each entity instance. You should not disable change tracking if you want to manipulate entity instances and persist those changes to the database using DbContext.SaveChanges().
// Ou seja, não traz os metadados (que em termos bem simples diz ao contexto para não mapear o objeto) e isso aumenta muito a performance, útil para casos de apenas leitura do dado
// var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 5);

// SingleOrDefault retorna erro caso tenha mais de um, ou seja, mais de uma Tag com id == 5
// var tag = context.Tags.AsNoTracking().SingleOrDefault(x => x.Id == 5);

// Sempre usar o nullable quando usar o FirstOrDefault
// Console.WriteLine(tag?.Name);
#endregion

// Saves all changes made in this context to the database
context.SaveChanges();
