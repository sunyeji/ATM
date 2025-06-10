using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;

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
        GameManager.Instance.Refresh();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(GameManager.Instance.userData);
        File.WriteAllText(Directory.GetCurrentDirectory() + "/UserData.json", json);
        
        Debug.Log("저장완료");
    }

    public void LoadData()
    {
        string path = Directory.GetCurrentDirectory() + "/UserData.json";//Application.persistentDataPath
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameManager.Instance.userData = JsonUtility.FromJson<UserData>(json);
            
            Debug.Log("불러오기 성공. 유저 이름: " + GameManager.Instance.userData.userName);
            Debug.Log("통장잔액: " + GameManager.Instance.userData.coin + ", 현금: " + GameManager.Instance.userData.money);
        }
    }
}
