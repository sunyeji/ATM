using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance; // ✅ 싱글톤 인스턴스

    public UserData userData = new UserData("선예지", 100000, 50000);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject); // 이미 있다면 중복 제거
        }
        
        LoadData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(userData);
        File.WriteAllText(Application.persistentDataPath + "/UserData.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/UserData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            userData = JsonUtility.FromJson<UserData>(json);
            
            Debug.Log("불러오기 성공. 유저 이름: " + userData.userName);
            Debug.Log("코인: " + userData.coin + ", 통장 잔액: " + userData.money);
        }
    }
}
