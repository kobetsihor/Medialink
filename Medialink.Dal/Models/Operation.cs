using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Medialink.Dal.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public double Result { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}