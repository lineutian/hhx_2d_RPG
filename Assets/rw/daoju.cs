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
            NewBehaviourScript pc = other.GetComponent<NewBehaviourScript>();
            if (pc != null)
            {
                pc.changHP(-(int)pc.MYmaxHP/4);
                Destroy(this.gameObject);
            }
        }
    }
}
