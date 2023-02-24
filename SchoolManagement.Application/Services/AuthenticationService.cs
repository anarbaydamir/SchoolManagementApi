using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.ProjectAggregates.Exceptions;
using SchoolManagement.Domain.ProjectAggregates.Helpers;
using SchoolManagement.Domain.Specifications;
using SchoolManagement.Infrastructure.Authentication.Interfaces;
using SchoolManagement.Infrastructure.Models;
using SchoolManagement.Infrastructure.Persistence;
using System;
using System.Linq;

namespace SchoolManagement.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITokenService tokenService;
        private readonly UserMapper userMapper;

        public AuthenticationService(IUnitOfWork unitOfWork, ITokenService tokenService,
                                    UserMapper userMapper)
        {
            this.unitOfWork = unitOfWork;
            this.tokenService = tokenService;
            this.userMapper= userMapper;
        }

        public TokenModel AuthenticateUser(string email, string password)
        {
            var user = unitOfWork.Repository<User>()
                .Find(new UserAuthenticationWithRoleSpecification(email), tracking: true).FirstOrDefault();

            if (user == null || !PasswordManager.VerifyPassword(password, user.Password))
                throw new UserNotFoundException();
            
            var userClaimsModel = userMapper.EntityToUserClaimsModel(user);

            var accessToken = tokenService.GenerateToken(userClaimsModel);
            var refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenExpiryTime = refreshToken.ExpiryTime;
            unitOfWork.Repository<User>().Update(user);
            unitOfWork.Complete();

            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }

        public string RefreshToken(string refreshToken)
        {
            var user = unitOfWork.Repository<User>()
                .Find(new UserByRefreshTokenWithRoleSpecification(refreshToken)).FirstOrDefault();

            if(user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Invalid token or user doesn't exist");

            var userClaimsModel = userMapper.EntityToUserClaimsModel(user);
            var accessToken = tokenService.GenerateToken(userClaimsModel);

            return accessToken;
        }
    }
}
