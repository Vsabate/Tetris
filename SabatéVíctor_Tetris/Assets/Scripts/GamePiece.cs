using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    #region VARIABLES
    public Field g_field { get; private set; }
    public Vector3Int g_pos { get; private set; }
    public Vector3Int[] g_cells { get; private set; }
    public PieceData g_data { get; private set; }
    #endregion

    public void Init(Field _field, Vector3Int _pos, PieceData _data)
    {
        g_field = _field;
        g_pos = _pos;
        g_data = _data;

        if (g_cells==null)
        {
            g_cells = new Vector3Int[_data.p_cells.Length];
        }

        for (int i = 0; i < _data.p_cells.Length; i++)
        {
            g_cells[i] = (Vector3Int)_data.p_cells[i];
        }
    }
}
