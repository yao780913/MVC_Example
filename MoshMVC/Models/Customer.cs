using MoshMVC.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoshMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    }
}