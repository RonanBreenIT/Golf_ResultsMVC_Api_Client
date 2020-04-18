using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_ResultsMVC_Api_Client.Models
{
    class Golfer
    {
        public int ID { get; set; }

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return Firstname + " " + Surname;
            }
        }

        public virtual ICollection<Comp_Result> Comp_Result { get; set; }

        public override string ToString()
        {
            return "\nID: " + ID + "\nGolfer Name: " + FullName;
        }
    }
}
  
