// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("jobData")]
[XmlRoot(ElementName = "jobData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class JobData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string KindOfEmploymentValidateExceptionMessage = "KindOfEmployment is not valid! KindOfEmployment has to be maximum length 1";
    private const string JobTitleValidateExceptionMessage = "JobTitle is not valid! JobTitle has to be maximum length 100";

    private string _kindOfEmployment;
    private string _jobTitle;

    public JobData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="kindOfEmployment">Field is required.</param>
    /// <param name="jobTitle">Field is optional.</param>
    /// <param name="occupationData">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static JobData Create(string kindOfEmployment, string jobTitle = null, List<OccupationData> occupationData = null)
    {
        return new JobData()
        {
            KindOfEmployment = kindOfEmployment,
            JobTitle = jobTitle,
            OccupationDatas = occupationData
        };
    }

    [JsonProperty("kindOfEmployment")]
    [XmlElement(ElementName = "kindOfEmployment", Order = 1)]
    public string KindOfEmployment
    {
        get { return _kindOfEmployment; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 1)
            {
                throw new XmlSchemaValidationException(KindOfEmploymentValidateExceptionMessage);
            }
            _kindOfEmployment = value;
        }
    }

    [JsonProperty("jobTitle")]
    [XmlElement(ElementName = "jobTitle", Order = 2)]
    public string JobTitle
    {
        get { return _jobTitle; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(JobTitleValidateExceptionMessage);
            }
            _jobTitle = value;
        }
    }

    [JsonProperty("occupationData")]
    [XmlElement(ElementName = "occupationData", Order = 3)]
    public List<OccupationData> OccupationDatas { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OccupationDatasSpecified => OccupationDatas != null && OccupationDatas.Any();
}
