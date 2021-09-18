using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class VmBook
    {
        public int BookId { get; set; }
        public string Code { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
    }
}