using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Teknosib.Business.Interface.File;
using Teknosib.Business.Dto.File;


namespace Teknosib.Business.Services
{
    public class AzureBlobService : IFileService
    {
        private readonly string _connectionString;
        private readonly string _containerName;
        private readonly long _maxFileSizeBytes;
        private readonly string[] _allowedContentTypes;
        private readonly ILogger<AzureBlobService> _logger;

        public AzureBlobService(IConfiguration configuration, ILogger<AzureBlobService> logger)
        {
            _connectionString = configuration["AzureStorageConfig:ConnectionString"];
            _containerName = configuration["AzureStorageConfig:ContainerName"];           
            var maxSizeConfig = configuration["AzureStorageConfig:MaxFileSizeBytes"];
            _maxFileSizeBytes = long.TryParse(maxSizeConfig, out var maxSize) ? maxSize : 2 * 1024 * 1024;

            _allowedContentTypes = configuration.GetSection("AzureStorageConfig:AllowedContentTypes").Get<string[]>()
                ?? new[] { "image/jpeg", "image/png", "image/webp" };
            _logger = logger;
        }

        public async Task<ResponseDto<FileResponseDto>> SaveCompanyLogoAsync(IFormFile file)
        {
            try
            {
                if (!IsValidImageFile(file))
                {
                    _logger.LogWarning("Invalid company logo file upload attempt: {FileName}", file?.FileName);
                    return ResponseDto<FileResponseDto>.Fail("Geçersiz dosya. Sadece JPEG, PNG, WebP formatları ve maksimum 2MB boyut kabul edilir.",500);
                }

                var fileUrl = await SaveFileInternalAsync(file, "company-logos");

                var response = new FileResponseDto
                {
                    FileUrl = fileUrl,
                    FileName = file.FileName,
                    FileSize = file.Length,
                    ContentType = file.ContentType,
                    Subfolder = "company-logos"
                };

                _logger.LogInformation("Company logo uploaded successfully: {FileUrl}", fileUrl);
                return ResponseDto<FileResponseDto>.Success(response,200, "Logo başarıyla yüklendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading company logo: {FileName}", file?.FileName);
                return ResponseDto<FileResponseDto>.Fail("Logo yükleme başarısız", 500);
            }
        }
        public async Task<ResponseDto<FileResponseDto>> SaveInstitutionLogoAsync(IFormFile file)
        {
            try
            {
                if (!IsValidImageFile(file))
                {
                    _logger.LogWarning("Invalid company logo file upload attempt: {FileName}", file?.FileName);
                    return ResponseDto<FileResponseDto>.Fail("Geçersiz dosya. Sadece JPEG, PNG, WebP formatları ve maksimum 2MB boyut kabul edilir.", 500);
                }

                var fileUrl = await SaveFileInternalAsync(file, "institution-logos");

                var response = new FileResponseDto
                {
                    FileUrl = fileUrl,
                    FileName = file.FileName,
                    FileSize = file.Length,
                    ContentType = file.ContentType,
                    Subfolder = "institution-logos"
                };

                _logger.LogInformation("Institution logo uploaded successfully: {FileUrl}", fileUrl);
                return ResponseDto<FileResponseDto>.Success(response, 200, "Logo başarıyla yüklendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading institution logo: {FileName}", file?.FileName);
                return ResponseDto<FileResponseDto>.Fail("Logo yükleme başarısız", 500);
            }
        }

        public async Task<ResponseDto<FileResponseDto>> SaveProfileImageAsync(IFormFile file)
        {
            try
            {
                if (!IsValidImageFile(file))
                {
                    _logger.LogWarning("Invalid product image file upload attempt: {FileName}", file?.FileName);
                    return ResponseDto<FileResponseDto>.Fail("Geçersiz dosya formatı", 404);
                }

                var fileUrl = await SaveFileInternalAsync(file, "product-images");

                var response = new FileResponseDto
                {
                    FileUrl = fileUrl,
                    FileName = file.FileName,
                    FileSize = file.Length,
                    ContentType = file.ContentType,
                    Subfolder = "product-images"
                };

                _logger.LogInformation("Product image uploaded successfully: {FileUrl}", fileUrl);
                return ResponseDto<FileResponseDto>.Success(response,200, "Ürün resmi başarıyla yüklendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading product image: {FileName}", file?.FileName);
                return ResponseDto<FileResponseDto>.Fail("Ürün resmi yükleme başarısız", 500);
            }
        }

        public async Task<ResponseDto<object>> DeleteFileAsync(string fileUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(fileUrl))
                {
                    return ResponseDto<object>.Fail("Dosya URL'si gerekli",404);
                }

                await DeleteFileInternalAsync(fileUrl);

                _logger.LogInformation("File deleted successfully: {FileUrl}", fileUrl);
                return ResponseDto<object>.Success(null,200 ,"Dosya başarıyla silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {FileUrl}", fileUrl);
                return ResponseDto<object>.Fail("Dosya silme başarısız",500);
            }
        }

        private async Task<string> SaveFileInternalAsync(IFormFile file, string subfolder)
        {
            if (!IsValidImageFile(file))
                throw new ArgumentException("Geçersiz dosya");

            try
            {
                var containerClient = new BlobContainerClient(_connectionString, _containerName);
                await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

                // Dosya adını temizle ve GUID ekle
                var cleanFileName = Path.GetFileNameWithoutExtension(file.FileName)
                    .Replace(" ", "_")
                    .Replace("-", "_");
                var extension = Path.GetExtension(file.FileName);
                var blobName = $"{subfolder}/{Guid.NewGuid()}_{cleanFileName}{extension}";

                var blobClient = containerClient.GetBlobClient(blobName);

                using var stream = file.OpenReadStream();
                await blobClient.UploadAsync(stream, new BlobHttpHeaders
                {
                    ContentType = file.ContentType,
                    CacheControl = "public, max-age=31536000" // 1 yıl cache
                });

                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Dosya yüklenirken hata oluştu", ex);
            }
        }

        private async Task DeleteFileInternalAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl)) return;

            try
            {
                var containerClient = new BlobContainerClient(_connectionString, _containerName);

                // URL'den blob name'i çıkar
                var uri = new Uri(fileUrl);
                var blobName = uri.AbsolutePath.TrimStart('/');

                // Container name'i URL'den çıkar
                if (blobName.StartsWith(_containerName + "/"))
                {
                    blobName = blobName.Substring(_containerName.Length + 1);
                }

                var blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Dosya silinirken hata oluştu", ex);
            }
        }

        private bool IsValidImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;
            if (file.Length > _maxFileSizeBytes) return false;
            if (!_allowedContentTypes.Contains(file.ContentType)) return false;

            // Dosya uzantısı kontrolü
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            return allowedExtensions.Contains(fileExtension);
        }

        
    }
}