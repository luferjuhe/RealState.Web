using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RealState.Data;
using RealState.Data.Entities;
using RealState.Web.ViewModels;

namespace RealState.Web.Services
{
    public interface IUsersService
    {
        Task<User> GetUserByEmail(string email);
        Task<UserViewModel> GetUserById(int userId);
    }

    public class UsersService(RealStateContext ctx, IMapper mapper) : IUsersService
    {
        public async Task<User> GetUserByEmail(string email) =>
            await ctx.Users.FirstOrDefaultAsync(u => u.UserName == email);

        public async Task<UserViewModel> GetUserById(int userId) =>
            mapper.Map<UserViewModel>(await ctx.Users.FirstOrDefaultAsync(u => u.UserId == userId));
    }
}
