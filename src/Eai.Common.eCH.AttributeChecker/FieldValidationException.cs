// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Runtime.Serialization;

namespace Eai.Common.eCH.AttributeChecker;

public class FieldValidationException : Exception
{
    public FieldValidationException()
    {
    }

    public FieldValidationException(string message) : base(message)
    {
    }

    public FieldValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected FieldValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
