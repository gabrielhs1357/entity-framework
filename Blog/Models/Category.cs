using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    // Por padrão o EF tenta buscar por uma tabela chamada "Categories"
    [Table("Category")]
    public class Category
    {
        // Por padrão o EF associa a propriedade Id ao Id da tabela, mas é uma boa prática colocar a anotação Key
        [Key]
        // Indica que o valor é gerado automaticamente pelo banco
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // NotNull
        [Required]
        // Tamanho máximo do campo
        [MaxLength(80)]
        // Tamanho minímo do campo
        [MinLength(3)]
        // Nome e tipo da coluna
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        [MinLength(3)]
        // Nome e tipo da coluna
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}
