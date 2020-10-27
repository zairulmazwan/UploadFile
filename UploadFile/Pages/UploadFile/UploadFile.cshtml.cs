using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace UploadFile.Pages.UploadFile
{
    public class UploadFileModel : PageModel
    {

        private readonly IHostingEnvironment _webHostEnvironment;

        public UploadFileModel (IHostingEnvironment env)
        {
            _webHostEnvironment = env;
        }



        [BindProperty]
        public IFormFile UserFile { get; set; }

        
        public void OnGet()
        {
            Console.WriteLine("The page of upload is loaded");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var FileToUpload = Path.Combine(_webHostEnvironment.WebRootPath, "images", UserFile.FileName);
            Console.WriteLine("File Name : "+FileToUpload);

            using (var FStream = new FileStream (FileToUpload, FileMode.Create))
            {
                await UserFile.CopyToAsync(FStream);
            }

            return Page();
        }
       
    }
}