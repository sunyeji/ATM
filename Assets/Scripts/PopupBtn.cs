using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBtn : MonoBehaviour
{
    public static PopupBtn Instance; //싱글톤
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
    
    public UserData userData;
    
    [Header("입출금 판넬 버튼들")]
    public GameObject UserInfo;
    public GameObject Deposit;
    public GameObject Withdrawal;
    public GameObject StartBtnl;
    
    [Header("직접 입출금값 지정")]
    public TMP_InputField inputDeposit;
    public TMP_InputField inputWithdrawal;
    
    [Header("돈부족 판넬")]
    public GameObject PupupError;
    
    
    void Start() 
    {
        Deposit.SetActive(false); //입금창
        Withdrawal.SetActive(false); //출금창
    }

    public void OnClickDeposit() //입금버튼을 눌렀을때
    {
        StartBtnl.SetActive(false); //스타트버튼은 사라지고
        Deposit.SetActive(true); //입금창이 뜬다
    }

    public void OnClickWithdrawal() //출금버튼을 눌렀을때
    {
        StartBtnl.SetActive(false); //스타트 버튼이 사라지고
        Withdrawal.SetActive(true); //출금창이 뜬다
    }

    public void OnClickBack() //뒤로가기 버튼을 눌렀을때
    {
        Deposit.SetActive(false); //입금창 사라짐
        Withdrawal.SetActive(false); //출금창 사라짐
        
        StartBtnl.SetActive(true); //스타트버튼이 생기고
        UserInfo.SetActive(true); //기본 창이 뜬다.
    }

    public void OnClickReback() //잔액부족 뒤로가기 버튼을 눌렀을때
    {
        PupupError.SetActive(false); //에러창이 꺼진다
    }
}
