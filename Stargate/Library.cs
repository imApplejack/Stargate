using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Stargate.SGGodot;
using Stargate.Stargate.Enum;

namespace Stargate.Stargate
{

    
    public class Library
    {

        CardImporter cardImporter = null;

        public Library(string path) {

            cardImporter = new CardImporter() { Path = path + Const.SetFile };
            cardImporter.Load();
        }

        public SGCard getCardByGuid(string guid) // id = hash bdd
        {
            return cardImporter.GetCardFromGUID(guid);
        }



        /**
         * genere un deck depuis une liste de hash bdd
         */
        public List<SGCard> GetCardsFromGuidList(List<string> hashlist)
        {
            List<SGCard> retour = new List<SGCard>();

            foreach (string hash in hashlist)
            {
                retour.Add(this.getCardByGuid(hash));
            }
          
            return retour;
        }

          
    }

}

