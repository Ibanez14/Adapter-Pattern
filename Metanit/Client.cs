using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_Patterns.Metanit
{
    // Adaptee:
    // 

    // Adapter: 
    // 

    #region Specification of Adapter Pattern


    /// <summary>
    /// Client => Использует объекты Target для реализации своих задач
    /// </summary>
    public class Client
    {
        public void WriteObject(Target target) =>
            target.WriteToExcel();

    }

    /// <summary>
    /// Target => представляет объекты, которые используются клиентом
    /// </summary>
    public class Target
    {
        public virtual void WriteToExcel()
        {
            // Writing to File
        }
    }


    /// <summary>
    /// Cобственно адаптер, который позволяет работать с объектами Adaptee как с объектами Target.
    /// </summary>
    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void WriteToExcel()
        {
            adaptee.WriteToWORD();
        }


    }

    /// <summary>
    /// представляет адаптируемый класс, который мы хотели бы использовать у клиента вместо объектов Target
    /// </summary>
    public class Adaptee
    {
        public void WriteToWORD()
        {
            // some new feature
        }
    }


    #endregion

}
