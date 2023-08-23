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
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("religionDataType")]
[XmlRoot(ElementName = "religionDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class ReligionDataType : FieldValueChecker<ReligionDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _religion;
    private DateTime? _religionValidFrom;

    public ReligionDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="religion">Field is required.</param>
    /// <param name="religionValidFrom">Field is optional.</param>
    /// <returns>ReligionDataType.</returns>
    public static ReligionDataType Create(string religion, DateTime? religionValidFrom)
    {
        return new ReligionDataType
        {
            Religion = religion,
            ReligionValidFrom = religionValidFrom
        };
    }

    [FieldRegex("\\d{3,6}")]
    [JsonProperty("religion")]
    [XmlElement(ElementName = "religion")]
    public string Religion
    {
        get => _religion;
        set => CheckAndSetValue(ref _religion, value);
    }

    [JsonProperty("religionValidFrom")]
    [XmlElement(ElementName = "religionValidFrom")]
    public DateTime? ReligionValidFrom
    {
        get => _religionValidFrom;
        set => CheckAndSetValue(ref _religionValidFrom, value);
    }
}
