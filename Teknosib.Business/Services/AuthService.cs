using AutoMapper;
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
using Teknosib.Entity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Teknosib.Business.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
           var user = await _unitOfWork.AppUsers.GetByFilterAsync(u=>u.Email == dto.Email);
            if(user == null)
            {

                return "Geçersiz kullanıcı adı veya şifre";
            }
            if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return "Geçersiz kullanıcı adı veya şifre.";
            }
            return _tokenService.CreateToken(user);
        }

        public async Task<string> RegisterBusinessAsync(RegisterBusinessProviderDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x => x.Email == dto.Email);
            if (existingUser != null)
            {

                return "Bu e-posta adresi zaten kullanılıyor";

            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newuser = _mapper.Map<AppUser>(dto);
            newuser.PasswordHash = passwordHash;
            newuser.PasswordSalt = passwordSalt;

            var businessProvider = _mapper.Map<BusinessProvider>(dto);
            businessProvider.AppUser = newuser;

            await _unitOfWork.AppUsers.Add(newuser);
            await _unitOfWork.BusinessProviders.Add(businessProvider);   
            await _unitOfWork.SaveChangesAsync();

            return "Şirket başarıyla oluşturuldu";



        }

        public async Task<string> RegisterIndividualAsync(RegisterIndividualProviderDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x=>x.Email == dto.Email);
            if (existingUser != null)
            {
                return "Bu e-posta zaten kullanılıyor.";

            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = _mapper.Map<AppUser>(dto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            var individual = _mapper.Map<IndividualProvider>(dto);
            individual.AppUser = newUser;

            await _unitOfWork.AppUsers.Add(newUser);
            await _unitOfWork.Individuals.Add(individual);
            await _unitOfWork.SaveChangesAsync();

            return "Bireysel çözüm sağlayıcı başarıyla oluşturuldu";
        }

        public async Task<string> RegisterCompanyAsync(RegisterCompanyDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x => x.Email == dto.Email);
            if (existingUser != null)
            {
                return "Bu e-posta zaten kullanılıyor.";

            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = _mapper.Map<AppUser>(dto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            var company = _mapper.Map<Company>(dto);
            company.AppUser = newUser;

            await _unitOfWork.AppUsers.Add(newUser);
            await _unitOfWork.Companies.Add(company);
            await _unitOfWork.SaveChangesAsync();

            return "Bireysel çözüm sağlayıcı başarıyla oluşturuldu";
        }


        private void CreatePasswordHash(string password, out byte[] hash ,out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Kullanıcının kaydındaki salt'ı kullanarak aynı HMAC nesnesini oluştur
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                // Login olurken girilen şifreyi hash'le
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Oluşturulan hash ile veritabanındaki hash'i karşılaştır
                return computedHash.SequenceEqual(passwordHash);
            }
        }


    }
}
