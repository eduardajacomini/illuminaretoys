using System.Xml.Serialization;

namespace IlluminareToys.Infrastructure.Bling.Contracts
{
    [XmlRoot(ElementName = "produto")]
    public class PutImageInProductRequest
    {
        [XmlElement(ElementName = "codigo")]
        public string Code { get; set; }

        [XmlElement(ElementName = "descricao")]
        public string Description { get; set; }

        [XmlElement(ElementName = "imagens")]
        public ImageRequest Images { get; set; }
    }

    [XmlRoot(ElementName = "imagens")]
    public record ImageRequest
    {
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
    }
}
