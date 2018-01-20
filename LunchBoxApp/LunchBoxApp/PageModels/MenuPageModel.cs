using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using Xamarin.Forms;

namespace LunchBoxApp.PageModels
{
    public class MenuPageModel : FreshBasePageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;

        private ObservableCollection<Subcategory> _subcategories;
        private Subcategory _selectedSubcategory;
        private int _subcategoryHeight;

        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private int _productHeight;

        private List<Product> _orderedProducts;
        private int _totalProductsInOrderedProducts;
        private decimal _totalPriceInOrderedProducts;

        //Start Ordered Products
        public List<Product> OrderedProducts
        {
            get => _orderedProducts;
            set
            {
                _orderedProducts = value;
                RaisePropertyChanged();
            }
        }

        public int TotalProductsInOrderedProducts
        {
            get => _totalProductsInOrderedProducts;
            set
            {
                _totalProductsInOrderedProducts = value;
                RaisePropertyChanged(nameof(TotalProductsInOrderedProducts));
                RaisePropertyChanged(nameof(OrderButtonVisible));
            }
        }

        public decimal TotalPriceInOrderedProducts
        {
            get => _totalPriceInOrderedProducts;
            set
            {
                _totalPriceInOrderedProducts = value;
                RaisePropertyChanged();
            }
        }

        public bool OrderButtonVisible => CheckTotalOrdersValue(TotalProductsInOrderedProducts);
        private bool CheckTotalOrdersValue(int i) { return i > 0; }
        //End Ordered Products

        //Start Categories
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                RaisePropertyChanged();
            }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                GetSubcategoriesById();
            }
        }

        public int CategoryHeight { get; set; }
        //End Categories

        //Start Subcategories
        public ObservableCollection<Subcategory> Subcategories

        {
            get => _subcategories;
            set
            {
                _subcategories = value;
                RaisePropertyChanged();
            }
        }

        public Subcategory SelectedSubcategory
        {
            get => _selectedSubcategory;
            set
            {
                _selectedSubcategory = value;
                GetProductsById();
            }
        }

        public int SubcategoryHeight
        {
            get => _subcategoryHeight;
            set
            {
                _subcategoryHeight = value; 
                RaisePropertyChanged();
            }
        }
        //End Subcategories

        //Start Products
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                AddProductToList.Execute(null);
            }
        }

        public int ProductHeight
        {
            get => _productHeight;
            set
            {
                _productHeight = value;
                RaisePropertyChanged();
            }
        }
        //End Products

        public MenuPageModel(ICategoryService categoryService, ISubcategoryService subcategoryService, IProductService productService, IOrderService orderService)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _productService = productService;
            _orderService = orderService;
        }

        public override async void Init(object initData)
        {
            OrderedProducts = new List<Product>();
            await GetAllCategories();
            TotalProductsInOrderedProducts = 0;
            TotalPriceInOrderedProducts = 0;

            if (initData is Product product)
            {
                await Task.Delay(1);
                SelectedProduct = product;
            }

            base.Init(initData);
        }

        public override void ReverseInit(object returnedData)
        {
            //returns the product if orderd - if null then nothign was ordered (or added to OrderedProducts)
            if (returnedData is Product product)
            {
                _orderService.SaveProductToOrder(product);
                base.ReverseInit(returnedData);
            }
        }

        /// <summary>
        /// Gets all existing categories
        /// </summary>
        /// <returns></returns>
        private async Task GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            Categories = null;
            Categories = new ObservableCollection<Category>(categories);

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    CategoryHeight = Categories.Count * 45;
                    break;
                case Device.UWP:
                    CategoryHeight = Categories.Count * 60;
                    break;
                default:
                    CategoryHeight = Categories.Count * 50;
                    break;
            }
        }

        /// <summary>
        /// Gets all existing subcategories by Id
        /// </summary>
        /// <returns></returns>
        private async Task GetSubcategoriesById()
        {
            if (SelectedCategory != null)
            {
                Products = null;
                ProductHeight = 0;

                Subcategories = null;
                SubcategoryHeight = 0;

                var subcategories = await _subcategoryService.GetSubcategoriesByCategoryId(SelectedCategory.CategoryId);
                Subcategories = new ObservableCollection<Subcategory>(subcategories);
                
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        SubcategoryHeight = Subcategories.Count * 45;
                        break;
                    case Device.UWP:
                        SubcategoryHeight = Subcategories.Count * 60;
                        break;
                    default:
                        SubcategoryHeight = Subcategories.Count * 50;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets all existing subcategories by Id
        /// </summary>
        /// <returns></returns>
        private async Task GetProductsById()
        {
            if (SelectedSubcategory != null)
            {
                var products = await _productService.GetProductBySubcategoryId(SelectedSubcategory.SubcategoryId);
                Products = null;
                Products = new ObservableCollection<Product>(products);
                ProductHeight = Products.Count * 45;

                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        ProductHeight = Products.Count * 45;
                        break;
                    case Device.UWP:
                        ProductHeight = Products.Count * 60;
                        break;
                    default:
                        ProductHeight = Products.Count * 50;
                        break;
                }
            }
        }

        /// <summary>
        /// Return to menu command
        /// </summary>
        public ICommand PopCurrentPage
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        await CoreMethods.PopPageModel();
                    });
            }
        }

        /// <summary>
        /// Push selected product into ProductPage
        /// </summary>
        public ICommand AddProductToList
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        try
                        {
                            if (SelectedProduct != null)
                            {
                                await CoreMethods.PushPageModel<ProductPageModel>(SelectedProduct);
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Write(e.ToString());
                        }
                    });
            }
        }

        /// <summary>
        /// Push OrderedProducts into OrderPage
        /// </summary>
        public ICommand FinishCurrentOrder
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        try
                        {
                            if (OrderedProducts != null)
                            {
                                await CoreMethods.PushPageModel<OrderPageModel>();
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Write(e.ToString());
                        }
                    });
            }
        }

        /// <summary>
        /// Resets the order
        /// </summary>
        public ICommand ResetOrder
        {
            get
            {
                return  new Command(
                    async () =>
                    {
                        if (OrderedProducts.Count > 0)
                        {
                            OrderedProducts.Clear();
                            await _orderService.ClearOrderProducts();
                            RefreshPage();
                        }
                    });
            }
        }

        public async Task SyncOrderedProductsTask()
        {
            await Task.Delay(0);
            OrderedProducts  =  _orderService.GetOrder().Result.Products;
            RefreshPage();
        }

        /// <summary>
        /// Refreshes TotalProductsInOrderedProducts & TotalPriceInOrderedProducts
        /// </summary>
        private void RefreshPage()
        {
            int totalCount = 0;
            decimal totalPrice = 0;

            try
            {
                foreach (var orderedProduct in OrderedProducts)
                {
                    totalCount += orderedProduct.ProductQuantity;
                    totalPrice += orderedProduct.ProductPrice * orderedProduct.ProductQuantity;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            _orderService.UpdateOrderPriceAndCount(totalCount, totalPrice);
            TotalProductsInOrderedProducts = totalCount;
            TotalPriceInOrderedProducts = totalPrice;
        }
    }
}
