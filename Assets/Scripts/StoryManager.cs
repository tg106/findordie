﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{

    public static StoryManager Instance;

    private bool isDisplaying =false;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    [SerializeField] Text StoryText;
    [SerializeField] Story Intro;
    [SerializeField] Story Instruct_1;
    [SerializeField] Story Instruct_2;
    [SerializeField] Story Dark_1;
    [SerializeField] Story Dark_2;
    [SerializeField] Story Dark_3;

    [SerializeField] GameObject TimeNRockPanel;
    void Awake()
    {   
        if (!Instance){
            Instance = this;
        }

    }

    private IEnumerator sIntro(){
        TimeNRockPanel.SetActive(false);

        isDisplaying = true;
        StoryText.text  = Intro.getStory();
        yield return new WaitForSecondsRealtime(6);

        StoryText.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.75f);

        StoryText.gameObject.SetActive(true);
        StoryText.text = Instruct_1.getStory();
        yield return new WaitForSecondsRealtime(6.5f);

        StoryText.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.75f);

        StoryText.gameObject.SetActive(true);
        StoryText.text = Instruct_2.getStory();

        yield return new WaitForSecondsRealtime(6);

        StoryText.gameObject.SetActive(false);
        GameplayManager.Instance.startGame = true;
        TimeNRockPanel.SetActive(true);
    }

    //private IEnumerator sInstruct_1(){
    //    isDisplaying = true;
    //    isDisplaying=false;
    //}

    private IEnumerator sInstruct_2(){
        isDisplaying = true;
        yield return new WaitForSecondsRealtime(4);

        StartCoroutine(sInstruct_2());
        isDisplaying=false; 
    }

    private IEnumerator sDark_1(){
        isDisplaying = true;
        StoryText.text = "";
        StoryText.text  = Dark_1.getStory();
        yield return new WaitForSecondsRealtime(4);
        StoryText.text = "";
        isDisplaying=false;
    }

    private IEnumerator sDark_2(){
        isDisplaying = true;
        StoryText.text = "";   
        StoryText.text  = Dark_2.getStory();
        yield return new WaitForSecondsRealtime(4);
        StoryText.text = "";
        isDisplaying=false;
    }

    private IEnumerator sDark_3(){
        isDisplaying = true;
        StoryText.text = ""; 
        StoryText.text  = Dark_3.getStory();
        yield return new WaitForSecondsRealtime(4);
        StoryText.text = "";
        isDisplaying=false;
    }


    public void ShowIntro(){
        StartCoroutine(sIntro());
    }

    public void ShowDark_1(){
        coroutine = sDark_1();
        StartCoroutine(coroutine);
    }

    public void ShowDark_2(){
        coroutine = sDark_2();
        StartCoroutine(coroutine);
    }

    public void ShowDark_3(){
        coroutine = sDark_3();
        StartCoroutine(coroutine);
    }
}
