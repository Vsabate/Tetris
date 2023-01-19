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

public struct PieceData
{
    public TetrisPiece p_tetrisPiece;
    public Tile p_tile;

}
