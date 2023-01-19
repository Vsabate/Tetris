using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static readonly float cos = Mathf.Cos(Mathf.PI / 2f);
    public static readonly float sin = Mathf.Sin(Mathf.PI / 2f);
    public static readonly float[] RotationMatrix = new float[] { cos, sin, -sin, cos };

    public static readonly Dictionary<TetrisPiece, Vector2[]> Cells = new Dictionary<TetrisPiece, Vector2[]>()
    {
        { TetrisPiece.I, new Vector2[] { new Vector2(-1, 1), new Vector2( 0, 1), new Vector2( 1, 1), new Vector2( 2, 1) } },
        { TetrisPiece.J, new Vector2[] { new Vector2(-1, 1), new Vector2(-1, 0), new Vector2( 0, 0), new Vector2( 1, 0) } },
        { TetrisPiece.L, new Vector2[] { new Vector2( 1, 1), new Vector2(-1, 0), new Vector2( 0, 0), new Vector2( 1, 0) } },
        { TetrisPiece.O, new Vector2[] { new Vector2( 0, 1), new Vector2( 1, 1), new Vector2( 0, 0), new Vector2( 1, 0) } },
        { TetrisPiece.S, new Vector2[] { new Vector2( 0, 1), new Vector2( 1, 1), new Vector2(-1, 0), new Vector2( 0, 0) } },
        { TetrisPiece.T, new Vector2[] { new Vector2( 0, 1), new Vector2(-1, 0), new Vector2( 0, 0), new Vector2( 1, 0) } },
        { TetrisPiece.Z, new Vector2[] { new Vector2(-1, 1), new Vector2( 0, 1), new Vector2( 0, 0), new Vector2( 1, 0) } },
    };

    private static readonly Vector2[,] WallKicksI = new Vector2[,] {
        { new Vector2(0, 0), new Vector2(-2, 0), new Vector2( 1, 0), new Vector2(-2,-1), new Vector2( 1, 2) },
        { new Vector2(0, 0), new Vector2( 2, 0), new Vector2(-1, 0), new Vector2( 2, 1), new Vector2(-1,-2) },
        { new Vector2(0, 0), new Vector2(-1, 0), new Vector2( 2, 0), new Vector2(-1, 2), new Vector2( 2,-1) },
        { new Vector2(0, 0), new Vector2( 1, 0), new Vector2(-2, 0), new Vector2( 1,-2), new Vector2(-2, 1) },
        { new Vector2(0, 0), new Vector2( 2, 0), new Vector2(-1, 0), new Vector2( 2, 1), new Vector2(-1,-2) },
        { new Vector2(0, 0), new Vector2(-2, 0), new Vector2( 1, 0), new Vector2(-2,-1), new Vector2( 1, 2) },
        { new Vector2(0, 0), new Vector2( 1, 0), new Vector2(-2, 0), new Vector2( 1,-2), new Vector2(-2, 1) },
        { new Vector2(0, 0), new Vector2(-1, 0), new Vector2( 2, 0), new Vector2(-1, 2), new Vector2( 2,-1) },
    };

    private static readonly Vector2[,] WallKicksJLOSTZ = new Vector2[,] {
        { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(0,-2), new Vector2(-1,-2) },
        { new Vector2(0, 0), new Vector2( 1, 0), new Vector2( 1,-1), new Vector2(0, 2), new Vector2( 1, 2) },
        { new Vector2(0, 0), new Vector2( 1, 0), new Vector2( 1,-1), new Vector2(0, 2), new Vector2( 1, 2) },
        { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(0,-2), new Vector2(-1,-2) },
        { new Vector2(0, 0), new Vector2( 1, 0), new Vector2( 1, 1), new Vector2(0,-2), new Vector2( 1,-2) },
        { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(-1,-1), new Vector2(0, 2), new Vector2(-1, 2) },
        { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(-1,-1), new Vector2(0, 2), new Vector2(-1, 2) },
        { new Vector2(0, 0), new Vector2( 1, 0), new Vector2( 1, 1), new Vector2(0,-2), new Vector2( 1,-2) },
    };

    public static readonly Dictionary<TetrisPiece, Vector2[,]> WallKicks = new Dictionary<TetrisPiece, Vector2[,]>()
    {
        { TetrisPiece.I, WallKicksI },
        { TetrisPiece.J, WallKicksJLOSTZ },
        { TetrisPiece.L, WallKicksJLOSTZ },
        { TetrisPiece.O, WallKicksJLOSTZ },
        { TetrisPiece.S, WallKicksJLOSTZ },
        { TetrisPiece.T, WallKicksJLOSTZ },
        { TetrisPiece.Z, WallKicksJLOSTZ },
    };
}
