using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVController : MonoBehaviour
{
    List<ProbandDataContainer> containerList = new List<ProbandDataContainer>();


    //[SerializeField]
    //private string csvPath;
    private TextAsset probandData;
    private ProbandDataContainer dataContainer = new ProbandDataContainer();


    ProbandDataContainer newProband;

    

    public void CreateNewProband()
    {
        newProband = new ProbandDataContainer();
    }

    public void WriteProband()
    {
        print("test");
        newProband.ID = containerList.Count + 1;
        newProband.Emotionen = GetComponent<VisibilityController>().EmotionStings;
        WriteCSVFile();

    }

    void Start()
    {

        ReadCSVFile();
        CreateNewProband();

    }



    public void WriteCSVFile()
    {
        print("start");
        //StreamWriter sw = new StreamWriter("Assets/Resources/CSV/ProbandenDaten.csv");

        //sw.WriteLine("1");

        ///*
        //foreach (ProbandDataContainer p in containerList)
        //{
        //    sw.WriteLine(p.ID + ";");
        //    foreach (string s in newProband.Emotionen)
        //    {
        //        sw.WriteLine(s + ";");
        //    }
        //    sw.WriteLine("\n");
        //}
        //*/
  

        //sw.Flush();
        //sw.Close();
    }

    public void ReadCSVFile()
    {
        probandData = Resources.Load<TextAsset>("Assets/Resources/CSV/ProbandenDaten") as TextAsset;
        
        string[] data = probandData.text.Split(new char[] { '\n' });


        for (int i = 0; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });

            if(row[1] == "")
            {
                int.TryParse(row[0], out dataContainer.ID);
//                dataContainer.Emotion6  = row[6];

            }
            containerList.Add(dataContainer);
        }

        foreach(ProbandDataContainer p in containerList)
        {
            //Debug.Log(p.ID);
        }
    }
}
