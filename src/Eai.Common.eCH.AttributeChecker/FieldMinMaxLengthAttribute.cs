// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace Eai.Common.eCH.AttributeChecker;

[AttributeUsage(AttributeTargets.Property)]
public class FieldMinMaxLengthAttribute : Attribute
{
    public int Min { get; private set; }

    public int Max { get; private set; }

    public FieldMinMaxLengthAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}
