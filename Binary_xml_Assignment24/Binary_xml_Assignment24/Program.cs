using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EmployeeAssignment_24;
using System.Xml.Serialization;

namespace BinaryXmlSeEmployee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee em = new Employee
            {
                Id = 101,
                FirstName = "Ethan",
                LastName = "Hunt",
                Salary = 50000.95
            };

            //Binary Serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"D:\\SimpliLearn Course\\Day21\\Assignment24_Employee\\employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, em);
            }
            Console.WriteLine("Binary Serialization of Employee");



            //Binary Deserialization
            Employee deserializedEmployee;
            using (FileStream fs = new FileStream(@"D:\\SimpliLearn Course\\Day21\\Assignment24_Employee\\employee.bin", FileMode.Open))
            {
                deserializedEmployee = (Employee)formatter.Deserialize(fs);
                Console.WriteLine("\nBinary Deserialization of Employee");
                Console.WriteLine("ID: " + deserializedEmployee.Id);
                Console.WriteLine("First Name: " + deserializedEmployee.FirstName);
                Console.WriteLine("Last Name: " + deserializedEmployee.LastName);
                Console.WriteLine("Salary: " + deserializedEmployee.Salary);
            }
            Console.ReadKey();

            //XML Serialization

            Employee employee = new Employee
            {
                Id = 102,
                FirstName = "Ilsa",
                LastName = "Faust",
                Salary = 35000.90
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter write = new StreamWriter(@"D:\\SimpliLearn Course\\Day21\\Assignment24_Employee\\employee.xml"))
            {
                serializer.Serialize(write, employee);
            }
            Console.WriteLine("\nXML Serializtion of Employee");


            //XML Deserialization
            // Employee deserializedXmlEmployee;
            using (TextReader reader = new StreamReader(@"D:\\SimpliLearn Course\\Day21\\Assignment24_Employee\\employee.xml"))
            {
                Employee deserializedXmlEmployee = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("\nXML Deserializarion of Employee");
                Console.WriteLine("Id: " + deserializedXmlEmployee.Id);
                Console.WriteLine("First Name: " + deserializedXmlEmployee.FirstName);
                Console.WriteLine("Last Name: " + deserializedXmlEmployee.LastName);
                Console.WriteLine("Salary: " + deserializedXmlEmployee.Salary);
            }
            Console.ReadKey();
        }
    }
}