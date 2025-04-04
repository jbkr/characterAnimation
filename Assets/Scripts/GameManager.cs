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
        startButton.onClick.AddListener(onClickStartButton);
    }

    private void onClickStartButton()
    {
        Debug.Log("start button");
        startButton.gameObject.SetActive(false);

        GameObject loadedModeUI = Resources.Load<GameObject>("Prefabs/ModeUI");
        GameObject instanceModeUI = Instantiate<GameObject>(loadedModeUI, target, false);

        ModeUI modeUI = instanceModeUI.GetComponent<ModeUI>();
        modeUI.onClickTimeAttack(TimeAttackMode);
        modeUI.onClickStage(StageMode);
    }

    private void TimeAttackMode()
    {
        Debug.Log("Time Attack Mode");
        StartCoroutine(LoadSceneAsync("GameScene"));

        GameObject character = Resources.Load<GameObject>("Prefabs/Character");
        Instantiate(character);
    }

    private void StageMode()
    {
        Debug.Log("Stage Mode");
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        Debug.Log("Game Scene Load");
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    void Update()
    {

    }
}
