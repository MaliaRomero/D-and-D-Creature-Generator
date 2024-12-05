using UnityEngine;
using System;

public class ScalesFactory : IMonsterFactory
{
    public IMonster Create(MonsterRequirements requirements)
    {
        if (requirements.Eyes < 2)
            return requirements.IsFlying ? new Dracolich() : new Nothic();
        else if (requirements.Eyes == 2)
            return requirements.IsFlying ? new Dragon() : new Basilisk();
        else
            return requirements.IsFlying ? new Beholder() : new Hydra();
    }
}