// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace eCH_0020_3_0f.Mapper;

/// <summary>
/// Mappingclass eCH_0020_3_0f
/// eCh-0020-3-0 to eCh-0020-3-0f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0020/3/index3_0.html.
/// </summary>
public static class ECHtoECHf
{
#pragma warning disable SA1311 // Static readonly fields should begin with upper-case letter
    private static readonly MethodInfo[] mappingMethodsECH0021 = typeof(eCH_0021_7_0f.Mapper.ECHtoECHf).GetMethods();
#pragma warning restore SA1311 // Static readonly fields should begin with upper-case letter

    public static BaseDeliveryRestrictedMoveInPersonType GetBaseDeliveryRestrictedMoveInPersonType(eCH_0020_3_0.BaseDeliveryRestrictedMoveInPersonType moveInPerson)
    {
        var fMoveInPerson = new BaseDeliveryRestrictedMoveInPersonType();

        fMoveInPerson.PersonIdentification = (moveInPerson.PersonIdentification != null) ? eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(moveInPerson.PersonIdentification) : null;
        fMoveInPerson.NameInfo = (moveInPerson.NameInfo != null) ? NameInfo.Create(moveInPerson.NameInfo.NameData, moveInPerson.NameInfo.NameValidFrom) : null;
        fMoveInPerson.BirthInfo = (moveInPerson.BirthInfo != null) ? GetBirthInfo(moveInPerson.BirthInfo) : null;
        fMoveInPerson.ContactDatas = null;
        fMoveInPerson.ReligionData = (moveInPerson.ReligionData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetReligionData(moveInPerson.ReligionData) : null;
        fMoveInPerson.MaritalInfo = (moveInPerson.MaritalInfo != null) ? GetMaritalInfo(moveInPerson.MaritalInfo) : null;
        fMoveInPerson.NationalityData = (moveInPerson.NationalityData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetNationalityData(moveInPerson.NationalityData) : null;
        fMoveInPerson.PersonAdditionalDatas = moveInPerson.PersonAdditionalDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.PersonAdditionalData>(moveInPerson.PersonAdditionalDatas.Cast<object>().ToList()) : null;
        fMoveInPerson.PlaceOfOriginInfos = null;
        fMoveInPerson.ResidencePermitData = (moveInPerson.ResidencePermitData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetResidencePermitData(moveInPerson.ResidencePermitData) : null;
        fMoveInPerson.LockData = (moveInPerson.LockData != null) ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetLockData(moveInPerson.LockData) : null;
        fMoveInPerson.MaritalRelationships = moveInPerson.MaritalRelationshipsSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.MaritalRelationship>(moveInPerson.MaritalRelationships.Cast<object>().ToList()) : null;
        fMoveInPerson.ParentalRelationships = moveInPerson.ParentalRelationshipsSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.ParentalRelationship>(moveInPerson.ParentalRelationships.Cast<object>().ToList()) : null;
        fMoveInPerson.GuardianRelationships = moveInPerson.GuardianRelationshipsSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.GuardianRelationship>(moveInPerson.GuardianRelationships.Cast<object>().ToList()) : null;
        fMoveInPerson.ArmedForcesDatas = moveInPerson.ArmedForcesDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.ArmedForcesData>(moveInPerson.ArmedForcesDatas.Cast<object>().ToList()) : null;
        fMoveInPerson.CivilDefenseDatas = moveInPerson.CivilDefenseDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.CivilDefenseData>(moveInPerson.CivilDefenseDatas.Cast<object>().ToList()) : null;
        fMoveInPerson.FireServiceDatas = moveInPerson.FireServiceDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.FireServiceData>(moveInPerson.FireServiceDatas.Cast<object>().ToList()) : null;
        fMoveInPerson.HealthInsuranceDatas = moveInPerson.HealthInsuranceDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.HealthInsuranceData>(moveInPerson.HealthInsuranceDatas.Cast<object>().ToList()) : null;
        fMoveInPerson.MatrimonialInheritanceArrangementDatas = moveInPerson.MatrimonialInheritanceArrangementDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.MatrimonialInheritanceArrangementData>(moveInPerson.MatrimonialInheritanceArrangementDatas.Cast<object>().ToList()) : null;
        fMoveInPerson.PoliticalRightDatas = moveInPerson.PoliticalRightDatasSpecified ? ConvertIntoForgivableList<eCH_0021_7_0f.PoliticalRightData>(moveInPerson.PoliticalRightDatas.Cast<object>().ToList()) : null;

        if (moveInPerson.ContactDatasSpecified && moveInPerson.ContactDatas.First() != null)
        {
            fMoveInPerson.ContactDatas = new List<eCH_0011_8_1f.ContactData>();
            foreach (var data in moveInPerson.ContactDatas)
            {
                fMoveInPerson.ContactDatas.Add(eCH_0011_8_1f.Mapper.ECHtoECHf.GetContactData(data));
            }
        }

        if (moveInPerson.PlaceOfOriginInfosSpecified && moveInPerson.PlaceOfOriginInfos.First() != null)
        {
            fMoveInPerson.PlaceOfOriginInfos = new List<PlaceOfOriginInfo>();
            foreach (var data in moveInPerson.PlaceOfOriginInfos.Where(d => d != null))
            {
                fMoveInPerson.PlaceOfOriginInfos.Add(GetPlaceOfOriginInfo(data));
            }
        }

        return fMoveInPerson;
    }

    public static Header GetHeader(eCH_0020_3_0.Header deliveryHeader)
    {
        return new Header()
        {
            Action = deliveryHeader.Action,
            Attachments = deliveryHeader.AttachmentsSpecified ? deliveryHeader.Attachments : null,
            BusinessCaseClosed = deliveryHeader.BusinessCaseClosed,
            BusinessProcessId = deliveryHeader.BusinessProcessId,
            Comment = deliveryHeader.Comment,
            DataLock = deliveryHeader.DataLockSpecified ? (eCH_0021_7_0f.DataLockType?)Enum.Parse(typeof(eCH_0021_7_0f.DataLockType), deliveryHeader.DataLock.ToString()) : null,
            DataLockValidFrom = deliveryHeader.DataLockValidFrom,
            DataLockValidTo = deliveryHeader.DataLockValidTo,
            DeclarationLocalReference = deliveryHeader.DeclarationLocalReference,
            EventDate = deliveryHeader.EventDate,
            Extension = deliveryHeader.Extension,
            InitialMessageDate = deliveryHeader.InitialMessageDate,
            MessageDate = deliveryHeader.MessageDate,
            MessageId = deliveryHeader.MessageId,
            MessageType = deliveryHeader.MessageType,
            ModificationDate = deliveryHeader.ModificationDate,
            NamedMetaDatas = deliveryHeader.NamedMetaDatas,
            OriginalSenderId = deliveryHeader.OriginalSenderId,
            OurBusinessReferenceId = deliveryHeader.OurBusinessReferenceId,
            PartialDelivery = deliveryHeader.PartialDelivery,
            RecipientIds = deliveryHeader.RecipientIds,
            ReferenceMessageId = deliveryHeader.ReferenceMessageId,
            ResponseExpected = deliveryHeader.ResponseExpected,
            SenderId = deliveryHeader.SenderId,
            SendingApplication = deliveryHeader.SendingApplication,
            Subject = deliveryHeader.Subject,
            SubMessageType = deliveryHeader.SubMessageType,
            TestDeliveryFlag = deliveryHeader.TestDeliveryFlag,
            UniqueIdBusinessTransaction = deliveryHeader.UniqueIdBusinessTransaction,
            YourBusinessReferenceId = deliveryHeader.YourBusinessReferenceId
        };
    }

    public static ReportingMunicipalityRestrictedMoveOut GetReportingMunicipalityRestrictedMoveOut(eCH_0020_3_0.ReportingMunicipalityRestrictedMoveOut moveOutReportingDestination)
    {
        return new ReportingMunicipalityRestrictedMoveOut()
        {
            DepartureDate = moveOutReportingDestination.DepartureDate,
            FederalRegister = (moveOutReportingDestination.FederalRegister != null) ? (FederalRegisterType?)Enum.Parse(typeof(FederalRegisterType), moveOutReportingDestination.FederalRegister.ToString()) : null,
            GoesTo = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(moveOutReportingDestination.GoesTo),
            ReportingMunicipality = moveOutReportingDestination.ReportingMunicipalitySpecified ? eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(moveOutReportingDestination.ReportingMunicipality) : null
        };
    }

    public static List<T> ConvertIntoForgivableList<T>(List<object> orgData)
    {
        if (orgData == null)
        {
            throw new ArgumentNullException($"Argument for '{MethodBase.GetCurrentMethod().Name}'-Method is null!");
        }

        if (!orgData.Any() || orgData.First() == null)
        {
            return null;
        }

        List<T> fDatas = new();
        var methodName = $"Get{orgData.First().GetType().Name}";
        var method = mappingMethodsECH0021.FirstOrDefault(m => m.Name == methodName);

        if (method == null)
        {
            throw new NullReferenceException($"No Method called '{methodName}' found in the 'eCH_0021_7_0f.Mapper.ECHtoECHf' class!");
        }

        try
        {
            foreach (var data in orgData)
            {
                fDatas.Add((T)method.Invoke(null, new object[] { data }));
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Error in generic Method '{MethodBase.GetCurrentMethod().Name}' while open Method '{methodName}' in the 'eCH_0021_7_0f.Mapper.ECHtoECHf' class!", e);
        }
        return fDatas;
    }

    public static PlaceOfOriginInfo GetPlaceOfOriginInfo(eCH_0020_3_0.PlaceOfOriginInfo data)
    {
        return new PlaceOfOriginInfo()
        {
            PlaceOfOrigin = (data.PlaceOfOrigin != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetPlaceOfOrigin(data.PlaceOfOrigin) : null,
            PlaceOfOriginAddonData = (data.PlaceOfOriginAddonData != null) ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetPlaceOfOriginAddonData(data.PlaceOfOriginAddonData) : null
        };
    }

    internal static EventMoveIn GetEventMoveIn(eCH_0020_3_0.EventMoveIn moveIn)
    {
        return new EventMoveIn()
        {
            Extension = moveIn.Extension,
            HasMainResidence = moveIn.HasMainResidenceSpecified ? GetHasMainResidenceMoveIn(moveIn.HasMainResidence) : null,
            HasOtherResidence = moveIn.HasOtherResidenceSpecified ? GetReportingMunicipalityRestrictedMoveIn(moveIn.HasOtherResidence) : null,
            HasSecondaryResidence = moveIn.HasSecondaryResidenceSpecified ? GetHasSecondaryResidenceMoveIn(moveIn.HasSecondaryResidence) : null,
            MoveInPerson = GetBaseDeliveryRestrictedMoveInPersonType(moveIn.MoveInPerson)
        };
    }

    internal static EventMoveOut GetEventMoveOut(eCH_0020_3_0.EventMoveOut moveOut)
    {
        return new EventMoveOut()
        {
            Extension = moveOut.Extension,
            MoveOutPerson = eCH_0044_4_1f.Mapper.ECHtoECHf.GetPersonIdentification(moveOut.MoveOutPerson),
            MoveOutReportingDestination = GetReportingMunicipalityRestrictedMoveOut(moveOut.MoveOutReportingDestination)
        };
    }

    public static HasMainResidenceMoveIn GetHasMainResidenceMoveIn(eCH_0020_3_0.HasMainResidenceMoveIn hasMainResidence)
    {
        var fHasMainResidence = new HasMainResidenceMoveIn()
        {
            ArrivalDate = hasMainResidence.ArrivalDate,
            ComesFrom = hasMainResidence.ComesFromSpecified ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(hasMainResidence.ComesFrom) : null,
            DwellingAddress = (hasMainResidence.DwellingAddress != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(hasMainResidence.DwellingAddress) : null,
            FederalRegister = (hasMainResidence.FederalRegister != null) ? (FederalRegisterType?)Enum.Parse(typeof(FederalRegisterType), hasMainResidence.FederalRegister.ToString()) : null,
            ReportingMunicipality = hasMainResidence.ReportingMunicipalitySpecified ? eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(hasMainResidence.ReportingMunicipality) : null,
            SecondaryResidences = null
        };

        if (hasMainResidence.SecondaryResidencesSpecified)
        {
            fHasMainResidence.SecondaryResidences = new List<eCH_0007_5_0f.SwissMunicipality>();

            foreach (var data in hasMainResidence.SecondaryResidences)
            {
                fHasMainResidence.SecondaryResidences.Add(eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(data));
            }
        }

        return fHasMainResidence;
    }

    public static HasSecondaryResidenceMoveIn GetHasSecondaryResidenceMoveIn(eCH_0020_3_0.HasSecondaryResidenceMoveIn hasSecondaryResidenceMoveIn)
    {
        var fHasSecondaryResidenceMoveIn = new HasSecondaryResidenceMoveIn()
        {
            ArrivalDate = hasSecondaryResidenceMoveIn.ArrivalDate,
            ComesFrom = hasSecondaryResidenceMoveIn.ComesFromSpecified ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(hasSecondaryResidenceMoveIn.ComesFrom) : null,
            DwellingAddress = (hasSecondaryResidenceMoveIn.DwellingAddress != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(hasSecondaryResidenceMoveIn.DwellingAddress) : null,
            FederalRegister = (hasSecondaryResidenceMoveIn.FederalRegister != null) ? (FederalRegisterType?)Enum.Parse(typeof(FederalRegisterType), hasSecondaryResidenceMoveIn.FederalRegister.ToString()) : null,
            ReportingMunicipality = hasSecondaryResidenceMoveIn.ReportingMunicipalitySpecified ? eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(hasSecondaryResidenceMoveIn.ReportingMunicipality) : null,
            MainResidences = null
        };

        if (hasSecondaryResidenceMoveIn.MainResidencesSpecified)
        {
            fHasSecondaryResidenceMoveIn.MainResidences = new List<eCH_0007_5_0f.SwissMunicipality>();

            foreach (var data in hasSecondaryResidenceMoveIn.MainResidences)
            {
                fHasSecondaryResidenceMoveIn.MainResidences.Add(eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(data));
            }
        }

        return fHasSecondaryResidenceMoveIn;
    }

    public static ReportingMunicipalityRestrictedMoveIn GetReportingMunicipalityRestrictedMoveIn(eCH_0020_3_0.ReportingMunicipalityRestrictedMoveIn hasOtherResidence)
    {
        return new ReportingMunicipalityRestrictedMoveIn()
        {
            ArrivalDate = hasOtherResidence.ArrivalDate,
            ComesFrom = hasOtherResidence.ComesFromSpecified ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(hasOtherResidence.ComesFrom) : null,
            DwellingAddress = (hasOtherResidence.DwellingAddress != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(hasOtherResidence.DwellingAddress) : null,
            FederalRegister = (hasOtherResidence.FederalRegister != null) ? (FederalRegisterType?)Enum.Parse(typeof(FederalRegisterType), hasOtherResidence.FederalRegister.ToString()) : null,
            ReportingMunicipality = hasOtherResidence.ReportingMunicipalitySpecified ? eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(hasOtherResidence.ReportingMunicipality) : null
        };
    }

    public static BirthInfo GetBirthInfo(eCH_0020_3_0.BirthInfo birthInfo)
    {
        return new BirthInfo()
        {
            BirthAddonData = birthInfo.BirthAddonDataSpecified ? eCH_0021_7_0f.Mapper.ECHtoECHf.GetBirthAddonData(birthInfo.BirthAddonData) : null,
            BirthData = (birthInfo.BirthData != null) ? eCH_0011_8_1f.Mapper.ECHtoECHf.GetBirthData(birthInfo.BirthData) : null
        };
    }

    public static MaritalInfo GetMaritalInfo(eCH_0020_3_0.MaritalInfo maritalInfo)
    {
        return new MaritalInfo()
        {
            MaritalData = eCH_0011_8_1f.Mapper.ECHtoECHf.GetMaritalData(maritalInfo.MaritalData),
            MaritalDataAddon = eCH_0021_7_0f.Mapper.ECHtoECHf.GetMaritalDataAddon(maritalInfo.MaritalDataAddon)
        };
    }
}
