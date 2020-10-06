using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}