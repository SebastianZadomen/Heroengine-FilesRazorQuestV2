using System.Timers;
using VideoGameManager.Models;

namespace VideoGameManager.Service
{
    public class GameService
    {
        private  List<Game> Games { get; set; }

        public GameService()
        {
            Games = new List<Game>();
        }

        public List<Game> GetAll()
        {
            return Games;
        }
        public Game GetById(int id)
        {
           Game searchId = Games.Find(x => x.Id == id);
            return searchId;
        }
        public void Add(Game newGame)
        {
            Games.Add(newGame);
        }
        public void Update(Game newGame)
        {
            if (newGame != null)
            {
                foreach (var item in Games)
                {
                    if (item.Id == newGame.Id)
                    {
                        item.Title = newGame.Title;
                        item.Genre = newGame.Genre;
                        item.Year = newGame.Year;
                        item.Score = newGame.Score;
                        item.Description = newGame.Description;
                        return;
                    }
                }

            }
            else
            {
                Console.WriteLine("El elemento que tratas de actualizar no existe");
            }
        }
        public void Delete(int id)
        {
            var gameDelete = GetById(id);
            if (gameDelete != null)
            {
                Games.Remove(gameDelete);
            }
        }
    }
}
