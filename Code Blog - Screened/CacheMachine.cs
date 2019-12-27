using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Adapter_Patterns.Code_Blog
{

    /// <summary>
    /// Кассовый аппарат собственного производства.
    /// </summary>
    public class CashMachine : ICashMachine
    {
        private List<Product> _products;

        /// <summary>
        /// Уникальный номер кассового аппарата.
        /// </summary>
        private Guid _number;

        public IReadOnlyList<Product> Products => _products;

        public string Id => _number.ToString();

        public CashMachine()
        {
            _number = Guid.NewGuid();
            _products = new List<Product>();
        }

        
        public void AddProduct(Product product)
            => _products.Add(product);
        
        public string PrintCheck()
        {
            var checkText = GetCheckText();
            Save(checkText);
            return checkText;
        }

        public void Save(string checkText)
        {
            using (var sr = new StreamWriter("checks.txt", true, Encoding.Default))
            {
                sr.WriteLine(checkText);
            }
            _products.Clear();
        }

        private string GetCheckText()
        {
            var date = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            var checkText = $"Кассовый чек от {date}\r\n";
            checkText += $"Идентификатор чека: {Guid.NewGuid()}\r\n";
            checkText += "Список товаров:\r\n";
            foreach (var product in _products)
            {
                checkText += $"{product.Name}\t\t\t{product.Price}\r\n";
            }
            var sum = _products.Sum(p => p.Price);
            checkText += $"ИТОГО\t\t\t{sum}\r\n";
            return checkText;
        }
    }
}
