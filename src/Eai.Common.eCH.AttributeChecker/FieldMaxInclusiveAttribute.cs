// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace Eai.Common.eCH.AttributeChecker;

[AttributeUsage(AttributeTargets.Property)]
public class FieldMaxInclusiveAttribute : Attribute
{
    public long Max { get; private set; }

    public FieldMaxInclusiveAttribute(byte max)
    {
        Max = max;
    }

    public FieldMaxInclusiveAttribute(short max)
    {
        Max = max;
    }

    public FieldMaxInclusiveAttribute(int max)
    {
        Max = max;
    }

    public FieldMaxInclusiveAttribute(long max)
    {
        Max = max;
    }
}
