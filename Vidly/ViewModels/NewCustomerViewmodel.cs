using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewmodel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customers Customer { get; set; }
    }
}