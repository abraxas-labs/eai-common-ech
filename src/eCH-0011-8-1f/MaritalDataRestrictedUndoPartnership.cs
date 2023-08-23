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
[JsonObject("maritalDataRestrictedUndoPartnership")]
[XmlRoot(ElementName = "maritalDataRestrictedUndoPartnership", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class MaritalDataRestrictedUndoPartnership
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MaritalDataRestrictedUndoPartnership()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalStatus">Field is required.</param>
    /// <param name="dateOfMaritalStatus">Field is required.</param>
    /// <param name="cancelationReason">Field is required.</param>
    /// <returns>MaritalData.</returns>
    public static MaritalDataRestrictedUndoPartnership Create(MaritalStatus maritalStatus, DateTime dateOfMaritalStatus, PartnerShipAbolition cancelationReason)
    {
        return new MaritalDataRestrictedUndoPartnership()
        {
            MaritalStatus = maritalStatus,
            DateOfMaritalStatus = dateOfMaritalStatus,
            CancelationReason = cancelationReason
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
}
