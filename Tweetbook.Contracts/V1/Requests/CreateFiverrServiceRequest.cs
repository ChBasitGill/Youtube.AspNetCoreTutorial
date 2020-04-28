using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tweetbook.Contracts.V1.Requests
{
    public class CreateFiverrServiceRequest
    {
        public decimal rate { get; set; }
        public string fiverrURL { get; set; }
        public string title { get; set; }   
        public string description { get; set; }
        public IFormFile image { get; set; }
    }
    public class UpdateeFiverrServiceRequest
    {
        public Guid Id { get; set; }
        public decimal Rate { get; set; }
        public string FiverrURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
