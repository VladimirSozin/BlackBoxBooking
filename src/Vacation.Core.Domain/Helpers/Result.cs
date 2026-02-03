using System.Collections.ObjectModel;

namespace Vacation.Core.Domain.Helpers
{
    /// <summary>
    /// Represents a result with data and errors.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Gets a value indicating whether the result is successful.
        /// </summary>
        public bool IsSuccess
        {
            get { return Errors.Count == 0; }
        }

        /// <summary>
        /// Gets or sets the list of errors.
        /// </summary>
        public ICollection<string> Errors { get; } = new Collection<string>();

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Gets a string representation of all errors.
        /// </summary>
        /// <returns>The errors as a string.</returns>
        public string GetErrorsString()
        {
            return string.Join(',', Errors);
        }

        /// <summary>
        /// Adds an error to the result and returns the result.
        /// </summary>
        /// <param name="err">The error to add.</param>
        /// <returns>The result.</returns>
        public Result<T> AddError(string err)
        {
            Errors.Add(err);
            return this;
        }
    }
}