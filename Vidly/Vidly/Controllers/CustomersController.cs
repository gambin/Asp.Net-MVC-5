using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route ("customers")]
        public ActionResult Index()
        {
            // Old fashioned way
            /*
            List<Customer> cList = new List<Customer>();
            Customer a = new Customer();
            a.Id = 1;
            a.Name = "John Smith";
            Customer b = new Customer();
            b.Id = 2;
            b.Name = "Mary Willians";

            cList.Add(a);
            cList.Add(b);
            */

            // New way :)
            List<Customer> cList = new List<Customer>()
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Maty Willians"}
            };

            CustomersViewModel viewModel = new CustomersViewModel
            {
                Customers = cList
            };

            return View(viewModel);
        }

        [Route("customers/{id}")]
        public ActionResult Details(int id)
        {
            List<Customer> cList = new List<Customer>()
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Maty Willians"}
            };

            int posCliente = cList.FindIndex(x => x.Id == id);
            Customer customer = cList[posCliente];

            // return View(id);
            return View("Details", customer);
        }

    }
}