// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventDeath.
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class Delivery
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DeliveryHeaderNullValidateExceptionMessage = "DeliveryHeader is not valid! DeliveryHeader is required";

    private Header _deliveryHeader;

    public Delivery()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deliveryHeader">Field is required.</param>
    /// <param name="baseDelivery"></param>
    /// <returns>Delivery.</returns>
    public static Delivery Create(Header deliveryHeader, BaseDeliveryMessage baseDelivery)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            BaseDelivery = baseDelivery
        };
    }

    public static Delivery Create(Header deliveryHeader, KeyExchangeMessage keyExchange)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            KeyExchange = keyExchange
        };
    }

    public static Delivery Create(Header deliveryHeader, EventDataRequest dataRequest)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            DataRequest = dataRequest
        };
    }

    public static Delivery Create(Header deliveryHeader, EventIdentificationConversion identificationConversion)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            IdentificationConversion = identificationConversion
        };
    }

    public static Delivery Create(Header deliveryHeader, EventAnnounceDuplicate announceDuplicate)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            AnnounceDuplicate = announceDuplicate
        };
    }

    public static Delivery Create(Header deliveryHeader, EventDeletedInRegister deletedInRegister)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            DeletedInRegister = deletedInRegister
        };
    }

    public static Delivery Create(Header deliveryHeader, EventAdoption adoption)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Adoption = adoption
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChildRelationship childRelationship)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChildRelationship = childRelationship
        };
    }

    public static Delivery Create(Header deliveryHeader, EventNaturalizeForeigner naturalizeForeigner)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            NaturalizeForeigner = naturalizeForeigner
        };
    }

    public static Delivery Create(Header deliveryHeader, EventNaturalizeSwiss naturalizeSwiss)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            NaturalizeSwiss = naturalizeSwiss
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoCitizen undoCitizen)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoCitizen = undoCitizen
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoSwiss undoSwiss)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoSwiss = undoSwiss
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeOrigin changeOrigin)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeOrigin = changeOrigin
        };
    }

    public static Delivery Create(Header deliveryHeader, EventBirth birth)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Birth = birth
        };
    }

    public static Delivery Create(Header deliveryHeader, EventMarriage marriage)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Marriage = marriage
        };
    }

    public static Delivery Create(Header deliveryHeader, EventPartnership partnership)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Partnership = partnership
        };
    }

    public static Delivery Create(Header deliveryHeader, EventSeparation separation)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Separation = separation
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoSeparation undoSeparation)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoSeparation = undoSeparation
        };
    }

    public static Delivery Create(Header deliveryHeader, EventDivorce divorce)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Divorce = divorce
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoMarriage undoMarriage)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoMarriage = undoMarriage
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoPartnership undoPartnership)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoPartnership = undoPartnership
        };
    }

    public static Delivery Create(Header deliveryHeader, EventDeath death)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Death = death
        };
    }

    public static Delivery Create(Header deliveryHeader, EventMissing missing)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Missing = missing
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoMissing undoMissing)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoMissing = undoMissing
        };
    }

    public static Delivery Create(Header deliveryHeader, EventMaritalStatusPartner maritalStatusPartner)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            MaritalStatusPartner = maritalStatusPartner
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeName changeName)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeName = changeName
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeSex changeSex)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeSex = changeSex
        };
    }

    public static Delivery Create(Header deliveryHeader, EventMoveIn moveIn)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            MoveIn = moveIn
        };
    }

    public static Delivery Create(Header deliveryHeader, EventMove move)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Move = move
        };
    }

    public static Delivery Create(Header deliveryHeader, EventContact contact)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Contact = contact
        };
    }

    public static Delivery Create(Header deliveryHeader, EventMoveOut moveOut)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            MoveOut = moveOut
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeResidenceType changeResidenceType)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeResidenceType = changeResidenceType
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeReligion changeReligion)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeReligion = changeReligion
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeOccupation changeOccupation)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeOccupation = changeOccupation
        };
    }

    public static Delivery Create(Header deliveryHeader, EventGuardianMeasure guardianMeasure)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            GuardianMeasure = guardianMeasure
        };
    }

    public static Delivery Create(Header deliveryHeader, EventUndoGuardian undoGuardian)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            UndoGuardian = undoGuardian
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeGuardian changeGuardian)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeGuardian = changeGuardian
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeNationality changeNationality)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeNationality = changeNationality
        };
    }

    public static Delivery Create(Header deliveryHeader, EventEntryResidencePermit changeResidencePermit)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeResidencePermit = changeResidencePermit
        };
    }

    public static Delivery Create(Header deliveryHeader, EventDataLock dataLock)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            DataLock = dataLock
        };
    }

    public static Delivery Create(Header deliveryHeader, EventPaperLock paperLock)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            PaperLock = paperLock
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCare care)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            Care = care
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeArmedForces changeArmedForces)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeArmedForces = changeArmedForces
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeCivilDefense changeCivilDefense)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeCivilDefense = changeCivilDefense
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeFireService changeFireService)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeFireService = changeFireService
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeHealthInsurance changeHealthInsurance)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeHealthInsurance = changeHealthInsurance
        };
    }

    public static Delivery Create(Header deliveryHeader, EventChangeMatrimonialInheritanceArrangement changeMatrimonialInheritanceArrangement)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            ChangeMatrimonialInheritanceArrangement = changeMatrimonialInheritanceArrangement
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectGuardianRelationship correctGuardianRelationship)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectGuardianRelationship = correctGuardianRelationship
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectParentalRelationship correctParentalRelationship)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectParentalRelationship = correctParentalRelationship
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectReporting correctReporting)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectReporting = correctReporting
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectOccupation correctOccupation)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectOccupation = correctOccupation
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectIdentification correctIdentification)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectIdentification = correctIdentification
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectName correctName)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectName = correctName
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectNationality correctNationality)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectNationality = correctNationality
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectContact correctContact)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectContact = correctContact
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectReligion correctReligion)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectReligion = correctReligion
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectPlaceOfOrigin correctPlaceOfOrigin)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectPlaceOfOrigin = correctPlaceOfOrigin
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectResidencePermit correctResidencePermit)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectResidencePermit = correctResidencePermit
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectMaritalInfo correctMaritalInfo)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectMaritalInfo = correctMaritalInfo
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectBirthInfo correctBirthInfo)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectBirthInfo = correctBirthInfo
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectDeathData correctDeathData)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectDeathData = correctDeathData
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectPersonAdditionalData correctPersonAdditionalData)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectPersonAdditionalData = correctPersonAdditionalData
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectPoliticalRightData correctPoliticalRightData)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectPoliticalRightData = correctPoliticalRightData
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectDataLock correctDataLock)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectDataLock = correctDataLock
        };
    }

    public static Delivery Create(Header deliveryHeader, EventCorrectPaperLock correctPaperLock)
    {
        return new Delivery
        {
            DeliveryHeader = deliveryHeader,
            CorrectPaperLock = correctPaperLock
        };
    }

    [JsonProperty("version")]
    [XmlAttribute(AttributeName = "version")]
    public string Version
    {
        get { return "3.0"; }
        set { }
    }

    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader")]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => _deliveryHeader = value ?? throw new XmlSchemaValidationException(DeliveryHeaderNullValidateExceptionMessage);
    }

    [JsonProperty("baseDelivery")]
    [XmlElement(ElementName = "baseDelivery")]
    public BaseDeliveryMessage BaseDelivery { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BaseDeliverySpecified => BaseDelivery != null;

    [JsonProperty("keyExchange")]
    [XmlElement(ElementName = "keyExchange")]
    public KeyExchangeMessage KeyExchange { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool KeyExchangeSpecified => KeyExchange != null;

    [JsonProperty("dataRequest")]
    [XmlElement(ElementName = "dataRequest")]
    public EventDataRequest DataRequest { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataRequestSpecified => DataRequest != null;

    [JsonProperty("identificationConversion")]
    [XmlElement(ElementName = "identificationConversion")]
    public EventIdentificationConversion IdentificationConversion { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool IdentificationConversionSpecified => IdentificationConversion != null;

    [JsonProperty("announceDuplicate")]
    [XmlElement(ElementName = "announceDuplicate")]
    public EventAnnounceDuplicate AnnounceDuplicate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AnnounceDuplicateSpecified => AnnounceDuplicate != null;

    [JsonProperty("deletedInRegister")]
    [XmlElement(ElementName = "deletedInRegister")]
    public EventDeletedInRegister DeletedInRegister { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeletedInRegisterSpecified => DeletedInRegister != null;

    [JsonProperty("adoption")]
    [XmlElement(ElementName = "adoption")]
    public EventAdoption Adoption { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AdoptionSpecified => Adoption != null;

    [JsonProperty("childRelationship")]
    [XmlElement(ElementName = "childRelationship")]
    public EventChildRelationship ChildRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChildRelationshipSpecified => ChildRelationship != null;

    [JsonProperty("naturalizeForeigner")]
    [XmlElement(ElementName = "naturalizeForeigner")]
    public EventNaturalizeForeigner NaturalizeForeigner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NaturalizeForeignerSpecified => NaturalizeForeigner != null;

    [JsonProperty("naturalizeSwiss")]
    [XmlElement(ElementName = "naturalizeSwiss")]
    public EventNaturalizeSwiss NaturalizeSwiss { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NaturalizeSwissSpecified => NaturalizeSwiss != null;

    [JsonProperty("undoCitizen")]
    [XmlElement(ElementName = "undoCitizen")]
    public EventUndoCitizen UndoCitizen { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoCitizenSpecified => UndoCitizen != null;

    [JsonProperty("undoSwiss")]
    [XmlElement(ElementName = "undoSwiss")]
    public EventUndoSwiss UndoSwiss { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoSwissSpecified => UndoSwiss != null;

    [JsonProperty("changeOrigin")]
    [XmlElement(ElementName = "changeOrigin")]
    public EventChangeOrigin ChangeOrigin { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeOriginSpecified => ChangeOrigin != null;

    [JsonProperty("birth")]
    [XmlElement(ElementName = "birth")]
    public EventBirth Birth { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BirthSpecified => Birth != null;

    [JsonProperty("marriage")]
    [XmlElement(ElementName = "marriage")]
    public EventMarriage Marriage { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MarriageSpecified => Marriage != null;

    [JsonProperty("partnership")]
    [XmlElement(ElementName = "partnership")]
    public EventPartnership Partnership { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnershipSpecified => Partnership != null;

    [JsonProperty("separation")]
    [XmlElement(ElementName = "separation")]
    public EventSeparation Separation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SeparationSpecified => Separation != null;

    [JsonProperty("undoSeparation")]
    [XmlElement(ElementName = "undoSeparation")]
    public EventUndoSeparation UndoSeparation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoSeparationSpecified => UndoSeparation != null;

    [JsonProperty("divorce")]
    [XmlElement(ElementName = "divorce")]
    public EventDivorce Divorce { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DivorceSpecified => Divorce != null;

    [JsonProperty("undoMarriage")]
    [XmlElement(ElementName = "undoMarriage")]
    public EventUndoMarriage UndoMarriage { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoMarriageSpecified => UndoMarriage != null;

    [JsonProperty("undoPartnership")]
    [XmlElement(ElementName = "undoPartnership")]
    public EventUndoPartnership UndoPartnership { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoPartnershipSpecified => UndoPartnership != null;

    [JsonProperty("death")]
    [XmlElement(ElementName = "death")]
    public EventDeath Death { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeathSpecified => Death != null;

    [JsonProperty("missing")]
    [XmlElement(ElementName = "missing")]
    public EventMissing Missing { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MissingSpecified => Missing != null;

    [JsonProperty("undoMissing")]
    [XmlElement(ElementName = "undoMissing")]
    public EventUndoMissing UndoMissing { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoMissingSpecified => UndoMissing != null;

    [JsonProperty("maritalStatusPartner")]
    [XmlElement(ElementName = "maritalStatusPartner")]
    public EventMaritalStatusPartner MaritalStatusPartner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MaritalStatusPartnerSpecified => MaritalStatusPartner != null;

    [JsonProperty("changeName")]
    [XmlElement(ElementName = "changeName")]
    public EventChangeName ChangeName { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeNameSpecified => ChangeName != null;

    [JsonProperty("changeSex")]
    [XmlElement(ElementName = "changeSex")]
    public EventChangeSex ChangeSex { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeSexSpecified => ChangeSex != null;

    [JsonProperty("moveIn")]
    [XmlElement(ElementName = "moveIn")]
    public EventMoveIn MoveIn { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MoveInSpecified => MoveIn != null;

    [JsonProperty("move")]
    [XmlElement(ElementName = "move")]
    public EventMove Move { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MoveSpecified => Move != null;

    [JsonProperty("contact")]
    [XmlElement(ElementName = "contact")]
    public EventContact Contact { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactSpecified => Contact != null;

    [JsonProperty("moveOut")]
    [XmlElement(ElementName = "moveOut")]
    public EventMoveOut MoveOut { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MoveOutSpecified => MoveOut != null;

    [JsonProperty("changeResidenceType")]
    [XmlElement(ElementName = "changeResidenceType")]
    public EventChangeResidenceType ChangeResidenceType { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeResidenceTypeSpecified => ChangeResidenceType != null;

    [JsonProperty("changeReligion")]
    [XmlElement(ElementName = "changeReligion")]
    public EventChangeReligion ChangeReligion { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeReligionSpecified => ChangeReligion != null;

    [JsonProperty("changeOccupation")]
    [XmlElement(ElementName = "changeOccupation")]
    public EventChangeOccupation ChangeOccupation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeOccupationSpecified => ChangeOccupation != null;

    [JsonProperty("guardianMeasure")]
    [XmlElement(ElementName = "guardianMeasure")]
    public EventGuardianMeasure GuardianMeasure { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GuardianMeasureSpecified => GuardianMeasure != null;

    [JsonProperty("undoGuardian")]
    [XmlElement(ElementName = "undoGuardian")]
    public EventUndoGuardian UndoGuardian { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UndoGuardianSpecified => UndoGuardian != null;

    [JsonProperty("changeGuardian")]
    [XmlElement(ElementName = "changeGuardian")]
    public EventChangeGuardian ChangeGuardian { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeGuardianSpecified => ChangeGuardian != null;

    [JsonProperty("changeNationality")]
    [XmlElement(ElementName = "changeNationality")]
    public EventChangeNationality ChangeNationality { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeNationalitySpecified => ChangeNationality != null;

    [JsonProperty("changeResidencePermit")]
    [XmlElement(ElementName = "changeResidencePermit")]
    public EventEntryResidencePermit ChangeResidencePermit { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeResidencePermitSpecified => ChangeResidencePermit != null;

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock")]
    public EventDataLock DataLock { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockSpecified => DataLock != null;

    [JsonProperty("paperLock")]
    [XmlElement(ElementName = "paperLock")]
    public EventPaperLock PaperLock { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PaperLockSpecified => PaperLock != null;

    [JsonProperty("care")]
    [XmlElement(ElementName = "care")]
    public EventCare Care { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CareSpecified => Care != null;

    [JsonProperty("changeArmedForces")]
    [XmlElement(ElementName = "changeArmedForces")]
    public EventChangeArmedForces ChangeArmedForces { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeArmedForcesSpecified => ChangeArmedForces != null;

    [JsonProperty("changeCivilDefense")]
    [XmlElement(ElementName = "changeCivilDefense")]
    public EventChangeCivilDefense ChangeCivilDefense { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeCivilDefenseSpecified => ChangeCivilDefense != null;

    [JsonProperty("changeFireService")]
    [XmlElement(ElementName = "changeFireService")]
    public EventChangeFireService ChangeFireService { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeFireServiceSpecified => ChangeFireService != null;

    [JsonProperty("changeHealthInsurance")]
    [XmlElement(ElementName = "changeHealthInsurance")]
    public EventChangeHealthInsurance ChangeHealthInsurance { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeHealthInsuranceSpecified => ChangeHealthInsurance != null;

    [JsonProperty("changeMatrimonialInheritanceArrangement")]
    [XmlElement(ElementName = "changeMatrimonialInheritanceArrangement")]
    public EventChangeMatrimonialInheritanceArrangement ChangeMatrimonialInheritanceArrangement { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ChangeMatrimonialInheritanceArrangementSpecified => ChangeMatrimonialInheritanceArrangement != null;

    [JsonProperty("correctGuardianRelationship")]
    [XmlElement(ElementName = "correctGuardianRelationship")]
    public EventCorrectGuardianRelationship CorrectGuardianRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectGuardianRelationshipSpecified => CorrectGuardianRelationship != null;

    [JsonProperty("correctParentalRelationship")]
    [XmlElement(ElementName = "correctParentalRelationship")]
    public EventCorrectParentalRelationship CorrectParentalRelationship { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectParentalRelationshipSpecified => CorrectParentalRelationship != null;

    [JsonProperty("correctReporting")]
    [XmlElement(ElementName = "correctReporting")]
    public EventCorrectReporting CorrectReporting { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectReportingSpecified => CorrectReporting != null;

    [JsonProperty("correctOccupation")]
    [XmlElement(ElementName = "correctOccupation")]
    public EventCorrectOccupation CorrectOccupation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectOccupationSpecified => CorrectOccupation != null;

    [JsonProperty("correctIdentification")]
    [XmlElement(ElementName = "correctIdentification")]
    public EventCorrectIdentification CorrectIdentification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectIdentificationSpecified => CorrectIdentification != null;

    [JsonProperty("correctName")]
    [XmlElement(ElementName = "correctName")]
    public EventCorrectName CorrectName { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectNameSpecified => CorrectName != null;

    [JsonProperty("correctNationality")]
    [XmlElement(ElementName = "correctNationality")]
    public EventCorrectNationality CorrectNationality { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectNationalitySpecified => CorrectNationality != null;

    [JsonProperty("correctContact")]
    [XmlElement(ElementName = "correctContact")]
    public EventCorrectContact CorrectContact { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectContactSpecified => CorrectContact != null;

    [JsonProperty("correctReligion")]
    [XmlElement(ElementName = "correctReligion")]
    public EventCorrectReligion CorrectReligion { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectReligionSpecified => CorrectReligion != null;

    [JsonProperty("correctPlaceOfOrigin")]
    [XmlElement(ElementName = "correctPlaceOfOrigin")]
    public EventCorrectPlaceOfOrigin CorrectPlaceOfOrigin { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectPlaceOfOriginSpecified => CorrectPlaceOfOrigin != null;

    [JsonProperty("correctResidencePermit")]
    [XmlElement(ElementName = "correctResidencePermit")]
    public EventCorrectResidencePermit CorrectResidencePermit { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectResidencePermitSpecified => CorrectResidencePermit != null;

    [JsonProperty("correctMaritalInfo")]
    [XmlElement(ElementName = "correctMaritalInfo")]
    public EventCorrectMaritalInfo CorrectMaritalInfo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectMaritalInfoSpecified => CorrectMaritalInfo != null;

    [JsonProperty("correctBirthInfo")]
    [XmlElement(ElementName = "correctBirthInfo")]
    public EventCorrectBirthInfo CorrectBirthInfo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectBirthInfoSpecified => CorrectBirthInfo != null;

    [JsonProperty("correctDeathData")]
    [XmlElement(ElementName = "correctDeathData")]
    public EventCorrectDeathData CorrectDeathData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectDeathDataSpecified => CorrectDeathData != null;

    [JsonProperty("correctPersonAdditionalData")]
    [XmlElement(ElementName = "correctPersonAdditionalData")]
    public EventCorrectPersonAdditionalData CorrectPersonAdditionalData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectPersonAdditionalDataSpecified => CorrectPersonAdditionalData != null;

    [JsonProperty("correctPoliticalRightData")]
    [XmlElement(ElementName = "correctPoliticalRightData")]
    public EventCorrectPoliticalRightData CorrectPoliticalRightData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectPoliticalRightDataSpecified => CorrectPoliticalRightData != null;

    [JsonProperty("correctDataLock")]
    [XmlElement(ElementName = "correctDataLock")]
    public EventCorrectDataLock CorrectDataLock { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectDataLockSpecified => CorrectDataLock != null;

    [JsonProperty("correctPaperLock")]
    [XmlElement(ElementName = "correctPaperLock")]
    public EventCorrectPaperLock CorrectPaperLock { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CorrectPaperLockSpecified => CorrectPaperLock != null;
}
