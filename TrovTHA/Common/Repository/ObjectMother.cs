using System;
using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// A place to put sample data
    /// </summary>
    public class ObjectMother
    {
        public static List<Purchase> GetTestPurchases()
        {
            var dateTimeNow = DateTime.Now;
            var result = new List<Purchase>
            {
                new Purchase {DateTime = dateTimeNow, ItemId = 1, DomainId = "1"},
                new Purchase {DateTime = dateTimeNow, ItemId = 2, DomainId = "2"},
                new Purchase {DateTime = dateTimeNow, ItemId = 3, DomainId = "3"},
            };
            return result;
        }


        public static List<Item> GetTestItems()
        {
            var result = new List<Item>
            {
                new Item {Name = "Apple", Price = 1, Description = "Gala apple.", DomainId = "1"},
                new Item {Name = "Orange", Price = 1, Description = "Sunkist orange.", DomainId = "2"},
                new Item {Name = "Ice Cream", Price = 5, Description = "Chocolate ice cream.", DomainId = "3"},
                new Item {Name = "Carton of Eggs", Price = 1, Description = "A dozen eggs.", DomainId = "4"}
            };
            return result;
        }
    }
}
