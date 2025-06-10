using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
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
            PopupBtn.Instance.PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
    
    
    public void CostomDeposit() //자유입금
    {
        int isinputDeposit = int.Parse(PopupBtn.Instance.inputDeposit.text);

        if (GameManager.Instance.userData.money >= isinputDeposit)
        {
            GameManager.Instance.userData.money -= isinputDeposit;
            GameManager.Instance.userData.coin += isinputDeposit;
            Debug.Log("자유입금 되었습니다.");
            
            PopupBtn.Instance.inputDeposit.text = ""; //텍스트 쓰고 지우는 문구 
            UserManager.Instance.SaveData();
            GameManager.Instance.Refresh();
        }

        else
        {
            PopupBtn.Instance.PupupError.SetActive(true);
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
            PopupBtn.Instance.PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
    
    public void CostomWithdrawal() //자유 출금
    {
        int isinputWithdrawal = int.Parse(PopupBtn.Instance.inputWithdrawal.text);
        if (GameManager.Instance.userData.coin >= isinputWithdrawal)
        {
            GameManager.Instance.userData.money += isinputWithdrawal;
            GameManager.Instance.userData.coin -= isinputWithdrawal;
            Debug.Log("자유출금 되었습니다.");
            
            PopupBtn.Instance.inputWithdrawal.text = ""; //텍스트 쓰고 지우는 문구 
            UserManager.Instance.SaveData();
            GameManager.Instance.Refresh();
            
        }

        else
        {
            
            PopupBtn.Instance.PupupError.SetActive(true);
            Debug.Log("잔액이 부족합니다.");
        }
    }
}
