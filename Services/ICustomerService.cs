using System.Collections.Generic;
using TinyCrm.Model;
using TinyCrm.Model.Options;

namespace TinyCrm.Services {
    interface ICustomerService {

        bool AddCustomer(AddCustomerOptions options);

        bool UpdateCustomerInfo(int customerId,
            UpdateCustomerOptions options);
 
        Customer GetCustomerById(int? id);

        Customer GetCustomerByVatNumber(string vatnumber);

        List<Customer> SearchCustomers(SearchCustomerOptions options);

        bool IsValidEmail(string email);

        int UniqueId();
    }
}
