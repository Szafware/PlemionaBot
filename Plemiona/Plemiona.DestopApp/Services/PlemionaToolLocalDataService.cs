using Plemiona.DestopApp.Models;
using System.IO;
using System.Xml.Serialization;

namespace Plemiona.DestopApp.Services
{
    public class PlemionaToolLocalDataService
    {
        private readonly string _fileName = "PlemionaToolLocalData.xml";

        public void Save(PlemionaToolLocalData plemionaToolLocalData)
        {
            using (var streamWriter = new StreamWriter(_fileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(PlemionaToolLocalData));

                xmlSerializer.Serialize(streamWriter, plemionaToolLocalData);
            }
        }

        public PlemionaToolLocalData Load()
        {
            if (!File.Exists(_fileName))
            {
                Save(new PlemionaToolLocalData());
            }

            using (var streamWriter = new StreamReader(_fileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(PlemionaToolLocalData));

                var plemionaToolLocalData = (PlemionaToolLocalData)xmlSerializer.Deserialize(streamWriter);

                return plemionaToolLocalData;
            }
        }
    }
}