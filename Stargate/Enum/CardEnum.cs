using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Enum
{
    public enum CardState
    {
        Team,
        Hand,
        Library,
        Ready,
        Mission,
        Stop,
        Disabled,
        Destroy,
        MissionPile
    };


    public enum CardType
    {
        Adversary,
        SupportCharacter,
        Event,
        Gear,
        Obstacle,
        TeamCharacter,
        Mission,
        NONE
    };

    public enum Glyphe
    {
        Orion,
        NONE
    };
}
