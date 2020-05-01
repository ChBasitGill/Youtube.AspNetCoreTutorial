using System;
using System.Collections.Generic;
using System.Text;

namespace Tweetbook.Contracts.V1.Responses
{
 public class CreateFiverrServiceResponse
    {
        public decimal Rate { get; set; }
        public string FiverrURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Categories { get; set; }
        public string UserId { get; set; }
    }

}
