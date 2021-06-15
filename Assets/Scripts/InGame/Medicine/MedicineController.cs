using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MedicineController : MonoBehaviour
{
    void Start()
    {
        transform.localScale *= GetComponent<AbstractTrigger>().prefabSize;
    }

}
