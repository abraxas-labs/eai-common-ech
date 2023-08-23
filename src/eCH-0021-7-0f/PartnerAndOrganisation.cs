// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0010_5_1f;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Beziehungsangaben.
/// </summary>
[Serializable]
[JsonObject("partnerAndOrganisation")]
[XmlRoot(ElementName = "partnerAndOrganisation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class PartnerAndOrganisation : Partner
{
    public PartnerAndOrganisation()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partnerIdOrganisation">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static PartnerAndOrganisation Create(PartnerIdOrganisation partnerIdOrganisation, MailAddress address = null)
    {
        return new PartnerAndOrganisation()
        {
            PartnerIdOrganisation = partnerIdOrganisation,
            PersonIdentification = null,
            PersonIdentificationPartner = null,
            Address = address
        };
    }

    [JsonProperty("partnerIdOrganisation")]
    [XmlElement(ElementName = "partnerIdOrganisation")]
    public PartnerIdOrganisation PartnerIdOrganisation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnerIdOrganisationSpecified => PartnerIdOrganisation != null;
}
