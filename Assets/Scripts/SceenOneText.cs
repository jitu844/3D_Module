using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class StringAudioPair
{
    public string label;
    public AudioClip audioClip;
}

public class SceenOneText : MonoBehaviour
{
    public TMP_Text narrationTxt;
    public AudioSource narrationSrc;

    public List<StringAudioPair> narrationPairs = new List<StringAudioPair>();

    void Start()
    {
        StartCoroutine(Activity());
    }



    IEnumerator PlayNarration(int id)
    {
        if (id < 0 || id >= narrationPairs.Count)
        {
            Debug.LogWarning($"Narration ID {id} is out of bounds.");
            yield break;
        }

        var pair = narrationPairs[id];
        narrationTxt.text = pair.label;

        if (pair.audioClip == null)
        {
            Debug.LogWarning($"AudioClip is not assigned for narration '{pair.label}'. Waiting 2 seconds instead.");
            yield return new WaitForSeconds(2f);
        }
        else
        {
            narrationSrc.clip = pair.audioClip;
            narrationSrc.Play();
            yield return new WaitUntil(() => !narrationSrc.isPlaying);
        }
        narrationTxt.text = "";
    }

    //IEnumerator PlayNarration(int id)
    //{
    //    var pair = narrationPairs[id];
    //    narrationTxt.text = pair.label;
    //    narrationSrc.clip = pair.audioClip;
    //    narrationSrc.Play();
    //    yield return new WaitUntil(() => !narrationSrc.isPlaying);
    //    narrationTxt.text = "";
    //}

    IEnumerator Activity()
    {
        yield return PlayNarration(0);

        yield return PlayNarration(1);

        yield return PlayNarration(2);
    }
}
