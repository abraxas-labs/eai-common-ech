// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Zivilstandsangaben zu einer Person.
/// </summary>
[Serializable]
[JsonObject("maritalData")]
[XmlRoot(ElementName = "maritalData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class MaritalData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MaritalData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalStatus">Field is required.</param>
    /// <param name="dateOfMaritalStatus">Field is optional.</param>
    /// <param name="cancelationReason">Field is optional.</param>
    /// <param name="officialProofOfMaritalStatusYesNo">Field is optional.</param>
    /// <param name="separationData">Field is optional.</param>
    /// <returns>MaritalData.</returns>
    public static MaritalData Create(MaritalStatus maritalStatus, DateTime? dateOfMaritalStatus = null, PartnerShipAbolition? cancelationReason = null, bool? officialProofOfMaritalStatusYesNo = null, SeparationData separationData = null)
    {
        return new MaritalData()
        {
            MaritalStatus = maritalStatus,
            DateOfMaritalStatus = dateOfMaritalStatus,
            CancelationReason = cancelationReason,
            OfficialProofOfMaritalStatusYesNo = officialProofOfMaritalStatusYesNo,
            SeparationData = separationData
        };
    }

    [JsonProperty("maritalStatus")]
    [XmlElement(ElementName = "maritalStatus", Order = 1)]
    public MaritalStatus MaritalStatus { get; set; }

    [JsonProperty("dateOfMaritalStatus")]
    [XmlElement(DataType = "date", ElementName = "dateOfMaritalStatus", Order = 2)]
    public DateTime? DateOfMaritalStatus { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfMaritalStatusSpecified => DateOfMaritalStatus.HasValue;

    [JsonProperty("cancelationReason")]
    [XmlElement(ElementName = "cancelationReason", Order = 3)]
    public PartnerShipAbolition? CancelationReason { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CancelationReasonSpecified => CancelationReason.HasValue;

    [JsonProperty("officialProofOfMaritalStatusYesNo")]
    [XmlElement(ElementName = "officialProofOfMaritalStatusYesNo", Order = 4)]
    public bool? OfficialProofOfMaritalStatusYesNo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OfficialProofOfMaritalStatusYesNoSpecified => OfficialProofOfMaritalStatusYesNo.HasValue;

    [JsonProperty("separationData")]
    [XmlElement(ElementName = "separationData", Order = 5)]
    public SeparationData SeparationData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationDataSpecified => SeparationData != null;
}
