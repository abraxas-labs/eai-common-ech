// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("maritalDataRestricted")]
[XmlRoot(ElementName = "maritalDataRestricted", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class MaritalDataRestricted
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MaritalDataRestricted()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalStatus">Field is required.</param>
    /// <param name="dateOfMaritalStatus">Field is optional.</param>
    /// <returns>NameInfo.</returns>
    public static MaritalDataRestricted Create(MaritalStatus maritalStatus, DateTime? dateOfMaritalStatus = null)
    {
        return new MaritalDataRestricted()
        {
            MaritalStatus = maritalStatus,
            DateOfMaritalStatus = dateOfMaritalStatus
        };
    }

    [JsonProperty("maritalStatus")]
    [XmlElement(ElementName = "maritalStatus")]
    public MaritalStatus MaritalStatus { get; set; }

    [JsonProperty("dateOfMaritalStatus")]
    [XmlElement(DataType = "date", ElementName = "dateOfMaritalStatus")]
    public DateTime? DateOfMaritalStatus { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfMaritalStatusSpecified => DateOfMaritalStatus.HasValue;
}
