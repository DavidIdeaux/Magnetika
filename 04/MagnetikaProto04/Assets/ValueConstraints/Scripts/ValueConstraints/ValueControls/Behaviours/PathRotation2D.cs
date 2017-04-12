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
using ValueConstraints.Interfaces;

namespace ValueConstraints.ValueControls.Behaviours
{
    /// <summary>
    /// Rotates a transform along the minimum and maximum 2D position vectors
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Behaviours/PathRotation 2D", 2010)]
    public class PathRotation2D : PathRotation
    {

        [Tooltip("Flips the direction of the sprite when moving along route.")]
        [SerializeField]
        bool m_FlipScaleX = false;

        IValueControl m_ValueControl;
        int m_FlipDirection;
        bool m_PingPongFlip;

        /// <summary>
        /// Awake is called when the script instance is being loaded
        /// <para>Used to initialize variables</para>
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            CheckForValueControl();
        }

        /// <summary>
        /// Rotate object in 2D world space
        /// </summary>
        /// <param name="travelDirection">Current direction of travel</param>
        /// <returns>Quaternion to set object transform rotation value</returns>
        protected override Quaternion DoPathRotation(Vector3 travelDirection)
        {
            float angle = Mathf.Atan2(travelDirection.y, travelDirection.x) * Mathf.Rad2Deg;

            float flipedAngle = angle + (m_FlipScaleX ? 180 : 0);
            flipedAngle = CheckForPingPong(flipedAngle);
            return Quaternion.AngleAxis(flipedAngle, Vector3.forward);
        }

        void CheckForValueControl()
        {
            MemberReference<Vector3> memberReference = GetComponent<MemberReference<Vector3>>();
            if(memberReference)
            {
                m_ValueControl = memberReference.valueControl;
                m_FlipDirection = m_ValueControl.direction;
            }
        }

        float CheckForPingPong(float flipedAngle)
        {
            if(m_ValueControl != null)
            {
                if(m_ValueControl.actionType == ActionType.PingPong)
                {
                    if(m_FlipDirection != m_ValueControl.direction)
                    {
                        m_PingPongFlip = !m_PingPongFlip;
                        var s = m_Trans.localScale;
                        m_Trans.localScale = new Vector3(s.x * -1, s.y, s.z);
                    }
                    m_FlipDirection = m_ValueControl.direction;
                }
                flipedAngle = flipedAngle + (m_PingPongFlip ? 180 : 0);
            }
            return flipedAngle;
        }
    }
}
