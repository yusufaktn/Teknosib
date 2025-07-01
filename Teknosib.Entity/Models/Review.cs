using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknosib.Entity.Models
{
    public class Review:BaseEntitiy
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project  { get; set; }

        public Guid ReviewerId { get; set; }//AppUserId
        public AppUser Reviewer { get; set; }

        public Guid RevieweeId { get; set; }//AppUserId
        public AppUser Reviewee { get; set; }



    }
}
