using UnityEngine;

public class MenuScript : MonoBehaviour
{
  public void StartNewGame()
    {
        Scenes_Controller.LoadScene(Scenes.TestingScene);
    }

    public void ContinueGame()
    {
        //load existing game and continue on the correct scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
