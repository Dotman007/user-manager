using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Dto;
using UserManager.Domain.Entities;

namespace UserManager.Application.Interface
{
    public interface IUserService
    {
        Task<ResponseInfo<object>> CreateUser(CreateUserDto create);
        Task<ResponseInfo<object>> EditUser(string id, EditUserDto create);

        Task<ResponseInfo<object>> DeleteUser(string id);

        Task<ResponseInfo<object>> SearchUser(string param);

        Task<ResponseInfo<object>> DeleteMultipleUser(List<string> id);
        Task<PagedResponse<UserList>> GetUsers(int pageNumber, int pageSize);
    }
}
