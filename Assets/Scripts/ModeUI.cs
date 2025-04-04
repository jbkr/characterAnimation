using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    private Button timeAttackButton;

    [SerializeField]
    private Button stageModeButton;

    void Start()
    {

    }

    public void onClickTimeAttack(UnityAction callBackAction)
    {
        timeAttackButton.onClick.AddListener(callBackAction);
    }

    public void onClickStage(UnityAction callBackAction)
    {
        stageModeButton.onClick.AddListener(callBackAction);
    }

    void Update()
    {

    }
}
