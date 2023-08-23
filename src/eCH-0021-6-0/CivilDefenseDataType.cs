// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Zivilschutzdienstpflichtangaben.
/// </summary>
[Serializable]
[JsonObject("civilDefenseDataType")]
[XmlRoot(ElementName = "civilDefenseDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class CivilDefenseDataType : FieldValueChecker<CivilDefenseDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private YesNoType? _civilDefense;
    private DateTime? _civilDefenseValidFrom;

    public CivilDefenseDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="civilDefense">Field is optional.</param>
    /// <param name="civilDefenseValidFrom">Field is optional.</param>
    /// <returns>CivilDefenseDataType.</returns>
    public static CivilDefenseDataType Create(YesNoType? civilDefense = null, DateTime? civilDefenseValidFrom = null)
    {
        return new CivilDefenseDataType
        {
            CivilDefense = civilDefense,
            CivilDefenseValidFrom = civilDefenseValidFrom
        };
    }

    [JsonProperty("civilDefense")]
    [XmlElement(ElementName = "civilDefense")]
    public YesNoType? CivilDefense
    {
        get => _civilDefense;
        set => CheckAndSetValue(ref _civilDefense, value);
    }

    [JsonProperty("civilDefenseValidFrom")]
    [XmlElement(DataType = "date", ElementName = "civilDefenseValidFrom")]
    public DateTime? CivilDefenseValidFrom
    {
        get => _civilDefenseValidFrom;
        set => CheckAndSetValue(ref _civilDefenseValidFrom, value);
    }
}
