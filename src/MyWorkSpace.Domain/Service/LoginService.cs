using Microsoft.Extensions.Caching.Memory;
using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Domain.Service
{
    public class LoginService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;

        public LoginService(IMemoryCache memoryCache, IUserRepository userRepository)
        {
            _memoryCache = memoryCache;
            _userRepository = userRepository;
        }

        public string SignOn(string account, string password)
        {
            var matchedUser = _userRepository.GetUserByAccount(account);
            var isCorrectUser = matchedUser?.IsMatch(password);

            if (isCorrectUser.HasValue ? isCorrectUser.Value : false)
            {
                var identyGuid = Guid.NewGuid().ToString();
                _memoryCache.GetOrCreate(identyGuid,cacheEntry=>  )
                return true;
            }

            return ;
        }
    }
}
