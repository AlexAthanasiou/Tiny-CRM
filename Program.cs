using System;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new Services.ProductService();
            productService.AddProduct(
                new Model.Options.AddProductOptions() {
                    Id = "123",
                    Price = 13.33M,
                    ProductCategory = Model.ProductCategory.Cameras,
                    Name = "Camera 1"
                });

            productService.UpdateProduct("123",
                new Model.Options.UpdateProductOptions() {
                    Price = 22.22M
                });


            var customerService = new Services.CustomerService();
            customerService.AddCustomer(
                new Model.Options.AddCustomerOptions() {
                    VatNumber = "107786108",
                   Email = "alex_a_@thhotmail.com"

                });

          var cust1=  customerService.GetCustomerByVatNumber("107786108");

            Console.WriteLine($"{cust1.Id} k {cust1.VatNumber}");

            customerService.AddCustomer(
           new Model.Options.AddCustomerOptions() {
               VatNumber = "107786108",
               Email = "alex_a_@thhotmail.com"

           });

            var orderService = new Services.OrderService();
            orderService.AddNewOrder(new Model.Options.AddOrderOptions() {

                Id = cust1.Id,                
                Products = productService.ProductsList

            }) ;
            Console.WriteLine($"{cust1.Id} k {cust1.VatNumber}");
            Console.ReadLine();
            
        }
    }
}
