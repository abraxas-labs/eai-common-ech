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
///     Bezeichnung einer Abstimmung von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("voteDescriptionInformation")]
[XmlRoot(ElementName = "voteDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class VoteDescriptionInformation
{
    private const string VoteDescriptionNullValidateExceptionMessage =
        "VoteDescriptionInfo is not valid! VoteDescriptionInfo is required";

    private const string VoteDescriptionInfoOutOfRangeValidateExceptionMessage =
        "VoteDescriptionInfo is not valid! VoteDescriptionInfo needs at least one item";

    private List<VoteDescriptionInfo> _voteDescriptionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VoteDescriptionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("voteDescriptionInfo")]
    [XmlElement(ElementName = "voteDescriptionInfo")]
    public List<VoteDescriptionInfo> VoteDescriptionInfo
    {
        get => _voteDescriptionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(VoteDescriptionNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(VoteDescriptionInfoOutOfRangeValidateExceptionMessage);
            }

            _voteDescriptionInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="voteDescriptionInfo">Field is required.</param>
    /// <returns>VoteDescriptionInformation.</returns>
    public static VoteDescriptionInformation Create(List<VoteDescriptionInfo> voteDescriptionInfo)
    {
        return new VoteDescriptionInformation
        {
            VoteDescriptionInfo = voteDescriptionInfo
        };
    }
}
