using UnityEngine;

namespace rw
{
    public class daoju: MonoBehaviour
    {
        protected Transform d_transform;
        // Start is called before the first frame update
        void Start()
        {
            d_transform = this.transform;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Character pc = other.GetComponent<Character>();
            if (pc != null)
            {
                HurtManager.Instance.hurt(pc.gameObject,pc.Data.MaxHealth/10,HurtType.Cure);
                Destroy(this.gameObject);
            }
        }
    }
}
