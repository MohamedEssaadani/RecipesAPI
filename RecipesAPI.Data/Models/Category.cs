using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class Category
    {
        [Key]
        private int CategoryId { get; set; }
        private string CategoryName { get; set; }
    }
}