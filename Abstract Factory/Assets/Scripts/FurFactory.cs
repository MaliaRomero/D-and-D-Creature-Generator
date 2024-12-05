using UnityEngine;
using System;
public class FurFactory : IMonsterFactory
{
    public IMonster Create(MonsterRequirements requirements)
    {
        if (requirements.Eyes < 2)
            return requirements.IsFlying ? new RugOfSmothering() : new Grimlock();
        else if (requirements.Eyes == 2)
            return requirements.IsFlying ? new Griffon() : new Owlbear();
        else
            return requirements.IsFlying ? new Chimera() : new Demogorgon();
    }
}
