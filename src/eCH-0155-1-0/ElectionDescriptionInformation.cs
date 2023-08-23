// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Electionenbezeichnung Kurzbezeichnung von maximal 12 Zeichen und optionale Bezeichnung
///     von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("electionDescriptionInformation")]
[XmlRoot(ElementName = "electionDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class ElectionDescriptionInformation
{
    private const string ElectionDescriptionNullValidateExceptionMessage =
        "ElectionDescriptionInfo is not valid! ElectionDescriptionInfo is required";

    private const string ElectionDescriptionInfoOutOfRangeValidateExceptionMessage =
        "ElectionDescriptionInfo is not valid! ElectionDescriptionInfo needs at least one item";

    private List<ElectionDescriptionInfo> _electionDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ElectionDescriptionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("electionDescriptionInfo")]
    [XmlElement(ElementName = "electionDescriptionInfo")]
    public List<ElectionDescriptionInfo> ElectionDescriptionInfo
    {
        get => _electionDescriptionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ElectionDescriptionNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(ElectionDescriptionInfoOutOfRangeValidateExceptionMessage);
            }

            _electionDescriptionInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionDescriptionInfo">Field is required.</param>
    /// <returns>ElectionDescriptionInformation.</returns>
    public static ElectionDescriptionInformation Create(List<ElectionDescriptionInfo> electionDescriptionInfo)
    {
        return new ElectionDescriptionInformation
        {
            ElectionDescriptionInfo = electionDescriptionInfo
        };
    }
}
