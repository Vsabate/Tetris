using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion

    #region VARIABLES
    public GameObject u_menuPanel;
    public TextMeshProUGUI[] u_scoreText;
    #endregion

    private void Start()
    {
        TextUpdate();
    }

    public void TextUpdate()
    {
        u_scoreText[0].SetText("Score: " + ScoreManager.instance.s_currentScore);
        u_scoreText[1].SetText("Max Score: " + ScoreManager.instance.s_maxScore);
    }
}
