// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0008_3_0f.Mapper;

/// <summary>
/// Mappingclass eCH_0008_3_0f
/// eCh-0008-3-0 to eCh-0008-3-0f (forgiving)
/// https://share.ech.ch/xmlns//eCH-0008/3/index3_0.html.
/// </summary>
public static class ECHtoECHf
{
    public static Country GetCountry(eCH_0008_3_0.Country country)
    {
        return new Country()
        {
            CountryId = country.CountryId,
            CountryIdIso2 = country.CountryIdIso2,
            CountryNameShort = country.CountryNameShort
        };
    }
}
