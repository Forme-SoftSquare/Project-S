using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeStats
{
    // Stats /100
    internal int attack;
    internal int defense;
    internal int speed;

    // speed used for movement
    internal int moveSpeed => speed /5;

    public ShapeStats(int attack, int defense, int speed)
    {
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
    }
}