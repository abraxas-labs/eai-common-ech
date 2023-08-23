// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace Eai.Common.eCH.AttributeChecker;

[AttributeUsage(AttributeTargets.Property)]
public class FieldRangeExclusiveAttribute : Attribute
{
    public long Min { get; private set; }

    public long Max { get; private set; }

    public FieldRangeExclusiveAttribute(byte min, byte max)
    {
        Min = min;
        Max = max;
    }

    public FieldRangeExclusiveAttribute(short min, short max)
    {
        Min = min;
        Max = max;
    }

    public FieldRangeExclusiveAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public FieldRangeExclusiveAttribute(long min, long max)
    {
        Min = min;
        Max = max;
    }
}
