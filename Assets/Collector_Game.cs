using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector_Game : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            //Destroy(this.gameObject);
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win!";
        }
    }
}
