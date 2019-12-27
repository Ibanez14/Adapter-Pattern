﻿using System;
using System.Collections.Generic;
using System.Text;
using static Adapter_Patterns.dotnettutorials.net.ThirdPartyBillingSystem;


/// <summary>
/// Object Adapter DP
/// </summary>



namespace Adapter_Patterns.dotnettutorials.net
{

    // SCREENED


    // CLIENT  class can only see the Target interface
    class Client
    {
        static void Using(string[] args)
        {
            string[,] employeesArray = new string[5, 4]
            {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
            };

            ITarget target = new EmployeeAdapter(); // EmployeeADapter inside use Adaptee
            target.ProcessCompanySalary(employeesArray);
        }
    }


    // ADAPTee: который мы хотели бы использовать у клиента вместо объектов Target но используем в Адаптере
    public class ThirdPartyBillingSystem
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public Employee(int id, string name, decimal salary)
            {
                ID = id;
                Name = name;
                Salary = salary;
            }
        }

        public void CountSalary(List<Employee> listEmployee)
        {
            foreach (Employee employee in listEmployee)
                Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.Name + " Account");
        }
    }




    // TARGET: Представляет объекты, которые используются клиентом
    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }



    // ADAPTER, который позволяет работать с объектами Adaptee как с объектами Target.
    public class EmployeeAdapter : ITarget
    {
        ThirdPartyBillingSystem thirdPartySystem;
        public EmployeeAdapter(ThirdPartyBillingSystem sys)
        {
            thirdPartySystem = sys;
        }

        #region ctor

        public EmployeeAdapter()
        {
            thirdPartySystem = new ThirdPartyBillingSystem();
        }


        #endregion


        public void ProcessCompanySalary(string[,] employeesArray)
        {
            string Id = null;
            string Name = null;
            string Salary = null;
            List<Employee> listEmployee = new List<Employee>();

            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0) Id = employeesArray[i, j];
                    else if (j == 1) Name = employeesArray[i, j];
                    else Salary = employeesArray[i, j];
                }
                listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Convert.ToDecimal(Salary)));
            }

            thirdPartySystem.CountSalary(listEmployee);
        }


    }
}