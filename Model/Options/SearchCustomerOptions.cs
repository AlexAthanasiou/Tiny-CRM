using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCrm.Model.Options {
    class SearchCustomerOptions {

        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}