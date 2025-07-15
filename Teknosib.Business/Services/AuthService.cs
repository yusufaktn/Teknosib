using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.LoginDto;
using Teknosib.Business.Dto.AuthDto.RegisterDto;
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

        public async Task<ResponseDto<string>> LoginAsync(LoginDto dto)
        {
           var user = await _unitOfWork.AppUsers.GetByFilterAsync(u=>u.Email == dto.Email);
            if(user == null)
            {
                return ResponseDto<string>.Fail("Geçersiz kullanıcı adı veya şifre!",400);
            }
            if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return ResponseDto<string>.Fail("Geçersiz kullancı adı veya şifre!", 400);
            }
            var token = _tokenService.CreateToken(user);
            return ResponseDto<string>.Success(token, 200);
        }

        public async Task<ResponseDto<object>> RegisterIntitutionAsync(RegisterInstitutionDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x => x.Email == dto.Email);
            if (existingUser != null)
            {

                return ResponseDto<object>.Fail("Bu e-posta ile kayıt oluşturulmuş", 400);

            }

            CreatePasswordHash(dto.AdminPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var newuser = _mapper.Map<AppUser>(dto);
            newuser.PasswordHash = passwordHash;
            newuser.PasswordSalt = passwordSalt;

            var institution = _mapper.Map<Institution>(dto);
            newuser.LegalEntity = institution;

            var address = _mapper.Map<Address>(dto);
            institution.Address = address;



            await _unitOfWork.AppUsers.AddAsync(newuser);
            await _unitOfWork.Addresses.AddAsync(address);
            await _unitOfWork.Institutions.AddAsync(institution);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<object>.Success("Şirket çözüm sağlayıcı kaydı başarıyla oluşturuldu.", 200);

        }

        public async Task<ResponseDto<object>> RegisterUserAsync(RegisterUserDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x=>x.Email == dto.Email);
            if (existingUser != null)
            {
                return ResponseDto<object>.Fail("Bu e-posta ile kayıt oluşturulmuş", 400);

            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = _mapper.Map<AppUser>(dto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _unitOfWork.AppUsers.AddAsync(newUser);     
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<object>.Success("Bireysel çözüm sağlayıcı kaydı başarıyla oluşturuldu.", 200);
        }

        public async Task<ResponseDto<object>> RegisterCompanyAsync(RegisterCompanyDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x => x.Email == dto.Email);
            if (existingUser != null)
            {
                return ResponseDto<object>.Fail("Bu e-posta ile kayıt oluşturulmuş", 400);

            }

            CreatePasswordHash(dto.AdminPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = _mapper.Map<AppUser>(dto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            var company = _mapper.Map<Company>(dto);
            newUser.LegalEntity = company;

            var address = _mapper.Map<Address>(dto);
            company.Address = address;

            await _unitOfWork.AppUsers.AddAsync(newUser);
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.Addresses.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<object>.Success("Şirket ve Admin kaydı başarıyla oluşturuldu.", 200);
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
