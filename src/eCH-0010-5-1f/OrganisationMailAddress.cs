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
/// Postadresse einer Firma, Organisation oder Behörde.
/// </summary>
[Serializable]
[JsonObject("organisationMailAddress")]
[XmlRoot(ElementName = "organisationMailAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010-f/5")]
public class OrganisationMailAddress : FieldValueChecker<OrganisationMailAddress>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private OrganisationMailAddressInfo _organisationMailAddressInfo;
    private AddressInformation _addressInformation;

    public OrganisationMailAddress()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010-f/5");
    }

    /// <summary>
    /// /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="organisationMailAddressInfo">Field is reqired.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>OrganisationMailAddress.</returns>
    public static OrganisationMailAddress Create(eCH_0010_5_1.OrganisationMailAddressInfo organisationMailAddressInfo,
        eCH_0010_5_1.AddressInformation addressInformation)
    {
        return new OrganisationMailAddress()
        {
            OrganisationMailAddressInfo = eCH_0010_5_1f.Mapper.ECHtoECHf.GetOrganisationMailAddressInfo(organisationMailAddressInfo),
            AddressInformation = Mapper.ECHtoECHf.GetAddressInformation(addressInformation)
        };
    }

    [FieldRequired]
    [JsonProperty("organisation")]
    [XmlElement(ElementName = "organisation")]
    public OrganisationMailAddressInfo OrganisationMailAddressInfo
    {
        get => _organisationMailAddressInfo;
        set => CheckAndSetValue(ref _organisationMailAddressInfo, value);
    }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation")]
    public AddressInformation AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }
}
