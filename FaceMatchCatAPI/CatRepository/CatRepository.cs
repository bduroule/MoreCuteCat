using Repository.Interface;
using Model;
using Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CatRepository : ICatRepository
    {
        // private readonly List<Cat> _cats;
        private readonly CatContext _catContext =null;

        public CatRepository(CatContext appContext)
        {
            _catContext = appContext;
        }

        public IEnumerable<Cat> GetAllCats()
        {
            return  _catContext.Cats.ToList();
        }

        public void UpdateCatScore(string catId, int newScore)
        {
            var catToUpdate = _catContext.Cats.FirstOrDefault(c => c.Id == catId);

            if (catToUpdate == null)
            {
                throw new InvalidOperationException($"The Cat Id: {catId} dosent found");
            }

            catToUpdate.Score = newScore;

            try
            {
                _catContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An Error has ocurate while updated cat", ex);
            }
        }

    }
}