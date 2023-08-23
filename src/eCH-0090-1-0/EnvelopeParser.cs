// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace eCH_0090_1_0;

public static class EnvelopeParser
{
    public static Envelope ParseXmlStringToEnvelope(string envlString)
    {
        var envl = new Envelope();

        var envlXml = new XmlDocument();
        envlXml.LoadXml(envlString);

        var envlXmlNodeList = envlXml.GetElementsByTagName("envelope");

        if (envlXmlNodeList.Count != 1)
        {
            envlXmlNodeList = envlXml.GetElementsByTagName("eCH-0090:envelope");

            if (envlXmlNodeList.Count != 1)
            {
                throw new EnvelopeParserException("The number of envelope elements in the xml must be 1!");
            }
        }

        var envlXmlNode = envlXmlNodeList[0];

        if (envlXmlNode.Attributes == null)
        {
            throw new EnvelopeParserException("Envelope element must contain a version attribute!");
        }

        envl.Version = envlXmlNode.Attributes["version"]?.Value;

        var recipientId = new List<string>();
        var messageClassRead = false;

        foreach (XmlNode childNode in envlXmlNode.ChildNodes)
        {
            if (childNode.Name.Equals("messageId", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:messageId", StringComparison.InvariantCultureIgnoreCase))
            {
                envl.MessageId = childNode.FirstChild.Value;
            }

            if (childNode.Name.Equals("messageType", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:messageType", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!int.TryParse(childNode.FirstChild.Value, out int messageType))
                {
                    throw new EnvelopeParserException($"Error while trying to parse messageType value '{childNode.FirstChild.Value}' to Int32!");
                }
                envl.MessageType = messageType;
            }

            if (childNode.Name.Equals("messageClass", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:messageClass", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!int.TryParse(childNode.FirstChild.Value, out int messageClass))
                {
                    throw new EnvelopeParserException($"Error while trying to parse messageClass value '{childNode.FirstChild.Value}' to Int32!");
                }
                envl.MessageClass = messageClass;
                messageClassRead = true;
            }

            if (childNode.Name.Equals("senderId", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:senderId", StringComparison.InvariantCultureIgnoreCase))
            {
                envl.SenderId = childNode.FirstChild.Value;
            }

            if (childNode.Name.Equals("recipientId", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:recipientId", StringComparison.InvariantCultureIgnoreCase))
            {
                recipientId.Add(childNode.FirstChild.Value);
            }

            if (childNode.Name.Equals("eventDate", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:eventDate", StringComparison.InvariantCultureIgnoreCase))
            {
                envl.EventDate = childNode.FirstChild.Value;
            }

            if (childNode.Name.Equals("messageDate", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:messageDate", StringComparison.InvariantCultureIgnoreCase))
            {
                envl.MessageDate = childNode.FirstChild.Value;
            }

            if (childNode.Name.Equals("referenceMessageId", StringComparison.InvariantCultureIgnoreCase) || childNode.Name.Equals("eCH-0090:referenceMessageId", StringComparison.InvariantCultureIgnoreCase))
            {
                envl.ReferenceMessageId = childNode.FirstChild.Value;
            }
        }

        if (recipientId.Count > 0)
        {
            envl.RecipientId = recipientId.ToArray();
        }

        if (string.IsNullOrEmpty(envl.Version) || envl.Version != "1.0")
        {
            throw new EnvelopeParserException("Version is not valid! Version maust be 1.0");
        }

        if (string.IsNullOrEmpty(envl.MessageId))
        {
            throw new EnvelopeParserException("MessageId is not valid! MessageId is required");
        }

        if (!Regex.Match(envl.MessageId, @"([a-zA-Z]|[0-9]|-){1,36}", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
        {
            throw new EnvelopeParserException("MessageId is not valid! MessageId has to match the regex ([a-zA-Z]|[0-9]|-){1,36}");
        }

        if (!messageClassRead)
        {
            throw new EnvelopeParserException("MessageClass is not valid! MessageClass is required");
        }

        if (envl.MessageType < 0 || envl.MessageType > 2699999)
        {
            throw new EnvelopeParserException($"MessageType is not valid! MessageType must be between 0 and 2699999.");
        }

        if (envl.ReferenceMessageIdSpecified)
        {
            if (!Regex.Match(envl.ReferenceMessageId, @"([a-zA-Z]|[0-9]|-){1,36}", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
            {
                throw new EnvelopeParserException("ReferenceMessageId is not valid! ReferenceMessageId has to match the regex ([a-zA-Z]|[0-9]|-){1,36}");
            }
        }

        if (string.IsNullOrEmpty(envl.SenderId))
        {
            throw new EnvelopeParserException("SenderId is not valid! SenderId is required");
        }

        if (!Regex.Match(envl.SenderId, @"T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success)
        {
            throw new EnvelopeParserException("SenderId is not valid! SenderId has to match the regex (T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)");
        }

        if (envl.RecipientId == null || !envl.RecipientId.Any())
        {
            throw new EnvelopeParserException("RecipientId is not valid! RecipientId is required");
        }

        if (envl.RecipientId.Any(s => string.IsNullOrEmpty(s) || !Regex.Match(s, @"T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0", RegexOptions.None, TimeSpan.FromMilliseconds(500)).Success))
        {
            throw new EnvelopeParserException("RecipientId is not valid! Eevery element of RecipientId has to match the regex (T?[1-9]-[0-9A-Z]+-[0-9]+|T?0-sedex-0)");
        }

        return envl;
    }

    public static Envelope ParseXmlFileToEnvelope(string envlFilePath)
    {
        if (File.Exists(envlFilePath))
        {
            return ParseXmlStringToEnvelope(File.ReadAllText(envlFilePath));
        }

        throw new EnvelopeParserException($"Xml file '{envlFilePath}' does not exist!");
    }
}
