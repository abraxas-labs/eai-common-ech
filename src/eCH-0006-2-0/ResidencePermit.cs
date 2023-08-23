// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitType bildet alle möglichen erlaubten Ausländerkategorien ab.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public class ResidencePermit
{
    private static readonly List<string> ResidencePermits = new()
    {
        "01", "0102",
        "02", "0201", "0202",
        "03", "0301", "0302",
        "04", "0401", "0402",
        "05", "0503",
        "06", "0601", "0602", "060101", "060201", "060102", "060202",
        "07", "0701", "0702", "070101", "070201", "070102", "070202", "070103", "070104", "070204", "070105", "070205", "070206", "070907",
        "08", "0804",
        "09", "0905",
        "10", "1006", "100601", "100602", "100603",
        "11", "1107",
        "12", "1208",
        "1300"
    };

    public static bool Validate(string value)
    {
        return ResidencePermits.Any(x => x.Equals(value));
    }
}
