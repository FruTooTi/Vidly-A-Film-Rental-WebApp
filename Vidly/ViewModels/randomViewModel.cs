using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class randomViewModel
    {
        public Movie movies { get; set; }
        public List<Customers> customers { get; set; }
    }
}