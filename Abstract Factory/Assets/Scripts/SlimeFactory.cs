using UnityEngine;
using System;
public class SlimeFactory : IMonsterFactory
{
    public IMonster Create(MonsterRequirements requirements)
    {
        if (requirements.Eyes < 2)
            return requirements.IsFlying ? new Grell() : new GelatinousCube();
        else if (requirements.Eyes == 2)
            return requirements.IsFlying ? new Flumph() : new Slaad();
        else
            return requirements.IsFlying ? new Darkmantle() : new GibberingMouther();
    }
}