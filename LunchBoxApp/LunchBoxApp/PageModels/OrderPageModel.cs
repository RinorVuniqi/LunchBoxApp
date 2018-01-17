using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using LunchBoxApp.Services;
using Xamarin.Forms;

namespace LunchBoxApp.PageModels
{
    public class OrderPageModel : FreshBasePageModel
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly ISoundPlayer _soundPlayer;
        private ObservableCollection<Product> _orderedProducts;
        private Order _order;
        private Product _selectedProduct;
        private decimal _orderTotalPrice;
        private int _orderTotalCount;
        private bool _deliverToCompany;
        private string _selectedPayment;
        private string _companyName;
        private bool _activityIndicator;
        private bool _orderProcessing;

        //Start Order & Ordered products
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Product> OrderedProducts
        {
            get => _orderedProducts;
            set
            {
                _orderedProducts = value;
                RaisePropertyChanged();
            }
        }

        public Decimal OrderTotalPrice
        {
            get => _orderTotalPrice;
            set
            {
                _orderTotalPrice = value;
                RaisePropertyChanged();
            }
        }

        public int OrderTotalCount
        {
            get => _orderTotalCount;
            set
            {
                _orderTotalCount = value;
                RaisePropertyChanged();
            }
        }

        public bool OrderProcessing
        {
            get => _orderProcessing;
            set
            {
                _orderProcessing = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Payment> Payments { get; set; }
        public List<string> PaymentNames { get; set; }

        public string SelectedPayment
        {
            get => _selectedPayment;
            set
            {
                _selectedPayment = value;
                RaisePropertyChanged();
            }
        }
        //End Order & Ordered products

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value; 
                RaisePropertyChanged();
            }
        }

        public bool DeliverToCompany
        {
            get => _deliverToCompany;
            set
            {
                _deliverToCompany = value;

                if (!value)
                {
                    CompanyName = "";
                }

                RaisePropertyChanged();
            }
        }

        public string CompanyName
        {
            get => _companyName;
            set
            {
                _companyName = value;
                RaisePropertyChanged();
            }
        }

        public bool ActivityIndicatorVisible
        {
            get => _activityIndicator;
            set
            {
                _activityIndicator = value;
                RaisePropertyChanged();
            }
        }

        public OrderPageModel(IUserService userService, IOrderService orderService, IPaymentService paymentService, ISoundPlayer soundPlayer)
        {
            _userService = userService;
            _orderService = orderService;
            _paymentService = paymentService;
            _soundPlayer = soundPlayer;

        }

        public override void Init(object initData)
        {
            if (_orderService.GetOrder().Result != null)
            {
                Order = _orderService.GetOrder().Result;
                OrderedProducts = new ObservableCollection<Product>(Order.Products);
                OrderTotalPrice = Order.OrderTotalPrice;
                OrderTotalCount = Order.OrderTotalProductCount;
                ActivityIndicatorVisible = false;
                OrderProcessing = true;
                base.Init(initData);
            }

            if (_paymentService.GetPayments().Result != null)
            {
                Payments = new ObservableCollection<Payment>(_paymentService.GetPayments().Result);
                PaymentNames = new List<string>();

                foreach (var payment in Payments)
                {
                    PaymentNames.Add(payment.PaymentName);
                    SelectedPayment = PaymentNames.FirstOrDefault();
                }
            }
        }

        public ICommand DeleteSelectedProduct
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
                                await _orderService.RemoveProductFromOrder(SelectedProduct);
                                OrderedProducts = new ObservableCollection<Product>(_orderService.GetOrder().Result.Products);

                                if (OrderedProducts.Count == 0)
                                {
                                    await CoreMethods.PopPageModel();
                                }

                                RefreshPage();
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Write(e.ToString());
                        }
                    });
            }
        }

        public ICommand SubmitOrder
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        if (string.IsNullOrWhiteSpace(CompanyName))
                        {
                            DeliverToCompany = false;
                            CompanyName = "Lunchbox";
                            await _orderService.UpdateOrderCompany("Lunchbox");
                        }
                        else
                        {
                            await _orderService.UpdateOrderCompany(CompanyName);
                        }
                        
                        await _orderService.UpdateOrderPayment(Payments.FirstOrDefault(p => p.PaymentName == SelectedPayment));

                        OrderProcessing = false;
                        ActivityIndicatorVisible = true;

                        EmailService email = new EmailService();
                        bool emailSent = false;

                        await Task.Run(async () => { emailSent = await email.SendEmail(_orderService.GetOrder().Result, _userService.GetCurrentUser().Result); });

                        ActivityIndicatorVisible = false;

                        if (emailSent)
                        {
                            await _soundPlayer.PlaySuccessSound();

                            await CoreMethods.DisplayAlert("Succes", "De bestelling werd correct verzonden!", "Ok");
                            await _orderService.ClearOrderProducts();
                            await CoreMethods.PopPageModel();
                        }
                        else
                        {
                            await _soundPlayer.PlayDeniedSound();
                            await CoreMethods.DisplayAlert("Error", "Er liep iets verkeerd bij uw bestelling. Controleer of u een actieve internetverbinding heeft.", "Ok");
                        }
                    });
            }
        }

        private void RefreshPage()
        {
            int totalCount = 0;
            decimal totalPrice = 0;

            foreach (var orderedProduct in OrderedProducts)
            {
                totalCount += orderedProduct.ProductQuantity;
                totalPrice += orderedProduct.ProductPrice * orderedProduct.ProductQuantity;
            }

            _orderService.UpdateOrderPriceAndCount(totalCount, totalPrice);
            OrderTotalCount = totalCount;
            OrderTotalPrice = totalPrice;
        }
    }
}
