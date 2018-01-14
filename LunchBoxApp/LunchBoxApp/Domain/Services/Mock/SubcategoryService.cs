using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;

namespace LunchBoxApp.Domain.Services.Mock
{
    public class SubcategoryService : ISubcategoryService
    {
        private IProductService _productService;
        private static ObservableCollection<Product> Products;

        /// <summary>
        /// Generate subcategories
        /// </summary>
        private static readonly List<Subcategory> Subcategories = new List<Subcategory>()
        {
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory1Guid,
                SubcategoryName = "Kaas",
                CategoryId = new Constants().Category1Guid,
                ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory2Guid,
                SubcategoryName = "Vis",
                CategoryId = new Constants().Category1Guid,
                ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory3Guid,
                SubcategoryName = "Vlees",
                CategoryId = new Constants().Category1Guid,
                ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory4Guid,
                SubcategoryName = "Kip",
                CategoryId = new Constants().Category1Guid,
                ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory5Guid,
                SubcategoryName = "Panini's",
                CategoryId = new Constants().Category2Guid,
                ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory6Guid,
                SubcategoryName = "Salades",
                CategoryId = new Constants().Category2Guid,
                ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory7Guid,
                SubcategoryName = "Pasta's",
                CategoryId = new Constants().Category2Guid,
                ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory8Guid,
                SubcategoryName = "Snacks",
                CategoryId = new Constants().Category2Guid,
                ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory9Guid,
                SubcategoryName = "Dessert",
                CategoryId = new Constants().Category3Guid,
                ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory10Guid,
                SubcategoryName = "Ontbijt",
                CategoryId = new Constants().Category3Guid,
                ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg"
            },
            new Subcategory()
            {
                SubcategoryId = new Constants().Subcategory11Guid,
                SubcategoryName = "Warme dranken",
                CategoryId = new Constants().Category4Guid,
                ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg"
            }
        };

        public SubcategoryService()
        {
            _productService = new ProductService();

            //Fill in here your product list by using the IProductService - following method fills the subcategories with their products
            GetAllProducts();

            foreach (var subcategory in Subcategories)
            {
                var products = Products.Where(p => p.SubcategoryId == subcategory.SubcategoryId).ToList();
                subcategory.Products = products;

                foreach (var product in products)
                {
                    product.Subcategory = subcategory;
                }
            }
        }

        /// <summary>
        /// Returns all existing subcategories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Subcategory>> GetAllSubcategories()
        {
            await Task.Delay(0);
            return Subcategories;
        }

        /// <summary>
        /// Returns a subcategory by SubcategoryId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Subcategory> GetSubcategoryBySubcategoryId(Guid id)
        {
            await Task.Delay(0);
            return Subcategories.FirstOrDefault(s => s.SubcategoryId == id);
        }

        /// <summary>
        /// Returns a list of subcategories by CategoryId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryId(Guid id)
        {
            await Task.Delay(0);
            return Subcategories.Where(s => s.CategoryId == id).ToList();
        }

        /// <summary>
        /// Gets all products (private)
        /// </summary>
        private async void GetAllProducts()
        {
            var products = await _productService.GetAlProducts();
            Products = null;
            Products = new ObservableCollection<Product>(products);
        }
    }
}
