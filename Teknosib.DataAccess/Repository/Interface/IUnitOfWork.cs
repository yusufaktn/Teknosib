

using Teknosib.DataAccess.Repository.Interface;

public interface IUnitOfWork : IAsyncDisposable
{
    
    ICategoryRepository Categories { get; }
    IAppUserRepository AppUsers { get; } 
    ICompanyRepository Companies { get; }
    IKosgebSupportRepository KosgebSupports { get; }
    IProblemRepository Problems { get; }
    IProjectRepository Projects { get; }
    IProposalRepository Proposals { get; }
    IReviewRepository Reviews { get; }
    IindividualProviderRepository Individuals { get; }
    IBusinessProviderRepository BusinessProviders { get; }

    Task<int> SaveChangesAsync();
}