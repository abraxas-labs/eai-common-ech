// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Lieferung Personendaten für Haushaltabgabe (eCH-0201)
///     Personendaten.
/// </summary>
[Serializable]
[JsonObject("reportedPerson")]
[XmlRoot(ElementName = "reportedPerson", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public class ReportedPersonType : FieldValueChecker<ReportedPersonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonType _person;
    private ReportingMunicipalityRestrictedBaseMainType _hasMainResidence;
    private ReportingMunicipalityRestrictedBaseSecondaryType _hasOtherResidence;
    private DateTime? _reportedPersonValidFrom;
    private object _extension;

    public ReportedPersonType()
    {
        Xmlns.Add("eCH-0201", "http://www.ech.ch/xmlns/eCH-0201/1");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="person">Field is reqired.</param>
    /// <param name="residenceChoice">Field is reqired.</param>
    /// <param name="reportedPersonValidFrom">Field can be null.</param>
    /// <param name="extension">Field can be null.</param>
    /// <returns>ReportedPerson.</returns>
    public static ReportedPersonType Create(PersonType person, object residenceChoice, DateTime? reportedPersonValidFrom = null, object extension = null)
    {
        var reportedPerson = new ReportedPersonType
        {
            Person = person,
            ReportedPersonValidFrom = reportedPersonValidFrom,
            Extension = extension,
        };

        if (residenceChoice is ReportingMunicipalityRestrictedBaseMainType residence)
        {
            reportedPerson.HasMainResidence = residence;
        }

        if (residenceChoice is ReportingMunicipalityRestrictedBaseMainType mainResidence)
        {
            reportedPerson.HasMainResidence = mainResidence;
        }

        return reportedPerson;
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person")]
    public PersonType Person
    {
        get => _person;
        set => CheckAndSetValue(ref _person, value);
    }

    [JsonProperty("hasMainResidence")]
    [XmlElement("hasMainResidence")]
    public ReportingMunicipalityRestrictedBaseMainType HasMainResidence
    {
        get => _hasMainResidence;
        set
        {
            if (value == null && HasOtherResidence != null)
            {
                _hasMainResidence = value;
            }

            if (value == null && HasOtherResidence == null)
            {
                throw new XmlSchemaValidationException("Either HasMainResidence or HasOtherResidence can not be null");
            }

            if (value != null && HasOtherResidence != null)
            {
                throw new XmlSchemaValidationException("Provide exactly one of HasMainResidence or HasOtherResidence");
            }

            _hasMainResidence = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasMainResidenceSpecified => HasOtherResidence == null && HasMainResidence != null;

    [JsonProperty("hasOtherResidence")]
    [XmlElement("hasOtherResidence")]
    public ReportingMunicipalityRestrictedBaseSecondaryType HasOtherResidence
    {
        get => _hasOtherResidence;
        set
        {
            if (value == null && HasMainResidence != null)
            {
                _hasOtherResidence = null;
            }

            if (value == null && HasMainResidence == null)
            {
                throw new XmlSchemaValidationException("Either HasMainResidence or HasOtherResidence can not be null");
            }

            if (value != null && HasMainResidence != null)
            {
                throw new XmlSchemaValidationException("Provide exactly one of HasMainResidence or HasOtherResidence");
            }

            _hasOtherResidence = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool HasOtherResidenceSpecified => HasMainResidence == null && HasOtherResidence != null;

    [JsonProperty("reportedPersonValidFrom")]
    [XmlElement(DataType = "date", ElementName = "reportedPersonValidFrom")]
    public DateTime? ReportedPersonValidFrom
    {
        get => _reportedPersonValidFrom;
        set => CheckAndSetValue(ref _reportedPersonValidFrom, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReportedPersonValidFromSpecified => ReportedPersonValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
