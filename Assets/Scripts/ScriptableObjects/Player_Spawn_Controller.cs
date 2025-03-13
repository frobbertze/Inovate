using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Player_Spawn_Controller", menuName = "Scriptable Objects/Player_Spawn_Controller")]
public class Player_Spawn_Controller : ScriptableObject
{

    public Vector3 spawnPosition;

    public string lastSceneName;

}
