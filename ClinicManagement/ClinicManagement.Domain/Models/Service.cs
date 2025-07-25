using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Models
{
    public class Service
    {
        public Service(string name, string description, double value, int duration)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Value = value;
            Duration = duration;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Value { get; private set; }
        public int Duration { get; private set; }
        public List<Consult> Consults { get; set; } = new List<Consult>();

    }
}
