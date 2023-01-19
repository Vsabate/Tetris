using UnityEngine;

public class Field : MonoBehaviour
{
    #region VARIABLES
    public PieceData[] f_pieceDataArray;
    #endregion

    private void Awake()
    {
        for (int i = 0; i < f_pieceDataArray.Length; i++)
        {
            f_pieceDataArray[i].Init();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
