using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using TinyCrm.Model;
using TinyCrm.Model.Options;

namespace TinyCrm.Services {
    /// <summary>
    /// 
    /// </summary>
    class CustomerService : ICustomerService {

        private List<Customer> CustomerList = new List<Customer>();

        public bool AddCustomer(AddCustomerOptions options) {

            if (options == null) {
                return false;
            }

            if (!IsValidEmail(options.Email)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.VatNumber)) {
                return false;
            }

            var customer = GetCustomerByVatNumber(options.VatNumber);

            if (customer != null) {
                return false;
            }

            var tempId = UniqueId();

            customer = new Customer() {
                Id = tempId,
                Email = options.Email,
                VatNumber = options.VatNumber,
                Status = true
            };

            CustomerList.Add(customer);

            Console.WriteLine($"{CustomerList[0].Email}" +
                              $" and {CustomerList[0].Id} " +
                              $"and {CustomerList[0].VatNumber}" +
                              $" and {CustomerList[0].Status}");

            return true;
        }

        public bool UpdateCustomerInfo(int customerId,
            UpdateCustomerOptions options) {

            if (options == null) {
                return false;
            }

            var customer = GetCustomerById(customerId);
            if (customer == null) {
                return false;
            }

            if (IsValidEmail(options.Email)) {
                customer.Email = options.Email;
            }

            if (!string.IsNullOrWhiteSpace(options.Phone)) {
                customer.Phone = options.Phone;
            }

            customer.Status = options.Status;

            return true;
        }

        public Customer GetCustomerById(int? id) {

            return CustomerList.
                SingleOrDefault(c => c.Id.Equals(id));
        }

        public Customer GetCustomerByVatNumber(string vatnumber) {

            return CustomerList.
                SingleOrDefault(c => c.VatNumber.Equals(vatnumber));
        }

        public List<Customer> SearchCustomers(SearchCustomerOptions options) {

            var filteredList = new List<Customer>(CustomerList);

            filteredList = filteredList
                .Where(c => c.Status == true).ToList();

            if (!string.IsNullOrWhiteSpace(options.VatNumber)) {
                filteredList = filteredList
                    .Where(c => c.VatNumber.Equals(options.VatNumber)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(options.Email)) {
                filteredList = filteredList
                    .Where(c => c.Email.Equals(options.Email)).ToList();
            }

            if (options.DateTime != null) {
                filteredList = filteredList
                    .Where(c => c.DateTime.Equals(options.DateTime)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(options.Phone)) {
                filteredList = filteredList
                    .Where(c => c.Phone.Equals(options.Phone)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(options.Lastname)) {
                filteredList = filteredList
                    .Where(c => c.Lastname.Equals(options.Lastname)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(options.Firstname)) {
                filteredList = filteredList
                    .Where(c => c.Firstname.Equals(options.Firstname)).ToList();
            }

            if (options.Id != null) {
                filteredList = filteredList.Where(c => c.Id == options.Id).ToList();
            }

            if (options.Status != null) {
                filteredList = filteredList.Where(c => c.Status == options.Status).ToList();
            }

            return filteredList;
        }

        public bool IsValidEmail(string email) {

            try {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException e) {
                return false;
            }
        }

        public int UniqueId() {

            var now = DateTime.Now;
            var zeroDate = DateTime.MinValue
                .AddHours(now.Hour)
                .AddMinutes(now.Minute)
                .AddSeconds(now.Second)
                .AddMilliseconds(now.Millisecond);
            var uniqueId = (int)(zeroDate.Ticks / 10000);

            return uniqueId;
        }

    }
}
