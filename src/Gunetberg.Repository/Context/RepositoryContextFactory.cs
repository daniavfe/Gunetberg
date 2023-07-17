using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Repository.Context
{
    public class RepositoryContextFactory
    {

        private RepositoryContext _repositoryContext;

        public RepositoryContextFactory(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public RepositoryContext GetDBContext()
        {
            return _repositoryContext;
        }
    }
}
