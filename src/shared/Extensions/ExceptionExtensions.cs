using System;
using System.Text;

namespace Keycloak.Net.Shared.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Exception"/>
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Flatten and merges all inner exception messages
        /// </summary>
        public static string FlattenError(this Exception exception, params string[] additionalErrors)
        {
            var builder = new StringBuilder();
            var count = 0;
            Exception? currentException = exception;

            do
            {
                // Append all inner exception messages
                builder.AppendLine($"{(count != 0 ? "-> " : string.Empty)}[{currentException.GetType().Name}]: {currentException.Message}");
                currentException = currentException.InnerException;
                count++;
            } while (currentException != null);

            foreach (var error in additionalErrors)
            {
                // Append all additional error messages
                if (!string.IsNullOrEmpty(error))
                {
                    builder.AppendLine($"-> {error}");
                }
            }

            return builder.ToString();
        }
    }
}
