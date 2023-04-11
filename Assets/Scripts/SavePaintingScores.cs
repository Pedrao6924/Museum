using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SavePaintingScores : MonoBehaviour
{

    public PaintingDetails[] paintingDetails; 
    public bool save = false; //Testing button

    public void CreateTextFile(){
        string textDocument = Application.streamingAssetsPath + "/PaintingScores/" + "Scores" + ".txt";

        string text = "==SCORES==\n\n";
        for(int i=0; i<paintingDetails.Length; i++){

            text += paintingDetails[i].paintingID + " => " + paintingDetails[i].watchTime + "\n";
        }
        
        Debug.Log(text);
         File.WriteAllText(textDocument, text);
    }

    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/PaintingScores/");
    }

    // Update is called once per frame
    void Update()
    {
        if(save){
            CreateTextFile();//Add this to a button
            save = false;
        }
    }

    void OnApplicationQuit()
    {
        CreateTextFile();
    }
}
