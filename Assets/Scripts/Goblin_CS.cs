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
            Dialogues[index].GetComponent<AudioSource>().Play();
            StartCoroutine(DialogueTimer(Dialogues[index].GetComponent<AudioSource>().clip.length));
        }
    }

    private IEnumerator DialogueTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Dialogues[index].SetActive(false);

        index = -99;
    }

}
