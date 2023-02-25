using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using System.IO;
using Unity.VisualScripting;

public class EndingTrigger : MonoBehaviour
{
    private TextMeshProUGUI endingText;
    
    private bool hitten = false;

    private float score = 0;

    private List<float> highScores = new List<float>();

    private string FILE_PATH;
    private const string FILE_NAME = "HighScores.txt";
    private const string FILE_DIR = "/DATA/";

    // private string systemLog =
    //     System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Denied" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Ipconfig Smart Plug B09HPW" + "     Permitted" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Ping 192.168.122.235/24" + "            Permitted" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      Request WebCam Permission" + "      Permitted" + "\n"
    //     +System.DateTime.Now.ToString() + "     CCTVMaze.exe" + "       anonymous" + "      "+Environment.UserName+", isn't it?" + "\n"
    //     +System.DateTime.Now.ToString() + "     👁👁👁👁👁" + "       👁👁👁👁" + "      👁👁👁👁👁👁👁👁👁👁👁" + "     👁👁👁👁"; //content of the txt file
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chair")) //if player hit the chair, fade in ending text in 3 seconds
        {
            if (hitten == false) //if not hitten before
            {
                UpdateHighScore();
                endingText = GameObject.Find("EndingText").GetComponent<TextMeshProUGUI>(); //find TextMeshProUGUI in the scene
                endingText.text = "The End\n" + File.ReadAllText(FILE_PATH); //set text in UI
                endingText.DOFade(0, 0); //set text alpha to 0
                endingText.DOFade(1, 3); //text fade in
                // File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/System Log.txt", systemLog); //create a txt file on desktop
                hitten = true; //set status to hitten
            }
        }
    }

    private void UpdateHighScore() //Update High Score Function
    {
        score = Time.timeSinceLevelLoad; //record current score

        //read high scores from txt
        if (highScores.Count == 0)
        {
            string[] fileSplit = File.ReadAllText(FILE_PATH).Split("\n");
            for (int i = 1; i < fileSplit.Length - 1; i++) 
            {
                highScores.Add(float.Parse(fileSplit[i]));
            }
        }
        
        //insert current score into high score
        for (int i = 0; i < highScores.Count; i++)
        {
            if (score <= highScores[i]) 
            {
                highScores.Insert(i, score);
                break;
            }
        }

        //write high scores into txt
        string highScoresText = "High Scores:\n";
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoresText += highScores[i] + "\n";
        }
        File.WriteAllText(FILE_PATH, highScoresText);
    }
}
