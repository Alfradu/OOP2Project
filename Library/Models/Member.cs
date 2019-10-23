using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Member
    {

        [Key]
        public int Id { get; set; }
        public string PersonalId { get; set; }
        public string Name { get; set; }
        public DateTime MembershipDate { get; set; }
        public List<Loan> Loans { get; set; }

        public Member()
        {
            Loans = new List<Loan>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}