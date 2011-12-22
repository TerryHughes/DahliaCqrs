namespace Dahlia.Repositories
{
    using System.Collections.Generic;
    using ViewModels;

    public interface RetreatRepository
    {
        IEnumerable<RetreatViewModel> GetAll();
    }
}
