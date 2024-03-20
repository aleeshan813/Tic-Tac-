using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;
    private Cell[] mCells = new Cell[9];

    public void Build(Main main)
    {
        for (int i = 0; i < mCells.Length; i++)
        {
            GameObject newCell = Instantiate(mCellPrefab, transform);
            mCells[i] = newCell.GetComponent<Cell>();
            mCells[i].mMain = main; 
        }
    }

    public void Reset()
    {
        AudioManager.Instance.PlaymusicSound(AudioManager.Instance.GameStrt);
        foreach(Cell cell in mCells)
        {
            cell.mLabel.text = "";
            cell.mButton.interactable = true;
        }
    }

    public bool CheckForWinner()
    {
        int i = 0;
        //Horizontal
        for (i = 0; i <= 6; i += 3)
        {
            if (!CheckValue(i, i + 1))
            {
                continue;
            }

            if (!CheckValue(i, i + 2))
            {
                continue;
            }
            
            return true;
        }

        //Vertical
        for (i = 0; i <= 2; i++)
        {
            if (!CheckValue(i, i + 3))
            {
                continue;
            }

            if (!CheckValue(i, i + 6))
            {
                continue;
            }

            return true;
        }

        // Diagonal
        if (CheckValue(0, 4) && CheckValue(4, 8))
        {
            return true;
        }

        if (CheckValue(2, 4) && CheckValue(4, 6))
        {
            return true;
        }

        return false;
    }

    bool CheckValue(int firstIndex, int secondIndex)
    {
        string firstValue = mCells[firstIndex].mLabel.text;
        string secondValue = mCells[secondIndex].mLabel.text;

        if (firstValue == "" || secondValue == "")
        {
            return false;
        }

        if (firstValue == secondValue)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }

}
