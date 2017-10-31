using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route ("customers")]
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
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

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }

    }
}