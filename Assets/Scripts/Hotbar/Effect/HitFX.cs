using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyEffect", 2f);
    }

    void DestroyEffect()
    {
        Destroy(this.gameObject);
    }
}
