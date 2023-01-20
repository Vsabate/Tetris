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

    public float g_moveDelay = 1f;
    public float g_lockDelay = 0.5f;

    private float g_moveTime;
    private float g_lockTime;
    #endregion

    public void Init(Field _field, Vector3Int _pos, PieceData _data)
    {
        g_field = _field;
        g_pos = _pos;
        g_data = _data;
        g_rotIndex = 0;
        g_moveTime = Time.time+ g_moveDelay;
        g_lockTime = 0f;

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
        g_lockTime += Time.deltaTime;

        CheckRotation();
        CheckMovement();

        if (Time.time >= g_moveTime)
        {
            Step();
        }
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
        Lock();
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
            g_lockTime = 0f;
        }

        return auxValidPos;
    }
    private void Rotate(int _direction)
    {
        int aux_lastRotIndex = g_rotIndex;
        g_rotIndex = Wrap(g_rotIndex+_direction, 0, 4);
        RotMatrix(_direction);

        if (!CheckWallLimits(g_rotIndex, _direction))
        {
            g_rotIndex = aux_lastRotIndex;
            RotMatrix(-_direction);
        }
    }
    private void RotMatrix(int _direction)
    {
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
            g_cells[i] = new Vector3Int(auxX, auxY, 0);
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
    private bool CheckWallLimits(int _rotIndex, int _rotDirection)
    {
        int wallLimitIndex = GetWallLimitIndex(_rotIndex, _rotDirection);
        for (int i = 0; i < g_data.p_wallLimits.GetLength(1); i++)
        {
            Vector2Int auxTranslation = g_data.p_wallLimits[wallLimitIndex, i];
            if (Move(auxTranslation))
            {
                return true;
            }
        }
        return false;
    }
    private int GetWallLimitIndex(int _rotIndex, int _rotDirection)
    {
        int wallLimitIndex = _rotIndex*2;
        if (_rotDirection < 0)
        {
            wallLimitIndex--;
        }
        return Wrap(wallLimitIndex, 0, g_data.p_wallLimits.GetLength(0));
    }
    private void Step()
    {
        g_moveTime = Time.time + g_moveDelay;
        Move(Vector2Int.down);
        if (g_lockTime >= g_lockDelay)
        {
            Lock();
        }
    }
    private void Lock()
    {
        g_field.Set(this);
        g_field.SpawnPiece();
    }
    #endregion
}
