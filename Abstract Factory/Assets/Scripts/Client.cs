using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Client : MonoBehaviour
{
    public TMP_Text MonsterName;
    public Image MonsterImage;
    public Sprite[] MonsterSprites;

    private int eyes;
    private int factoryType;
    private bool isFlying;

    public void SetEyes(int value)
    {
        eyes = value;
    }

    public void SetFactory(int type)
    {
        factoryType = type;
    }

    public void SetFlying(bool value)
    {
        isFlying = value;
    }

    public void GenerateMonster()
    {
        MonsterRequirements requirements = new MonsterRequirements
        {
            Eyes = eyes,
            IsFlying = isFlying
        };

        IMonsterFactory factory = GetFactory(factoryType);
        if (factory == null)
        {
            Debug.LogError("Invalid factory type selected.");
            return;
        }

        IMonster monster = factory.Create(requirements);
        MonsterName.text = monster.GetType().Name;
        int spriteIndex = GetSpriteIndex(monster);
        if (spriteIndex >= 0 && spriteIndex < MonsterSprites.Length)
        {
            MonsterImage.sprite = MonsterSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Invalid sprite index.");
        }
    }

    private IMonsterFactory GetFactory(int type)
    {
        return type switch
        {
            0 => new ScalesFactory(),
            1 => new SlimeFactory(),
            2 => new FurFactory(),
            _ => null // Return null if the type is invalid
        };
    }

    private int GetSpriteIndex(IMonster monster)
    {
        if (monster is Basilisk) return 0;
        if (monster is Beholder) return 1;
        if (monster is Chimera) return 2;
        if (monster is Darkmantle) return 3;
        if (monster is Demogorgon) return 4;
        if (monster is Dracolich) return 5;
        if (monster is Dragon) return 6;
        if (monster is Flumph) return 7;
        if (monster is GelatinousCube) return 8;
        if (monster is GibberingMouther) return 9;
        if (monster is Grell) return 10;
        if (monster is Griffon) return 11;
        if (monster is Grimlock) return 12;
        if (monster is Hydra) return 13;
        if (monster is Nothic) return 14;
        if (monster is Owlbear) return 15;
        if (monster is RugOfSmothering) return 16;
        if (monster is Slaad) return 17;
        return -1;
    }
}