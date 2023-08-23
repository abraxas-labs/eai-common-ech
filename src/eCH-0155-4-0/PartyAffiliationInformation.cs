// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     "Parteizugehörigkeit " Kurzbezeichnung von maximal 12 Zeichen und optionale Bezeichnung
///     von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("partyAffiliationformation")]
[XmlRoot(ElementName = "partyAffiliationformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class PartyAffiliationInformation
{
    private const string PartyAffiliationNullValidateExceptionMessage =
        "PartyAffiliationInfo is not valid! PartyAffiliationInfo is required";

    private List<PartyAffiliationInfo> _partyAffiliationInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PartyAffiliationInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("partyAffiliationInfo")]
    [XmlElement(ElementName = "partyAffiliationInfo", Order = 1)]
    public List<PartyAffiliationInfo> PartyAffiliationInfo
    {
        get => _partyAffiliationInfo;
        set
        {
            _partyAffiliationInfo = value ?? throw new XmlSchemaValidationException(PartyAffiliationNullValidateExceptionMessage);
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="partyAffiliationInfo">Field is required.</param>
    /// <returns>PartyAffiliationInformation.</returns>
    public static PartyAffiliationInformation Create(List<PartyAffiliationInfo> partyAffiliationInfo)
    {
        return new PartyAffiliationInformation
        {
            PartyAffiliationInfo = partyAffiliationInfo
        };
    }
}
