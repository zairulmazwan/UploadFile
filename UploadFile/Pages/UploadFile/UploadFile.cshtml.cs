using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UploadFile.Pages.UploadFile
{
    public class UploadFileModel : PageModel
    {

        private readonly IWebHostEnvironment _env;

        public UploadFileModel (IWebHostEnvironment env)
        {
            _env = env;
        }



        [BindProperty]
        public IFormFile FileName { get; set; }

        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var FileToUpload = PathString.Combine(_env.WebRootPath, )
        }
       
    }
}