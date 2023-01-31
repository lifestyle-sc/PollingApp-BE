using Shared.DTOs;
using System.Text;

namespace PollingApp.Formatter
{
    public class CandidateCsvOutputFormatter : CsvOutputFormatterBase<CandidateDto>
    {
        public CandidateCsvOutputFormatter()
        {

        }

        protected override void FormatCsv(StringBuilder buffer, CandidateDto entityDto)
        {
            buffer.AppendLine($"{entityDto.Id}, \" {entityDto.Name}, \" {entityDto.Count}, \" {entityDto.CreatedAt}, \" {entityDto.UpdatedAt}");

        }
    }
}
