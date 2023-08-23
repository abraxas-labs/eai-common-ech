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
/// Postadresse einer Firma, Organisation oder Behörde.
/// </summary>
[Serializable]
[JsonObject("organisationMailAddress")]
[XmlRoot(ElementName = "organisationMailAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/6")]
public class OrganisationMailAddressType : FieldValueChecker<OrganisationMailAddressType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private OrganisationMailAddressInfoType _organisationMailAddressInfo;
    private AddressInformationType _addressInformation;

    public OrganisationMailAddressType()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/6");
    }

    /// <summary>
    /// /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="organisationMailAddressInfo">Field is reqired.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>OrganisationMailAddress.</returns>
    public static OrganisationMailAddressType Create(OrganisationMailAddressInfoType organisationMailAddressInfo,
        AddressInformationType addressInformation)
    {
        return new OrganisationMailAddressType
        {
            OrganisationMailAddressInfo = organisationMailAddressInfo,
            AddressInformation = addressInformation
        };
    }

    [FieldRequired]
    [JsonProperty("organisation")]
    [XmlElement(ElementName = "organisation", Order = 1)]
    public OrganisationMailAddressInfoType OrganisationMailAddressInfo
    {
        get => _organisationMailAddressInfo;
        set => CheckAndSetValue(ref _organisationMailAddressInfo, value);
    }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation", Order = 2)]
    public AddressInformationType AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }
}
