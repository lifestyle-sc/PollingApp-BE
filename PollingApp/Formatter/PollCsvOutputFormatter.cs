using Shared.DTOs;
using System.Text;

namespace PollingApp.Formatter
{
    public class PollCsvOutputFormatter : CsvOutputFormatterBase<PollDto>
    {
        public PollCsvOutputFormatter()
        {

        }

        public override void FormatCsv(StringBuilder buffer, PollDto entityDto)
        {
            buffer.AppendLine($"{entityDto.Id}, \" {entityDto.Name}, \" {entityDto.Deadline}, \" {entityDto.IsDisabled}, \" {entityDto.CreatedAt}, \" {entityDto.UpdatedAt} \"");
        }
    }
}
