using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyChecker : MonoBehaviour
{
    public bool hasKey1, hasKey2, hasKey3, hasKey4;
    public BoolValue key1, key2, key3, key4;
    // Start is called before the first frame update
    void Start()
    {
        hasKey1 = key1.value; hasKey2 = key2.value; hasKey3 = key3.value; hasKey4 = key4.value;
    }

    // Update is called once per frame
    void Update()
    {
        key1.value = hasKey1;
        key2.value = hasKey2;
        key3.value = hasKey3;
        key4.value = hasKey4;
    }
}
