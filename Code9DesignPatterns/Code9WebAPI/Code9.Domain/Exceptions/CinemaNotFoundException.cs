using System.Runtime.Serialization;

namespace Code9.Domain.Exceptions;

[Serializable]
public class CinemaNotFoundException : Exception
{
    public CinemaNotFoundException() { }

    public CinemaNotFoundException(string message) : base(message) { }

    public CinemaNotFoundException(string message, Exception inner) : base(message, inner) { }

    public CinemaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}