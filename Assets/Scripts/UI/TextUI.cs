using System.Collections;
using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    [SerializeField] private Playerstat stat;
    [SerializeField] private CropSystem crop;
    [SerializeField] private float TextShowTime;
    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(TextShowTime);
    }

    public void ShowText(float value)
    {
        StartCoroutine(ShowTextCoroutine(value));
    }
    
    public IEnumerator ShowTextCoroutine(float value)
    {
        GameObject go = pool.Get();
        go.GetComponent<TMP_Text>().text = string.Format("+ {0}", value);
        yield return delay;
        pool.Release(go);
    }
}
