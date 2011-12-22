namespace Dahlia.Repositories
{
    using System.Collections.Generic;
    using Dahlia.ViewModels;

    public class InMemoryRetreatRepository : RetreatRepository
    {
        public readonly IList<RetreatViewModel> Data = new List<RetreatViewModel>();

        public IEnumerable<RetreatViewModel> GetAll()
        {
            return Data;
        }

        public IEnumerable<dynamic> GetAllAsDynamic()
        {
            throw new System.NotImplementedException();
        }
    }
}
