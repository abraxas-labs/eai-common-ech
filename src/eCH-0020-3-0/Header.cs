// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0021_7_0;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Der Meldungskopf enthält die für das Dispatching nötigen Informationen.
/// </summary>
[Serializable]
[JsonObject("deliveryHeader")]
[XmlRoot(ElementName = "deliveryHeader", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class Header : eCH_0058_5_0.Header
{
    public Header()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="senderId">Field is reqired.</param>
    /// <param name="originalSenderId">Field can be optional.</param>
    /// <param name="declarationLocalReference">Field can be optional.</param>
    /// <param name="recipientIds">Field can be optional.</param>
    /// <param name="messageId">Field is reqired.</param>
    /// <param name="referenceMessageId">Field can be optional.</param>
    /// <param name="businessProcessId">Field can be optional.</param>
    /// <param name="ourBusinessReferenceId">Field can be optional.</param>
    /// <param name="yourBusinessReferenceId">Field can be optional.</param>
    /// <param name="uniqueIdBusinessTransaction">Field can be optional.</param>
    /// <param name="messageType">Field is reqired.</param>
    /// <param name="subMessageType">Field can be optional.</param>
    /// <param name="sendingApplication">Field is reqired.</param>
    /// <param name="partialDelivery">Field can be optional.</param>
    /// <param name="subject">Field can be optional.</param>
    /// <param name="comment">Field can be optional.</param>
    /// <param name="messageDate">Field is reqired.</param>
    /// <param name="initialMessageDate">Field can be optional.</param>
    /// <param name="eventDate">Field can be optional.</param>
    /// <param name="modificationDate">Field can be optional.</param>
    /// <param name="action">Field is reqired.</param>
    /// <param name="attachment">Field can be optional.</param>
    /// <param name="testDeliveryFlag">Field is reqired.</param>
    /// <param name="responseExpected">Field can be optional.</param>
    /// <param name="businessCaseClosed">Field can be optional.</param>
    /// <param name="namedMetaData">Field can be optional.</param>
    /// <param name="extension">Field can be optional.</param>
    /// <param name="dataLock">Field can be optional.</param>
    /// <param name="dataLockValidFrom">Field can be optional.</param>
    /// <param name="dataLockValidTo">Field can be optional.</param>
    /// <returns>Header.</returns>
    public static Header Create(string senderId, string messageId, string messageType, SendingApplication sendingApplication, DateTime messageDate, string action, bool testDeliveryFlag, string originalSenderId = null, string declarationLocalReference = null, List<string> recipientIds = null, string referenceMessageId = null, string businessProcessId = null, string ourBusinessReferenceId = null, string yourBusinessReferenceId = null, string uniqueIdBusinessTransaction = null, string subMessageType = null, PartialDelivery partialDelivery = null, string subject = null, string comment = null, DateTime? initialMessageDate = null, DateTime? eventDate = null, DateTime? modificationDate = null, List<object> attachment = null, bool? responseExpected = null, bool? businessCaseClosed = null, List<NamedMetaData> namedMetaData = null, object extension = null, DataLockType? dataLock = null, DateTime? dataLockValidFrom = null, DateTime? dataLockValidTo = null)
    {
        return new Header()
        {
            SenderId = senderId,
            OriginalSenderId = originalSenderId,
            DeclarationLocalReference = declarationLocalReference,
            RecipientIds = recipientIds,
            MessageId = messageId,
            ReferenceMessageId = referenceMessageId,
            BusinessProcessId = businessProcessId,
            OurBusinessReferenceId = ourBusinessReferenceId,
            YourBusinessReferenceId = yourBusinessReferenceId,
            UniqueIdBusinessTransaction = uniqueIdBusinessTransaction,
            MessageType = messageType,
            SubMessageType = subMessageType,
            SendingApplication = sendingApplication,
            PartialDelivery = partialDelivery,
            Subject = subject,
            Comment = comment,
            MessageDate = messageDate.ToString("yyyy-MM-ddTHH:mm:ss.fff"),
            InitialMessageDate = initialMessageDate,
            EventDate = eventDate?.ToString("yyyy-MM-dd"),
            ModificationDate = modificationDate,
            Action = action,
            Attachments = attachment,
            TestDeliveryFlag = testDeliveryFlag,
            ResponseExpected = responseExpected,
            BusinessCaseClosed = businessCaseClosed,
            NamedMetaDatas = namedMetaData,
            Extension = extension,
            DataLock = dataLock,
            DataLockValidFrom = dataLockValidFrom,
            DataLockValidTo = dataLockValidTo
        };
    }

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock")]
    public DataLockType? DataLock { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockSpecified => DataLock.HasValue;

    [JsonProperty("dataLockValidFrom")]
    [XmlElement(DataType = "date", ElementName = "dataLockValidFrom")]
    public DateTime? DataLockValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockValidFromSpecified => DataLockValidFrom.HasValue;

    [JsonProperty("dataLockValidTo")]
    [XmlElement(DataType = "date", ElementName = "dataLockValidTo")]
    public DateTime? DataLockValidTo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataLockValidToSpecified => DataLockValidTo.HasValue;
}
