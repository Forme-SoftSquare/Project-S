using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeStats
{
    // Stats / 100
    internal int attack;
    internal int defense;
    private int speed;

    public ShapeStats(int attack, int defense, int speed)
    {
        this.attack = attack;
        this.defense = defense;
        this.Speed = speed;
    }

    public int Speed
    {
        get { return speed / 5; }
        private set { speed = value; }
    }
}