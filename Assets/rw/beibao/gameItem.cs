using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rw.beibao
{
    public class gameItem : MonoBehaviour
    {
        [SerializeField]
        private ItemStack _stack;

        [SerializeField]
        private SpriteRenderer spriteRenderer;


        private void setupGameObject()
        {
            if (_stack.Item == null) return;
        }

    }
}