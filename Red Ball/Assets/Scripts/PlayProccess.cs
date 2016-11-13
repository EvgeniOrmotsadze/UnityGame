using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class PlayProccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(ConstantType._win, 0);
        PlayerPrefs.SetInt(ConstantType._starN, 0);
        ConstantType.finish = 0;
        SoundController.initialSound();
        configTool();
	}

    private void configTool()
    {
        GameObject.Find("Lvl").GetComponent<Text>().text = ConstantType._level + " " + PlayerPrefs.GetString(ConstantType._currentLevel);

        GameObject.Find("ScoreTxt").GetComponent<Text>().text = "0/" + ConstantType.starArr[int.Parse(PlayerPrefs.GetString(ConstantType._currentLevel)) - 1];
    }
   
	

	void Update () {

        if(Input.GetKeyDown(KeyCode.R)){
            ToolPanelManager tlp = new ToolPanelManager();
            tlp.Restart();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ToolPanelManager tlp = new ToolPanelManager();
            tlp.MenuManager();
        }

        if (PlayerPrefs.GetInt(ConstantType._win) == 1 && ConstantType.finish == 1)
        {
            configFinishLevel();
        }
	}

    private void configFinishLevel()
    {
        int nextLevel = int.Parse(PlayerPrefs.GetString(ConstantType._currentLevel)) + 1;
        PlayerPrefs.SetString(ConstantType._level + nextLevel, ConstantType._unblock);
    }
}
