using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    void Start()
    {
        GameObject resCharacter = Resources.Load<GameObject>("Prefabs/Character");
        GameObject sceneCharacter = Instantiate(resCharacter);
    }

    void Update()
    {
        
    }
}
