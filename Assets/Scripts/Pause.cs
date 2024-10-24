using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void pausar() => Time.timeScale = 0f;
    public void despausar() => Time.timeScale = 1f;

}
