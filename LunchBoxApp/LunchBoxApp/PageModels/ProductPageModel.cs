using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using LunchBoxApp.Domain.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LunchBoxApp.PageModels
{
    class ProductPageModel : FreshBasePageModel
    {
        private string _productNote;
        private int _productQuantity;
        private string _selectedItem;
        private decimal _productPrice;
        private decimal _totalProductPrice;
        private bool _productMultigrain;

        public Product Product { get; set; }

        public string ProductName { get; set; }

        public string ProductPersonName { get; set; }

        public string ProductImageUrl { get; set; }

        public List<string> Ingredients { get; set; }


        public decimal ProductPrice
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                TotalProductPrice = value * ProductQuantity;
                RaisePropertyChanged();
            }
        }

        public decimal TotalProductPrice
        {
            get => _totalProductPrice;
            set
            {
                _totalProductPrice = value;
                RaisePropertyChanged();
            }
        }

        public int ProductQuantity
        {
            get => _productQuantity;
            set
            {
                _productQuantity = value;
                TotalProductPrice = value * ProductPrice;
                RaisePropertyChanged();
            }
        }

        public string ProductNote
        {
            get => _productNote;
            set
            {
                _productNote = value;
                RaisePropertyChanged();
            }
        }

        public bool IngredientsVisible { get; set; }

        public bool ProductMultigrain
        {
            get => _productMultigrain;
            set
            {
                _productMultigrain = value;
                if (value)
                {
                    ProductPrice += 0.30m;
                    ProductNote = ProductNote + "-Meergranenbrood\n";
                }
                else
                {
                    ProductPrice -= 0.30m;
                    ProductNote = ProductNote.Replace("-Meergranenbrood\n", "");
                }
                
                RaisePropertyChanged();
            }
        }

        //Each time an ingredient is selected in the Picker it modifies the string in the ProductNote
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;


                if (_selectedItem != null)
                {
                    string editIngredient = $"-Geen {value}\n";

                    if (ProductNote.Contains(editIngredient))
                    {
                        ProductNote = ProductNote.Replace(editIngredient, "");
                    }
                    else
                    {
                        ProductNote = ProductNote + editIngredient;
                    }

                    _selectedItem = null;
                }

                RaisePropertyChanged();
            }
        }

        public override void Init(object initData)
        {
            if (initData is Product product)
            {
                Product = product;
                base.Init(initData);
            }

            if (Product != null)
            {
                ProductName = Product.ProductName;
                ProductImageUrl = Product.ImageUrl;
                //Converts the JSON IngredientsBlobbed into a string list (if it exists) - else the Ingredients are null
                Ingredients = Product.IngredientsBlobbed != null ? JsonConvert.DeserializeObject<List<string>>(Product.IngredientsBlobbed) : null;
                IngredientsVisible = Ingredients != null;
                ProductNote = "";
                ProductQuantity = 1;
                ProductPrice = Product.ProductPrice;
                TotalProductPrice = ProductQuantity * ProductPrice;
            }
        }

        /// <summary>
        /// Increases Product Quantity by 1
        /// </summary>
        public ICommand IncreaseQuantity
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        await Task.Delay(0);
                        ProductQuantity += 1;
                    });
            }
        }

        /// <summary>
        /// Decreases Product Quantity by 1
        /// </summary>
        public ICommand DecreaseQuantity
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        await Task.Delay(0);
                        if (ProductQuantity > 1)
                        {
                            ProductQuantity -= 1;
                        }
                    });
            }
        }


        /// <summary>
        /// Adds the product to the OrderList command
        /// </summary>
        public ICommand AddProductToOrder
        {
            get {
                return new Command(
                async () =>
                {
                    //Creating a new product since every product can be modified in price!
                    var newProduct = new Product()
                    {
                        ProductId = Guid.NewGuid(),
                        ProductName = Product.ProductName,
                        ProductDescription = Product.ProductDescription,
                        ProductPrice = ProductPrice,
                        ProductNote = ProductNote,
                        ProductQuantity = ProductQuantity,
                        ProductPersonName = ProductPersonName,
                        Ingredients = Product.Ingredients,
                        ImageUrl = Product.ImageUrl,
                        Subcategory = Product.Subcategory,
                        SubcategoryId = Product.SubcategoryId
                    };
                    await CoreMethods.PopPageModel(newProduct);
                });
            }
        }
    }
}
