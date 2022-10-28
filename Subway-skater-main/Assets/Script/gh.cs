
using UnityEngine;
using UnityEngine.UI;
public class gh : MonoBehaviour
{
    public Text muteText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
            muteText.text = "/";
        else
            muteText.text = "";
    }

    
    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            muteText.text = "";
            GameManager.Instance.ResumeGame();

        }
        else
        {
            GameManager.mute = true;
            muteText.text = "/";

        }
    }

}
