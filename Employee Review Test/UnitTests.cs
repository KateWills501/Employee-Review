﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee_Review;

namespace Employee_Review_Test
{
    [TestClass]
    public class EmployeeReviewTest
    {
        Department d = new Department("Sales");
        Employee kate = new Employee("Kate", "kramsey@thv11.com", "501-743-6074", 8000);
        Employee parker = new Employee("Dave Parker", "news@thv11.com", "501-244-4514", 10000);
        Employee byron = new Employee("B-dubs", "bwilkinson@thv11.com", "501-244-4517", 2 );


        [TestMethod]
        public void DepartmentCreation()
        {
            Department news = new Department("News");
            Assert.AreEqual("News", news.Name);
        }

        [TestMethod]
        public void EmployeeCreation()
        {
            Employee parker = new Employee("Dave Parker", "news@thv11.com", "501-244-4514", 10000);
            Assert.AreEqual("Dave Parker", parker.Name);
        }

        [TestMethod]
        public void EmployeeName()
        {
            Assert.AreEqual("Kate", kate.Name);
        }

        [TestMethod]
        public void AddEmployeeToDepartment()
        {
            d.AddEmployee(kate);
            Assert.IsFalse(d.Employees.Count == 0);

            Assert.AreSame("Kate", d.Employees[0].Name);
        }

        [TestMethod]
        public void AddMultipleEmployeesToDepartment()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);
            Assert.IsFalse(d.Employees.Count == 0);

            Assert.AreSame("Kate", d.Employees[0].Name);
            Assert.AreSame("B-dubs", d.Employees[1].Name);
            Assert.AreSame("Dave Parker", d.Employees[2].Name);
        }

        [TestMethod]
        public void GetEmployeeName()
        {
            string employeeName = kate.Name;
            Assert.AreEqual("Kate", employeeName);
        }

        [TestMethod]
        public void GetEmployeeSalary()
        {
            decimal employeeSalary = kate.Salary;
            Assert.AreEqual(8000, employeeSalary);
        }

        [TestMethod]
        public void GetDepartmentName()
        {
            string departmentName = d.Name;
            Assert.AreEqual("Sales", departmentName);
        }

        [TestMethod]
        public void GetDepartmentSalary()
        {
            d.AddEmployee(kate);
            decimal departmentSalary = d.TotalSalaries();
            Assert.AreEqual(8000, departmentSalary);
        }

        [TestMethod]
        public void AddReviewText()
        {
            kate.Review = "Kate is amazing and we need to pay her more! The best employee I've ever had!!";
            Assert.IsNotNull(kate.Review);
        }

        [TestMethod]
        public void AssignNegativeReview()
        {
            kate.Review = "Kate is amazing and we need to pay her more! The best employee I've ever had!!";
            kate.EvaluateReview();
            Assert.IsFalse(kate.IsSatisfactory);
        }

        [TestMethod]
        public void AssignPositiveReview()
        {
            kate.Review = "Kate is amazing and we need to pay her more! The best employee I've ever had!!";
            kate.EvaluateReview();
            Assert.IsTrue(kate.IsSatisfactory);
        }


        [TestMethod]
        public void MarkEmployeeSatisfactory()
        {
            kate.IsSatisfactory = true;
            Assert.IsTrue(kate.IsSatisfactory);
        }

        [TestMethod]
        public void TestRaise()
        {
            kate.Raise(200);
            Assert.AreEqual(8200, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaise()
        {
            d.AddEmployee(kate);
            kate.IsSatisfactory = true;
            d.DepartmentRaise(200);
            Assert.AreEqual(8200, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaiseWithMultipleEmployeesAllSatisfactory()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);

            kate.IsSatisfactory = true;
            parker.IsSatisfactory = true;
            byron.IsSatisfactory = true;
            d.DepartmentRaise(3000);
            Assert.AreEqual(9000, kate.Salary);
        }

        [TestMethod]
        public void TestDepartmentRaiseWithMultipleEmployeesNotAllSatisfactory()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);

            kate.IsSatisfactory = true;
            parker.IsSatisfactory = false;
            byron.IsSatisfactory = true;
            d.DepartmentRaise(2000);
            Assert.AreEqual(9000, kate.Salary);
        }

        [TestMethod]
        public void PrintingEmployeeInfo()
        {
            d.AddEmployee(kate);
            d.AddEmployee(byron);
            d.AddEmployee(parker);

            kate.IsSatisfactory = true;
            parker.IsSatisfactory = false;
            byron.IsSatisfactory = true;

            string employeeInfoString = "";

            employeeInfoString = $"{d.Employees[0].Name}'s email address is {d.Employees[0].EmailAddress} " +
                                 $"Their phone number is {d.Employees[0].PhoneNumber} " +
                                 $"and their salary is ${d.Employees[0].Salary}. " +
                                 $"They are currently marked as Satisfactory: {d.Employees[0].IsSatisfactory}";

            Assert.AreEqual("Kate's email address is kramsey@thv11.com Their phone number is 501-743-6074 and their salary is $8000. They are currently marked as Satisfactory: True", employeeInfoString);


            
                
            
        }
    }
}
