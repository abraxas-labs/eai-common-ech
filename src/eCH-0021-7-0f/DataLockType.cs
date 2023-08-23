// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Datensperre.
/// </summary>
[XmlType(TypeName = "dataLockType", Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public enum DataLockType
{
    /// <summary>
    /// 0 = Keine Sperre gesetzt.
    /// </summary>
    [EnumMember(Value = "0")]
    [XmlEnum("0")]
    KeineSperre = 0,

    /// <summary>
    /// 1 = Adresssperre gesetzt Die Adresssperre dient der Verhinderung von systematisch geordneten Adressabgaben,
    /// z.Bsp. bewilligte Auslistungen für gemeinnützige oder ideelle Zwecke oder für politische Parteien.
    /// Einzelauskünfte sind von dieser Sperre nicht betroffen.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Adresssperre = 1,

    /// <summary>
    /// 2 = Auskunftssperre gesetzt Die Auskunftssperre verbietet jegliche Auskunftsgabe über die
    /// Personendaten inkl. Adresse.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Auskunftssperre = 2
}
