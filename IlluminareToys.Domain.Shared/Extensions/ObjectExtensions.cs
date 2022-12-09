using System.Xml;
using System.Xml.Serialization;

namespace IlluminareToys.Domain.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToXml<T>(this T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using var sww = new StringWriter();

            using var writer = new XmlTextWriter(sww)
            {
                Formatting = Formatting.Indented
            };

            serializer.Serialize(writer, obj);

            var xml = sww.ToString();

            xml = xml.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            xml = xml.Replace("utf-16", "UTF-8");

            return xml;
        }
    }
}
