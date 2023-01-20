using UnityEngine;
using UnityEngine.Tilemaps;

public class Field : MonoBehaviour
{
    #region VARIABLES
    public GamePiece f_currentPiece { get; private set; }
    public PieceData[] f_pieceDataArray;
    public Tilemap f_tilemap { get; private set; }
    public Vector3Int f_spawnPos;
    public Vector2Int f_fieldSize;
    public RectInt f_fieldBounds
    {
        get { Vector2Int pos = new Vector2Int(-f_fieldSize.x / 2, -f_fieldSize.y / 2);
            return new RectInt(pos, f_fieldSize);}
    }
    #endregion

    private void Awake()
    {
        f_tilemap = GetComponentInChildren<Tilemap>();
        f_currentPiece = GetComponentInChildren<GamePiece>();
        for (int i = 0; i < f_pieceDataArray.Length; i++)
        {
            f_pieceDataArray[i].Init();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPiece();
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
        f_currentPiece.Init(this, f_spawnPos, pData);
        if (IsPositionValid(f_currentPiece, f_spawnPos))
        {
            Set(f_currentPiece);
        }
        else
        {
            GameOver();
        }
    }
    public void Set(GamePiece _piece)
    {
        for (int i = 0; i < _piece.g_cells.Length; i++)
        {
            Vector3Int tilePos = _piece.g_cells[i] + _piece.g_pos;
            f_tilemap.SetTile(tilePos, _piece.g_data.p_tile);
        }
    }
    public void Clear(GamePiece _piece)
    {
        for (int i = 0; i < _piece.g_cells.Length; i++)
        {
            Vector3Int tilePos = _piece.g_cells[i] + _piece.g_pos;
            f_tilemap.SetTile(tilePos, null);
        }
    }
    public bool IsPositionValid(GamePiece _piece, Vector3Int _pos)
    {
        RectInt auxBounds = f_fieldBounds;

        for (int i = 0; i < _piece.g_cells.Length; i++)
        {
            Vector3Int tilePos = _piece.g_cells[i] + _pos;
            if (!auxBounds.Contains((Vector2Int)tilePos))
            {
                return false;
            }
            if (f_tilemap.HasTile(tilePos))
            {
                return false;
            }
        }
        return true;
    }
    public void ClearLine()
    {
        RectInt fieldBounds = f_fieldBounds;
        int auxRow = fieldBounds.yMin;
        while (auxRow < fieldBounds.yMax)
        {
            if (IsLineFull(auxRow))
            {
                DestroyLine(auxRow);
            }
            else
            {
                auxRow++;
            }
        }

    }
    private bool IsLineFull(int _row)
    {
        RectInt auxBounds = f_fieldBounds;
        for (int col = auxBounds.xMin; col < auxBounds.xMax; col++)
        {
            Vector3Int auxPos = new Vector3Int(col, _row, 0);
            if (!f_tilemap.HasTile(auxPos))
            {
                return false;
            }
        }
        return true;
    }
    private void DestroyLine(int _row)
    {
        RectInt auxBounds = f_fieldBounds;
        for (int col = auxBounds.xMin; col < auxBounds.xMax; col++)
        {
            Vector3Int auxPos = new Vector3Int(col, _row, 0);
            f_tilemap.SetTile(auxPos, null);
        }
        while (_row < auxBounds.yMax)
        {
            for (int col = auxBounds.xMin; col < auxBounds.xMax; col++)
            {
                Vector3Int auxPos = new Vector3Int(col, _row+1, 0);
                TileBase aux_UpTile = f_tilemap.GetTile(auxPos);
                auxPos = new Vector3Int(col, _row, 0);
                f_tilemap.SetTile(auxPos, aux_UpTile);
            }
            _row++;
        }
    }
    private void GameOver()
    {
        Debug.Log("GAME OVER");
        f_tilemap.ClearAllTiles();
    }
    #endregion
}
