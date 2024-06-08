using System.IO;
using System.Xml.Serialization;

namespace Cartório21.Business
{
    public static class Utils
    {
        public static T MesclarObjetos<T>(params object[] objetos) where T : new()
        {
            T resultado = new T();

            foreach (var objeto in objetos)
            {
                foreach (var prop in objeto.GetType().GetProperties())
                {
                    if (resultado.GetType().GetProperty(prop.Name) != null)
                        resultado.GetType().GetProperty(prop.Name).SetValue(resultado, prop.GetValue(objeto));
                }
            }

            return resultado;
        }
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
