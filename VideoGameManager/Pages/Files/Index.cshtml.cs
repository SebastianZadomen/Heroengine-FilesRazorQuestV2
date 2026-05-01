using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Service;

namespace VideoGameManager.Pages.Files
{
    public class IndexModel : PageModel
    {
        public readonly GameService GameService;
        [BindProperty]
        public string Type { get; set; }
        public IndexModel(GameService gameService)
        {
            GameService = gameService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostDownloadFile()
        {

            switch (Type)
            {
                case "Txt":
                    byte[] fileBytes = System.IO.File.ReadAllBytes(GameService.Path);
                    string fileName = "activity_log.txt";
                    return File(fileBytes, "application/octet-stream", fileName);
                    break;
                case "Json":
                  
                    break;
                case "Csv":
                    
                    break;
                case "Xml":
                    
                    break;
            }
            return null;
        }
    }
}
