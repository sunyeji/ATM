using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserData
{
    [Header("기본 유저 정보")]
    public string userName; 
    public int coin; 
    public int money;
    
    public UserData(string userName, int coin, int money)
    {
        this.userName = userName;
        this.coin = coin;
        this.money = money;
    }
}