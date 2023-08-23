// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0044_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044)
/// Schlüssel für die Geschlechtsangabe.
/// </summary>
[XmlType(TypeName = "sex", Namespace = "http://www.ech.ch/xmlns/eCH-0044/3")]
public enum SexType
{
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Männlich = 1,

    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Weiblich = 2
}
