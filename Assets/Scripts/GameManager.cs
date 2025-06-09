using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
    
    [Header("바뀔 유저 정보")]
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI moneyText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        userData = new UserData("선예지", 50000, 100000);
        
        Refresh();
    }

    public void Refresh() //리프레시로 한번 선언해두고 다음에 다른곳에서 호출되어야 할때 그냥 이것만 가져가서 사용할때 쓰는 문장
    {
        userNameText.text = userData.userName; //유저네임텍스트에 텍스트에, 유저테이터안에 유저네임을 가져오겠다.
        coinText.text = userData.coin.ToString("N0"); //숫자를 스트링값으로 가져오는것
        moneyText.text = userData.money.ToString("N0");
    }
    
}
