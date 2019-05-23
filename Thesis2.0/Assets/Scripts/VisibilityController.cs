using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisibilityController : MonoBehaviour
{

    public UnityEvent probandFinsih;

    // Nixcht gezeigte Chars
    private List<Transform> show;

    // Anzahl Charaktere
    private int charCount;
    private int randCharNum;

    [SerializeField]
    public List<string> EmotionStings;

    [SerializeField]
    int SecondsToWait = 1;


    void Awake()
    {

    }

    void Start()
    {
        show = new List<Transform>();

        foreach (Transform child in transform)
        {
            show.Add(child);
            child.gameObject.SetActive(false);
        }

        randCharNum = show.Count;
        StartCoroutine(ChangeVisibleCharacter());
    }

    IEnumerator ChangeVisibleCharacter()
    {

        //print("-----------new--------------");
        randCharNum = Random.Range(0, show.Count - 1);

        if (show.Count != 0)
        {

            show[randCharNum].transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(SecondsToWait);
            show[randCharNum].transform.gameObject.SetActive(false);

            // Emotionen zur Liste hinzufügen
            EmotionStings.Add(show[randCharNum].transform.gameObject.name);



            //print("Removed: " + show[randCharNum].transform.gameObject.name);
            show.RemoveAt(randCharNum);

            StopCoroutine(ChangeVisibleCharacter());
            StartCoroutine(ChangeVisibleCharacter());

        }
        else
        {
            //proband ist fertig
            print("Fertig");
            GetComponent<CSVController>().WriteProband();
            yield return null;
        }
    }
}
