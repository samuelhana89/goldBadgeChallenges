using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoDepartment_Repository
{
    public class KomodoDepartment
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public KomodoDepartment() { }
        public KomodoDepartment(int claimID, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        public override string ToString()
        {

         return $" {this.ClaimID}\t" +
                $" {this.ClaimType}\t\t" +
                $" {this.Description}\t" +
                $"${this.ClaimAmount}\t" +
                $" {this.DateOfIncident.ToShortDateString()}\t\t" +
                $" {this.DateOfClaim.ToShortDateString()}\t" +
                $" {this.IsValid}";
        }

    }
}


