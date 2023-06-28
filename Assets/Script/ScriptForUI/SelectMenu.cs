using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private Button[] levelButton;

    // Start is called before the first frame update
    void Start()
    {
        // Kiem soat level da choi toi
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButton[i].interactable = false;
        }
    }

    // Nut bam de chuyen toi level do
    public void LevelSelect(int level)
    {   try{
            SceneManager.LoadScene("Level " + level.ToString());
        }catch(Exception e)
        {
            Console.Write(e.Message);
            SceneManager.LoadScene("Level 1_Network");
        }
        AudioManager.Instance.PlayMusic("Theme");
    }
}
