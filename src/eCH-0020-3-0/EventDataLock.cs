// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventDataLock.
/// </summary>
[Serializable]
[JsonObject("eventDataLock")]
[XmlRoot(ElementName = "eventDataLock", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventDataLock
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DataLockPersonNullValidateExceptionMessage = "DataLockPerson is not valid! DataLockPerson is required";

    private PersonIdentification _dataLockPerson;

    public EventDataLock()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dataLockPerson">Field is required.</param>
    /// <param name="dataLock">Field is reqired.</param>
    /// <param name="dataLockValidTill">Field is optional.</param>
    /// <param name="dataLockValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventDataLock Create(PersonIdentification dataLockPerson, DataLockType dataLock, DateTime? dataLockValidFrom = null, DateTime? dataLockValidTill = null, object extension = null)
    {
        return new EventDataLock()
        {
            DataLockPerson = dataLockPerson,
            DataLock = dataLock,
            DataLockValidFrom = dataLockValidFrom,
            DataLockValidTill = dataLockValidTill,
            Extension = extension
        };
    }

    [JsonProperty("dataLockPerson")]
    [XmlElement(ElementName = "dataLockPerson")]
    public PersonIdentification DataLockPerson
    {
        get { return _dataLockPerson; }

        set
        {
            _dataLockPerson = value ?? throw new XmlSchemaValidationException(DataLockPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock")]
    public DataLockType DataLock { get; set; }

    [JsonProperty("dataLockValidFrom")]
    [XmlElement(DataType = "date", ElementName = "dataLockValidFrom")]
    public DateTime? DataLockValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockValidFromSpecified => DataLockValidFrom.HasValue;

    [JsonProperty("dataLockValidTill")]
    [XmlElement(DataType = "date", ElementName = "dataLockValidTill")]
    public DateTime? DataLockValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockValidTillSpecified => DataLockValidTill.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
