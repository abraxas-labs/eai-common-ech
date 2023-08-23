// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("nameInfo")]
[XmlRoot(ElementName = "nameInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class NameInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private NameData _nameData;

    public NameInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nameData">Field is required.</param>
    /// <param name="nameValidFrom">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static NameInfo Create(eCH_0011_8_1.NameData nameData, DateTime? nameValidFrom = null)
    {
        return new NameInfo()
        {
            NameData = eCH_0011_8_1f.Mapper.ECHtoECHf.GetNameData(nameData),
            NameValidFrom = nameValidFrom
        };
    }

    [JsonProperty("nameData")]
    [XmlElement(ElementName = "nameData")]
    public NameData NameData
    {
        get { return _nameData; }
        set { _nameData = value; }
    }

    [JsonProperty("nameValidFrom")]
    [XmlElement(DataType = "date", ElementName = "nameValidFrom")]
    public DateTime? NameValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameValidFromSpecified => NameValidFrom.HasValue;
}
