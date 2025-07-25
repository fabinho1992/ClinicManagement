using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Services
{
    public class ResponseServisesList
    {
        public ResponseServisesList(Guid id, string name, string description, double value, int duration)
        {
            Id = id;
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
    }
}
