using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBtn : MonoBehaviour
{
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
    
    public void DepositAmount(int amount)  //입금
    {
        int money = int.Parse(GameManager.Instance.moneyText.text.Replace(",", ""));  //마지막 문구는 문자열 쉼표제거
        int coin = int.Parse(GameManager.Instance.coinText.text.Replace(",", ""));
        
        if (money >= amount) 
        {
            money -= amount;
            coin += amount;


            GameManager.Instance.userData.money = money;
            GameManager.Instance.userData.coin = coin;
            Debug.Log("입금 되었습니다.");
            
            UserManager.Instance.SaveData();
            GameManager.Instance.Refresh();
        }
        else
        {
            PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
    
    
    public void CostomDeposit() //자유입금
    {
        int isinputDeposit = int.Parse(inputDeposit.text);

        if (GameManager.Instance.userData.money >= isinputDeposit)
        {
            GameManager.Instance.userData.money -= isinputDeposit;
            GameManager.Instance.userData.coin += isinputDeposit;
            Debug.Log("자유입금 되었습니다.");
            
            UserManager.Instance.SaveData();
            GameManager.Instance.Refresh();
        }

        else
        {
            PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
    
    
    public void WithdrawalAmount(int amount) //출금
    {
        int money = int.Parse(GameManager.Instance.moneyText.text.Replace(",", ""));
        int coin = int.Parse(GameManager.Instance.coinText.text.Replace(",", ""));

        if (coin >= amount)
        {
            money += amount;
            coin -= amount;
            
            GameManager.Instance.userData.coin = coin;
            GameManager.Instance.userData.money = money;
            Debug.Log("출금 되었습니다.");
            
            UserManager.Instance.SaveData();
            GameManager.Instance.Refresh();
            
        }
        else
        {
            PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
    
    public void CostomWithdrawal() //자유 출금
    {
        int isinputWithdrawal = int.Parse(inputWithdrawal.text);
        if (GameManager.Instance.userData.coin >= isinputWithdrawal)
        {
            GameManager.Instance.userData.money += isinputWithdrawal;
            GameManager.Instance.userData.coin -= isinputWithdrawal;
            Debug.Log("자유출금 되었습니다.");
            
            UserManager.Instance.SaveData();
            GameManager.Instance.Refresh();
            
        }

        else
        {
            
            PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
}
