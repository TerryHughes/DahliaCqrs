namespace Dahlia.Repositories
{
    using System.Collections.Generic;
    using Dahlia.ViewModels;

    public class InMemoryRetreatRepository : RetreatRepository
    {
        public readonly IList<RetreatViewModel> Data = new List<RetreatViewModel>();

        public IEnumerable<dynamic> GetAllAsDynamic()
        {
            return Data;
        }
    }
}
