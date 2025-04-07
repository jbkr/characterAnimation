using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Transform target;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        startButton.onClick.AddListener(onClickStartButton);
    }

    private void onClickStartButton()
    {
        startButton.gameObject.SetActive(false);

        GameObject loadedModeUI = Resources.Load<GameObject>("Prefabs/ModeUI");
        GameObject instanceModeUI = Instantiate<GameObject>(loadedModeUI, target, false);

        ModeUI modeUI = instanceModeUI.GetComponent<ModeUI>();
        modeUI.onClickTimeAttack(TimeAttackMode);
        modeUI.onClickStage(StageMode);
    }

    private void TimeAttackMode()
    {
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private void StageMode()
    {
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);

        GameObject resCharacter = Resources.Load<GameObject>("Prefabs/Character");
        GameObject sceneCharacter = Instantiate(resCharacter);
    }
}
