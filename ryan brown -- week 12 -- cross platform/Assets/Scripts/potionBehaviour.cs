using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionBehaviour : MonoBehaviour
{
    public PotionInfo potionInfo;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = potionInfo.potionColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
