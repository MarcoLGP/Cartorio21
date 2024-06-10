using System.IO;
using System.Xml.Serialization;

namespace Cartório21.Business
{
    public static class Utils
    {
        public static T DesiralizarXML<T>(string caminhoArquivoXML)
        {
            using (StreamReader reader = new StreamReader(caminhoArquivoXML))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                var xmlDesiralizado =  (T)serializer.Deserialize(reader);
                reader.Close();

                return xmlDesiralizado;
            }
        }
    }
}
