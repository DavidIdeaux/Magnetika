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

namespace ValueConstraints.Extras
{
    /// <summary>
    /// Border to destroy spawned game objects
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Extras/Border 2D")]
    public class Border2D : MonoBehaviour
    {
        /// <summary>
        /// Amount of spawned items that collide/triggered a miss
        /// </summary>
        public int m_Missed;

        /// <summary>
        /// Amount of spawned items that collide/triggered a miss
        /// </summary>
        public int missed { get { return this.m_Missed; } set { this.m_Missed = value; } }

        void OnCollisionEnter2D(Collision2D collision)
        {
            StartCoroutine(DestroyCaught(collision.gameObject));
            this.missed++;
        }

        IEnumerator DestroyCaught(GameObject go)
        {
            yield return new WaitForSeconds(5);
            go.SetActive(false);
        }
    } 
}
