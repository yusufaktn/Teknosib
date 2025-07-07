using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.LoginDto;
using Teknosib.Business.Dto.RegisterDto;
using Teknosib.Business.Interface;
using Teknosib.DataAccess.EntitiyFramework;

namespace Teknosib.Business.Services
{
    public class AuthService : IAuthService
    {

        private readonly MyContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(MyContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public Task<string> LoginAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterBusinessAsync(RegisterBusinessProviderDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterIndividualAsync(RegisterIndividualProviderDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterIndividualAsync(RegisterCompanyDto dto)
        {
            throw new NotImplementedException();
        }


        private void CreatePasswordHash(string password, out byte[] hash ,out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


    }
}
