using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }

    
}
