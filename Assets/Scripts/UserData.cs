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
    
    public UserData(string userName, int coin, int money) //매개변수
    {
        this.userName = userName; //위에 변수이름은 매개변수에 적혀있는 유저네임으로 정한다
        this.coin = coin;
        this.money = money;
    }
}