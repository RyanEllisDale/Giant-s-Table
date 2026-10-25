// Includes : 
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Fish_CS : Knockable_CS
{
    // Member Data : 
    public UnityEvent UEvent;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private GameObject Bubble;

    private void Start()
    {
        if (UEvent == null)
        {
            UEvent = new UnityEvent();
        }
    }

    // Death :
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death") == true && collision.gameObject != Table)
        {
            UEvent.Invoke();
            Bubble.SetActive(true);
            Text.alpha = 255.0f;
            StartCoroutine(ReturnStart());
        }
    }

    IEnumerator ReturnStart()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("StartGame_S");
    }
}
