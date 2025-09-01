using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using BankApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.TwoFactor
{

    public class TwoFactorService : ITwoFactorService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserTwoFactorEntity> _TwoFactorRepository;

        public TwoFactorService(IUnitOfWork unitOfWork,IRepository<UserTwoFactorEntity> repository )
        {
            _unitOfWork = unitOfWork;
            _TwoFactorRepository = repository;
        }

        public string GenerateOtpCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); 
        }

        public async Task<ServiceMessage<string>> GenerateOtpAsync(int userId, string provider)
        {
            var otpCode = GenerateOtpCode();
            var expireAt = DateTime.Now.AddMinutes(5); 

            var entity = new UserTwoFactorEntity
            {
                UserId = userId,
                OtpCode = otpCode,
                Provider = provider,
                ExpireAt = expireAt,
                IsUsedCode = false
            };

            await _TwoFactorRepository.AddAsync( entity );
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<string>
            {
                IsSuccess = true,
                Data = otpCode
            };
        }


        public async Task<ServiceMessage<bool>> VerifyOtpAsync(int userId, string otpCode)
        {
            var otpEntity = await _TwoFactorRepository.GetAll(x => x.UserId == userId && x.OtpCode == otpCode)
                                                      .OrderByDescending(x => x.ExpireAt)
                                                      .FirstOrDefaultAsync();

            if (otpEntity == null)
            {
                return new ServiceMessage<bool>
                {
                    IsSuccess = false,
                    Message = "OTP kodu bulunamadı."
                };
            }

            if (otpEntity.IsUsedCode)
            {
                return new ServiceMessage<bool>
                {
                    IsSuccess = false,
                    Message = "Bu OTP kodu zaten kullanılmış."
                };
            }

            if (otpEntity.ExpireAt < DateTime.Now)
            {
                return new ServiceMessage<bool>
                {
                    IsSuccess = false,
                    Message = "OTP kodunun süresi dolmuş."
                };
            }

           
            otpEntity.IsUsedCode = true;

            await _TwoFactorRepository.UpdateAsync( otpEntity );
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage<bool>
            {
                IsSuccess = true,
                Data = true
            };
        }
    }
}
