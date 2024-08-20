using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    private int standartCoin = 10;
    private int bigCoin = 50;
    private int eatGhost = 200;
    public int StandartCoin
    {
        get
        {
            return standartCoin;
        }
        set
        {
            standartCoin = value;
        }
    }
    public int BigCoin
    {
        get
        {
            return bigCoin;
        }
    }
    public int EatGhost
    {
        get
        {
            return eatGhost;
        }
        set
        {
            eatGhost = value;
        }
    }
}
