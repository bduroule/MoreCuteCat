using Model;

namespace Repository.Interface
{
    public interface ICatRepository
    {
        IEnumerable<Cat> GetAllCats();
        void UpdateCatScore(string catId, int newScore);
    }
}
