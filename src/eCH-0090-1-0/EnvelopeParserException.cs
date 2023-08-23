// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace eCH_0090_1_0;

public class EnvelopeParserException : Exception
{
    public EnvelopeParserException()
    {
    }

    public EnvelopeParserException(string message) : base(message)
    {
    }

    public EnvelopeParserException(string message, Exception inner) : base(message, inner)
    {
    }
}
