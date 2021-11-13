using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Model
{
    public class NPCModel : MonoBehaviour
    {
        public float moveSpeed = 3f;

        public void SetMoveSpeed(float moveSpeed) => this.moveSpeed = moveSpeed;
    }
}


