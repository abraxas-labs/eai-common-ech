// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventUndoSwiss.
/// </summary>
[Serializable]
[JsonObject("eventUndoSwiss")]
[XmlRoot(ElementName = "eventUndoSwiss", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventUndoSwiss
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string UndoSwissPersonNullValidateExceptionMessage = "UndoSwissPerson is not valid! UndoSwissPerson is required";
    private const string NationalityDataNullValidateExceptionMessage = "NationalityData is not valid! NationalityData is required";

    private PersonIdentification _undoSwissPerson;
    private NationalityData _nationalityData;

    public EventUndoSwiss()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="undoSwissPerson">Field is required.</param>
    /// <param name="nationalityData">Field is optional.</param>
    /// <param name="residencePermitData">Field is optional.</param>
    /// <param name="undoSwissValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventUndoSwiss.</returns>
    public static EventUndoSwiss Create(PersonIdentification undoSwissPerson, NationalityData nationalityData, ResidencePermitData residencePermitData = null, DateTime? undoSwissValidFrom = null, object extension = null)
    {
        return new EventUndoSwiss()
        {
            UndoSwissPerson = undoSwissPerson,
            NationalityData = nationalityData,
            ResidencePermitData = residencePermitData,
            UndoSwissValidFrom = undoSwissValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("undoSwissPerson")]
    [XmlElement(ElementName = "undoSwissPerson")]
    public PersonIdentification UndoSwissPerson
    {
        get { return _undoSwissPerson; }

        set
        {
            _undoSwissPerson = value ?? throw new XmlSchemaValidationException(UndoSwissPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData")]
    public NationalityData NationalityData
    {
        get { return _nationalityData; }

        set
        {
            _nationalityData = value ?? throw new XmlSchemaValidationException(NationalityDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("residencePermitData")]
    [XmlElement(ElementName = "residencePermitData")]
    public ResidencePermitData ResidencePermitData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitDataSpecified => ResidencePermitData != null;

    [JsonProperty("undoSwissValidFrom")]
    [XmlElement(DataType = "date", ElementName = "undoSwissValidFrom")]
    public DateTime? UndoSwissValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoSwissValidFromSpecified => UndoSwissValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
