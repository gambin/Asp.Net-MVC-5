using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        // definicao de Id de viewModel. identifica o Id do Cliente (customer obj)
        public int? Id { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        // property title que retorna o tipo de chamada na viewModel
        // e define se os headers e page title sao de edicao ou criacao
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        // Definicao de construct 'base' sem a necessidade de passagem de paramentros
        // Id default = 0
        public CustomerFormViewModel()
        {
            Id = 0;
        }

        // Definicao de construct definindo o Id do ViewModel com definicao de Id 
        // com o Id do current customer
        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Customer = customer;
        }
    }
}