using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Play : Btn_Parent
{
    public override void ButtonAction()
    {
        JsonFileSystem.instance.LoadSaveFile();
        UIManager.instance.u_menuPanel.SetActive(false);
    }
}
