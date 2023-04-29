using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public string name;
    public int health;
    public int damage;
    public int defence;
    // public string name = "";
    // public int coins = 0;
}


[System.Serializable]
public class PlayerList
{
    public PlayerData[] playerData;
}
