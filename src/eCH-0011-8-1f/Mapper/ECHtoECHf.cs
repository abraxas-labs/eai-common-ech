// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;

namespace eCH_0011_8_1f.Mapper;

/// <summary>
/// Mappingclass eCH_0011_8_1f
/// eCh-0011-8-1 to eCh-0011-8-1f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0011/8/index8_1.html.
/// </summary>
public static class ECHtoECHf
{
    public static PartnerIdOrganisation GetPartnerIdOrganisation(eCH_0011_8_1.PartnerIdOrganisation partnerIdOrganisation)
    {
        PartnerIdOrganisation fPartnerIdOrganisation = new();

        if (partnerIdOrganisation.OtherPersonId != null && partnerIdOrganisation.OtherPersonId.Any())
        {
            List<eCH_0044_4_1f.NamedPersonId> fOtherPersonId = new();

            foreach (var persId in partnerIdOrganisation.OtherPersonId)
            {
                fOtherPersonId.Add(eCH_0044_4_1f.NamedPersonId.Create(persId.PersonIdCategory, persId.PersonId));
            }
            fPartnerIdOrganisation.OtherPersonId = fOtherPersonId;
        }

        fPartnerIdOrganisation.LocalPersonId = eCH_0044_4_1f.NamedPersonId.Create(partnerIdOrganisation.LocalPersonId.PersonIdCategory, partnerIdOrganisation.LocalPersonId.PersonId);

        return fPartnerIdOrganisation;
    }

    public static NameData GetNameData(eCH_0011_8_1.NameData nameData)
    {
        return new NameData()
        {
            FirstName = nameData.FirstName,
            OfficialName = nameData.OfficialName,
            OriginalName = nameData.OriginalName,
            AllianceName = nameData.AllianceName,
            AliasName = nameData.AliasName,
            OtherName = nameData.OtherName,
            CallName = nameData.CallName,
            DeclaredForeignName = nameData.DeclaredForeignNameSpecified ? ForeignerName.Create(nameData.DeclaredForeignName.Name, nameData.DeclaredForeignName.FirstName) : null,
            NameOnForeignPassport = nameData.NameOnForeignPassportSpecified ? ForeignerName.Create(nameData.NameOnForeignPassport.Name, nameData.NameOnForeignPassport.FirstName) : null
        };
    }

    public static ResidencePermitData GetResidencePermitData(eCH_0011_8_1.ResidencePermitData residencePermitData)
    {
        return new ResidencePermitData()
        {
            EntryDate = residencePermitData.EntryDate,
            ResidencePermit = residencePermitData.ResidencePermit,
            ResidencePermitValidFrom = residencePermitData.ResidencePermitValidFrom,
            ResidencePermitValidTill = residencePermitData.ResidencePermitValidTill
        };
    }

    public static NationalityData GetNationalityData(eCH_0011_8_1.NationalityData nationalityData)
    {
        List<CountryInfo> fCountryInfos = null;

        if (nationalityData.CountryInfosSpecified && nationalityData.CountryInfos.First() != null)
        {
            fCountryInfos = new List<CountryInfo>();

            foreach (var info in nationalityData.CountryInfos)
            {
                fCountryInfos.Add(GetCountryInfo(info));
            }
        }

        return new NationalityData()
        {
            CountryInfos = fCountryInfos,
            NationalityStatus = (NationalityStatus)Enum.Parse(typeof(NationalityStatus), nationalityData.NationalityStatus.ToString())
        };
    }

    public static ContactData GetContactData(eCH_0011_8_1.ContactData data)
    {
        return new ContactData()
        {
            ContactAddress = (data.ContactAddress != null) ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetMailAddress(data.ContactAddress) : null,
            ContactValidFrom = data.ContactValidFrom,
            ContactValidTill = data.ContactValidTill,
            PartnerIdOrganisation = data.PartnerIdOrganisationSpecified ? GetPartnerIdOrganisation(data.PartnerIdOrganisation) : null,
            PersonIdentification = data.PersonIdentificationSpecified ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(data.PersonIdentification) : null,
            PersonIdentificationPartner = data.PersonIdentificationPartnerSpecified ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentificationLight(data.PersonIdentificationPartner) : null
        };
    }

