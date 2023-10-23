using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.Interface;
using UserManager.Application.ResponseHelper;
using UserManager.Domain.Constant;
using UserManager.Domain.Dto;
using UserManager.Domain.Entities;
using UserManager.Infrastructure.DAL;

namespace UserManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(AppDbContext db, IMapper mapper,UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ResponseInfo<object>> CreateUser(CreateUserDto create)
        {
            try
            {
                var destination = _mapper.Map<ApplicationUser>(create);
                var checkUserExixt =  await _userManager.FindByEmailAsync(create.Email);
                if (checkUserExixt is not null || checkUserExixt?.Phone == create.Phone || checkUserExixt?.UserName == create.Email.Substring(0,create.Email.IndexOf("@")))
                {
                    return ResponseHelperService.Error<object>(ReponseMapping.DuplicateUserCode, ReponseMapping.DuplicateUserMessage);
                }
                destination.UserName = create.Email.Substring(0, create.Email.IndexOf("@"));
                var result = await _userManager.CreateAsync(destination,create.Password);

                if (result.Succeeded)
                {
                    if (create.AccountType == Domain.Constant.AccountType.CUSTOMER)
                    {
                      await  _userManager.AddToRoleAsync(destination, RoleData.Customer);
                    }
                    if (create.AccountType == Domain.Constant.AccountType.ADMIN)
                    {
                        await _userManager.AddToRoleAsync(destination, RoleData.Admin);
                    }
                    return ResponseHelperService.Success<object>(result.Succeeded, ReponseMapping.SuccessMessage, ReponseMapping.SuccessCode);
                }
                return ResponseHelperService.Success<object>(result.Errors, ReponseMapping.SuccessMessage, ReponseMapping.SuccessCode);
            }
            catch (Exception ex)
            {
                return ResponseHelperService.Error<object>(ReponseMapping.ErrorCode, ReponseMapping.ErrorMessage);
            }
        }

        public async Task<ResponseInfo<object>> EditUser(string id, EditUserDto create)
        {
            try
            {
                var checkUserExixt = await _userManager.FindByIdAsync(id);
                if (checkUserExixt is null)
                {
                    return ResponseHelperService.Success<object>(null, ReponseMapping.UserNotFoundMessage, ReponseMapping.UserNotFoundCode);
                }
                checkUserExixt.UserName = create.Email.Substring(0, create.Email.IndexOf("@")) ?? string.Empty;
                checkUserExixt.BirthDate = create.BirthDate.Value;
                checkUserExixt.FirstName = create.FirstName;
                checkUserExixt.Email = create.Email;
                checkUserExixt.PhoneNumber = create.Phone;
                checkUserExixt.LastName = create.LastName;
                checkUserExixt.Gender = create.Gender;
                var result = await _userManager.UpdateAsync(checkUserExixt);
                if (result.Succeeded)
                {
                    return ResponseHelperService.Success<object>(result.Succeeded, ReponseMapping.SuccessMessage, ReponseMapping.SuccessCode);
                }
                return ResponseHelperService.Success<object>(result.Succeeded, ReponseMapping.NotSuccessMessage, ReponseMapping.NotSuccessMessage);
            }
            catch (Exception ex)
            {
                return ResponseHelperService.Error<object>(ReponseMapping.ErrorCode, ReponseMapping.ErrorMessage);
            }
        }


        public async Task<ResponseInfo<object>> DeleteUser(string id)
        {
            try
            {
                var checkUserExixt = await _userManager.FindByIdAsync(id);
                if (checkUserExixt is not null)
                {
                    var result = await _userManager.DeleteAsync(checkUserExixt);
                    return ResponseHelperService.Success<object>(result.Succeeded, ReponseMapping.SuccessMessage, ReponseMapping.SuccessCode);
                }
                return ResponseHelperService.Success<object>(null, ReponseMapping.UserNotFoundMessage, ReponseMapping.UserNotFoundCode);
            }
            catch (Exception ex)
            {
                return ResponseHelperService.Error<object>(ReponseMapping.ErrorCode, ReponseMapping.ErrorMessage);
            }
        }

        

        public async Task<ResponseInfo<object>> SearchUser(string param)
        {
            try
            {
                var checkUserExixt = await _userManager.Users.Include(b=>b.Nationality).Where(x=>x.FirstName.Contains(param) || x.LastName.Contains(param) || x.UserName.Contains(param) || x.Email.Contains(param)  || x.Nationality.Name.Contains(param) || x.Phone.Contains(param)).ToListAsync();
                var destination = _mapper.Map<List<UserList>>(checkUserExixt);
                if (checkUserExixt is not null)
                {
                    return ResponseHelperService.Success<object>(destination, ReponseMapping.SuccessMessage, ReponseMapping.SuccessCode);
                }
                return ResponseHelperService.Success<object>(null, ReponseMapping.UserNotFoundMessage, ReponseMapping.UserNotFoundCode);
            }
            catch (Exception ex)
            {
                return ResponseHelperService.Error<object>(ReponseMapping.ErrorCode, ReponseMapping.ErrorMessage);
            }
        }


        public async Task<ResponseInfo<object>> DeleteMultipleUser(List<string> id)
        {
            try
            {

                var usersToDelete = await _userManager.Users.Where(u => id.Contains(u.Id)).ToListAsync();
                if (usersToDelete.Any())
                {
                    _db.Users.RemoveRange(usersToDelete);
                    await _db.SaveChangesAsync();
                    return ResponseHelperService.Success<object>(true, ReponseMapping.SuccessMessage, ReponseMapping.SuccessCode);

                }
                return ResponseHelperService.Success<object>(null, ReponseMapping.UserNotFoundMessage, ReponseMapping.UserNotFoundCode);
            }
            catch (Exception ex)
            {
                return ResponseHelperService.Error<object>(ReponseMapping.ErrorCode, ReponseMapping.ErrorMessage);
            }
        }

        

        public async Task<PagedResponse<UserList>> GetUsers(int pageNumber, int pageSize)
        {
            try
            {
                var totalCount = await _userManager.Users.CountAsync();
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
                var users = await _userManager.Users.Include(x=>x.Nationality)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                var destination = _mapper.Map<List<UserList>>(users);

                var response = new PagedResponse<UserList>(destination, pageNumber, pageSize, totalCount, totalPages);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
