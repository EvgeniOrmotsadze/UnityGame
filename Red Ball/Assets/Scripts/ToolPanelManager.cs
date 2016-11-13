using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ToolPanelManager : MonoBehaviour {

    public GameObject Canvas;


    public void Restart()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(ConstantType._level + PlayerPrefs.GetString(ConstantType._currentLevel));
    }

    public void MenuManager()
    {
        if (GameObject.Find("MenuCanvas") == null)
        {
            Time.timeScale = 0.0f;
            GameObject popUp = Instantiate(Resources.Load("Prefabs/MenuCanvas"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            popUp.name = "MenuCanvas";
            popUp.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
    }

}
