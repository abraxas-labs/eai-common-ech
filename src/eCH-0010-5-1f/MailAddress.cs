// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer natürlichen Person im In- oder Ausland.
/// </summary>
[Serializable]
[JsonObject("mailAddress")]
[XmlRoot(ElementName = "mailAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010-f/5")]
public class MailAddress : FieldValueChecker<MailAddress>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AddressInformation _addressInformation;

    public MailAddress()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010-f/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="organisationMailAddressInfo">Has dependency to personMailAddressInfo.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>PersonMailAddress.</returns>
    public static MailAddress Create(eCH_0010_5_1.OrganisationMailAddressInfo organisationMailAddressInfo, eCH_0010_5_1.AddressInformation addressInformation)
    {
        return new MailAddress()
        {
            OrganisationMailAddressInfo = Mapper.ECHtoECHf.GetOrganisationMailAddressInfo(organisationMailAddressInfo),
            PersonMailAddressInfo = null,
            AddressInformation = AddressInformation.Create(addressInformation.Town, addressInformation.Country)
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
    public static MailAddress Create(eCH_0010_5_1.PersonMailAddressInfo personMailAddressInfo, eCH_0010_5_1.AddressInformation addressInformation)
    {
        return new MailAddress()
        {
            OrganisationMailAddressInfo = null,
            PersonMailAddressInfo = Mapper.ECHtoECHf.GetPersonMailAddressInfo(personMailAddressInfo),
            AddressInformation = AddressInformation.Create(addressInformation.Town, addressInformation.Country)
        };
    }

    [JsonProperty("organisation")]
    [XmlElement(ElementName = "organisation")]
    public OrganisationMailAddressInfo OrganisationMailAddressInfo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OrganisationMailAddressInfoSpecified => OrganisationMailAddressInfo != null;

    [JsonProperty("person")]
    [XmlElement(ElementName = "person")]
    public PersonMailAddressInfo PersonMailAddressInfo { get; set; }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation")]
    public AddressInformation AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonMailAddressInfoSpecified => PersonMailAddressInfo != null;
}
