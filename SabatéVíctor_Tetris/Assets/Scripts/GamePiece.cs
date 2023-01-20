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
    public int g_rotIndex { get; private set; }
    #endregion

    public void Init(Field _field, Vector3Int _pos, PieceData _data)
    {
        g_field = _field;
        g_pos = _pos;
        g_data = _data;
        g_rotIndex = 0;

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
        CheckRotation();
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
    private void CheckRotation()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // counter clockwise
        {
            Rotate(-1);
        }
        else if (Input.GetKeyDown(KeyCode.X)) // clockwise
        {
            Rotate(1);
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
    private void Rotate(int _direction)
    {
        g_rotIndex = Wrap(g_rotIndex+_direction, 0, 4);
        for (int i = 0; i < g_cells.Length; i++)
        {
            Vector3 auxCell = g_cells[i];
            int auxX, auxY;
            switch (g_data.p_tetrisPiece)
            {
                case TetrisPiece.I:
                    auxCell.x -= 0.5f;
                    auxCell.y -= 0.5f;
                    auxX = Mathf.CeilToInt((auxCell.x * Data.RotationMatrix[0] * _direction) + (auxCell.y * Data.RotationMatrix[1] * _direction));
                    auxY = Mathf.CeilToInt((auxCell.x * Data.RotationMatrix[2] * _direction) + (auxCell.y * Data.RotationMatrix[3] * _direction));
                    break;
                case TetrisPiece.O:
                    auxCell.x -= 0.5f;
                    auxCell.y -= 0.5f;
                    auxX = Mathf.CeilToInt((auxCell.x * Data.RotationMatrix[0] * _direction) + (auxCell.y * Data.RotationMatrix[1] * _direction));
                    auxY = Mathf.CeilToInt((auxCell.x * Data.RotationMatrix[2] * _direction) + (auxCell.y * Data.RotationMatrix[3] * _direction));
                    break;
                default:
                    auxX = Mathf.RoundToInt((auxCell.x * Data.RotationMatrix[0] * _direction) + (auxCell.y * Data.RotationMatrix[1] * _direction));
                    auxY = Mathf.RoundToInt((auxCell.x * Data.RotationMatrix[2] * _direction) + (auxCell.y * Data.RotationMatrix[3] * _direction));
                    break;
            }
            g_cells[i] = new Vector3Int(auxX,auxY,0);
        }
    }
    private int Wrap(int _input, int _min, int _max)
    {
        if (_input < _min)
        {
            return _max - (_min - _input) % (_max-_min);
        }
        else
        {
            return _min - (_input-_min) % (_max-_min);
        }
    }
    #endregion
}
