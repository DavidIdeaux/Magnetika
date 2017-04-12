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

using BezierAlgorithms;
using UnityEngine;
using ValueConstraints.Interfaces;
using ValueConstraints.Utils;

namespace ValueConstraints.ValueControls.Behaviours
{
    /// <summary>
    /// Positions a transform along the minimum and maximum waypoint vectors with bezier smooth curves
    /// </summary>
    public abstract class SmoothWaypointBehaviour : MemberReference<Vector3>
    {

        CurveControlSection m_ControlSection;

        /// <summary>
        /// Defines a controller for the Value classes as Vector2 values for waypoint positioning
        /// </summary>
        public abstract IValueSmoothWaypoint valueSmoothWaypoint { get; }

        /// <summary>
        /// Access to local value control type
        /// </summary>
        public sealed override IValueControl valueControl { get { return valueSmoothWaypoint; } }

        /// <summary>
        /// Called to setup variables
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            ValueSmoothWaypointUtils.InitilizeDirection(valueSmoothWaypoint, OnValueVectorClamp);
            ValueWaypointUtils.SetVecsToNode(valueSmoothWaypoint);
            ValueSmoothWaypointUtils.CalculateCurrentIndex(valueSmoothWaypoint, out m_ControlSection);
        }

        /// <summary>
        /// Reset to default values
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            valueSmoothWaypoint.current = 0.0f;
            valueSmoothWaypoint.curveScales = new float[] { 0.2f };
        }

        /// <summary>
        /// Responds to OnClamped event from Value Waypoint
        /// </summary>
        /// <param name="sender">Value Waypoint sending the event</param>
        /// <param name="e">Not Used!</param>
        protected virtual void OnValueVectorClamp(object sender, System.EventArgs e)
        {
            if(valueSmoothWaypoint.Equals(sender as IValueSmoothWaypoint))
            {
                ValueSmoothWaypointUtils.OnValueWaypointClamp(valueSmoothWaypoint);
            }
        }

        /// <summary>
        /// Get the value by type to set the member variable value
        /// </summary>
        /// <returns>Value type after Value reference to Value Constraints calculation</returns>
        protected override Vector3 GetValue()
        {
            valueSmoothWaypoint.DoAction(Time.deltaTime);            
            ValueSmoothWaypointUtils.CalculateCurrentIndex(valueSmoothWaypoint, out m_ControlSection);
            
            return BezierCurveUtils.CubicBezier3(
                m_ControlSection.p0.position,
                m_ControlSection.q0.position,
                m_ControlSection.q1.position,
                m_ControlSection.p1.position,
                valueSmoothWaypoint.current);
        }

        /// <summary>
        /// Initilize default values for transform position reference
        /// </summary>
        public override void InitilizeComponent()
        {
            base.InitilizeComponent();
            base.component = transform;
            base.memberType = System.Reflection.MemberTypes.Property;
            base.memberName = "position";
        }
    }
}
