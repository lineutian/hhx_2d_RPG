using UnityEngine;

namespace rw.beibao
{
    [CreateAssetMenu(menuName ="Inventory/Itea Definition",fileName ="New Itea Definition")]
    public class Itemdefinition : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private bool _isStackable;

        [SerializeField]
        private Sprite _inGameSprite;

        [SerializeField]
        private Sprite _uiSprite;

        public string Name => _name;
        public bool IsStackable => _isStackable;
        public Sprite ingameSprite => _inGameSprite;
        public Sprite uisprite => _uiSprite;
    }
}
