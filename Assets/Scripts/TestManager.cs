using UnityEngine;

public class TestManager : MonoBehaviour
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
