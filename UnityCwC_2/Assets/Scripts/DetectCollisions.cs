using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public Slider slider;
    public int feed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            feed++;
            SetFeed(feed);
            Destroy(other.gameObject);
            if (feed == 3)
            {
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    public void SetFeed(int feed)
    {
        slider.value = feed;
    }
}
