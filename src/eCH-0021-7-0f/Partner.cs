// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Beziehungsangaben.
/// </summary>
[Serializable]
[JsonObject("partner")]
[XmlRoot(ElementName = "partner", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class Partner
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public Partner()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static Partner Create(eCH_0044_4_1.PersonIdentification personIdentification, eCH_0010_5_1.MailAddress address = null)
    {
        return new Partner()
        {
            PersonIdentification = eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(personIdentification),
            PersonIdentificationPartner = null,
            Address = (address != null) ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetMailAddress(address) : null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentificationPartner">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static Partner Create(eCH_0044_4_1.PersonIdentificationLight personIdentificationPartner, eCH_0010_5_1.MailAddress address = null)
    {
        return new Partner()
        {
            PersonIdentification = null,
            PersonIdentificationPartner = eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentificationLight(personIdentificationPartner),
            Address = (address != null) ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetMailAddress(address) : null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partnerIdOrganisation">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static Partner Create(eCH_0011_8_1.PartnerIdOrganisation partnerIdOrganisation, eCH_0010_5_1.MailAddress address = null)
    {
        return new Partner()
        {
            PersonIdentification = null,
            PersonIdentificationPartner = null,
            PartnerIdOrganisation = eCH_0011_8_1f.PartnerIdOrganisation.Create(partnerIdOrganisation.LocalPersonId, partnerIdOrganisation.OtherPersonId),
            Address = (address != null) ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetMailAddress(address) : null
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public eCH_0044_4_1f.PersonIdentification PersonIdentification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonIdentificationSpecified => PersonIdentification != null;

    [JsonProperty("personIdentificationPartner")]
    [XmlElement(ElementName = "personIdentificationPartner")]
    public eCH_0044_4_1f.PersonIdentificationLight PersonIdentificationPartner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonIdentificationPartnerSpecified => PersonIdentificationPartner != null;

    [JsonProperty("partnerIdOrganisation")]
    [XmlElement(ElementName = "partnerIdOrganisation")]
    public eCH_0011_8_1f.PartnerIdOrganisation PartnerIdOrganisation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnerIdOrganisationSpecified => PartnerIdOrganisation != null;

    [JsonProperty("address")]
    [XmlElement(ElementName = "address")]
    public eCH_0010_5_1f.MailAddress Address { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AddressSpecified => Address != null;
}
