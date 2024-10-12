using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void ShowMessage(GameObject go)
    {
        Debug.Log($"{go.name}!");
    }
}
