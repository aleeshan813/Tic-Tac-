using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public TextMeshProUGUI mLabel;
    public Button mButton;
    internal Main mMain;

    public void Fill()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Click);
        mButton.interactable = false;
        mLabel.text = mMain.GetTurnCharacter();
        mMain.Switch();
    }
}
