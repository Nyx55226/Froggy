using UnityEngine;

public class ButtonMenuLogic : MonoBehaviour
{
    public void quitBtn()
    {
        PlayerPrefs.DeleteKey("LevelCount");
    }

    public void playBtn()
    {
        GameManager.instance.loadLevel();
    }
}
