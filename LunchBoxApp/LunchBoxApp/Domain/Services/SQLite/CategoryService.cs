using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public class CategoryService : SQLiteServiceBase, ICategoryService
    {
        private readonly ISubcategoryService _subcategoryService;
        private static ObservableCollection<Subcategory> Subcategories;

        /// <summary>
        /// Generate categories
        /// </summary>
        private static List<Category> Categories = new List<Category>();

        public CategoryService()
        {
            Categories = connection.Table<Category>().ToList();

            if (Categories.Count == 0)
            {
                GenerateData();
                Categories = connection.Table<Category>().ToList();
            }

            _subcategoryService = new SubcategoryService();

            //Fill in here your subcategory list by using the ISubcategoryService - following method fills the categories up with their subcategories
            GetAllSubcategories();

            foreach (var category in Categories)
            {
                var subcategories = Subcategories.Where(s => s.CategoryId == category.CategoryId).ToList();
                category.Subcategories = subcategories;

                foreach (var subcategory in subcategories)
                {
                    subcategory.Category = category;
                }
            }
        }

        /// <summary>
        /// Returns all existing categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            await Task.Delay(0);
            return Categories;
        }

        /// <summary>
        /// Returns a category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(Guid id)
        {
            await Task.Delay(0);
            return Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        private async void GetAllSubcategories()
        {
            var subcategories = await _subcategoryService.GetAllSubcategories();
            Subcategories = null;
            Subcategories = new ObservableCollection<Subcategory>(subcategories);
        }

        private void GenerateData()
        {
            try
            {
                connection.Insert(new Category
                    {
                        CategoryId = new Constants().Category1Guid,
                        CategoryName = "Broodjes",
                        ImageUrl = "https://i.gyazo.com/53c9732d5d7ddd2c6930c280c0741d3d.png"
                });

                connection.Insert(new Category
                {
                    CategoryId = new Constants().Category2Guid,
                    CategoryName = "Salades, Pastas & Snacks",
                    ImageUrl = "https://i.gyazo.com/34588c393daf67de6d11b4e70813eaad.png"
                });

                connection.Insert(new Category
                {
                    CategoryId = new Constants().Category3Guid,
                    CategoryName = "Dessert & Ontbijt",
                    ImageUrl = "https://i.gyazo.com/bbbc74b660b2d6c61cd36959b8cb33bd.png"
                });

                connection.Insert(new Category
                {
                    CategoryId = new Constants().Category4Guid,
                    CategoryName = "Dranken",
                    ImageUrl = "https://i.gyazo.com/620cdf58213e034fda28cb102ae84430.png"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
