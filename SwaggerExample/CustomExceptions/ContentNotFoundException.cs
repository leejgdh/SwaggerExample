using System;
namespace SwaggerExample.CustomExceptions
{

    public class ContentNotFoundException : InvalidOperationException
    {

        public ContentNotFoundException()
        {

        }

        public ContentNotFoundException(string message) : base(message)
        {
        }

        public ContentNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}