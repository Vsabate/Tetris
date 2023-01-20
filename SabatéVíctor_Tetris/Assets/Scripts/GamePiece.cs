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

    private void Update()
    {
        g_field.Clear(this);

        CheckMovement();

        g_field.Set(this);
    }

    #region MOVEMENT_FUNCTIONS
    private void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector2Int.right);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector2Int.down);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropPiece();
        }
    }
    private void DropPiece()
    {
        while (Move(Vector2Int.down))
        {
            continue;
        }
    }

    private bool Move(Vector2Int _movement)
    {
        Vector3Int newPos = g_pos;
        newPos.x += _movement.x;
        newPos.y += _movement.y;

        bool auxValidPos = g_field.IsPositionValid(this, newPos);
        if (auxValidPos)
        {
            g_pos = newPos;
        }

        return auxValidPos;
    }
    #endregion
}
