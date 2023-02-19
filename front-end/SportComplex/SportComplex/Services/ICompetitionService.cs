using RestEase;
using SportComplex.Models;
using System.Threading.Tasks;

namespace SportComplex.Services
{
    public interface ICompetitionService
    {
        [Get("Competitions")]
        public Task GetCompetitions();

        [Post("Competitions")]
        public Task CreateCompetition([Body] Competition model);
    }
}
