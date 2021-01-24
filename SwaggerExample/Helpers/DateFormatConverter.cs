using Newtonsoft.Json.Converters;

namespace SwaggerExample.Helpers
{

    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }

    }
}