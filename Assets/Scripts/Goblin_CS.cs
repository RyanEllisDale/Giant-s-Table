using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_CS : MonoBehaviour
{
    [SerializeField] private List<GameObject> Dialogues;
    private int index = -99;

    public void CallDialogue()
    {
        if (index == -99)
        {
            index = Random.Range(0, Dialogues.Count);
            Dialogues[index].SetActive(true);
            StartCoroutine(DialogueTimer());
        }
    }

    private IEnumerator DialogueTimer()
    {
        yield return new WaitForSeconds(0.9f);
        Dialogues[index].SetActive(false);

        index = -99;
    }

}
