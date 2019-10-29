using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Defines the Member table in the database.
    /// </summary>
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PersonalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
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