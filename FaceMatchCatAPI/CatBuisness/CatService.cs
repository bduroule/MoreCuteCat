using Services.Interface;
using Model;
using Repository.Interface;
using Repository;

namespace Services
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;
        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public IEnumerable<Cat> GetAllCats()
        {
            return _catRepository.GetAllCats();
        }

        public IEnumerable<Cat> GetRandomCats(int count, List<string> excludeIds)
        {
            var randomCats = _catRepository.GetAllCats()
                .Where(cat => !excludeIds.Contains(cat.Id))
                .OrderBy(c => c.Score)
                .Take(count)
                .ToList();

            return randomCats;
        }


        private double CalculateExpectedScore(int playerScore, int opponentScore)
        {
            return 1 / (1 + Math.Pow(10, (opponentScore - playerScore) / 400.0));
        }

        private int CalculateNewScore(int playerScore, double expectedScore, bool hasWon)
        {
            int kFactor = 32;
            int newScore;

            if (hasWon)
            {
                newScore = (int)(playerScore + kFactor * (1 - expectedScore));
            }
            else
            {
                newScore = (int)(playerScore + kFactor * (0 - expectedScore));
            }

            return newScore;
        }

        public void PutVoteForChat(VoteModel model)
        {
            var participatingChats = model.ParticipatingCats;
            var winningChatId = model.WinnerCatId;

            if (!participatingChats.Any(c => c.Id == winningChatId))
            {
                throw new InvalidOperationException($"winner cat dosent exist in this context {winningChatId}");
            }

            foreach (var cat in participatingChats)
            {
                double expectedScore = CalculateExpectedScore(cat.Score, participatingChats.First(c => c.Id == winningChatId).Score);
                cat.Score = CalculateNewScore(cat.Score, expectedScore, cat.Id == winningChatId);

                try
                {
                    _catRepository.UpdateCatScore(cat.Id, cat.Score);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Updating scor failed {ex}");
                }
            }
        }
    }
}