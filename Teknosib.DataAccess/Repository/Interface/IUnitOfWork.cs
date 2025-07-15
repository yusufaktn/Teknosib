

using Teknosib.DataAccess.Repository.Interface;

public interface IUnitOfWork : IAsyncDisposable
{
    
    ICategoryRepository Categories { get; }
    IAppUserRepository AppUsers { get; } 
    ICompanyRepository Companies { get; }
    ISupportCallRepository SupportCalls { get; }
    IProblemRepository Problems { get; }
    IProjectRepository Projects { get; }
    IProposalRepository Proposals { get; }
    IReviewRepository Reviews { get; }
    IAddressRepository Addresses { get; }
    I_InstitutionRepository Institutions { get; }

    Task<int> SaveChangesAsync();
}