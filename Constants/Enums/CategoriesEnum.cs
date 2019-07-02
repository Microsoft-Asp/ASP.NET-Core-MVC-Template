using System.ComponentModel.DataAnnotations;

namespace Constants.Enums
{
    public enum CategoriesEnum
    {
        [Display(Name = "Food")]
        Food = 1,
        [Display(Name = "Drinks")]
        Drinks = 2,
        [Display(Name = "Condiments")]
        Condiments = 3,
        [Display(Name = "Spices")]
        Spices = 4,
    }
}