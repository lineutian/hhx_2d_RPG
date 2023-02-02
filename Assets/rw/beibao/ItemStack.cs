using System;
using UnityEngine;

namespace rw.beibao 
{ 
    [Serializable]
      public class ItemStack
      {
        [SerializeField]
        private Itemdefinition _item;

        [SerializeField]
        private int _number0_fItems;

        public bool IsStackable => _item != null && _item.IsStackable; // _item != null 判断是否拥有该项目
        public Itemdefinition Item => _item;
        public int Number0_fItems
        {
            get => _number0_fItems;
            set
            {
                value = value < 0 ? 0 : value;//确保数值不是负数
                _number0_fItems = _item.IsStackable ? value : 1;//判断是否可堆叠，不可堆叠赋值为1
            }
        }
       public ItemStack(Itemdefinition item,int numberOfltems)
        {
            _item = item;
            Number0_fItems = numberOfltems;
        }
        public ItemStack() { }
      }
}