using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Enum
{


    public enum Skill
    {
        None = 0,
        Culture = 1,
        Science= 2,
        Combat = 4,
        Ingenuity = 8,
        ALL = Culture & Science & Combat & Ingenuity
    };

    public enum CardState
    {
        NONE = 0,
        Hand = 1,
        Library = 2,
        Ready = 4,
        Mission = 8,
        Stop = 16,
        Disabled = 32,
        Destroy = 64,
        MissionPile = 128,
        Aside = 256,
        Board = Ready | Stop | Disabled
    };


    public enum CardType
    {
        NONE = 0,
        Adversary = 1,
        SupportCharacter = 2,
        Event = 4,
        Gear = 8,
        Obstacle = 16,
        TeamCharacter = 32,
        Mission = 64,
        HeroPlayerMissionObjets = SupportCharacter | TeamCharacter,
        VIllanPlayerMissionObjects = Adversary | Obstacle,
        Character =  SupportCharacter | TeamCharacter | Adversary,
        HeroPlayerAction = TeamCharacter | SupportCharacter | Gear | Event,
        VillanPlayerAction = Adversary | Obstacle
    };

    public enum Glyphe
    {
        Orion,
        NONE
    };
}
