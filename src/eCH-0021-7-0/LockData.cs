// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Sperrvermerke.
/// </summary>
[Serializable]
[JsonObject("lockData")]
[XmlRoot(ElementName = "lockData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class LockData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public LockData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dataLock">Field is required.</param>
    /// <param name="paperLock">Field is required.</param>
    /// <param name="dataLockValidFrom">Field is optional.</param>
    /// <param name="dataLockValidTill">Field is optional.</param>
    /// <param name="paperLockValidFrom">Field is optional.</param>
    /// <param name="paperLockValidTill">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static LockData Create(DataLockType dataLock, YesNo paperLock, DateTime? dataLockValidFrom = null, DateTime? dataLockValidTill = null, DateTime? paperLockValidFrom = null, DateTime? paperLockValidTill = null)
    {
        return new LockData()
        {
            DataLock = dataLock,
            DataLockValidFrom = dataLockValidFrom,
            DataLockValidTill = dataLockValidTill,
            PaperLock = paperLock,
            PaperLockValidFrom = paperLockValidFrom,
            PaperLockValidTill = paperLockValidTill
        };
    }

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock", Order = 1)]
    public DataLockType DataLock { get; set; }

    [JsonProperty("dataLockValidFrom")]
    [XmlElement(DataType = "date", ElementName = "dataLockValidFrom", Order = 2)]
    public DateTime? DataLockValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockValidFromSpecified => DataLockValidFrom.HasValue;

    [JsonProperty("dataLockValidTill")]
    [XmlElement(DataType = "date", ElementName = "dataLockValidTill", Order = 3)]
    public DateTime? DataLockValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockValidTillSpecified => DataLockValidTill.HasValue;

    [JsonProperty("paperLock")]
    [XmlElement(ElementName = "paperLock", Order = 4)]
    public YesNo PaperLock { get; set; }

    [JsonProperty("paperLockValidFrom")]
    [XmlElement(DataType = "date", ElementName = "paperLockValidFrom", Order = 5)]
    public DateTime? PaperLockValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PaperLockValidFromSpecified => PaperLockValidFrom.HasValue;

    [JsonProperty("paperLockValidTill")]
    [XmlElement(DataType = "date", ElementName = "paperLockValidTill", Order = 6)]
    public DateTime? PaperLockValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PaperLockValidTillSpecified => PaperLockValidTill.HasValue;
}
