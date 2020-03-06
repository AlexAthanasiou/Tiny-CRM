using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Model;
using TinyCrm.Model.Options;

namespace TinyCrm.Services {
    class OrderService : IOrderService
    {
        List<Order> OrderList = new List<Order>();
      

        public bool AddNewOrder(AddOrderOptions options) {

            if (options == null) {
                return false;
            }

            if (options.Id == null) {
                return false;
            }

            if (options.Products == null) {
                return false;
            }

            var customerService = new CustomerService();
          var customer =  customerService.GetCustomerById(options.Id);

            if (customer == null) {
                Console.WriteLine("No customer with such id");
                return false;
            }

            if (customer.Status == false) {
                Console.WriteLine("the customer is inactive");
                return false;
            }

            var productService = new ProductService();
             foreach (var p in options.Products) {
                    var   product = productService.GetProductById(p.Id);

                if (product == null) {

                    Console.WriteLine($" The product with id {p.Id} does not exist ");
                    return false;
                }

             }

            var newOrder = new Order();
            newOrder.Id = options.Id;
            newOrder.Products = new List<Product>(options.Products);
            newOrder.OrderStatus = true;
          

            OrderList.Add(newOrder);
            GetOrderDetails(newOrder);
            return true;

        }

        public Order GetOrderDetails(Order order) {


            Console.WriteLine($"The order with Id : {order.Id}  is in progress ");
            return order;

        }

        public bool UpdateOrder(int? id, UpdateOrderOptions options) {


            if (id == null) {
                return false;
            }

            var order = GetOrderById(id);
            if (order == null) {
                Console.WriteLine("there is no such order");
                return false;
            }


            if (order.OrderStatus == true) {

                Console.WriteLine("If you want to update the product list press 1" +
                                  "if you want to delete an order press 2");
                var temp = int.Parse(Console.ReadLine());
                if (temp == 1) {

                    if (options == null) {
                        Console.WriteLine("option null");
                        return false;
                    }

                    if (options.Products == null) {
                        Console.WriteLine("products null");
                        return false;
                    }

                    order.Products = new List<Product>(options.Products);
                }

                if (temp == 2) {
                    OrderList.Remove(order);
                }


            }

            return true;
        }

        public Order GetOrderById(int? id) {

            return OrderList.SingleOrDefault(o => o.Id.Equals(id));
        }

    }
}
