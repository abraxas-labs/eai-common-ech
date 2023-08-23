// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;

namespace eCH_0007_5_0f.Mapper;

/// <summary>
/// Mappingclass eCH_0044_4_1f
/// eCh-0007-6-0 to eCh-0007-6-0f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0007/5/index5_0.html.
/// </summary>
public static class ECHtoECHf
{
    public static SwissMunicipality GetSwissMunicipality(eCH_0007_5_0.SwissMunicipality swissTown)
    {
        return new SwissMunicipality()
        {
            MunicipalityName = swissTown.MunicipalityName,
            HistoryMunicipalityId = swissTown.HistoryMunicipalityId,
            CantonAbbreviation = swissTown.CantonAbbreviationSpecified ? (CantonAbbreviation?)Enum.Parse(typeof(CantonAbbreviation), swissTown.CantonAbbreviation.ToString()) : null,
            MunicipalityId = swissTown.MunicipalityId
        };
    }
}
