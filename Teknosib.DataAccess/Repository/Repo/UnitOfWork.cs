

using Teknosib.DataAccess.EntitiyFramework;
using Teknosib.DataAccess.Repository.Interface;
using Teknosib.DataAccess.Repository.Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyContext _context;

    
    public ICategoryRepository Categories { get; private set; }
    public IAppUserRepository AppUsers { get; private set; }
    public ICompanyRepository Companies { get; private set; }
    public IKosgebSupportRepository KosgebSupports { get; private set; }
    public IProblemRepository Problems { get; private set; }
    public IProposalRepository Proposals { get; private set; }
    public IProjectRepository Projects { get; private set; }
    public IReviewRepository Reviews { get; private set; }
    public IindividualProviderRepository Individuals { get; private set; }
    public IBusinessProviderRepository BusinessProviders { get; set; }

    public UnitOfWork(MyContext context)
    {
        _context = context;

        // Atamaları yeni property isimleriyle yapıyoruz.
        Categories = new CategoryRepository(_context);
        AppUsers = new AppUserRepository(_context); // new UserRepository -> new AppUserRepository
        Companies = new CompanyRepository(_context);
        KosgebSupports = new KosgebSupportRepository(_context);
        Problems = new ProblemRepository(_context);
        Proposals = new ProposalRepository(_context);
        Projects = new ProjectRepository(_context);
        Reviews = new ReviewRepository(_context);
        Individuals = new IndividualProviderRepository(_context) ;
        BusinessProviders = new BusinessProviderRepository(_context) ;
    }

    // ... SaveChangesAsync ve DisposeAsync metotları aynı kalacak ...
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

}

    
