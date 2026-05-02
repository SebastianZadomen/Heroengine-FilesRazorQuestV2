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
                    byte[] fileBytesTxt = System.IO.File.ReadAllBytes(GameService.Path);
                    string fileNameTxt = "activity_log.txt";
                    return File(fileBytesTxt, "application/octet-stream", fileNameTxt);
                    break;
                case "Json":
                    GameService.GameRepository.SaveAll(GameService.GetAll());
                    byte[] fileBytesJson = System.IO.File.ReadAllBytes(GameService.GameRepository.Path);
                    string fileNameJson = "games.json";
                    return File(fileBytesJson, "application/octet-stream", fileNameJson);
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
