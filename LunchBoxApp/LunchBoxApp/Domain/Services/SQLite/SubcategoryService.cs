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
    public class SubcategoryService : SQLiteServiceBase, ISubcategoryService
    {
        private readonly IProductService _productService;
        private static ObservableCollection<Product> Products;

        /// <summary>
        /// Generate subcategories
        /// </summary>
        private static List<Subcategory> Subcategories = new List<Subcategory>();

        public SubcategoryService()
        {
            Subcategories = connection.Table<Subcategory>().ToList();

            if (Subcategories.Count == 0)
            {
                GenerateData();
                Subcategories = connection.Table<Subcategory>().ToList();
            }

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


        private void GenerateData()
        {
            List<Subcategory> subcategoriesSeeding = new List<Subcategory>()
            {
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory1Guid,
                    SubcategoryName = "Kaas",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/dcb57ffbe1abcb79a1b041d051e73537.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory2Guid,
                    SubcategoryName = "Vis",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/696e7727867ff08405bc6de8fbf79cf9.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory3Guid,
                    SubcategoryName = "Vlees",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/42e96441e0073c3529fa601f53c1d190.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory4Guid,
                    SubcategoryName = "Kip",
                    CategoryId = new Constants().Category1Guid,
                    ImageUrl = "https://i.gyazo.com/ef7f85efe0561a167279a95dcff6a57c.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory5Guid,
                    SubcategoryName = "Panini's",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/108f1afbe8b92fe3d4e63cc403138d75.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory6Guid,
                    SubcategoryName = "Salades",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/cbd4c73d7e4f934334cde7f23110da86.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory7Guid,
                    SubcategoryName = "Pasta's",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/75558717c726461ab7070fe03f2d5419.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory8Guid,
                    SubcategoryName = "Snacks",
                    CategoryId = new Constants().Category2Guid,
                    ImageUrl = "https://i.gyazo.com/50d9352a192bd73b0eac7389d58eaeae.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory9Guid,
                    SubcategoryName = "Dessert",
                    CategoryId = new Constants().Category3Guid,
                    ImageUrl = "https://i.gyazo.com/bbde00ac13f5a5a3aaeae7c1a628f0c8.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory10Guid,
                    SubcategoryName = "Ontbijt",
                    CategoryId = new Constants().Category3Guid,
                    ImageUrl = "https://i.gyazo.com/bbbc74b660b2d6c61cd36959b8cb33bd.png"
                },
                new Subcategory()
                {
                    SubcategoryId = new Constants().Subcategory11Guid,
                    SubcategoryName = "Warme dranken",
                    CategoryId = new Constants().Category4Guid,
                    ImageUrl = "https://i.gyazo.com/52e9e60f205c73e46149fcbd0eba0ffc.png"
                }
            };

            connection.InsertAll(subcategoriesSeeding);
        }
    }
}
