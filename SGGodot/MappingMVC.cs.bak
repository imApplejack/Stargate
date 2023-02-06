using Godot;
using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.SGGodot
{
    public class MappingMVC
    {

        public Dictionary<CardModel, GDCard> Mapping = new Dictionary<CardModel, GDCard>();


        public void InitRessources(List<CardModel> cards)
        {
            foreach (CardModel item in cards)
            {
               initCardModel(item);
            }
        }

        public void initCardModel(CardModel model)
        {
            var scene = GD.Load<PackedScene>("res://SGGodot/"+model.Card.Type.ToString()+".tscn");
            GDCard instance = (GDCard)scene.Instance();
            TextureRect cardBackground = (TextureRect)instance.FindNode("Cardbackground");
            cardBackground.Texture = ResourceLoader.Load(Const.AssetPath + "/" + model.Card.Id + ".jpg") as Texture;

            //CardModel.CardModelObservable += new EventHandler(instance.HandleRefreshCard);
            instance.Card = model;
            this.Add(model, instance);
        }

        
        public void Add(CardModel CardModel, GDCard gDCard)
        {
            Mapping.Add(CardModel, gDCard);
        }

        public GDCard Get(CardModel CardModel)
        {
            return Mapping[CardModel];
        }


    }
}
