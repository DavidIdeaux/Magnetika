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
    /// Positions a transform along the minimum and maximum 3D waypoint vectors with bezier smooth curves
    /// </summary>
    [AddComponentMenu("Scripts/Value Constraints/Behaviours/SmoothWaypoint 3D", 1080)]
    public class SmoothWaypoint3DBehaviour : SmoothWaypointBehaviour
    {
        /// <summary>
        /// Defines a controller for the Value classes as Vector3 values for waypoint positioning
        /// </summary>
        [SerializeField]
        ValueSmoothWaypoint3 m_ValueSmoothWaypoint = new ValueSmoothWaypoint3();

        /// <summary>
        /// Defines a controller for the Value classes as Vector3 values for waypoint positioning
        /// </summary>
        public override IValueSmoothWaypoint valueSmoothWaypoint { get { return m_ValueSmoothWaypoint; } }

        /// <summary>
        /// Reset to default values
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            m_ValueSmoothWaypoint.nodes = new Vector3[] { transform.position };
        }

    }
}
