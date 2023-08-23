// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventChangeResidenceType.
/// </summary>
[Serializable]
[JsonObject("eventChangeResidenceType")]
[XmlRoot(ElementName = "eventChangeResidenceType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventChangeResidenceType
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ChangeResidenceTypePersonNullValidateExceptionMessage = "ChangeResidenceTypePerson is not valid! ChangeResidenceTypePerson is required";
    private const string ChangeResidenceTypeReportingRelationshipNullValidateExceptionMessage = "ChangeResidenceTypeReportingRelationship is not valid! ChangeResidenceTypeReportingRelationship is required";

    private BaseDeliveryRestrictedMoveInPersonType _changeResidenceTypePerson;
    private ReportingMunicipalityRestrictedMoveIn _changeResidenceTypeReportingRelationship;

    public EventChangeResidenceType()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeResidenceTypePerson">Field is required.</param>
    /// <param name="changeResidenceTypeReportingRelationship">Field is reqired.</param>
    /// <param name="residenceTypeValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeResidenceType Create(BaseDeliveryRestrictedMoveInPersonType changeResidenceTypePerson, ReportingMunicipalityRestrictedMoveIn changeResidenceTypeReportingRelationship, DateTime? residenceTypeValidFrom = null, object extension = null)
    {
        return new EventChangeResidenceType()
        {
            ChangeResidenceTypePerson = changeResidenceTypePerson,
            ChangeResidenceTypeReportingRelationship = changeResidenceTypeReportingRelationship,
            ResidenceTypeValidFrom = residenceTypeValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("changeResidenceTypePerson")]
    [XmlElement(ElementName = "changeResidenceTypePerson")]
    public BaseDeliveryRestrictedMoveInPersonType ChangeResidenceTypePerson
    {
        get { return _changeResidenceTypePerson; }

        set
        {
            _changeResidenceTypePerson = value ?? throw new XmlSchemaValidationException(ChangeResidenceTypePersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("changeResidenceTypeReportingRelationship")]
    [XmlElement(ElementName = "changeResidenceTypeReportingRelationship")]
    public ReportingMunicipalityRestrictedMoveIn ChangeResidenceTypeReportingRelationship
    {
        get { return _changeResidenceTypeReportingRelationship; }

        set
        {
            _changeResidenceTypeReportingRelationship = value ?? throw new XmlSchemaValidationException(ChangeResidenceTypeReportingRelationshipNullValidateExceptionMessage);
        }
    }

    [JsonProperty("residenceTypeValidFrom")]
    [XmlElement(DataType = "date", ElementName = "residenceTypeValidFrom")]
    public DateTime? ResidenceTypeValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidenceTypeValidFromSpecified => ResidenceTypeValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
