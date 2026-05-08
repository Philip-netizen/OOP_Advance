using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedOOPConsoleApp
{
    // ============================
    // 1. ABSTRACTION (Base Class)
    // ============================
    public abstract class Employee
    {
        public int EmpId { get; private set; }
        public string Name { get; private set; }

        protected Employee(int empId, string name)
        {
            EmpId = empId;
            Name = name;
        }

        public abstract decimal CalculateSalary();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {EmpId} | Name: {Name} | Salary: {CalculateSalary()}");
        }
    }

    // ============================
    // 2. INHERITANCE + POLYMORPHISM
    // ============================
    public class RegularEmployee : Employee
    {
        public decimal MonthlySalary { get; private set; }

        public RegularEmployee(int empId, string name, decimal monthlySalary)
            : base(empId, name)
        {
            MonthlySalary = monthlySalary;
        }

        public override decimal CalculateSalary()
        {
            return MonthlySalary;
        }
    }

    public class ContractEmployee : Employee
    {
        public decimal HourlyRate { get; private set; }
        public int HoursWorked { get; private set; }

        public ContractEmployee(int empId, string name, decimal hourlyRate, int hoursWorked)
            : base(empId, name)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Contract] ID: {EmpId} | Name: {Name} | Salary: {CalculateSalary()}");
        }
    }

    // ============================
    // 3. INTERFACE (Repository)
    // ============================
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<Employee> GetAll();
        Employee GetById(int empId);
    }

    // ============================
    // 4. REPOSITORY IMPLEMENTATION
    // ============================
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public void Add(Employee employee)
        {
            if (_employees.Any(e => e.EmpId == employee.EmpId))
                throw new Exception("Employee ID already exists!");

            _employees.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int empId)
        {
            return _employees.FirstOrDefault(e => e.EmpId == empId);
        }
    }

    // ============================
    // 5. FACTORY PATTERN
    // ============================
    public static class EmployeeFactory
    {
        public static Employee CreateEmployee(string type, int id, string name, decimal salaryOrRate, int hours = 0)
        {
            return type.ToLower() switch
            {
                "regular" => new RegularEmployee(id, name, salaryOrRate),
                "contract" => new ContractEmployee(id, name, salaryOrRate, hours),
                _ => throw new Exception("Invalid employee type!")
            };
        }
    }

    // ============================
    // 6. SERVICE LAYER (SOLID)
    // ============================
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
        }

        public void DisplayAllEmployees()
        {
            var employees = _repository.GetAll();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var emp in employees)
            {
                emp.DisplayInfo();
            }
        }

        public void DisplayEmployeeById(int empId)
        {
            var emp = _repository.GetById(empId);

            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            emp.DisplayInfo();
        }
    }

    // ============================
    // 7. MAIN PROGRAM (UI LAYER)
    // ============================
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository repo = new EmployeeRepository();
            EmployeeService service = new EmployeeService(repo);

            while (true)
            {
                Console.WriteLine("\n==== HR MANAGEMENT SYSTEM ====");
                Console.WriteLine("1. Add Regular Employee");
                Console.WriteLine("2. Add Contract Employee");
                Console.WriteLine("3. View All Employees");
                Console.WriteLine("4. View Employee By ID");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddRegularEmployee(service);
                            break;

                        case "2":
                            AddContractEmployee(service);
                            break;

                        case "3":
                            service.DisplayAllEmployees();
                            break;

                        case "4":
                            ViewEmployeeById(service);
                            break;

                        case "5":
                            Console.WriteLine("Exiting system...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }

        static void AddRegularEmployee(EmployeeService service)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Monthly Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Employee emp = EmployeeFactory.CreateEmployee("regular", id, name, salary);

            service.AddEmployee(emp);
            Console.WriteLine("Regular employee added successfully!");
        }

        static void AddContractEmployee(EmployeeService service)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Hourly Rate: ");
            decimal rate = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Hours Worked: ");
            int hours = int.Parse(Console.ReadLine());

            Employee emp = EmployeeFactory.CreateEmployee("contract", id, name, rate, hours);

            service.AddEmployee(emp);
            Console.WriteLine("Contract employee added successfully!");
        }

        static void ViewEmployeeById(EmployeeService service)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            service.DisplayEmployeeById(id);
        }
    }
}
