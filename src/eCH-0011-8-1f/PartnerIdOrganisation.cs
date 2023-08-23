// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Ids der Partnerorganisationen.
/// </summary>
[Serializable]
[JsonObject("partnerIdOrganisation")]
[XmlRoot(ElementName = "partnerIdOrganisation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class PartnerIdOrganisation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private eCH_0044_4_1f.NamedPersonId _localPersonId;

    public PartnerIdOrganisation()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="localPersonId">Field is required.</param>
    /// <param name="otherPersonId">Field is optional.</param>
    /// <returns>DeathData.</returns>
    public static PartnerIdOrganisation Create(eCH_0044_4_1.NamedPersonId localPersonId, List<eCH_0044_4_1.NamedPersonId> otherPersonId = null)
    {
        List<eCH_0044_4_1f.NamedPersonId> fOtherPersonId = new();

        foreach (var persId in otherPersonId.Where(p => p != null))
        {
            fOtherPersonId.Add(eCH_0044_4_1f.NamedPersonId.Create(persId.PersonIdCategory, persId.PersonId));
        }

        return new PartnerIdOrganisation()
        {
            LocalPersonId = eCH_0044_4_1f.NamedPersonId.Create(localPersonId.PersonIdCategory, localPersonId.PersonId),
            OtherPersonId = fOtherPersonId
        };
    }

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public eCH_0044_4_1f.NamedPersonId LocalPersonId
    {
        get { return _localPersonId; }
        set { _localPersonId = value; }
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<eCH_0044_4_1f.NamedPersonId> OtherPersonId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdSpecified => OtherPersonId != null && OtherPersonId.Any();
}
