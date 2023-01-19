using UnityEngine;
using UnityEngine.Tilemaps;

public class Field : MonoBehaviour
{
    #region VARIABLES
    public PieceData[] f_pieceDataArray;
    public Tilemap f_tilemap { get; private set; }
    #endregion

    private void Awake()
    {
        f_tilemap = GetComponentInChildren<Tilemap>();

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


    #region OTHER_FUNCTIONS
    public void SpawnPiece()
    {
        int randomNumber = Random.Range(0, f_pieceDataArray.Length);
        PieceData pData = f_pieceDataArray[randomNumber];
    }

    public void Set(GamePiece _piece)
    {
        for (int i = 0; i < _piece.g_cells.Length; i++)
        {
            Vector3Int tilePos = _piece.g_cells[i] + _piece.g_pos;
            f_tilemap.SetTile(tilePos, _piece.g_data.p_tile);
        }
    }
    #endregion
}
