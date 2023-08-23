// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0021_7_0f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventCorrectDataLock.
/// </summary>
[Serializable]
[JsonObject("eventCorrectDataLock")]
[XmlRoot(ElementName = "eventCorrectDataLock", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventCorrectDataLock
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctDataLockPerson;

    public EventCorrectDataLock()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctDataLockPerson">Field is required.</param>
    /// <param name="dataLock">Field is reqired.</param>
    /// <param name="dataLockValidTill">Field is optional.</param>
    /// <param name="dataLockValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectDataLock Create(PersonIdentification correctDataLockPerson, DataLockType dataLock, DateTime? dataLockValidFrom = null, DateTime? dataLockValidTill = null, object extension = null)
    {
        return new EventCorrectDataLock()
        {
            CorrectDataLockPerson = correctDataLockPerson,
            DataLock = dataLock,
            DataLockValidFrom = dataLockValidFrom,
            DataLockValidTill = dataLockValidTill,
            Extension = extension
        };
    }

    [JsonProperty("correctDataLockPerson")]
    [XmlElement(ElementName = "correctDataLockPerson")]
    public PersonIdentification CorrectDataLockPerson
    {
        get { return _correctDataLockPerson; }
        set { _correctDataLockPerson = value; }
    }

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock")]
    public DataLockType? DataLock { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockSpecified => DataLock.HasValue;

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
