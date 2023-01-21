using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Play : Btn_Parent
{
    public Field btn_field;


    public override void ButtonAction()
    {
        JsonFileSystem.instance.LoadSaveFile();
        UIManager.instance.TextUpdate();
        UIManager.instance.u_menuPanel.SetActive(false);
        btn_field.f_tilemap.ClearAllTiles();
        btn_field.SpawnPiece();
    }
}
