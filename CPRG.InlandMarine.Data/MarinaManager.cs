using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CPRG.InlandMarine.Data
{     /*
    * CPRG 214 Assignment 1
    * Purpose: This is the code that queries the data entities for the forms
    * Author: Doug Cameron and Ini Akpan
    * Date: July, 2020
    */
    public class MarinaManager
    {   

        //this method will check if the user already exist in the database
        public static CustomerDTO Authenticate(string firstname, string lastname)
        {
            CustomerDTO dto = null;
            var db = new MarinaEntities();
            //call to the database using the  lambda expression
            var auth = db.Customers.
                SingleOrDefault(a => a.FirstName == firstname && a.LastName == lastname);
            if (auth != null)  //if the customer is found
            {
                dto = new CustomerDTO // create a new DTO
                {
                    ID = auth.ID,
                    FullName = $"{auth.FirstName} {auth.LastName}"
                };
            }
            return dto;
        }
        //method for adding new customer to the database
        //takes the new customer object as input
        public static void AddCust(Customer cust)
        {
            var db = new MarinaEntities();
            db.Customers.Add(cust); //add customer to the database
            db.SaveChanges(); // save changes
        }

        //get all the docks from the database for the drop down list
        public IList GetDocks()
        {
            var db = new MarinaEntities();
            var docks = db.Docks.Select(d => new
            { ID = d.ID, Name = d.Name }).ToList();
            return docks;
        }
  

        //method to get the data from leases for a particular customer
        public IList GetSlipsGridviewCustomer(int selected)
        {
            using (var context = new MarinaEntities())
            {
                         
                //var customerSlips = context.Leases.Where(s => s.CustomerID == selected)
                //    .Select(s => s).ToList();
                var customerSlips = context.Leases.Where(s => s.CustomerID == selected)
                    .OrderBy(d => d.SlipID)
                    .Select(d => new { d.SlipID }).ToList();

                return customerSlips;
            }
        }
        //method to get a list of available slips for the dropdown list
        public IList GetSlipsAvailable(int selected)
        {
            
            using (var context = new MarinaEntities())
            {
                var availableSlips = context.Slips.Where(s => s.Leases.Count == 0 && s.DockID == selected)
                    //.Select(s => s).ToList();
                     .OrderBy(d => d.ID)
                    .Select(d => new { d.ID }).ToList();
                return availableSlips;
            }
        }
        //method that adds the lease informaton to the lease table
        //once the customer selects it
        public static void AddLease(Lease lease)
        {
            var db = new MarinaEntities();
            db.Leases.Add(lease); //add customer to the database
            db.SaveChanges(); // save changes
        }
    }
}
