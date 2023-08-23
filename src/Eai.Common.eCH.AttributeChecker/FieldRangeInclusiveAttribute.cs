// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace Eai.Common.eCH.AttributeChecker;

/// <summary>
/// sdas.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class FieldRangeInclusiveAttribute : Attribute
{
    public long Min { get; private set; }

    public long Max { get; private set; }

    public FieldRangeInclusiveAttribute(byte min, byte max)
    {
        Min = min;
        Max = max;
    }

    public FieldRangeInclusiveAttribute(short min, short max)
    {
        Min = min;
        Max = max;
    }

    public FieldRangeInclusiveAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public FieldRangeInclusiveAttribute(long min, long max)
    {
        Min = min;
        Max = max;
    }
}
