// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_1;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Beziehungsangaben.
/// </summary>
[Serializable]
[JsonObject("partner")]
[XmlRoot(ElementName = "partner", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class Partner
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification is not valid! PersonIdentification is Required";
    private const string PersonIdentificationPartnerNullValidateExceptionMessage = "PersonIdentificationPartner is not valid! PersonIdentificationPartner is Required";

    public Partner()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static Partner Create(PersonIdentification personIdentification, MailAddress address = null)
    {
        if (personIdentification == null)
        {
            throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
        }
        return new Partner()
        {
            PersonIdentification = personIdentification,
            PersonIdentificationPartner = null,
            Address = address
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentificationPartner">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static Partner Create(PersonIdentificationLight personIdentificationPartner, MailAddress address = null)
    {
        if (personIdentificationPartner == null)
        {
            throw new XmlSchemaValidationException(PersonIdentificationPartnerNullValidateExceptionMessage);
        }
        return new Partner()
        {
            PersonIdentification = null,
            PersonIdentificationPartner = personIdentificationPartner,
            Address = address
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partnerIdOrganisation">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static Partner Create(PartnerIdOrganisation partnerIdOrganisation, MailAddress address = null)
    {
        if (partnerIdOrganisation == null)
        {
            throw new XmlSchemaValidationException(PersonIdentificationPartnerNullValidateExceptionMessage);
        }
        return new Partner()
        {
            PersonIdentification = null,
            PersonIdentificationPartner = null,
            PartnerIdOrganisation = partnerIdOrganisation,
            Address = address
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification", Order = 1)]
    public PersonIdentification PersonIdentification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonIdentificationSpecified => PersonIdentification != null;

    [JsonProperty("personIdentificationPartner")]
    [XmlElement(ElementName = "personIdentificationPartner", Order = 2)]
    public PersonIdentificationLight PersonIdentificationPartner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonIdentificationPartnerSpecified => PersonIdentificationPartner != null;

    [JsonProperty("partnerIdOrganisation")]
    [XmlElement(ElementName = "partnerIdOrganisation", Order = 3)]
    public PartnerIdOrganisation PartnerIdOrganisation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnerIdOrganisationSpecified => PartnerIdOrganisation != null;

    [JsonProperty("address")]
    [XmlElement(ElementName = "address", Order = 4)]
    public MailAddress Address { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AddressSpecified => Address != null;
}
