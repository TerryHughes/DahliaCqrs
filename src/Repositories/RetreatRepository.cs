namespace Dahlia.Repositories
{
    using System.Collections.Generic;
    using Dahlia.ViewModels;

    public interface RetreatRepository
    {
        IEnumerable<RetreatViewModel> GetAll();
        IEnumerable<dynamic> GetAllAsDynamic();
    }
}
