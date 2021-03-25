using System.Globalization;
using System;


namespace entities
{
    class Employeer : IComparable
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employeer(string csvEmployee)
        {
            string[] line = csvEmployee.Split(',');
            Name = line[0];
            Salary = double.Parse(line[1], CultureInfo.InvariantCulture);
        }
        public override string ToString()
        {
            return Name + ", " + Salary.ToString("F2", CultureInfo.InvariantCulture);
        }
        public int CompareTo(object obj)
        {
            if(!(obj is Employeer))
            {
                throw new ArgumentException("Error");
            }
            Employeer other = obj as Employeer;
            return Salary.CompareTo(other.Salary);
        }
    }
}
