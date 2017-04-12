#region Author
/*
     
     Jones St. Lewis Cropper (caLLow)
     
     Another caLLowCreation
     
     Visit us on Google+ and other social media outlets @caLLowCreation
     
     Thanks for using our product.
     
     Send questions/comments/concerns/requests to 
      e-mail: caLLowCreation@gmail.com
      subject: ValueConstraints
     
*/
#endregion

using System.Collections;
using UnityEngine;
using ValueConstraints.ValueControls.Behaviours;

namespace ValueConstraints.Extras
{
    /// <summary>
    /// Catcher to catch and destroy spawned game objects
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Extras/Catcher 2D")]
    public class Catcher2D : MonoBehaviour
    {
        /// <summary>
        /// Size of the catcher
        /// </summary>
        public float size = 10.0f;

        Transform m_Transform;
        void Awake()
        {
            m_Transform = transform;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            StartCoroutine(Pause(collision.gameObject));
        }

        void Update()
        {
            if(!m_Transform.localScale.x.Equals(size))
            {
                m_Transform.localScale = new Vector3(size, 5.0f, 1.0f);
            }
        }

        IEnumerator Pause(GameObject go)
        {
            GetComponent<MemberReference<Vector3>>().valueControl.maxDelta = 0;
            yield return new WaitForSeconds(1);
            go.SetActive(false);
            GetComponent<MemberReference<Vector3>>().valueControl.maxDelta = 1;
        }
    } 
}
