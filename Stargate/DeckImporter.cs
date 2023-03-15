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
        public DeckImporter(string path)
        {
            Path = path;
        }

        public string Path { get; set; } = String.Empty;


      
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
