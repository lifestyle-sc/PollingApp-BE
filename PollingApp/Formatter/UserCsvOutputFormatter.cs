using Shared.DTOs;
using System.Text;

namespace PollingApp.Formatter
{
    public class UserCsvOutputFormatter : CsvOutputFormatterBase<UserDto>
    {
        public UserCsvOutputFormatter()
        {

        }

        protected override void FormatCsv(StringBuilder buffer, UserDto entityDto)
        {
            buffer.AppendLine($"{entityDto.Id}, \" {entityDto.FirstName}, \" {entityDto.LastName}, \" {entityDto.UserName}, \" {entityDto.Email}, \" {entityDto.EmailConfirmed}, \" {entityDto.PhoneNumber}");
        }
    }
}

