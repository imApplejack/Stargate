using Stargate;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace Stargate.Stargate
{

    public class Decklist
    {
        public Decklist() {
        }
        public List<string> team = new List<string>();
        public List<string> mission = new List<string>();
        public List<string> library = new List<string>();
    }

    public class DeckImporter
    {


        public string Path { get; set; } = String.Empty;


        /*
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
                //string value = element.Attributes["value"].Value;

                switch (element.Attributes["name"].Value)
                {


                    case "Type":
                        switch (element.Attributes["value"].Value)
                        {
                            case "Adversary" :  c.Type = CardType.Adversary; break;
                            case "Support Character": c.Type = CardType.SupportCharacter; break;
                            case "Mission": c.Type = CardType.Mission   ; break;
                            case "Team Character": c.Type = CardType.TeamCharacter  ; break;
                            case "Obstacle": c.Type = CardType.Obstacle; break;
                            case "Gear": c.Type = CardType.Gear; break;
                            case "Event": c.Type = CardType.Event ; break;

                        }

                        break;


                    case "Subtitle":
                        c.Subtitle = element.Attributes["value"].Value;
                        break;

                    case "Cost":
                        c.Cost = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Culture":
                        c.Culture = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Science":
                        c.Science = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Ingenuity":
                        c.Ingenuity = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Combat":
                        c.Combat = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Revive":
                        c.Revive = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Experience":
                        c.Experience = int.Parse(element.Attributes["value"].Value);
                        break;

                    case "Glyph":
                        switch (element.FirstChild.Attributes["value"].Value)
                        {
                            case "l":
                                c.Glyphe = Glyphe.Libra;
                                break;
                            case "o":
                                c.Glyphe = Glyphe.Orion;
                                break;
                            case "p":
                                c.Glyphe = Glyphe.Pisces;
                                break;
                            case "s":
                                c.Glyphe = Glyphe.Scorpius;
                                break;
                            case "t":
                                c.Glyphe = Glyphe.Triangulum;
                                break;
                            case "g":
                                c.Glyphe = Glyphe.Gemini;
                                break;
                        }
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




        public SGCard GetCardFromGUID(string guid)
        {
            if (list.ContainsKey(guid))
            {
                return list[guid];
            }
            else throw new Exception("card not found in lib");
      
        }

           */
        public Decklist Load(string deckname)
        {
           Decklist retour = new Decklist();

            XmlDocument xml = new XmlDocument();
            
            xml.Load(Path + deckname);


            Debug.WriteLine("Main");
            XmlNodeList Nodes = xml.SelectNodes("deck/section[@name='Main']");
            foreach (XmlElement CardNode in Nodes[0].SelectNodes("card"))
            {
                for (int i = 0;  i < int.Parse(CardNode.Attributes["qty"].Value); i++)
                {
                    retour.library.Add(CardNode.Attributes["id"].Value);
                }
            }


            Debug.WriteLine("Team");
            XmlNodeList Nodes2 = xml.SelectNodes("deck/section[@name='Team']");
            foreach (XmlElement CardNode in Nodes2[0].SelectNodes("card"))
            {
                for (int i = 0; i < int.Parse(CardNode.Attributes["qty"].Value); i++)
                {
                    retour.team.Add(CardNode.Attributes["id"].Value);
                }
            }

            Debug.WriteLine("Mission Pile");
            XmlNodeList Nodes3 = xml.SelectNodes("deck/section[@name='Mission Pile']");
            foreach (XmlElement CardNode in Nodes3[0].SelectNodes("card"))
            {
                for (int i = 0; i < int.Parse(CardNode.Attributes["qty"].Value); i++)
                {
                    retour.mission.Add(CardNode.Attributes["id"].Value);
                }
            }
            return retour;
        }

     
    }
}
