using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Model
{
    public class NPCModel : MonoBehaviour
    {
        public float moveSpeed = 1.0f;

        public void SetMoveSpeed(int moveSpeed) => this.moveSpeed = moveSpeed;
    }
}


