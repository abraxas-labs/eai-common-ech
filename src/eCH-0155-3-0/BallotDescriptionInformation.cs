// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bezeichnung der Vorlage als optionale Kurzbezeichnung von maximal 100 Zeichen und optionale Bezeichnung
///     von maximal 255 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("ballotDescriptionInformation")]
[XmlRoot(ElementName = "ballotDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class BallotDescriptionInformation
{
    private const string BallotDescriptionNullValidateExceptionMessage =
        "BallotDescriptionInfo is not valid! BallotDescriptionInfo is required";

    private const string BallotDescriptionInfoOutOfRangeValidateExceptionMessage =
        "BallotDescriptionInfo is not valid! BallotDescriptionInfo needs at least one item";

    private List<BallotDescriptionInfo> _ballotDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public BallotDescriptionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("ballotDescriptionInfo")]
    [XmlElement(ElementName = "ballotDescriptionInfo")]
    public List<BallotDescriptionInfo> BallotDescriptionInfo
    {
        get => _ballotDescriptionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(BallotDescriptionNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(BallotDescriptionInfoOutOfRangeValidateExceptionMessage);
            }

            _ballotDescriptionInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="ballotDescriptionInfo">Field is required.</param>
    /// <returns>BallotDescriptionInformation.</returns>
    public static BallotDescriptionInformation Create(List<BallotDescriptionInfo> ballotDescriptionInfo)
    {
        return new BallotDescriptionInformation
        {
            BallotDescriptionInfo = ballotDescriptionInfo
        };
    }
}
