using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ArchiveOrgDownloader.XmlModels;

namespace ArchiveOrgDownloader
{
    public static class XmlMethods
    {
        public static T DeserialiseXml<T>(string url)
        {
            var s = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(url))
                return (T)s.Deserialize(reader);
        }
    }
}
