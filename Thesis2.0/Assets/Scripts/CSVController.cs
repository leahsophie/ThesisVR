using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVController : MonoBehaviour
{
    public void WriteCSV()
    {
        ProbandDataContainer newProband = new ProbandDataContainer();
        // Die Reihenfolge der Namen speichern
        newProband.Emotionen = GetComponent<VisibilityController>().EmotionStings;

        string emotionString =  "";

        foreach(string s in newProband.Emotionen)
        {
           /// print(s);
        }


        // String erstellen
        for (int i = 0; i < newProband.Emotionen.Count; i++)
        {
            emotionString = emotionString + ";" + newProband.Emotionen[i];

        }

        // Datei schreiben
        // Anzahl der Bisherigen Probanden
        string fileData = File.ReadAllText("assets/resources/csv/probandendaten.csv");
        String[] lines = fileData.Split("\n"[0]);
        
        //Datei zum Schreiben Öffnen
        StreamWriter sw = new StreamWriter("assets/resources/csv/probandendaten.csv",true);
        sw.WriteLine(String.Format(lines.Length + ";" + emotionString));
        Debug.Log(String.Format(lines.Length + ";" + emotionString));

        sw.Flush();
        sw.Close();


        Debug.Log("Proband gespeichert");

    }
}
