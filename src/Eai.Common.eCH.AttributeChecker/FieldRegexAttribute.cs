// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace Eai.Common.eCH.AttributeChecker;

[AttributeUsage(AttributeTargets.Property)]
public class FieldRegexAttribute : Attribute
{
    public string Regex { get; private set; }

    public FieldRegexAttribute(string regex)
    {
        Regex = regex;
    }
}
