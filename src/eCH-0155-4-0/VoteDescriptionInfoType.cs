// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bezeichnung einer Abstimmung von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("voteDescriptionInfo")]
[XmlRoot(ElementName = "voteDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class VoteDescriptionInfoType : FieldValueChecker<VoteDescriptionInfoType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _language;
    private string _voteDescription;

    public VoteDescriptionInfoType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("language")]
    [XmlElement(ElementName = "language", Order = 1)]
    public string Language
    {
        get => _language;
        set => CheckAndSetValue(ref _language, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("voteDescription")]
    [XmlElement(ElementName = "voteDescription", Order = 2)]
    public string VoteDescription
    {
        get => _voteDescription;
        set => CheckAndSetValue(ref _voteDescription, value);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="voteDescription">Field is required.</param>
    /// <returns>VoteDescriptionInfo.</returns>
    public static VoteDescriptionInfoType Create(string language, string voteDescription)
    {
        return new VoteDescriptionInfoType
        {
            Language = language,
            VoteDescription = voteDescription
        };
    }
}
