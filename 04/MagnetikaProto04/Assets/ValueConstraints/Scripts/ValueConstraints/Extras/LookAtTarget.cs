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

using UnityEngine;

namespace ValueConstraints.Extras
{
    /// <summary>
    /// Rotates object to look at another object in 3D space
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Extras/LookAtTarget 3D")]
    public class LookAtTarget : MonoBehaviour
    {
        /// <summary>
        /// target transform to look at
        /// </summary>
        public Transform m_Target;

        Transform m_Trans;

        void Awake()
        {
            m_Trans = transform;
        }

        void LateUpdate()
        {
            m_Trans.LookAt(m_Target);
        }
    } 
}
