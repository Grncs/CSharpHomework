﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /// <summary>
    /// Customer the man who orders goods.
    /// </summary>

    [Serializable]
    class Customer {

    /// <summary>
    /// customer's identifier
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// customer's name
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    /// Customer constructor
    /// </summary>
    /// <param name="id">customer id</param>
    /// <param name="name">customer name </param>
    public Customer(uint id, string name) {
      this.Id = id;
      this.Name = name;
    }

    /// <summary>
    /// override ToString
    /// </summary>
    /// <returns>string:message of the Customer object</returns>
    public override string ToString() {
      return $"customerId:{Id}, CustomerName:{Name}";
    }

    public override bool Equals(object obj) {
            var customer1 = obj as Customer;
            if (customer1.Id == Id &&
                customer1.Name == Name)
                return true;
            return false;
        }
    public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }

    }
}
