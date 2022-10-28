using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace DailyrewardSystem
{
   
    public class DailyReward : MonoBehaviour
    {
        [Header("Main Menu")]
        [SerializeField] Text coinText;

        [Space]

        [Header("Reward UI")]
        [SerializeField] GameObject coinCanvas;
        [SerializeField] Button OpenButton,CloseButton, claimButton;


        [Space]

        [Header("Reward Database")]
        [SerializeField] RewardDatabase db;
        private int nextReward;


        private void Start()
        {
            Initalize();
        }
        void Initalize()
        {
            nextReward = PlayerPrefs.GetInt("Next Reward", 0);
            updateCoinTextUI();
           
            claimButton.onClick.RemoveAllListeners();
            claimButton.onClick.AddListener(ClaimButton);
        }

        private void ClaimButton()
        {
            Rewards reward = db.GetReward(nextReward);


            //Choose reward type
           
        }

        private void updateCoinTextUI()
        {

            coinText.text = GameData.Coins.ToString();
        }

        void openButton()
        {
            coinCanvas.SetActive(true);
        }
        void closeButton()
        {
            coinCanvas.SetActive(false);
        }
    }
}