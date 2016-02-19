using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallData.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Id, Name);
        }
    }
}