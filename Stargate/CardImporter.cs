using Stargate;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace Stargate.Stargate
{
    public class CardImporter
    {


        public string Path { get; set; } = String.Empty;

        public Dictionary<string, SGCard> list = new Dictionary<string, SGCard>();


        private SGCard generateCardFromXmlElement(XmlElement element)
        {

            string name = element.Attributes["name"].Value;
            string id = element.Attributes["id"].Value;

            string type = element.SelectSingleNode("property[@name='Type']").Attributes["value"].Value; // ici on a le type de card -> faire un switch pour appeler la factory correspondant au type

            SGCard card =  GenerateCard(element);
            card.Name = name;
            card.Id = id;
            list[card.Id] = card;
            return card;


            
        }

        private void FillPropertyValue(SGCard c, XmlNode element)
        {

            try
            {
                
                // TODO le texte n'est pas une value a faire
                string value = element.Attributes["value"].Value;

                switch (element.Attributes["name"].Value)
                {


                    case "Type":
                        switch (value)
                        {
                            case "Adversary" :  c.Type = CardType.Adversary; break;
                            case "Support Character": c.Type = CardType.SupportCharacter; break;
                            case "Mission": c.Type = CardType.Mission   ; break;
                            case "Team Character": c.Type = CardType.TeamCharacter  ; break;

                        }

                        break;


                    case "Subtitle":
                        c.Subtitle = value;
                        break;

                    case "Cost":
                        c.Cost = int.Parse(value);
                        break;

                    case "Culture":
                        c.Culture = int.Parse(value);
                        break;

                    case "Science":
                        c.Science = int.Parse(value);
                        break;

                    case "Ingenuity":
                        c.Ingenuity = int.Parse(value);
                        break;

                    case "Combat":
                        c.Combat = int.Parse(value);
                        break;

                    case "Revive":
                        c.Revive = int.Parse(value);
                        break;

                }

            }catch(Exception ex) { 
            
                // logger dans les TU pour implementer les manquantes, event armes ect...
            }
            
        }


        private SGCard GenerateCard(XmlElement element)
        {
            SGCard c = new SGCard() { };
            foreach(XmlNode item in element.ChildNodes)
            {
                FillPropertyValue(c, item);

            }


            return c;
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
            return retour;
        }


    }
}
