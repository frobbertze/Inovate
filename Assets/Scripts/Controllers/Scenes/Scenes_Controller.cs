using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Controller : MonoBehaviour
{

    public static Scenes_Controller Instance;

    

    private void Awake()
    {
        Instance = this;
    }

    public static void LoadScene(Scenes scene)
    {

        SceneManager.LoadScene(scene.ToString());

    }

   public static Scene ActiveScene()
   {

        return  SceneManager.GetActiveScene();

   }

}
