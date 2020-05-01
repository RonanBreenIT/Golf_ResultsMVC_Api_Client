using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_ResultsMVC_Api_Client.Models
{
    class Comp_Result
    {
        public int CompResultID { get; set; } // More than one results for each comp i.e. Comp 1 results for each year 2020, 2019 etc..

        public int CompetitionID { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string FullDate
        {
            get
            {
                return StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString();
            }
        }

        public int GolferID { get; set; }

        public string Position { get; set; } //? allows it to be null. If null will make missed cut.

        public int Season { get; set; }
        public string GolferScore { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual Golfer Golfer { get; set; }

        public override string ToString()
        {
            return "\nComp ID: " + CompetitionID + "\nSeason: " + Season + "\nGolfer ID: " + GolferID + "\nScore: " + GolferScore + "\nDates: " + FullDate + "\n";
        }
    }
}