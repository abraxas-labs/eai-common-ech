// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer natürlichen Person im In- oder Ausland.
/// </summary>
[Serializable]
[JsonObject("mailAddress")]
[XmlRoot(ElementName = "mailAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/5")]
public class MailAddress : FieldValueChecker<MailAddress>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string AddressInfoNullValidateExceptionMessage = "MailAddress is not valid! One of OrganisationMailAddressInfo, PersonMailAddressInfo is missing!";

    private AddressInformation _addressInformation;

    public MailAddress()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="organisationMailAddressInfo">Has dependency to personMailAddressInfo.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>PersonMailAddress.</returns>
    public static MailAddress Create(OrganisationMailAddressInfo organisationMailAddressInfo, AddressInformation addressInformation)
    {
        if (organisationMailAddressInfo == null)
        {
            throw new FieldValidationException(AddressInfoNullValidateExceptionMessage);
        }
        return new MailAddress()
        {
            OrganisationMailAddressInfo = organisationMailAddressInfo,
            PersonMailAddressInfo = null,
            AddressInformation = addressInformation
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="personMailAddressInfo">Has dependency to organisationMailAddressInfo.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>PersonMailAddress.</returns>
    public static MailAddress Create(PersonMailAddressInfo personMailAddressInfo, AddressInformation addressInformation)
    {
        if (personMailAddressInfo == null)
        {
            throw new FieldValidationException(AddressInfoNullValidateExceptionMessage);
        }
        return new MailAddress()
        {
            OrganisationMailAddressInfo = null,
            PersonMailAddressInfo = personMailAddressInfo,
            AddressInformation = addressInformation
        };
    }

    [JsonProperty("organisation")]
    [XmlElement(ElementName = "organisation", Order = 1)]
    public OrganisationMailAddressInfo OrganisationMailAddressInfo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OrganisationMailAddressInfoSpecified => OrganisationMailAddressInfo != null;

    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 2)]
    public PersonMailAddressInfo PersonMailAddressInfo { get; set; }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation", Order = 3)]
    public AddressInformation AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonMailAddressInfoSpecified => PersonMailAddressInfo != null;
}
