using UnityEngine;
using UnityEngine.SceneManagement;

namespace rw
{
    public class diaoluo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
      
        } 
        private void OnTriggerEnter2D(Collider2D other)
        {
            NewBehaviourScript pc = other.GetComponent<NewBehaviourScript>();
            if (pc != null)
            {
                teng_duizhan();
                  
            } 
        }
        public void teng_duizhan()
        {
            SceneManager.LoadScene("duizhan");
        }

    }
}
