using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceNetwork.Data.Models
{
    public class TrustedPeople
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrustedUserId { get; set; }

        public virtual User User { get; set; }
    }
}
