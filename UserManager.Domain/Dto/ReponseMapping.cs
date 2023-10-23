using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Dto
{
    public static class ReponseMapping
    {
        public static string SuccessCode = "00";
        public static string SuccessMessage = "Successful";


        public static string NotSuccessCode = "01";
        public static string NotSuccessMessage = "Not Successful";

        public static string ErrorCode = "99";
        public static string ErrorMessage = "An Error Occurred";


        public static string DuplicateUserCode = "21";
        public static string DuplicateUserMessage = "The user with this details already exist";


        public static string UserNotFoundCode = "29";
        public static string UserNotFoundMessage = "The user was not found";
    }
}
