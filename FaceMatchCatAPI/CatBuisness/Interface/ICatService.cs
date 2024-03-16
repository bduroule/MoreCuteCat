using Model;

namespace Services.Interface
{
    public interface ICatService
    {
        IEnumerable<Cat> GetAllCats();
        IEnumerable<Cat> GetRandomCats(int count, List<string> excludeIds);
        void PutVoteForChat(VoteModel model);
    }
}
