using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuideTextBougie : MonoBehaviour
{
    bool going;
    bool co1;
    bool co2;
    [SerializeField] private GameObject text;
    private float m_t;
    // Start is called before the first frame update
    void Start()
    {
        going = false;
        co1 = false;
        co2 = false;
        m_t = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (going && !co1)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, text.GetComponent<TextMeshProUGUI>()));
            co1 = true;
        }
        if (going)
        {
            m_t += Time.deltaTime;
        }
        if(going && !co2 && m_t>=3.5f)
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, text.GetComponent<TextMeshProUGUI>()));
            co2 = true;
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        text.SetActive(false);
    }
    public void go()
    {
        going = true;
    }
}
