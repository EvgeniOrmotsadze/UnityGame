using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class LevelController : MonoBehaviour {

    public GameObject startPanel;

    public Transform[] trans = new Transform[4];

	// Use this for initialization
	void Start () {

        int i = 0;
        foreach (Transform level in startPanel.GetComponentInChildren<Transform>())
        {
            print(level);
            if(level.gameObject.name.StartsWith("L"))
            {
                trans[i] = level;
                if (!PlayerPrefs.HasKey(level.gameObject.transform.name))
                {
                    PlayerPrefs.SetString(level.gameObject.transform.name, ConstantType._block);
                }
                i++;
            }
        }

        PlayerPrefs.SetString(trans[0].gameObject.transform.name, ConstantType._unblock);


        foreach (Transform obj in trans)
        {
            if (obj != null)
            {
                //Debug.Log(obj.gameObject.transform.name + " " + PlayerPrefs.GetString(obj.gameObject.transform.name));
                if (PlayerPrefs.GetString(obj.gameObject.transform.name).Equals(ConstantType._block))
                {
                    GameObject bl = obj.gameObject.transform.Find(ConstantType._block).gameObject;
                    bl.SetActive(true);
                    GameObject ubl = obj.gameObject.transform.Find(ConstantType._unblock).gameObject;
                    ubl.SetActive(false);
                }
                else
                {
                    if (obj.gameObject.transform.Find(ConstantType._block) != null || obj.gameObject.transform.Find(ConstantType._unblock) != null)
                    {
                        GameObject bl = obj.gameObject.transform.Find(ConstantType._block).gameObject;
                        bl.SetActive(false);
                        GameObject ubl = obj.gameObject.transform.Find(ConstantType._unblock).gameObject;
                        ubl.SetActive(true);
                    }
                }

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
