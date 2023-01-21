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


    // Start is called before the first frame update
    private void Start()
    {
        // MAX SCORE NEEDS TO BE LOADED FROM DATA FILE


        TextUpdate();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void TextUpdate()
    {
        u_scoreText[0].SetText("Score: " + ScoreManager.instance.s_currentScore);
        u_scoreText[1].SetText("Max Score: " + ScoreManager.instance.s_maxScore);
    }
}
