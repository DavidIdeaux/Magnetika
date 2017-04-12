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

namespace ValueConstraints.ValueControls.Behaviours
{
    /// <summary>
    /// Rotates a transform along the travel path
    /// </summary>
    public abstract class PathRotation : MonoBehaviour
    {
        /// <summary>
        /// Speed or turn to apply each frame
        /// </summary>
        [SerializeField]
        float m_TurnSpeed = 100.0f;

        /// <summary>
        /// Access to local cached transform
        /// </summary>
        protected Transform m_Trans;
        
        Vector3 m_LastPosition;

        /// <summary>
        /// Awake is called when the script instance is being loaded
        /// <para>Used to initialize variables</para>
        /// </summary>
        protected virtual void Awake()
        {
            m_Trans = transform;
            m_LastPosition = m_Trans.position;
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled
        /// </summary>
        protected virtual void Update()
        {
            Vector3 travelDirection = m_Trans.position - m_LastPosition;
            if(travelDirection != Vector3.zero)
            {
                Quaternion newRotation = DoPathRotation(travelDirection);
                m_Trans.rotation = Quaternion.RotateTowards(m_Trans.rotation, newRotation, m_TurnSpeed * Time.deltaTime);
            }
            m_LastPosition = m_Trans.position;
        }

        /// <summary>
        /// Override to calculate path rotation in derived class
        /// </summary>
        /// <param name="travelDirection">Current direction of travel</param>
        /// <returns>Quaternion to set object transform rotation value</returns>
        protected abstract Quaternion DoPathRotation(Vector3 travelDirection);

    }
}
