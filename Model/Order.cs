using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Services;

namespace TinyCrm.Model {
    class Order   {

        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product> Products;

        /// <summary>
        /// 
        /// </summary>
        public bool OrderStatus;

        /// <summary>
        /// 
        /// </summary>
       // public decimal TotalAmount;


    }
}
