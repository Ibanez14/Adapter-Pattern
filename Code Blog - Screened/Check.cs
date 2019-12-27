using System;
using System.Collections.Generic;

namespace Adapter_Patterns.Code_Blog
{
    public class Check : ICloneable
    {
      
        private List<Product> _products;
        public int Number { get; private set; }
        public DateTime DateTime { get; private set; }
        public IReadOnlyList<Product> Products => _products;
 
        public Check()
        {
            var rnd = new Random();
            Number = rnd.Next(10000, 99999);
            DateTime = DateTime.Now;
            _products = new List<Product>();
        }

        /// <summary>
        /// Добавить товар в чек.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public void Add(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (price < 0)
                throw new ArgumentException("Цена не может быть меньше нуля.", nameof(price));

            _products.Add(new Product(name, price));
        }

        /// <summary>
        /// Создать копию чека.
        /// </summary>
        /// <returns>Копия чека.</returns>
        public object Clone()
        {
            return new Check()
            {
                _products = _products,
                DateTime = DateTime,
                Number = Number
            };
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Текст чека.</returns>
        public override string ToString()
        {
            var checkText = $"Кассовый чек от {DateTime.ToString("HH:mm dd.MMMM.yyyy")}\r\n";
            checkText += $"Номер чека: {Number}\r\n";
            return checkText;
        }
    }
}
}