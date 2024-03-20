using System.Collections;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI X_text;
    [SerializeField] TextMeshProUGUI O_text;
    int xCout = 0;
    int oCout = 0;

    public Board mBoard;
    public GameObject mWinner;
    [SerializeField] AudioManager mAudioManager;

    bool mXTurn = true;
    int mTurnCount = 0;

    private void Awake()
    {
        mBoard.Build(this);
        mAudioManager.PlaymusicSound(mAudioManager.GameStrt);
    }

    public void Switch()
    {
        mTurnCount++;
        bool hasWinner = mBoard.CheckForWinner();
        if (hasWinner || mTurnCount == 9)
        {
            //End Game
            StartCoroutine(EndGame(hasWinner));
        }
        mXTurn = !mXTurn;
    }

    public string GetTurnCharacter()
    {
        if (mXTurn)
        {
            xCout++;
            print(xCout);
            X_text.text = xCout.ToString();
            return "X";  
        }
        else
        {
            oCout++;
            print(oCout);
            O_text.text = oCout.ToString();
            return "O"; 
        }
    }

    IEnumerator EndGame (bool hasWinner) 
    {
        TextMeshProUGUI winnerLabel = mWinner.GetComponentInChildren<TextMeshProUGUI>();

        if (hasWinner)
        {
            winnerLabel.text = GetTurnCharacter()+ " " + "Won!";
        }
        else
        { 
            winnerLabel.text= "Draw!";
        }
        mWinner.SetActive(true);
        AudioManager.Instance.PlaymusicSound(AudioManager.Instance.Winner);

        yield return new WaitForSeconds(AudioManager.Instance.Winner.length);

        mBoard.Reset();
        mTurnCount = 0;
        mWinner.SetActive(false);

    }
}
