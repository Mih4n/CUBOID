using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroer : MonoBehaviour
{
        private void OnTriggerStay2D(Collider2D other)
        {
            Destroy(gameObject);
        }
}
