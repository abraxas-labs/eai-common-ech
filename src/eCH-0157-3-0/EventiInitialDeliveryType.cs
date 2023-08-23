// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_3_0;
using Newtonsoft.Json;

namespace eCH_0157_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0157)
///     Bei der Initiallieferung werden von der Wahlbehörde die Angaben zu allen Kandidaten und allen Listen an das
///     eVoting-System geliefert.
///     Bei den Kandidaten und Listen werden alle gemäss [eCH-0155] definierten Attribute geliefert. Sind
///     Listenverbindungen oder Nebenwahlen
///     vorhanden, so werden diese als Beziehungen zwischen den entsprechenden Listen geliefert.
/// </summary>
[Serializable]
[JsonObject("eventInitialDelivery")]
[XmlRoot(ElementName = "eventInitialDelivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0157/3")]
public class EventInitialDeliveryType : FieldValueChecker<EventInitialDeliveryType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Contest _contest;
    private List<ElectionInformation> _electionInformation;
    private ExtensionType _extension;

    public EventInitialDeliveryType()
    {
        Xmlns.Add("eCH-0157", "http://www.ech.ch/xmlns/eCH-0157/3");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contest">Field is required.</param>
    /// <param name="electionInformation">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventInitialDeliveryType.</returns>
    public static EventInitialDeliveryType Create(Contest contest, List<ElectionInformation> electionInformation,
        ExtensionType extension)
    {
        return new EventInitialDeliveryType
        {
            Contest = contest,
            ElectionInformation = electionInformation,
            Extension = extension
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle minimalen Werte.
    /// </summary>
    /// <param name="contest">Field is required.</param>
    /// <param name="electionInformation">Field is required.</param>
    /// <returns>EventInitialDeliveryType.</returns>
    public static EventInitialDeliveryType Create(Contest contest, List<ElectionInformation> electionInformation)
    {
        return new EventInitialDeliveryType
        {
            Contest = contest,
            ElectionInformation = electionInformation
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

    [FieldRequired]
    [JsonProperty("electionInformation")]
    [XmlElement("electionInformation")]
    public List<ElectionInformation> ElectionInformation
    {
        get => _electionInformation;
        set => CheckAndSetValue(ref _electionInformation, value);
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
