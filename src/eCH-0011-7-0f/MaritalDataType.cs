// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("maritalDat")]
[XmlRoot(ElementName = "maritalDat", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]

public class MaritalDataType : FieldValueChecker<MaritalDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private MaritalStatusType _maritalStatus;
    private DateTime _dateOfMaritalStatus;
    private SeparationType _separation;
    private DateTime _dateOfSeparation;
    private DateTime _separationTill;
    private PartnerShipAbolitionType _cancelationReason;
    private bool _officialProofOfMaritalStatusYesNo;

    public MaritalDataType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalStatus">Field is required.</param>
    /// <param name="dateOfMaritalStatus">Field is optional.</param>
    /// <param name="separation">Field is optional.</param>
    /// <param name="dateOfSeparation">Field is optional.</param>
    /// <param name="separationTill">Field is optional.</param>
    /// <param name="cancelationReason">Field is optional.</param>
    /// <param name="officialProofOfMaritalStatusYesNo">Field is optional.</param>
    /// <returns>MaritalDataType.</returns>
    public static MaritalDataType Create(MaritalStatusType maritalStatus, DateTime dateOfMaritalStatus, SeparationType separation,
        DateTime dateOfSeparation, DateTime separationTill, PartnerShipAbolitionType cancelationReason, bool officialProofOfMaritalStatusYesNo)
    {
        return new MaritalDataType
        {
            MaritalStatus = maritalStatus,
            DateOfMaritalStatus = dateOfMaritalStatus,
            Separation = separation,
            DateOfSeparation = dateOfSeparation,
            SeparationTill = separationTill,
            CancelationReason = cancelationReason,
            OfficialProofOfMaritalStatusYesNo = officialProofOfMaritalStatusYesNo
        };
    }

    [FieldRequired]
    [JsonProperty("maritalStatus")]
    [XmlElement(ElementName = "maritalStatus")]
    public MaritalStatusType MaritalStatus
    {
        get => _maritalStatus;
        set => CheckAndSetValue(ref _maritalStatus, value);
    }

    [JsonProperty("dateOfMaritalStatus")]
    [XmlElement(ElementName = "dateOfMaritalStatus")]
    public DateTime DateOfMaritalStatus
    {
        get => _dateOfMaritalStatus;
        set => CheckAndSetValue(ref _dateOfMaritalStatus, value);
    }

    [JsonProperty("separation")]
    [XmlElement(ElementName = "separation")]
    public SeparationType Separation
    {
        get => _separation;
        set => CheckAndSetValue(ref _separation, value);
    }

    [JsonProperty("dateOfSeparation")]
    [XmlElement(ElementName = "dateOfSeparation")]
    public DateTime DateOfSeparation
    {
        get => _dateOfSeparation;
        set => CheckAndSetValue(ref _dateOfSeparation, value);
    }

    [JsonProperty("separationTill")]
    [XmlElement(ElementName = "separationTill")]
    public DateTime SeparationTill
    {
        get => _separationTill;
        set => CheckAndSetValue(ref _separationTill, value);
    }

    [JsonProperty("cancelationReason")]
    [XmlElement(ElementName = "cancelationReason")]
    public PartnerShipAbolitionType CancelationReason
    {
        get => _cancelationReason;
        set => CheckAndSetValue(ref _cancelationReason, value);
    }

    [JsonProperty("officialProofOfMaritalStatusYesNo")]
    [XmlElement(ElementName = "officialProofOfMaritalStatusYesNo")]
    public bool OfficialProofOfMaritalStatusYesNo
    {
        get => _officialProofOfMaritalStatusYesNo;
        set => CheckAndSetValue(ref _officialProofOfMaritalStatusYesNo, value);
    }
}
