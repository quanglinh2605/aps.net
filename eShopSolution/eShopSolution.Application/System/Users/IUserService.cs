﻿using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(int id,UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);

        Task<ApiResult<UserVm>> GetById(int id);
    }
}
