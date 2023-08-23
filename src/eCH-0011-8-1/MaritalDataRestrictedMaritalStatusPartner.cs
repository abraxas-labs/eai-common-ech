﻿// (c) Copyright 2023 by Abraxas Informatik AG
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
[JsonObject("maritalDataRestrictedMaritalStatusPartner")]
[XmlRoot(ElementName = "maritalDataRestrictedMaritalStatusPartner", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class MaritalDataRestrictedMaritalStatusPartner
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MaritalDataRestrictedMaritalStatusPartner()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalStatus">Field is required.</param>
    /// <param name="dateOfMaritalStatus">Field is required.</param>
    /// <param name="cancelationReason">Field is optional.</param>
    /// <returns>MaritalData.</returns>
    public static MaritalDataRestrictedMaritalStatusPartner Create(MaritalStatus maritalStatus, DateTime dateOfMaritalStatus, PartnerShipAbolition? cancelationReason)
    {
        return new MaritalDataRestrictedMaritalStatusPartner()
        {
            MaritalStatus = maritalStatus,
            DateOfMaritalStatus = dateOfMaritalStatus,
            CancelationReason = cancelationReason
        };
    }

    [JsonProperty("maritalStatus")]
    [XmlElement(ElementName = "maritalStatus", Order = 1)]
    public MaritalStatus MaritalStatus { get; set; }

    [JsonProperty("dateOfMaritalStatus")]
    [XmlElement(DataType = "date", ElementName = "dateOfMaritalStatus", Order = 2)]
    public DateTime DateOfMaritalStatus { get; set; }

    [JsonProperty("cancelationReason")]
    [XmlElement(ElementName = "cancelationReason", Order = 3)]
    public PartnerShipAbolition? CancelationReason { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CancelationReasonSpecified => CancelationReason.HasValue;
}
