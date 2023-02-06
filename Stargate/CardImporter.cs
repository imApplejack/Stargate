using Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace StargateConsole.Importer
{
    public class CardImporter
    {


        public string Path { get; set; } = String.Empty;


        


        private SGCard generateCardFromXmlElement(XmlElement element)
        {

            string name = element.Attributes["name"].Value;
            string id = element.Attributes["name"].Value;

            var Property =  element.SelectSingleNode("property[@name='Type']"); // ici on a le type de card -> faire un switch pour appeler la factory correspondant au type

            /*
            foreach (XmlElement CardNode in element.SelectSingleNode["property"])
            {

            }
            */


            return new SGCard();
        }

        public List<SGCard> Process()
        {
            List<SGCard> retour = new List<SGCard>();

            XmlDocument xml = new XmlDocument();


            xml.Load(Path);
            XmlNodeList Nodes = xml.SelectNodes("set/cards/card");


            foreach (XmlElement CardNode in Nodes)
            {
                this.generateCardFromXmlElement(CardNode);
            }

            /*
         
            XmlReader reader = XmlReader.Create(this.Path);


            reader.ReadToFollowing("card");

            //reader.ReadEndElement

            do
            {

                switch (reader.NodeType)
                {
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Element:
                        Console.WriteLine("Element " + reader.Name);
                        break;
                    case XmlNodeType.Attribute:
                        Console.WriteLine("Attribute");
                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.CDATA:
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine("Endelement");
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        break;
                }

                //Console.WriteLine($"NodeType: {reader.NodeType}");
            } while (reader.Read());

            */
            /*
            do
            {
                reader.MoveToFirstAttribute();
                Console.WriteLine($"{reader.Name}: {reader.Value}");
                reader.MoveToNextAttribute(); 
                Console.WriteLine($"{reader.Name}: {reader.Value}");



                reader.ReadToFollowing("property");
                do
                {



                    do
                    {

                        Console.WriteLine($"StartElement: {reader.}");

                        Console.WriteLine($"NodeType: {reader.NodeType}");

                        //Console.WriteLine($"  {reader.Name}: {reader.Value}");
                    } while (reader.MoveToNextAttribute());



                } while (reader.ReadToFollowing("property"));


                Console.WriteLine("-------------------------");

            } while (reader.ReadToFollowing("card"));
            */

            return retour;

        }






    }
}
