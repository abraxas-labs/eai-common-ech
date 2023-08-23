// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0157_4_0;

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
[XmlRoot(ElementName = "eventInitialDelivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0157/4")]
public class EventInitialDeliveryType : FieldValueChecker<EventInitialDeliveryType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ContestType _contest;
    private ElectionGroupBallotType[] _electionGroupBallot;
    private ExtensionType _extension;

    public EventInitialDeliveryType()
    {
        Xmlns.Add("eCH-0157", "http://www.ech.ch/xmlns/eCH-0157/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contest">Field is required.</param>
    /// <param name="electionGroupBallot">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventInitialDeliveryType.</returns>
    public static EventInitialDeliveryType Create(ContestType contest, ElectionGroupBallotType[] electionGroupBallot, ExtensionType extension = null)
    {
        return new EventInitialDeliveryType
        {
            Contest = contest,
            ElectionGroupBallot = electionGroupBallot,
            Extension = extension
        };
    }

    [FieldRequired]
    [JsonProperty("contest")]
    [XmlElement(ElementName = "contest", Order = 1)]
    public ContestType Contest
    {
        get => _contest;
        set => CheckAndSetValue(ref _contest, value);
    }

    [FieldRequired]
    [JsonProperty("electionGroupBallot")]
    [XmlElement("electionGroupBallot", Order = 2)]
    public ElectionGroupBallotType[] ElectionGroupBallot
    {
        get => _electionGroupBallot;
        set => _electionGroupBallot = value;
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension", Order = 3)]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
