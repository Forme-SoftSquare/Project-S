using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeStats
{

    internal int attack;
    internal int defense;
    internal int speed;

    public ShapeStats(int attack, int defense, int speed)
    {
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
    }
}
