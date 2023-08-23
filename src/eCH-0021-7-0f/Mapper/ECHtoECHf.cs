// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;

namespace eCH_0021_7_0f.Mapper;

/// <summary>
/// Mappingclass eCH_0021_7_0f
/// eCh-0021-7-0 to eCh-0021-7-0f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0021/7/index7_0.html.
/// </summary>
public static class ECHtoECHf
{
    public static BirthAddonData GetBirthAddonData(eCH_0021_7_0.BirthAddonData birthAddonData)
    {
        return new BirthAddonData()
        {
            NameOfFather = birthAddonData.NameOfFatherSpecified ? GetNameOfParent(birthAddonData.NameOfFather) : null,
            NameOfMother = birthAddonData.NameOfMotherSpecified ? GetNameOfParent(birthAddonData.NameOfMother) : null
        };
    }

    public static NameOfParent GetNameOfParent(eCH_0021_7_0.NameOfParent nameOfParent)
    {
        return new NameOfParent()
        {
            FirstName = nameOfParent.FirstName,
            FirstNameOnly = nameOfParent.FirstNameOnly,
            OfficialName = nameOfParent.OfficialName,
            OfficialNameOnly = nameOfParent.OfficialNameOnly,
            OfficialProofOfNameOfParentsYesNo = nameOfParent.OfficialProofOfNameOfParentsYesNo
        };
    }

