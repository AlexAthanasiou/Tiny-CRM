using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCrm.Model.Options {
    class AddOrderOptions {

        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set;  }

        /// <summary>
        /// 
        /// </summary>
        public List<Product> Products = new List<Product>();
    }
}
