using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public List<Vector3> Pos = new List<Vector3>();
    public TextMeshProUGUI m_leftScore;
    public int Chance = 17;

    private void Start()
    {
        m_leftScore.text = "Left:" + Chance.ToString();
        foreach (Transform item in transform.transform)
        {
            Pos.Add(item.localPosition);
        }
    }
    public void Syncevalue()
    {
        Chance--;
        if (Chance <= 0)
        {
            m_leftScore.text = "You Loose Try Again";
            Invoke(nameof(ResetGame), 3f);
        }
        else
        {
            m_leftScore.text = "Left:" + Chance.ToString();
            Pos.Clear();
            foreach (Transform item in transform.transform)
                Pos.Add(item.localPosition);
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
