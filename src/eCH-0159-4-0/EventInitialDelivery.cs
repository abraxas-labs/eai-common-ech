// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0159_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0159).
/// </summary>
[Serializable]
[JsonObject("eventInitialDelivery")]
[XmlRoot(ElementName = "eventInitialDelivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0159/4")]
public class EventInitialDelivery : FieldValueChecker<EventInitialDelivery>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ContestType _contestType;
    private VoteInformation[] _voteInformation;
    private ExtensionType _extension;

    public EventInitialDelivery()
    {
        Xmlns.Add("eCH-0159", "http://www.ech.ch/xmlns/eCH-0159/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contestType">Field is required.</param>
    /// <param name="voteInformation">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventInitialDelivery.</returns>
    public static EventInitialDelivery Create(ContestType contestType, VoteInformation[] voteInformation, ExtensionType extension = null)
    {
        return new EventInitialDelivery
        {
            ContestType = contestType,
            VoteInformation = voteInformation,
            Extension = extension
        };
    }

    [FieldRequired]
    [JsonProperty("contest")]
    [XmlElement(ElementName = "contest", Order = 1)]
    public ContestType ContestType
    {
        get => _contestType;
        set => CheckAndSetValue(ref _contestType, value);
    }

    [JsonProperty("voteInformation")]
    [XmlElement(ElementName = "voteInformation", Order = 2)]
    public VoteInformation[] VoteInformation
    {
        get => _voteInformation;
        set => _voteInformation = value;
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension", Order = 3)]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool ExtensionSpecified => Extension != null;
}
