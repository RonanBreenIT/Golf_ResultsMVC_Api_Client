using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_ResultsMVC_Api_Client.Models
{
    class Competition
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Comp_Result> Comp_Result { get; set; }

        public override string ToString()
        {
            return "\nID: " + ID + "\nName: " + Name;
        }

    }
}