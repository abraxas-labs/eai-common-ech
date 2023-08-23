// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;

namespace eCH_0044_4_1f.Mapper;

/// <summary>
/// Mappingclass eCH_0044_4_1f
/// eCh-0044-4-1 to eCh-0044-4-1f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0044/4/index4_1.html.
/// </summary>
public static class ECHtoECHf
{
    public static PersonIdentification GetPersonIdentification(eCH_0044_4_1.PersonIdentification personIdentification)
    {
        List<eCH_0044_4_1f.NamedPersonId> fOtherPersonIds = (personIdentification.OtherPersonIds != null) ? new List<eCH_0044_4_1f.NamedPersonId>() : null;

        if (fOtherPersonIds != null)
        {
            foreach (var persId in personIdentification.OtherPersonIds)
            {
                fOtherPersonIds.Add(eCH_0044_4_1f.NamedPersonId.Create(persId.PersonIdCategory, persId.PersonId));
            }
        }

        List<eCH_0044_4_1f.NamedPersonId> fEuPersonIds = (personIdentification.EuPersonIds != null) ? new List<eCH_0044_4_1f.NamedPersonId>() : null;

        if (fEuPersonIds != null)
        {
            foreach (var persId in personIdentification.EuPersonIds)
            {
                fEuPersonIds.Add(eCH_0044_4_1f.NamedPersonId.Create(persId.PersonIdCategory, persId.PersonId));
            }
        }

        eCH_0044_4_1f.PersonIdentification fPersonIfentification = new()
        {
            DateOfBirth = new eCH_0044_4_1f.DatePartiallyKnown()
            {
                Year = personIdentification.DateOfBirth.Year,
                YearMonth = personIdentification.DateOfBirth.YearMonth,
                YearMonthDay = personIdentification.DateOfBirth.YearMonthDay
            },
            Vn = personIdentification.Vn,
            EuPersonIds = fOtherPersonIds,
            OtherPersonIds = fOtherPersonIds,
            FirstName = personIdentification.FirstName,
            LocalPersonId = eCH_0044_4_1f.NamedPersonId.Create(personIdentification.LocalPersonId.PersonIdCategory, personIdentification.LocalPersonId.PersonId),
            OfficialName = personIdentification.OfficialName,
            OriginalName = personIdentification.OriginalName,
            Sex = (eCH_0044_4_1f.SexType)Enum.Parse(typeof(eCH_0044_4_1f.SexType), personIdentification.Sex.ToString())
        };

        return fPersonIfentification;
    }

    public static PersonIdentificationLight GetPersonIdentificationLight(eCH_0044_4_1.PersonIdentificationLight personIdentification)
    {
        List<NamedPersonId> fOtherPersonIds = new();

        foreach (var persId in personIdentification.OtherPersonIds)
        {
            fOtherPersonIds.Add(eCH_0044_4_1f.NamedPersonId.Create(persId.PersonIdCategory, persId.PersonId));
        }

        eCH_0044_4_1f.PersonIdentificationLight personIdentificationLight = new()
        {
            DateOfBirth = new eCH_0044_4_1f.DatePartiallyKnown()
            {
                Year = personIdentification.DateOfBirth.Year,
                YearMonth = personIdentification.DateOfBirth.YearMonth,
                YearMonthDay = personIdentification.DateOfBirth.YearMonthDay
            },
            Vn = personIdentification.Vn,
            OtherPersonIds = fOtherPersonIds,
            FirstName = personIdentification.FirstName,
            LocalPersonId = eCH_0044_4_1f.NamedPersonId.Create(personIdentification.LocalPersonId.PersonIdCategory, personIdentification.LocalPersonId.PersonId),
            OfficialName = personIdentification.OfficialName,
            OriginalName = personIdentification.OriginalName,
            Sex = personIdentification.SexSpecified ? (eCH_0044_4_1f.SexType?)Enum.Parse(typeof(eCH_0044_4_1f.SexType), personIdentification.Sex.ToString()) : null
        };

        return personIdentificationLight;
    }

    public static DatePartiallyKnown GetDatePartiallyKnown(eCH_0044_4_1.DatePartiallyKnown date)
    {
        return new DatePartiallyKnown()
        {
            Year = date.Year,
            YearMonth = date.YearMonth,
            YearMonthDay = date.YearMonthDay
        };
    }
}
