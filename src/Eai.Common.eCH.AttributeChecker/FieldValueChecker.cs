// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Eai.Common.eCH.AttributeChecker;

public class FieldValueChecker<T>
{
    public void CheckValue<TV>(TV newVal, [CallerMemberName] string propertyName = "")
    {
        var obj = (object)newVal;
        var propInfo = typeof(T).GetProperty(propertyName);
        var attributes = new Dictionary<Type, Attribute>();

        foreach (var attr in Attribute.GetCustomAttributes(propInfo, false))
        {
            var type = attr.GetType();
            if (!attributes.ContainsKey(type))
            {
                attributes.Add(type, attr);
            }
        }

        if (attributes.ContainsKey(typeof(FieldRequiredAttribute)))
        {
            CheckRequired(obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldNonNegativeIntegerAttribute)))
        {
            CheckNonNegativeInteger(obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldMaxInclusiveAttribute)))
        {
            CheckMax((FieldMaxInclusiveAttribute)attributes[typeof(FieldMaxInclusiveAttribute)], obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldRangeInclusiveAttribute)))
        {
            CheckRange((FieldRangeInclusiveAttribute)attributes[typeof(FieldRangeInclusiveAttribute)], obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldRangeExclusiveAttribute)))
        {
            CheckRange((FieldRangeExclusiveAttribute)attributes[typeof(FieldRangeExclusiveAttribute)], obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldMaxLengthAttribute)))
        {
            CheckLength((FieldMaxLengthAttribute)attributes[typeof(FieldMaxLengthAttribute)], obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldMinMaxLengthAttribute)))
        {
            CheckMinMaxLength((FieldMinMaxLengthAttribute)attributes[typeof(FieldMinMaxLengthAttribute)], obj, propertyName);
        }

        if (attributes.ContainsKey(typeof(FieldRegexAttribute)))
        {
            CheckRegex((FieldRegexAttribute)attributes[typeof(FieldRegexAttribute)], obj, propertyName);
        }
    }

    public void SetValue<TV>(ref TV target, TV newVal)
    {
        target = newVal;
    }

    public void CheckAndSetValue<TV>(ref TV target, TV newVal, [CallerMemberName] string propertyName = "")
    {
        CheckValue(newVal, propertyName);

        SetValue(ref target, newVal);
    }

    private void CheckRequired(Object obj, string propertyName)
    {
        var message = $"{propertyName} is required";
        var message2 = $"{propertyName} cannot be empty";

        if (obj == null)
        {
            throw new FieldValidationException(message);
        }

        if (obj is string s && s == "")
        {
            throw new FieldValidationException(message2);
        }

        if (obj is IEnumerable e)
        {
            var enumerator = e.GetEnumerator();

            if (enumerator.MoveNext())
            {
                return;
            }

            throw new FieldValidationException(message2);
        }
    }

    private void CheckNonNegativeInteger(Object obj, string propertyName)
    {
        var message = $"{propertyName} must be a positive intger";

        if (obj == null)
        {
            return;
        }

        if (obj is int i && i < 0)
        {
            throw new FieldValidationException(message);
        }
    }

    private void CheckMax(FieldMaxInclusiveAttribute attr, Object obj, string propertyName)
    {
        var message = $"{propertyName} is greater than {attr.Max}";

        if (obj == null)
        {
            return;
        }

        long val;
        if (obj is string s)
        {
            if (s == "")
            {
                return;
            }

            if (!long.TryParse(s, out val))
            {
                throw new FieldValidationException($"Cannot convert {propertyName} to a numeric value");
            }
        }
        else
        {
            try
            {
                val = Convert.ToInt64(obj);
            }
            catch (InvalidCastException)
            {
                throw new FieldValidationException($"Cannot cast {propertyName} to a numeric value");
            }
        }

        if (val > attr.Max)
        {
            throw new FieldValidationException(message);
        }
    }

    private void CheckRange(FieldRangeInclusiveAttribute attr, Object obj, string propertyName)
    {
        var message = $"{propertyName} is not between {attr.Min} and {attr.Max} inclusive";

        if (obj == null)
        {
            return;
        }

        long val;
        if (obj is string s)
        {
            if (s == "")
            {
                return;
            }

            if (!long.TryParse(s, out val))
            {
                throw new FieldValidationException($"Cannot convert {propertyName} to a numeric value");
            }
        }
        else
        {
            try
            {
                val = Convert.ToInt64(obj);
            }
            catch (InvalidCastException)
            {
                throw new FieldValidationException($"Cannot cast {propertyName} to a numeric value");
            }
        }

        if (val < attr.Min || val > attr.Max)
        {
            throw new FieldValidationException(message);
        }
    }

    private void CheckRange(FieldRangeExclusiveAttribute attr, Object obj, string propertyName)
    {
        var message = $"{propertyName} is not between {attr.Min} and {attr.Max} exclusive";

        if (obj == null)
        {
            return;
        }

        long val;
        if (obj is string s)
        {
            if (s == "")
            {
                return;
            }

            if (!long.TryParse(s, out val))
            {
                throw new FieldValidationException($"Cannot convert {propertyName} to a numeric value");
            }
        }
        else
        {
            try
            {
                val = Convert.ToInt64(obj);
            }
            catch (InvalidCastException)
            {
                throw new FieldValidationException($"Cannot cast {propertyName} to a numeric value");
            }
        }

        if (val <= attr.Min || val >= attr.Max)
        {
            throw new FieldValidationException(message);
        }
    }

    private void CheckLength(FieldMaxLengthAttribute attr, Object obj, string propertyName)
    {
        var message = $"{propertyName} has a length more than {attr.Length} characters";

        if (obj == null)
        {
            return;
        }

        if (obj is string s)
        {
            if (s == "")
            {
                return;
            }

            if (s.Length > attr.Length)
            {
                throw new FieldValidationException(message);
            }
        }
    }

    private void CheckMinMaxLength(FieldMinMaxLengthAttribute attr, Object obj, string propertyName)
    {
        var message = $"{propertyName} has less than {attr.Min} or more than {attr.Max} characters";

        if (obj == null)
        {
            return;
        }

        if (obj is string s)
        {
            if (s == "")
            {
                return;
            }

            if (s.Length < attr.Min || s.Length > attr.Max)
            {
                throw new FieldValidationException(message);
            }
        }
    }

    private void CheckRegex(FieldRegexAttribute attr, Object obj, string propertyName)
    {
        var message = $"{propertyName} does not match with regular expression {attr.Regex}";

        if (obj == null)
        {
            return;
        }

        if (obj is string s)
        {
            if (s == "")
            {
                return;
            }

            var regex = new Regex(attr.Regex, RegexOptions.None, TimeSpan.FromMilliseconds(500));

            if (!regex.IsMatch(s))
            {
                throw new FieldValidationException(message);
            }
        }
    }
}
