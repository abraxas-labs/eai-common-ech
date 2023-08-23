// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_0;
using eCH_0044_3_0;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Eine Person aus Sicht der Politischen Rechte ist eine natürliche Person welche für mindestens
///     einen Einflussbereich (Bsp. Bund, Kanton, Gemeinde, weitere) mindestens ein politisches Recht besitzt.
///     Unter Kandidat wird eine Person verstanden, welche explizit als Kandidat für eine Wahl gemeldet wird.
/// </summary>
[Serializable]
[JsonObject("candidate")]
[XmlRoot(ElementName = "candidate", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class Candidate
{
    private const string VnValidateExceptionMessage =
        "Vn is not valid! Vn has to be between 7560000000001 and 7569999999999";

    private const string CandidateIdentificationNullValidationExceptionMessage =
        "CandidateIdentification is not valid! CandidateIdentification is required";

    private const string CandidateIdentificationOutOfRangeValidateExceptionMessage =
            "CandidateIdentification is not valid! CandidateIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private const string FamilyNameNullValidationExceptionMessage =
        "FamilyName is not valid! FamilyName is required";

    private const string FamilyNameOutOfRangeValidateExceptionMessage =
        "FamilyName is not valid! FamilyName has minimal leght of 1 and maximal length of 100";

    private const string FirstNameOutOfRangeValidateExceptionMessage =
        "FirstName is not valid! FirstName has minimal leght of 1 and maximal length of 100";

    private const string CallNameNullValidationExceptionMessage = "CallName is not valid! CallName is required";

    private const string CallNameOutOfRangeValidateExceptionMessage =
        "CallName is not valid! CallName has minimal leght of 1 and maximal length of 100";

    private const string TitleOutOfRangeValidateExceptionMessage =
        "Title is not valid! Title has maximal length of 50";

    private const string CandidateReferenceNullValidateExceptionMessage =
        "CandidateReference is not valid! CandidateReference is required";

    private const string CandidateReferenceOutOfRangeValidateExceptionMessage =
        "CandidateReference is not valid! CandidateReference has minimal leght of 1 and has maximal length of 6";

    private const string SwissForeignChoiceNullValidateExceptionMessage =
        "SwissForeignChoice is not valid! SwissForeignChoice is required";

    private const string SwissForeignChoiceOutOfRangeValidateExceptionMessage =
            "SwissForeignChoice is not valid! SwissForeignChoice has to be of type eCH-0155.Swiss or eCH-0155.Foreigner"
        ;

    private string _callName;
    private string _candidateIdentification;
    private string _candidateReference;
    private string _familyName;
    private string _firstName;
    private object _swissForeignChoice;
    private string _title;

    private string _vn;

    [JsonIgnore][XmlIgnore] public ChoiceIdentifier ElementTypeName;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Candidate()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("vn")]
    [XmlElement(DataType = "string", ElementName = "vn")]
    public string Vn
    {
        get => _vn;
        set
        {
            if (!string.IsNullOrEmpty(value) && (long.Parse(value) < 7560000000001 || long.Parse(value) > 7569999999999))
            {
                throw new XmlSchemaValidationException(VnValidateExceptionMessage);
            }

            _vn = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => !string.IsNullOrEmpty(Vn);

    [JsonProperty("candidateIdentification")]
    [XmlElement("candidateIdentification")]
    public string CandidateIdentification
    {
        get => _candidateIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(CandidateIdentificationNullValidationExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(CandidateIdentificationOutOfRangeValidateExceptionMessage);
            }

            _candidateIdentification = value;
        }
    }

    [JsonProperty("bfsNumberCanton")]
    [XmlElement("bfsNumberCanton")]
    public BfsNumberCanton? BfsNumberCanton { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BfsNumberCantonSpecified => BfsNumberCanton.HasValue;

    [JsonProperty("familyName")]
    [XmlElement("familyName")]
    public string FamilyName
    {
        get => _familyName;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(FamilyNameNullValidationExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(FamilyNameOutOfRangeValidateExceptionMessage);
            }

            _familyName = value;
        }
    }

    [JsonProperty("firstName")]
    [XmlElement("firstName")]
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(FirstNameOutOfRangeValidateExceptionMessage);
            }

            _firstName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameSpecified => !string.IsNullOrEmpty(FirstName);

    [JsonProperty("callName")]
    [XmlElement("callName")]
    public string CallName
    {
        get => _callName;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(CallNameNullValidationExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(CallNameOutOfRangeValidateExceptionMessage);
            }

            _callName = value;
        }
    }

    [JsonProperty("candidateText")]
    [XmlElement("candidateText")]
    public CandidateTextInformation CandidateText { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CandidateTextSpecified => CandidateText != null;

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth", DataType = "date")]
    public DateTime DateOfBirth { get; set; }

    [JsonProperty("sex")]
    [XmlElement("sex")]
    public SexType Sex { get; set; }

    [JsonProperty("occupationalTitle")]
    [XmlElement("occupationalTitle")]
    public OccupationalTitleInformation OccupationalTitle { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OccupationalTitleSpecified => OccupationalTitle != null;

    [JsonProperty("contactAddress")]
    [XmlElement("contactAddress")]
    public PersonMailAddress ContactAddress { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactAddressSpecified => ContactAddress != null;

    [JsonProperty("politicalAddress")]
    [XmlElement("politicalAddress")]
    public SwissAddressInformation PoliticalAddress { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PoliticalAddressSpecified => PoliticalAddress != null;

    [JsonProperty("dwellingAddress")]
    [XmlElement("dwellingAddress")]
    public AddressInformation DwellingAddress { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DwellingAddressSpecified => DwellingAddress != null;

    [XmlElement("swiss", typeof(Swiss))]
    [XmlElement("foreigner", typeof(Foreigner))]
    [XmlChoiceIdentifier("ElementTypeName")]
    public object SwissForeignChoice
    {
        get => _swissForeignChoice;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(SwissForeignChoiceNullValidateExceptionMessage);
            }

            if (value is Swiss)
            {
                ElementTypeName = ChoiceIdentifier.swiss;
            }
            else if (value is Foreigner)
            {
                ElementTypeName = ChoiceIdentifier.foreigner;
            }
            else
            {
                throw new XmlSchemaValidationException(SwissForeignChoiceOutOfRangeValidateExceptionMessage);
            }

            _swissForeignChoice = value;
        }
    }

    [JsonProperty("mrMrs")]
    [XmlElement("mrMrs")]
    public MrMrs? MrMrs { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MrMrsSpecified => DwellingAddress != null;

    [JsonProperty("title")]
    [XmlElement("title")]
    public string Title
    {
        get => _title;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 50)
            {
                throw new XmlSchemaValidationException(TitleOutOfRangeValidateExceptionMessage);
            }

            _title = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TitleSpecified => !string.IsNullOrEmpty(Title);

    [JsonProperty("languageOfCorrespondence")]
    [XmlElement("languageOfCorrespondence")]
    public Language? LanguageOfCorrespondence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool LanguageOfCorrespondenceSpecified => LanguageOfCorrespondence.HasValue;

    [JsonProperty("hithertoYesNo")]
    [XmlElement("hithertoYesNo")]
    public bool? HithertoYesNo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool HithertoYesNoSpecified => HithertoYesNo.HasValue;

    [JsonProperty("candidateReference")]
    [XmlElement("candidateReference")]
    public string CandidateReference
    {
        get => _candidateReference;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(CandidateReferenceNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 6)
            {
                throw new XmlSchemaValidationException(CandidateReferenceOutOfRangeValidateExceptionMessage);
            }

            _candidateReference = value;
        }
    }

    [JsonProperty("role")]
    [XmlElement("role")]
    public RoleInformation Role { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RoleSpecified => Role != null;

    [JsonProperty("partyAffiliation")]
    [XmlElement("partyAffiliation")]
    public PartyAffiliationInformation PartyAffiliation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartyAffiliationSpecified => PartyAffiliation != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="vn">Field is optional.</param>
    /// <param name="candidateIdentification">Field is required.</param>
    /// <param name="familyName">Field is required.</param>
    /// <param name="firstName">Field is optional.</param>
    /// <param name="callName">Field is required.</param>
    /// <param name="title">Field is optional.</param>
    /// <param name="candidateReference">Field is required.</param>
    /// <param name="bfsNumberCanton">Field is optional.</param>
    /// <param name="candidateText">Field is optional.</param>
    /// <param name="dateOfBirth">Field is required.</param>
    /// <param name="sex">Field is required.</param>
    /// <param name="occupationalTitle">Field is optional.</param>
    /// <param name="contactAddress">Field is optional.</param>
    /// <param name="politicalAddress">Field is optional.</param>
    /// <param name="dwellingAddress">Field is optional.</param>
    /// <param name="swissForeignChoice">Field is required.</param>
    /// <param name="mrMrs">Field is optional.</param>
    /// <param name="languageOfCorrespondence">Field is optional.</param>
    /// <param name="hithertoYesNo">Field is optional.</param>
    /// <param name="role">Field is optional.</param>
    /// <param name="partyAffiliation">Field is optional.</param>
    /// <returns>Candidate.</returns>
    public static Candidate Create(string vn, string candidateIdentification, string familyName, string firstName,
        string callName, string title, string candidateReference, BfsNumberCanton? bfsNumberCanton,
        CandidateTextInformation candidateText, DateTime dateOfBirth, SexType sex,
        OccupationalTitleInformation occupationalTitle, PersonMailAddress contactAddress,
        SwissAddressInformation politicalAddress, AddressInformation dwellingAddress, object swissForeignChoice,
        MrMrs? mrMrs, Language? languageOfCorrespondence, bool? hithertoYesNo, RoleInformation role,
        PartyAffiliationInformation partyAffiliation)
    {
        return new Candidate
        {
            Vn = vn,
            CandidateIdentification = candidateIdentification,
            FamilyName = familyName,
            FirstName = firstName,
            CallName = callName,
            Title = title,
            CandidateReference = candidateReference,
            BfsNumberCanton = bfsNumberCanton,
            CandidateText = candidateText,
            DateOfBirth = dateOfBirth,
            Sex = sex,
            OccupationalTitle = occupationalTitle,
            ContactAddress = contactAddress,
            PoliticalAddress = politicalAddress,
            DwellingAddress = dwellingAddress,
            SwissForeignChoice = swissForeignChoice,
            MrMrs = mrMrs,
            LanguageOfCorrespondence = languageOfCorrespondence,
            HithertoYesNo = hithertoYesNo,
            Role = role,
            PartyAffiliation = partyAffiliation
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="candidateIdentification">Field is required.</param>
    /// <param name="familyName">Field is required.</param>
    /// <param name="callName">Field is required.</param>
    /// <param name="dateOfBirth">Field is required.</param>
    /// <param name="sex">Field is required.</param>
    /// <param name="swissForeignChoice">Field is required.</param>
    /// <param name="candidateReference">Field is required.</param>
    /// <returns>Candidate.</returns>
    public static Candidate Create(string candidateIdentification, string familyName, string callName,
        DateTime dateOfBirth, SexType sex, object swissForeignChoice, string candidateReference)
    {
        return new Candidate
        {
            CandidateIdentification = candidateIdentification,
            FamilyName = familyName,
            CallName = callName,
            CandidateReference = candidateReference,
            DateOfBirth = dateOfBirth,
            Sex = sex,
            SwissForeignChoice = swissForeignChoice
        };
    }
}

[XmlType(IncludeInSchema = false)]
public enum ChoiceIdentifier
{
    swiss,
    foreigner
}
