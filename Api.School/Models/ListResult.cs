using Newtonsoft.Json;
using System.Net;

namespace Api.School.Models
{
    /// <summary>
    /// User for return single model data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleEntityResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleEntityResult{T}"/> class.
        /// Initializes a new instance of the class and assign default values.
        /// </summary>
        /// <param name="singleResult">The single result.</param>
        /// <param name="status">The status or http response.</param>
        /// <param name="message">The message to pass along with response.</param>
        public SingleEntityResult(T singleResult = default(T), HttpStatusCode status = HttpStatusCode.OK, string message = null)
        {
            this.Result = singleResult;
            this.Status = status;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The model data.
        /// </value>
        [JsonProperty("result")]
        public T Result { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// Status to send in response.
        /// </value>
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// Message to send in response.
        /// </value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class MultipleEntityResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleEntityResult{T}"/> class.
        /// Initializes a new instance of the class and assign default values.
        /// </summary>
        /// <param name="multipleResult">The multiple result.</param>
        /// <param name="status">The status or http response.</param>
        /// <param name="message">The message to pass along with response.</param>
        public MultipleEntityResult(IEnumerable<T> multipleResult = default(IEnumerable<T>), HttpStatusCode status = HttpStatusCode.OK, string message = null)
        {
            this.Result = multipleResult;
            this.Status = status;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The model data.
        /// </value>
        [JsonProperty("result")]
        public IEnumerable<T> Result { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// Status to send in response.
        /// </value>
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// Message to send in response.
        /// </value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
