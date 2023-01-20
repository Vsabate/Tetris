using UnityEngine;
using UnityEngine.Tilemaps;

public enum TetrisPiece
{
    I,
    J,
    L,
    O,
    S,
    T,
    Z
}

[System.Serializable]
public struct PieceData
{
    public TetrisPiece p_tetrisPiece;
    public Tile p_tile;
    public Vector2Int[] p_cells { get; private set; }
    public Vector2Int[,] p_wallLimits { get; private set; }
    public void Init()
    {
        p_cells = Data.Cells[p_tetrisPiece];
        p_wallLimits = Data.WallKicks[this.p_tetrisPiece];
    }
}
