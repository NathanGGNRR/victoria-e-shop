//-----------------------------------------------------------------------
// <copyright file="ElasticException.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception on elastic search.
    /// </summary>
    [Serializable]
    public class ElasticException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticException"/> class.
        /// </summary>
        public ElasticException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticException"/> class.
        /// </summary>
        /// <param name="message">Message to print in the exception.</param>
        public ElasticException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected ElasticException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}