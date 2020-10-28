using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.IO;

namespace UploadFile.Pages.DeleteFile
{
    public class DeleteFileModel : PageModel
    {
        [BindProperty]
        public int NoFiles { get; set; }
        public void OnGet()
        {

            string path = "/images/";
            NoFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            
        }
    }
}
