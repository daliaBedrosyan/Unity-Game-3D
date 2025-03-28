using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunnersCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro runnersCounterText;
    [SerializeField] private Transform runnersParent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        runnersCounterText.text = runnersParent.childCount.ToString();
    }
}
