using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBtn : MonoBehaviour
{
    public static PopupBtn Instance;
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
        StartBtnl.SetActive(false);
        Deposit.SetActive(true);
    }

    public void OnClickWithdrawal() //출금버튼을 눌렀을때
    {
        StartBtnl.SetActive(false);
        Withdrawal.SetActive(true);
    }

    public void OnClickBack() //뒤로가기 버튼을 눌렀을때
    {
        Deposit.SetActive(false);
        Withdrawal.SetActive(false);
        
        StartBtnl.SetActive(true);
        UserInfo.SetActive(true);
    }

    public void OnClickReback() //잔액부족 뒤로가기 버튼을 눌렀을때
    {
        PupupError.SetActive(false);
    }
}
