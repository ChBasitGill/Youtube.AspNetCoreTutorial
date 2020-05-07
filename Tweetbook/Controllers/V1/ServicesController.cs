using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;
using Tweetbook.Domain;
using Tweetbook.Extensions;
using Tweetbook.Services;

namespace Tweetbook.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServicesController : Controller
    {
        private readonly IFiverrService _service;
        private readonly IUriService _uriService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ServicesController(IFiverrService Service, IUriService uriService, IWebHostEnvironment hostEnvironment    )
        {
            _service = Service;
            _uriService = uriService;
            webHostEnvironment = hostEnvironment;
        }
        [HttpGet(ApiRoutes.FiverrServices.GetAll)]
        public async Task<IActionResult> GetServices()
        {
            var result =await  _service.GetFiverrServicesAsync(HttpContext.GetUserId());
            result.ForEach(c => c.Image = Path.Combine("Content/Files/Images", $"{c.Image}"));
            return Ok(result);
        }
        [HttpGet(ApiRoutes.FiverrServicesTags.GetByUser)]
        public IActionResult GetTagsByUser()
        {
            var result =  _service.GetFiverrServicesTagsAsync(HttpContext.GetUserId());

            return Ok(result);
        }
        [HttpPost(ApiRoutes.FiverrServices.Create)]
        public async Task<IActionResult> Create(CreateFiverrServiceRequest request)
        {
            try
            {
                
                var newId = Guid.NewGuid();
                var model = new FiverrServices
                {
                    Id = newId,
                    Title = request.title,
                    FiverrURL = request.fiverrURL,
                    Description = request.description,
                    Image =UploadedFile(request.image),
                    Rate = request.rate,
                    Categories = request.categories,
                    UserId = HttpContext.GetUserId(),
                };
                await _service.CreateAsync(model);

                var locationUri = _uriService.GetFiverrServiceUri(model.Id.ToString());

                var response = new CreateFiverrServiceResponse
                {
                    Title = model.Title,
                    FiverrURL = model.FiverrURL,
                    Description = model.Description,
                    Rate = model.Rate,
                    Image = model.Image,
                    Categories = model.Categories, 
                    UserId = model.UserId,
                };

                return Created(locationUri, response);  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error: {ex}");
            }
        }
        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Content\\Files\\Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                   file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}