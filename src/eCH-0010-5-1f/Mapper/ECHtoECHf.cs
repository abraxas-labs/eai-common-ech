// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace eCH_0010_5_1f.Mapper;

/// <summary>
/// Mappingclass eCH_0010_5_1f
/// eCh-0010-5-1 to eCh-0010-5-1f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0010/5/index5_1.html.
/// </summary>
public static class ECHtoECHf
{
    public static OrganisationMailAddressInfo GetOrganisationMailAddressInfo(eCH_0010_5_1.OrganisationMailAddressInfo organisationMailAddressInfo)
    {
        OrganisationMailAddressInfo fOrganisationMailAddressInfo = new()
        {
            FirstName = organisationMailAddressInfo.FirstName,
            LastName = organisationMailAddressInfo.LastName,
            MrMrs = organisationMailAddressInfo.MrMrsSpecified ? (MrMrs?)Enum.Parse(typeof(MrMrs), organisationMailAddressInfo.MrMrs.ToString()) : null,
            OrganisationName = organisationMailAddressInfo.OrganisationName,
            OrganisationNameAddOn1 = organisationMailAddressInfo.OrganisationNameAddOn1,
            OrganisationNameAddOn2 = organisationMailAddressInfo.OrganisationNameAddOn2,
            Title = organisationMailAddressInfo.Title
        };

        return fOrganisationMailAddressInfo;
    }

    public static PersonMailAddressInfo GetPersonMailAddressInfo(eCH_0010_5_1.PersonMailAddressInfo personMailAddressInfo)
    {
        PersonMailAddressInfo fOrganisationMailAddressInfo = new()
        {
            FirstName = personMailAddressInfo.FirstName,
            LastName = personMailAddressInfo.LastName,
            MrMrs = personMailAddressInfo.MrMrsSpecified ? (MrMrs?)Enum.Parse(typeof(MrMrs), personMailAddressInfo.MrMrs.ToString()) : null,
            Title = personMailAddressInfo.Title
        };

        return fOrganisationMailAddressInfo;
    }

    public static AddressInformation GetAddressInformation(eCH_0010_5_1.AddressInformation addressInformation)
    {
        eCH_0010_5_1f.AddressInformation fAddressInformation = new()
        {
            AddressLine1 = addressInformation.AddressLine1,
            AddressLine2 = addressInformation.AddressLine2,
            Country = addressInformation.Country,
            DwellingNumber = addressInformation.DwellingNumber,
            ForeignZipCode = addressInformation.ForeignZipCode,
            HouseNumber = addressInformation.HouseNumber,
            Locality = addressInformation.Locality,
            PostOfficeBoxNumber = addressInformation.PostOfficeBoxNumber,
            PostOfficeBoxText = addressInformation.PostOfficeBoxText,
            Street = addressInformation.Street,
            SwissZipCode = addressInformation.SwissZipCode,
            SwissZipCodeAddOn = addressInformation.SwissZipCodeAddOn,
            SwissZipCodeId = addressInformation.SwissZipCodeId,
            Town = addressInformation.Town
        };

        return fAddressInformation;
    }

    public static MailAddress GetMailAddress(eCH_0010_5_1.MailAddress address)
    {
        MailAddress fAddress = new();

        if (address.AddressInformation != null)
        {
            fAddress.AddressInformation = new eCH_0010_5_1f.AddressInformation()
            {
                AddressLine1 = address.AddressInformation.AddressLine1,
                AddressLine2 = address.AddressInformation.AddressLine2,
                Country = address.AddressInformation.Country,
                DwellingNumber = address.AddressInformation.DwellingNumber,
                ForeignZipCode = address.AddressInformation.ForeignZipCode,
                HouseNumber = address.AddressInformation.HouseNumber,
                Street = address.AddressInformation.Street,
                Locality = address.AddressInformation.Locality,
                PostOfficeBoxNumber = address.AddressInformation.PostOfficeBoxNumber,
                PostOfficeBoxText = address.AddressInformation.PostOfficeBoxText,
                SwissZipCode = address.AddressInformation.SwissZipCode,
                SwissZipCodeAddOn = address.AddressInformation.SwissZipCodeAddOn,
                SwissZipCodeId = address.AddressInformation.SwissZipCodeId,
                Town = address.AddressInformation.Town
            };
        }

        if (address.OrganisationMailAddressInfoSpecified)
        {
            fAddress.OrganisationMailAddressInfo = GetOrganisationMailAddressInfo(address.OrganisationMailAddressInfo);
        }

        if (address.PersonMailAddressInfoSpecified)
        {
            fAddress.PersonMailAddressInfo = GetPersonMailAddressInfo(address.PersonMailAddressInfo);
        }

        return fAddress;
    }

    public static OrganisationMailAddress GetOrganisationMailAddress(eCH_0010_5_1.OrganisationMailAddress organisationAddress)
    {
        return new OrganisationMailAddress()
        {
            AddressInformation = (organisationAddress.AddressInformation != null) ? GetAddressInformation(organisationAddress.AddressInformation) : null,
            OrganisationMailAddressInfo = (organisationAddress.OrganisationMailAddressInfo != null) ? GetOrganisationMailAddressInfo(organisationAddress.OrganisationMailAddressInfo) : null
        };
    }

    public static SwissAddressInformation GetSwissAddressInformation(eCH_0010_5_1.SwissAddressInformation address)
    {
        return new SwissAddressInformation()
        {
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            Country = address.Country,
            DwellingNumber = address.DwellingNumber,
            HouseNumber = address.HouseNumber,
            Locality = address.Locality,
            Street = address.Street,
            SwissZipCode = address.SwissZipCode,
            SwissZipCodeAddOn = address.SwissZipCodeAddOn,
            SwissZipCodeId = address.SwissZipCodeId,
            Town = address.Town
        };
    }
}
