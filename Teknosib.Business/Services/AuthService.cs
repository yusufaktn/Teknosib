using AutoMapper;
using Microsoft.Extensions.Logging;
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
using Microsoft.Extensions.Logging;
using Teknosib.Business.Dto.TokenDto;

namespace Teknosib.Business.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, ILogger<AuthService>logger)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<ResponseDto<TokensDto>> LoginAsync(LoginDto dto)
        {
           var user = await _unitOfWork.AppUsers.GetByFilterAsync(u=>u.Email == dto.Email);
            if(user == null || !VerifyPasswordHash(dto.Password,user.PasswordHash,user.PasswordSalt))
            {
                _logger.LogWarning("Başarısız giriş denemesi. Denenen Email :{Email}", dto.Email);
                return ResponseDto<TokensDto>.Fail("Geçersiz kullanıcı adı veya şifre!",400);
            }
           
            var tokens = _tokenService.CreateTokens(user);
            user.RefreshToken = tokens.RefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.AppUsers.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Giriş başarılı. Giriş yapılan bilgileri: UserId :{AppUserId}, Name: {Name}", user.AppUserId, user.Name);
            return ResponseDto<TokensDto>.Success(tokens, 200);
        }

        public async Task<ResponseDto<object>> RegisterIntitutionAsync(RegisterInstitutionDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x => x.Email == dto.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Başarısız kayıt denemesi. Var olan email. Denenen Email :{Email}", dto.Email);
                return ResponseDto<object>.Fail("Bu e-posta ile kayıt oluşturulmuş", 400);

            }

            CreatePasswordHash(dto.AdminPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var newuser = _mapper.Map<AppUser>(dto);
            newuser.PasswordHash = passwordHash;
            newuser.PasswordSalt = passwordSalt;

            await _unitOfWork.AppUsers.AddAsync(newuser);
            
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Kurum Kaydı başarılı. Kayıt yapan admin bilgileri: UserId :{AppUserId}, Name: {Name}", newuser.AppUserId, newuser.Name);
            return ResponseDto<object>.Success("Kurum ve Admin kaydı başarıyla oluşturuldu.", 200);

        }

        public async Task<ResponseDto<object>> RegisterUserAsync(RegisterUserDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x=>x.Email == dto.Email);
            if (existingUser != null)
            {

                _logger.LogWarning("Başarısız kayıt denemesi. Var olan email. Denenen Email :{Email}", dto.Email);
                return ResponseDto<object>.Fail("Bu e-posta ile kayıt oluşturulmuş", 400);

            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = _mapper.Map<AppUser>(dto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _unitOfWork.AppUsers.AddAsync(newUser);     
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Kullanıcı/Çalışan Kaydı başarılı. Kayıt yapan kullanıcı bilgileri: UserId :{AppUserId}, Name: {Name}", newUser.AppUserId, newUser.Name);
            return ResponseDto<object>.Success("Kullanıcı/Çalışan kaydı başarıyla oluşturuldu.", 200);
        }

        public async Task<ResponseDto<object>> RegisterCompanyAsync(RegisterCompanyDto dto)
        {
            var existingUser = await _unitOfWork.AppUsers.GetByFilterAsync(x => x.Email == dto.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Başarısız kayıt denemesi. Var olan email. Denenen Email :{Email}", dto.Email);
                return ResponseDto<object>.Fail("Bu e-posta ile kayıt oluşturulmuş", 400);

            }

            CreatePasswordHash(dto.AdminPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = _mapper.Map<AppUser>(dto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _unitOfWork.AppUsers.AddAsync(newUser);
           
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Şirket Kaydı başarılı. Kayıt yapan admin bilgileri: UserId :{AppUserId}, Name: {Name}", newUser.AppUserId, newUser.Name);
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

        public async Task<ResponseDto<TokensDto>> RefreshToken(string refreshtoken)
        {
            var user = await _unitOfWork.AppUsers.GetByFilterAsync(u=>u.RefreshToken == refreshtoken);
            if(user is null)
            {
                return ResponseDto<TokensDto>.Fail("Oturum süresi dolmuş veya geçersiz.", 401);
            }
            var tokens = _tokenService.CreateTokens(user);

            
            user.RefreshToken = tokens.RefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.AppUsers.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<TokensDto>.Success(tokens, 200);

        }
    }
}
