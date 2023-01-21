using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;
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
    //[HideInInspector]
    public int s_currentScore, s_maxScore;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        s_currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
