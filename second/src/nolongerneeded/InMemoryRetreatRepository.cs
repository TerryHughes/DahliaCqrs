namespace Dahlia.Repositories
{
    using System.Collections.Generic;
    using ViewModels;

    public class InMemoryRetreatRepository : RetreatRepository
    {
        public readonly IList<RetreatViewModel> Data = new List<RetreatViewModel>();

        public IEnumerable<RetreatViewModel> GetAll()
        {
            return Data;
        }
    }
}
