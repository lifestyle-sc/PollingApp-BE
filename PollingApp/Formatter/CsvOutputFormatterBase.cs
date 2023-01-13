using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace PollingApp.Formatter
{
    public abstract class CsvOutputFormatterBase<T> : TextOutputFormatter
    {
        public CsvOutputFormatterBase()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if(typeof(T).IsAssignableFrom(type) || typeof(IEnumerable<T>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding supportedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if(context.Object is IEnumerable<T>)
            {
                foreach(var entity in (IEnumerable<T>)context.Object)
                {
                    FormatCsv(buffer, entity);
                }
            }
            else
            {
                FormatCsv(buffer, (T)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }

        public virtual void FormatCsv(StringBuilder buffer, T entityDto) { }
    }
}
