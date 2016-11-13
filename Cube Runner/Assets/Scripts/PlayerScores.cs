using UnityEngine;
using System.Collections;
using System;

public static class PlayerScores {
    private static int highScoresCount = 5;

	public static void addIfIsHighScore(int score) {
        IList highScores = getHighScores();
        for (int i = 0; i < highScoresCount; i++)
        {
            if (PlayerPrefs.HasKey(i.ToString()))
            {
                if (PlayerPrefs.GetInt(i.ToString()) < score)
                {
                    shiftHighScores(i);
                    PlayerPrefs.SetInt(i.ToString(), score);
                    break;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i.ToString(), score);
            }
        }
	}

    private static void shiftHighScores(int index)
    {
        for (int i = highScoresCount - 2; i >= index; i--)
        {
            if (PlayerPrefs.HasKey(i.ToString()))
            {
                PlayerPrefs.SetInt((i + 1).ToString(), PlayerPrefs.GetInt(i.ToString()));
            }
        }
    }

    internal static int GetBestScore()
    {
        if (PlayerPrefs.HasKey("0"))
        {
            return PlayerPrefs.GetInt("0");
        }
        return 0;
    }

    public static IList getHighScores ()
    {
        IList highScores = new ArrayList();
        for (int i = 0; i < highScoresCount; i++)
        {
            if (PlayerPrefs.HasKey(i.ToString()))
            {
                highScores.Add(PlayerPrefs.GetInt(i.ToString()));
            }
        }
        return highScores;
    }
}
