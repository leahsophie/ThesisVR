using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{

    // Nixcht gezeigte Chars
    private List<Transform> show;

    // Anzahl Charaktere
    private int charCount;
    private int randCharNum;

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

            //foreach (Transform t in show)
            //{
            //    print(show.Count + " : " + t.name +" : " + randCharNum);
            //}

            show[randCharNum].transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(SecondsToWait);
            show[randCharNum].transform.gameObject.SetActive(false);

            print("Removed: " + show[randCharNum].transform.gameObject.name);
            show.RemoveAt(randCharNum);

            StopCoroutine(ChangeVisibleCharacter());
            StartCoroutine(ChangeVisibleCharacter());

        }
        else
        {
            yield return null;
        }
    }
}
