using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter_Patterns.Code_Blog
{
    /// <summary>
    /// Иностранный кассовый аппарат.
    /// </summary>
    public class ForeignCashMachine
    {
        private List<Check> _checks = new List<Check>();

        public string Name { get; private set; }

        public Check[] Checks => 
            _checks.ToArray();

        public Check CurrentCheck =>
            _checks.LastOrDefault();

     
        public ForeignCashMachine()
        {
            var rnd = new Random();
            Name = $"KKA{rnd.Next(10000, 99999)}";
            _checks.Add(new Check());
        }

        public void Add(string name, decimal price)
        {
            CurrentCheck.Add(name, price);
        }

    
        public Check Save()
        {
            var check = (Check)CurrentCheck.Clone();
            _checks.Add(new Check());
            return check;
        }
    }
}
