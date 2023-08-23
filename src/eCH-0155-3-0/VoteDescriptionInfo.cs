// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
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
[JsonObject("voteDescriptionInfo")]
[XmlRoot(ElementName = "voteDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class VoteDescriptionInfo
{
    private const string VoteDescriptionNullValidateExceptionMessage =
        "VoteDescription is not valid! VoteDescription is required";

    private const string VoteDescriptionOutOfRangeValidateExceptionMessage =
        "VoteDescription is not valid! VoteDescription has minimal leght of 1 and maximal length of 100";

    private string _voteDescription;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VoteDescriptionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("voteDescription")]
    [XmlElement(ElementName = "voteDescription")]
    public string VoteDescription
    {
        get => _voteDescription;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(VoteDescriptionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(VoteDescriptionOutOfRangeValidateExceptionMessage);
            }

            _voteDescription = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="voteDescription">Field is required.</param>
    /// <returns>VoteDescriptionInfo.</returns>
    public static VoteDescriptionInfo Create(Language language, string voteDescription)
    {
        return new VoteDescriptionInfo
        {
            Language = language,
            VoteDescription = voteDescription
        };
    }
}
