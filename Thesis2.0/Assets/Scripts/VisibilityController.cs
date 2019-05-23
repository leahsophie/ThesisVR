using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisibilityController : MonoBehaviour
{
    // Nixcht gezeigte Chars
    private List<Transform> show;

    // Anzahl Charaktere
    private int charCount;
    private int randCharNum;

    public List<string> EmotionStings;

    [SerializeField]
    int SecondsToWait = 1;

    public int sessionCount = 0;
    bool first = true;

    private void Start()
    {

        // Liste für Kinder anlegen
        show = new List<Transform>();

        // Alle Kinder unsichtbar schalten 
        foreach (Transform child in transform)
        {
            show.Add(child);
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if (sessionCount < 1)
        {
            first = false;
        }


        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return))
        {

            show = new List<Transform>();

            foreach (Transform child in transform)
            {
                show.Add(child);
                child.gameObject.SetActive(false);
            }

            // Anzahl der Kinder
            randCharNum = show.Count;
            
            StartCoroutine(ChangeVisibleCharacter());
        }
    }

    IEnumerator ChangeVisibleCharacter()
    {
        randCharNum = Random.Range(0, show.Count - 1);

        if (show.Count != 0)
        {

            show[randCharNum].transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(SecondsToWait);
            show[randCharNum].transform.gameObject.SetActive(false);

            // Emotionen zur Liste hinzufügen
            EmotionStings.Add(show[randCharNum].transform.gameObject.name);
            show.RemoveAt(randCharNum);

            StopCoroutine(ChangeVisibleCharacter());
            StartCoroutine(ChangeVisibleCharacter());

        }
        else
        {
            //proband ist fertig
            StopCoroutine(ChangeVisibleCharacter());
            GetComponent<CSVController>().WriteCSV();
            EmotionStings.Clear();
            yield return null;
        }
    }
}