    public static PlaceOfOrigin GetPlaceOfOrigin(eCH_0011_8_1.PlaceOfOrigin placeOfOrigin)
    {
        return new PlaceOfOrigin()
        {
            CantonAbbreviation = (eCH_0007_5_0f.CantonAbbreviation?)Enum.Parse(typeof(eCH_0007_5_0f.CantonAbbreviation), placeOfOrigin.CantonAbbreviation.ToString()),
            HistoryMunicipalityId = placeOfOrigin.HistoryMunicipalityId,
            OriginName = placeOfOrigin.OriginName,
            PlaceOfOriginId = placeOfOrigin.PlaceOfOriginId
        };
    }

    private static CountryInfo GetCountryInfo(eCH_0011_8_1.CountryInfo info)
    {
        return new CountryInfo()
        {
            Country = (info.Country != null) ? eCH_0008_3_0f.Mapper.ECHtoECHf.GetCountry(info.Country) : null,
            NationalityValidFrom = info.NationalityValidFrom
        };
    }

    public static BirthData GetBirthData(eCH_0011_8_1.BirthData birthData)
    {
        return new BirthData()
        {
            DateOfBirth = (birthData.DateOfBirth != null) ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetDatePartiallyKnown(birthData.DateOfBirth) : null,
            PlaceOfBirth = (birthData.PlaceOfBirth != null) ? GetGeneralPlace(birthData.PlaceOfBirth) : null
        };
    }

    public static GeneralPlace GetGeneralPlace(eCH_0011_8_1.GeneralPlace generalPlace)
    {
        var fGeneralPlace = new GeneralPlace();

        if (generalPlace.ForeignCountrySpecified)
        {
            fGeneralPlace.ForeignCountry = ForeignCountry.Create(generalPlace.ForeignCountry.Country, generalPlace.ForeignCountry.Town);
        }

        if (generalPlace.SwissTownSpecified)
        {
            fGeneralPlace.SwissTown = eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(generalPlace.SwissTown);
        }

        if (generalPlace.UnknownSpecified)
        {
            fGeneralPlace.Unknown = generalPlace.Unknown;
        }

        return fGeneralPlace;
    }

    public static DwellingAddress GetDwellingAddress(eCH_0011_8_1.DwellingAddress dwellingAddress)
    {
        return new DwellingAddress()
        {
            Address = eCH_0010_5_1f.Mapper.ECHtoECHf.GetSwissAddressInformation(dwellingAddress.Address),
            EGID = dwellingAddress.EGID,
            EWID = dwellingAddress.EWID,
            HouseholdID = dwellingAddress.HouseholdID,
            MovingDate = dwellingAddress.MovingDate,
            TypeOfHousehold = (TypeOfHousehold)Enum.Parse(typeof(TypeOfHousehold), dwellingAddress.TypeOfHousehold.ToString())
        };
    }

    public static Destination GetDestination(eCH_0011_8_1.Destination comesFrom)
    {
        return new Destination()
        {
            ForeignCountry = comesFrom.ForeignCountrySpecified ? ForeignCountry.Create(comesFrom.ForeignCountry.Country, comesFrom.ForeignCountry.Town) : null,
            MailAddress = comesFrom.MailAddressSpecified ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetAddressInformation(comesFrom.MailAddress) : null,
            SwissTown = comesFrom.SwissTownSpecified ? eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(comesFrom.SwissTown) : null,
            Unknown = comesFrom.Unknown
        };
    }

    public static ReligionData GetReligionData(eCH_0011_8_1.ReligionData religionData)
    {
        return new ReligionData()
        {
            Religion = religionData.Religion,
            ReligionValidFrom = religionData.ReligionValidFrom
        };
    }

    public static MaritalData GetMaritalData(eCH_0011_8_1.MaritalData maritalData)
    {
        return new MaritalData()
        {
            CancelationReason = maritalData.CancelationReasonSpecified ? (PartnerShipAbolition?)Enum.Parse(typeof(PartnerShipAbolition), maritalData.CancelationReason.ToString()) : null,
            DateOfMaritalStatus = maritalData.DateOfMaritalStatus,
            MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), maritalData.MaritalStatus.ToString()),
            OfficialProofOfMaritalStatusYesNo = maritalData.OfficialProofOfMaritalStatusYesNo,
            SeparationData = maritalData.SeparationDataSpecified ? GetSeparationData(maritalData.SeparationData) : null
        };
    }

    public static SeparationData GetSeparationData(eCH_0011_8_1.SeparationData separationData)
    {
        return new SeparationData()
        {
            Separation = separationData.SeparationSpecified ? (Separation?)Enum.Parse(typeof(Separation), separationData.Separation.ToString()) : null,
            SeparationValidFrom = separationData.SeparationValidFrom,
            SeparationValidTill = separationData.SeparationValidTill
        };
    }
}
