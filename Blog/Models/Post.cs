using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        // Indica uma chave estrangeira, separando o CategoryId e referenciado a classe Category e propriedade Id
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        // Com uma propriedade referenciando o Id da categoria e outra referenciado a categoria em si, conseguimos acessar a categoria do objeto facilmente, isso chama-se propriedade de navegação
        public Category Category { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}