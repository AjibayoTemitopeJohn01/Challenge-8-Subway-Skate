using UnityEngine;

[CreateAssetMenu (fileName ="Reward", menuName ="DailyReward/ Reward Database")]
public class RewardDatabase:ScriptableObject
{
    public Rewards[] rewards;
    public int rewardCount {

        get
        {
            return rewards.Length;
        }

        
    }

    public Rewards GetReward(int index) => rewards[index];
}
