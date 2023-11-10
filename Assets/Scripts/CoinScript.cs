using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject trapDoor;
    public GameObject secondTrapDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString(); 

        if (coinCount >= 10)
        {
            Destroy(trapDoor);
        }

        if (coinCount >= 20)
        {
            Destroy(secondTrapDoor);
        }
    }
}
