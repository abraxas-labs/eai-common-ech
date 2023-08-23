// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
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
[JsonObject("voteDescriptionInformation")]
[XmlRoot(ElementName = "voteDescriptionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class VoteDescriptionInformationType : FieldValueChecker<VoteDescriptionInformationType>
{
    private const string VoteDescriptionNullValidateExceptionMessage = "VoteDescriptionInfo is not valid! VoteDescriptionInfo is required";
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private List<VoteDescriptionInfoType> _voteDescriptionInfo;

    public VoteDescriptionInformationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [JsonProperty("voteDescriptionInfo")]
    [XmlElement(ElementName = "voteDescriptionInfo", Order = 1)]
    public List<VoteDescriptionInfoType> VoteDescriptionInfo
    {
        get => _voteDescriptionInfo;
        set
        {
            _voteDescriptionInfo = value ?? throw new XmlSchemaValidationException(VoteDescriptionNullValidateExceptionMessage);
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="voteDescriptionInfo">Field is required.</param>
    /// <returns>VoteDescriptionInformation.</returns>
    public static VoteDescriptionInformationType Create(List<VoteDescriptionInfoType> voteDescriptionInfo)
    {
        return new VoteDescriptionInformationType
        {
            VoteDescriptionInfo = voteDescriptionInfo
        };
    }
}
