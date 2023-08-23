// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Die Wahlliste enthält die Information welche Kandidaten für ein Amt gewählt werden können. In
///     spezifischen Fällen – z.B. bei Majorzwahlen – kann es sein, dass diese Kandidaten nicht
///     explizit geliefert werden.
/// </summary>
[Serializable]
[JsonObject("list")]
[XmlRoot(ElementName = "list", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class List
{
    private const string ListIdentificationNullValidateExceptionMessage =
        "ListIdentification is not valid! CandidateIdentification is required";

    private const string ListIdentificationOutOfRangeValidateExceptionMessage =
        "ListIdentification is not valid! CandidateIdentification has minimal leght of 1 and maximal length of 50";

    private const string ListIndentureNumberNullValidateExceptionMessage =
        "ListIndentureNumber is not valid! CandidateReferenceOnPosition is required";

    private const string ListIndentureNumberOutOfRangeValidateExceptionMessage =
            "ListIndentureNumber is not valid! CandidateReferenceOnPosition has minimal leght of 1 and maximal length of 6"
        ;

    private const string ListDescriptionNullValidateExceptionMessage =
        "ListDescription is not valid! ListDescription is required";

    private const string ListOrderOfPrecedenceOutOfRangeValidateExceptionMessage =
        "ListOrderOfPrecedence is not valid! ListOrderOfPrecedence has to be a positive number";

    private const string TotalPositionsOnListOutOfRangeValidateExceptionMessage =
        "TotalPositionsOnList is not valid! TotalPositionsOnList has to be a positive number";

    private const string EmptyListPositionsOutOfRangeValidateExceptionMessage =
        "TotalPositionsOnList is not valid! TotalPositionsOnList has to be a positive number";

    private const string RefListInfoOutOfRangeValidateExceptionMessage =
            "CandidateIdentification is not valid! CandidateIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private List<CandidatePositionInformation> _candidatePosition = new();
    private int? _emptyListPositions;
    private ListDescriptionInformation _listDescription;

    private string _listIdentification;
    private string _listIndentureNumber;
    private int? _listOrderOfPrecedence;
    private string _refListInfo;
    private int? _totalPositionsOnList;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public List()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("listIdentification")]
    [XmlElement(ElementName = "listIdentification")]
    public string ListIdentification
    {
        get => _listIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ListIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(ListIdentificationOutOfRangeValidateExceptionMessage);
            }

            _listIdentification = value;
        }
    }

    [JsonProperty("listIndentureNumber")]
    [XmlElement(ElementName = "listIndentureNumber")]
    public string ListIndentureNumber
    {
        get => _listIndentureNumber;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ListIndentureNumberNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 6)
            {
                throw new XmlSchemaValidationException(ListIndentureNumberOutOfRangeValidateExceptionMessage);
            }

            _listIndentureNumber = value;
        }
    }

    [JsonProperty("listDescription")]
    [XmlElement(ElementName = "listDescription")]
    public ListDescriptionInformation ListDescription
    {
        get => _listDescription;
        set => _listDescription =
            value ?? throw new XmlSchemaValidationException(ListDescriptionNullValidateExceptionMessage);
    }

    [JsonProperty("listOrderOfPrecedence")]
    [XmlElement(ElementName = "listOrderOfPrecedence")]
    public int? ListOrderOfPrecedence
    {
        get => _listOrderOfPrecedence;
        set
        {
            if (value.HasValue && value < 0)
            {
                throw new XmlSchemaValidationException(ListOrderOfPrecedenceOutOfRangeValidateExceptionMessage);
            }

            _listOrderOfPrecedence = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ListOrderOfPrecedenceSpecified => ListOrderOfPrecedence.HasValue;

    [JsonProperty("totalPositionsOnList")]
    [XmlElement(ElementName = "totalPositionsOnList")]
    public int? TotalPositionsOnList
    {
        get => _totalPositionsOnList;
        set
        {
            if (value.HasValue && value < 0)
            {
                throw new XmlSchemaValidationException(TotalPositionsOnListOutOfRangeValidateExceptionMessage);
            }

            _totalPositionsOnList = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TotalPositionsOnListSpecified => TotalPositionsOnList.HasValue;

    [JsonProperty("candidatePosition")]
    [XmlElement(ElementName = "candidatePosition")]
    public List<CandidatePositionInformation> CandidatePosition
    {
        get => _candidatePosition;
        set => _candidatePosition = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CandidatePositionSpecified => CandidatePosition != null && CandidatePosition.Any();

    [JsonProperty("emptyListPositions")]
    [XmlElement(ElementName = "emptyListPositions")]
    public int? EmptyListPositions
    {
        get => _emptyListPositions;
        set
        {
            if (value.HasValue && value < 0)
            {
                throw new XmlSchemaValidationException(EmptyListPositionsOutOfRangeValidateExceptionMessage);
            }

            _emptyListPositions = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EmptyListPositionsSpecified => EmptyListPositions.HasValue;

    [JsonProperty("refListInfo")]
    [XmlElement(ElementName = "refListInfo")]
    public string RefListInfo
    {
        get => _refListInfo;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 50))
            {
                throw new XmlSchemaValidationException(RefListInfoOutOfRangeValidateExceptionMessage);
            }

            _refListInfo = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool RefListInfoSpecified => !string.IsNullOrEmpty(RefListInfo);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="listIdentification">Field is required.</param>
    /// <param name="listIndentureNumber">Field is required.</param>
    /// <param name="listDescription">Field is required.</param>
    /// <param name="listOrderOfPrecedence">Field is optional.</param>
    /// <param name="totalPositionsOnList">Field is optional.</param>
    /// <param name="candidatePosition">Field is optional.</param>
    /// <param name="emptyListPositions">Field is optional.</param>
    /// <param name="refListInfo">Field is optional.</param>
    /// <returns>List.</returns>
    public static List Create(string listIdentification, string listIndentureNumber,
        ListDescriptionInformation listDescription, int? listOrderOfPrecedence, int? totalPositionsOnList,
        List<CandidatePositionInformation> candidatePosition, int? emptyListPositions, string refListInfo)
    {
        return new List
        {
            ListIdentification = listIdentification,
            ListIndentureNumber = listIndentureNumber,
            ListDescription = listDescription,
            ListOrderOfPrecedence = listOrderOfPrecedence,
            TotalPositionsOnList = totalPositionsOnList,
            CandidatePosition = candidatePosition,
            EmptyListPositions = emptyListPositions,
            RefListInfo = refListInfo
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="listIdentification">Field is required.</param>
    /// <param name="listIndentureNumber">Field is required.</param>
    /// <param name="listDescription">Field is required.</param>
    /// <returns>List.</returns>
    public static List Create(string listIdentification, string listIndentureNumber,
        ListDescriptionInformation listDescription)
    {
        return new List
        {
            ListIdentification = listIdentification,
            ListIndentureNumber = listIndentureNumber,
            ListDescription = listDescription
        };
    }
}
