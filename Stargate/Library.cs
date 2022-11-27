using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Stargate.Stargate.Enum;

namespace Stargate.Stargate
{
    public class Library
    {

        public SGCard getCardById(string id) // id = hash bdd
        {

            // mock 3 chars
            switch (id)
            {
                case 
                    "79974bc9-9b81-41e1-8868-c75f8fc58837":
                    return new SGCard() { Id = id, Name = "Anise", Cost = 4, Culture = 2, Science = 1, Type= CardType.SupportCharacter};

                case "4901fb59-e7cc-47d4-8f3a-4f1f2e93f78d":
                    return new SGCard() { Id = id, Name = "Jack O'Neill", Cost = 3, Culture = 0, Science = 1, Combat = 3, Ingenuity = 3 , Type = CardType.TeamCharacter };

                case "dd59e9ee-9cf8-4d61-b891-5477c550b2b1":
                    return new SGCard() { Id = id, Name = "Yu", Cost = 2, Culture = 2, Combat = 2, Revive = 3,  Type = CardType.Adversary };
                default: return null;

                    
            }
        }



        /**
         * genere un deck depuis une liste de hash bdd
         */
        public List<SGCard> GetCardsFromHashList(List<string> hashlist)
        {
            List<SGCard> retour = new List<SGCard>();

            foreach (string hash in hashlist)
            {
                retour.Add(this.getCardById(hash));
            }
          
            return retour;
        }

          
    }

}

