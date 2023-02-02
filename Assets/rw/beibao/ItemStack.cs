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

        public bool IsStackable => _item != null && _item.IsStackable; // _item != null �ж��Ƿ�ӵ�и���Ŀ
        public Itemdefinition Item => _item;
        public int Number0_fItems
        {
            get => _number0_fItems;
            set
            {
                value = value < 0 ? 0 : value;//ȷ����ֵ���Ǹ���
                _number0_fItems = _item.IsStackable ? value : 1;//�ж��Ƿ�ɶѵ������ɶѵ���ֵΪ1
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