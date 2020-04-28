using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Domain
{
    public class FiverrServices
    {
        public Guid Id { get; set; }
        public decimal Rate { get; set; }
        public string FiverrURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = "";
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
