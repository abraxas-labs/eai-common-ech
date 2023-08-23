// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Zivilstandsangaben zu einer Person.
/// </summary>
[Serializable]
[JsonObject("maritalData")]
[XmlRoot(ElementName = "maritalData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class MaritalData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MaritalData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
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
    public static MaritalData Create(eCH_0011_8_1.MaritalStatus? maritalStatus, DateTime? dateOfMaritalStatus = null, eCH_0011_8_1.PartnerShipAbolition? cancelationReason = null, bool? officialProofOfMaritalStatusYesNo = null, eCH_0011_8_1.SeparationData separationData = null)
    {
        return new MaritalData()
        {
            MaritalStatus = (maritalStatus != null) ? (MaritalStatus?)Enum.Parse(typeof(MaritalStatus), maritalStatus.ToString()) : null,
            DateOfMaritalStatus = dateOfMaritalStatus,
            CancelationReason = (cancelationReason != null) ? (PartnerShipAbolition?)Enum.Parse(typeof(PartnerShipAbolition), cancelationReason.ToString()) : null,
            OfficialProofOfMaritalStatusYesNo = officialProofOfMaritalStatusYesNo,
            SeparationData = (separationData != null) ? SeparationData.Create(separationData.Separation, separationData.SeparationValidFrom, separationData.SeparationValidTill) : null
        };
    }

    [JsonProperty("maritalStatus")]
    [XmlElement(ElementName = "maritalStatus")]
    public MaritalStatus? MaritalStatus { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalStatusSpecified => MaritalStatus.HasValue;

    [JsonProperty("dateOfMaritalStatus")]
    [XmlElement(DataType = "date", ElementName = "dateOfMaritalStatus")]
    public DateTime? DateOfMaritalStatus { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfMaritalStatusSpecified => DateOfMaritalStatus.HasValue;

    [JsonProperty("cancelationReason")]
    [XmlElement(ElementName = "cancelationReason")]
    public PartnerShipAbolition? CancelationReason { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CancelationReasonSpecified => CancelationReason.HasValue;

    [JsonProperty("officialProofOfMaritalStatusYesNo")]
    [XmlElement(ElementName = "officialProofOfMaritalStatusYesNo")]
    public bool? OfficialProofOfMaritalStatusYesNo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OfficialProofOfMaritalStatusYesNoSpecified => OfficialProofOfMaritalStatusYesNo.HasValue;

    [JsonProperty("separationData")]
    [XmlElement(ElementName = "separationData")]
    public SeparationData SeparationData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationDataSpecified => SeparationData != null;
}
