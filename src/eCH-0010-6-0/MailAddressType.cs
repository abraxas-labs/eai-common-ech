// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer natürlichen Person im In- oder Ausland.
/// </summary>
[Serializable]
[JsonObject("mailAddressType")]
[XmlRoot(ElementName = "mailAddressType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/6")]
public class MailAddressType : FieldValueChecker<MailAddressType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string AddressInfoNullValidateExceptionMessage = "MailAddress is not valid! Either OrganisationMailAddressInfo or PersonMailAddressInfo has to be filled!";

    private AddressInformationType _addressInformation;

    public MailAddressType()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <param name="organisationMailAddressInfo">Has dependency to personMailAddressInfo.</param>
    /// <param name="personMailAddressInfo">Has dependency to organisationMailAddressInfo.</param>
    /// <returns>PersonMailAddress.</returns>
    public static MailAddressType Create(AddressInformationType addressInformation, OrganisationMailAddressInfoType organisationMailAddressInfo, PersonMailAddressInfoType personMailAddressInfo)
    {
        if (organisationMailAddressInfo != null && personMailAddressInfo == null)
        {
            return new MailAddressType
            {
                OrganisationMailAddressInfo = organisationMailAddressInfo,
                PersonMailAddressInfo = null,
                AddressInformation = addressInformation
            };
        }

        if (organisationMailAddressInfo == null && personMailAddressInfo != null)
        {
            return new MailAddressType
            {
                OrganisationMailAddressInfo = null,
                PersonMailAddressInfo = personMailAddressInfo,
                AddressInformation = addressInformation
            };
        }

        throw new FieldValidationException(AddressInfoNullValidateExceptionMessage);
    }

    [JsonProperty("organisation")]
    [XmlElement(ElementName = "organisation", Order = 1)]
    public OrganisationMailAddressInfoType OrganisationMailAddressInfo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OrganisationMailAddressInfoSpecified => OrganisationMailAddressInfo != null;

    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 2)]
    public PersonMailAddressInfoType PersonMailAddressInfo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonMailAddressInfoSpecified => PersonMailAddressInfo != null;

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation", Order = 3)]
    public AddressInformationType AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }
}
