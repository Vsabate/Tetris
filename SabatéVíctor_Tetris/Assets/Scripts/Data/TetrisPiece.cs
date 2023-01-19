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
    public Vector2[] p_cells { get; private set; }
    public void Init()
    {
        p_cells = Data.Cells[p_tetrisPiece];
    }
}
