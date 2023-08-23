// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_3_0;
using Newtonsoft.Json;

namespace eCH_0159_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0159).
/// </summary>
[Serializable]
[JsonObject("eventInitialDelivery")]
[XmlRoot(ElementName = "eventInitialDelivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0159/3")]
public class EventInitialDelivery : FieldValueChecker<EventInitialDelivery>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Contest _contest;
    private List<VoteInformation> _voteInformation;
    private ExtensionType _extension;

    public EventInitialDelivery()
    {
        Xmlns.Add("eCH-0159", "http://www.ech.ch/xmlns/eCH-0159/3");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contest">Field is required.</param>
    /// <param name="voteInformation">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventInitialDelivery.</returns>
    public static EventInitialDelivery Create(Contest contest, List<VoteInformation> voteInformation, ExtensionType extension = null)
    {
        return new EventInitialDelivery
        {
            Contest = contest,
            VoteInformation = voteInformation,
            Extension = extension
        };
    }

    [FieldRequired]
    [JsonProperty("contest")]
    [XmlElement(ElementName = "contest")]
    public Contest Contest
    {
        get => _contest;
        set => CheckAndSetValue(ref _contest, value);
    }

    [JsonProperty("voteInformation")]
    [XmlElement(ElementName = "voteInformation")]
    public List<VoteInformation> VoteInformation
    {
        get => _voteInformation;
        set => CheckAndSetValue(ref _voteInformation, value);
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool ExtensionSpecified => Extension != null;
}