    public static MaritalDataAddon GetMaritalDataAddon(eCH_0021_7_0.MaritalDataAddon maritalDataAddon)
    {
        return new MaritalDataAddon()
        {
            PlaceOfMarriage = (maritalDataAddon != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetGeneralPlace(maritalDataAddon.PlaceOfMarriage) : null
        };
    }

    public static PersonAdditionalData GetPersonAdditionalData(eCH_0021_7_0.PersonAdditionalData data)
    {
        return new PersonAdditionalData()
        {
            LanguageOfCorrespondance = data.LanguageOfCorrespondance,
            MrMrs = data.MrMrsSpecified ? (eCH_0010_5_1f.MrMrs?)Enum.Parse(typeof(eCH_0010_5_1f.MrMrs), data.MrMrs.ToString()) : null
        };
    }

    public static LockData GetLockData(eCH_0021_7_0.LockData lockData)
    {
        return new LockData()
        {
            DataLock = (DataLockType)Enum.Parse(typeof(DataLockType), lockData.DataLock.ToString()),
            DataLockValidFrom = lockData.DataLockValidFrom,
            DataLockValidTill = lockData.DataLockValidTill,
            PaperLock = (eCH_0011_8_1f.YesNo)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), lockData.PaperLock.ToString()),
            PaperLockValidFrom = lockData.PaperLockValidFrom,
            PaperLockValidTill = lockData.PaperLockValidTill
        };
    }

    public static PlaceOfOriginAddonData GetPlaceOfOriginAddonData(eCH_0021_7_0.PlaceOfOriginAddonData placeOfOriginAddonData)
    {
        return new PlaceOfOriginAddonData()
        {
            ExpatriationDate = placeOfOriginAddonData.ExpatriationDate,
            NaturalizationDate = placeOfOriginAddonData.NaturalizationDate
        };
    }

    public static PoliticalRightData GetPoliticalRightData(eCH_0021_7_0.PoliticalRightData data)
    {
        return new PoliticalRightData()
        {
            RestrictedVotingAndElectionRightFederation = data.RestrictedVotingAndElectionRightFederation
        };
    }

    public static MatrimonialInheritanceArrangementData GetMatrimonialInheritanceArrangementData(eCH_0021_7_0.MatrimonialInheritanceArrangementData data)
    {
        return new MatrimonialInheritanceArrangementData()
        {
            MatrimonialInheritanceArrangement = (eCH_0011_8_1f.YesNo)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.MatrimonialInheritanceArrangement.ToString()),
            MatrimonialInheritanceArrangementValidFrom = data.MatrimonialInheritanceArrangementValidFrom
        };
    }

    public static HealthInsuranceData GetHealthInsuranceData(eCH_0021_7_0.HealthInsuranceData data)
    {
        return new HealthInsuranceData()
        {
            Insurance = data.InsuranceSpecified ? GetInsurance(data.Insurance) : null,
            HealthInsured = (eCH_0011_8_1f.YesNo)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.HealthInsured.ToString()),
            HealthInsuranceValidFrom = data.HealthInsuranceValidFrom
        };
    }

    private static Insurance GetInsurance(eCH_0021_7_0.Insurance insurance)
    {
        return new Insurance()
        {
            InsuranceName = insurance.InsuranceName,
            InsuranceAddress = insurance.InsuranceAddressSpecified ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetOrganisationMailAddress(insurance.InsuranceAddress) : null
        };
    }

    public static FireServiceData GetFireServiceData(eCH_0021_7_0.FireServiceData data)
    {
        return new FireServiceData()
        {
            FireService = data.FireServiceSpecified ? (eCH_0011_8_1f.YesNo?)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.FireService.ToString()) : null,
            FireServiceLiability = data.FireServiceLiabilitySpecified ? (eCH_0011_8_1f.YesNo?)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.FireServiceLiability.ToString()) : null,
            FireServiceValidFrom = data.FireServiceValidFrom
        };
    }

    public static CivilDefenseData GetCivilDefenseData(eCH_0021_7_0.CivilDefenseData data)
    {
        return new CivilDefenseData()
        {
            CivilDefense = data.CivilDefenseSpecified ? (eCH_0011_8_1f.YesNo?)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.CivilDefense.ToString()) : null,
            CivilDefenseValidFrom = data.CivilDefenseValidFrom
        };
    }

    public static ArmedForcesData GetArmedForcesData(eCH_0021_7_0.ArmedForcesData data)
    {
        return new ArmedForcesData()
        {
            ArmedForcesLiability = data.ArmedForcesLiabilitySpecified ? (eCH_0011_8_1f.YesNo?)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.ArmedForcesLiability.ToString()) : null,
            ArmedForcesService = data.ArmedForcesServiceSpecified ? (eCH_0011_8_1f.YesNo?)Enum.Parse(typeof(eCH_0011_8_1f.YesNo), data.ArmedForcesService.ToString()) : null,
            ArmedForcesValidFrom = data.ArmedForcesValidFrom
        };
    }

    public static GuardianRelationship GetGuardianRelationship(eCH_0021_7_0.GuardianRelationship data)
    {
        return new GuardianRelationship()
        {
            Care = data.CareSpecified ? (Care?)Enum.Parse(typeof(Care), data.Care.ToString()) : null,
            GuardianMeasureInfo = (data.GuardianMeasureInfo != null) ? GetGuardianMeasureInfo(data.GuardianMeasureInfo) : null,
        };
    }

    public static GuardianMeasureInfo GetGuardianMeasureInfo(eCH_0021_7_0.GuardianMeasureInfo guardianMeasureInfo)
    {
        var fGuardianMeasureInfo = new GuardianMeasureInfo()
        {
            BasedOnLawAddOn = guardianMeasureInfo.BasedOnLawAddOn,
            BasedOnLaws = null,
            GuardianMeasureValidFrom = guardianMeasureInfo.GuardianMeasureValidFrom
        };

        if (guardianMeasureInfo.BasedOnLawsSpecified)
        {
            fGuardianMeasureInfo.BasedOnLaws = new List<BasedOnLaw>();

            foreach (var data in guardianMeasureInfo.BasedOnLaws)
            {
                fGuardianMeasureInfo.BasedOnLaws.Add((BasedOnLaw)Enum.Parse(typeof(BasedOnLaw), data.ToString()));
            }
        }

        return fGuardianMeasureInfo;
    }

    public static ParentalRelationship GetParentalRelationship(eCH_0021_7_0.ParentalRelationship data)
    {
        return new ParentalRelationship()
        {
            Care = (Care)Enum.Parse(typeof(Care), data.Care.ToString()),
            Partner = (data.Partner != null) ? GetPartner(data.Partner) : null,
            RelationshipValidFrom = data.RelationshipValidFrom,
            TypeOfRelationship = (TypeOfRelationship?)Enum.Parse(typeof(TypeOfRelationship), data.TypeOfRelationship.ToString())
        };
    }

    public static MaritalRelationship GetMaritalRelationship(eCH_0021_7_0.MaritalRelationship data)
    {
        return new MaritalRelationship()
        {
            Partner = (data.Partner != null) ? GetPartner(data.Partner) : null,
            TypeOfRelationship = (TypeOfRelationship)Enum.Parse(typeof(TypeOfRelationship), data.TypeOfRelationship.ToString())
        };
    }

    public static Partner GetPartner(eCH_0021_7_0.Partner partner)
    {
        return new Partner()
        {
            Address = partner.AddressSpecified ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetMailAddress(partner.Address) : null,
            PartnerIdOrganisation = partner.PartnerIdOrganisationSpecified ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetPartnerIdOrganisation(partner.PartnerIdOrganisation) : null,
            PersonIdentification = partner.PersonIdentificationSpecified ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(partner.PersonIdentification) : null,
            PersonIdentificationPartner = partner.PersonIdentificationPartnerSpecified ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentificationLight(partner.PersonIdentificationPartner) : null
        };
    }

    public static JobData GetJobData(eCH_0021_7_0.JobData data)
    {
        JobData fJobData = new()
        {
            JobTitle = data.JobTitle,
            KindOfEmployment = data.KindOfEmployment,
        };

        if (data.OccupationDatasSpecified)
        {
            fJobData.OccupationDatas = new List<OccupationData>();

            foreach (var occData in data.OccupationDatas)
            {
                fJobData.OccupationDatas.Add(GetOccupationData(occData));
            }
        }

        return fJobData;
    }

    public static OccupationData GetOccupationData(eCH_0021_7_0.OccupationData occData)
    {
        return new OccupationData()
        {
            Employer = occData.Employer,
            OccupationValidFrom = occData.OccupationValidFrom,
            OccupationValidTill = occData.OccupationValidTill,
            PlaceOfEmployer = occData.PlaceOfEmployerSpecified ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetAddressInformation(occData.PlaceOfEmployer) : null,
            PlaceOfWork = occData.PlaceOfWorkSpecified ? eCH_0010_5_1f.Mapper.ECHtoECHf.GetAddressInformation(occData.PlaceOfWork) : null,
            UID = occData.UIDSpecified ? GetUidStructure(occData.UID) : null
        };
    }

    public static UidStructure GetUidStructure(eCH_0021_7_0.UidStructure uID)
    {
        return new UidStructure()
        {
            UidOrganisationId = uID.UidOrganisationId,
            UidOrganisationIdCategorie = uID.UidOrganisationIdCategorie
        };
    }
}
