using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace UploadFile.Pages.DeleteFile
{
    public class DeleteFileModel : PageModel
    {
        [BindProperty]
        public int NoFiles { get; set; }

        [BindProperty]
        public List<string> FilesList { get; set; }

        private readonly IHostingEnvironment _webHostEnvironment;

        public DeleteFileModel(IHostingEnvironment env)
		{
            _webHostEnvironment = env;
        }


        public void OnGet(string fileToDelete = "")
        {
            string imageFolder = "images";
            string path = Path.Combine(_webHostEnvironment.WebRootPath, imageFolder);

            // Delete the file on the parameter
            if(fileToDelete != "")
                System.IO.File.Delete(Path.Combine(path, fileToDelete));

            // List
            var PathsList = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            NoFiles = PathsList.Length;

            FilesList = new List<string>();
            foreach(var FilePath in PathsList)
			{
                FilesList.Add(Path.GetFileName(FilePath));
			}
        }
    }
}
