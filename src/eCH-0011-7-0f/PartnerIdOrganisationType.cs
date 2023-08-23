// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0044_3_0f;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("contact")]
[XmlRoot(ElementName = "contact", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class PartnerIdOrganisationType : FieldValueChecker<PartnerIdOrganisationType>
{
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    private NamedPersonId _localPersonId;
    private List<NamedPersonId> _otherPersonId;

    public PartnerIdOrganisationType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="localPersonId">Field is required.</param>
    /// <param name="otherPersonId">Field is optional.</param>
    /// <returns>PartnerIdOrganisationType.</returns>
    public static PartnerIdOrganisationType Create(NamedPersonId localPersonId, List<NamedPersonId> otherPersonId)
    {
        return new PartnerIdOrganisationType
        {
            LocalPersonId = localPersonId,
            OtherPersonId = otherPersonId
        };
    }

    [FieldRequired]
    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set => CheckAndSetValue(ref _localPersonId, value);
    }

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public List<NamedPersonId> OtherPersonId
    {
        get => _otherPersonId;
        set => CheckAndSetValue(ref _otherPersonId, value);
    }
}
