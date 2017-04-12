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

using System;
using UnityEditor;
using UnityEngine;
using ValueConstraints.ValueControls;
using ValueConstraintsEditor.Utils;

namespace ValueConstraintsEditor.ValueDrawers
{

    /// <summary>
    /// Draws a Value class of ValueSmoothWaypoint2
    /// </summary>
    [CustomPropertyDrawer(typeof(ValueSmoothWaypoint2), true)]
    public class ValueSmoothWaypoint2Drawer : ValueSmoothWaypointDrawer<Vector2> { }

    /// <summary>
    /// Draws a Value class of ValueSmoothWaypoint3
    /// </summary>
    [CustomPropertyDrawer(typeof(ValueSmoothWaypoint3), true)]
    public class ValueSmoothWaypoint3Drawer : ValueSmoothWaypointDrawer<Vector3> { }

    /// <summary>
    /// Draws a Value class of ValueSmoothWaypoint class
    /// </summary>
    /// <typeparam name="V">Type of Vector to use Vector2 or Vector3</typeparam>
    public class ValueSmoothWaypointDrawer<V> : PropertyDrawer
    {
        SmoothWaypointConverter m_PropertyConverter = null;

        /// <summary>
        /// Acces to the property converter to draw the property in the inspector
        /// </summary>
        public PropertyConverter GetConverterInstance(SerializedProperty property, GUIContent label, Attribute attribute)
        {
            return m_PropertyConverter ?? new SmoothWaypointConverter(property, label, attribute);
        }

        /// <summary>
        /// Draws the property to the inspector on editor updates
        /// </summary>
        /// <param name="position">Position to draw the property field</param>
        /// <param name="property">Property field to draw</param>
        /// <param name="label">Label defining the title and tooltip</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PropertyConverter.DrawOnGUI<SmoothWaypointConverter, V>(this, GetConverterInstance(property, label, attribute), position, property, label, (pc) => pc.viewerGUI[SmoothWaypointConverter.SmoothWaypointID.CurveScales].property);
        }

        /// <summary>
        /// Gets the required height to draw the property
        /// </summary>
        /// <param name="property">Property being drawn</param>
        /// <param name="label">Label of the property</param>
        /// <returns>The calculated height</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return GetConverterInstance(property, label, attribute).GetPropertyHeight<SmoothWaypointConverter>((pc) => pc.viewerGUI[SmoothWaypointConverter.SmoothWaypointID.CurveScales].property);
        }


        /// <summary>
        /// Converts a SerializedProperty into a ValueSmoothWaypointDrawer Value classes drawing properties
        /// </summary>
        [Serializable]
        public class SmoothWaypointConverter : ValueWaypointDrawer<V>.WaypointConverter
        {
            /// <summary>
            /// Property viewer id for the collection of viewers
            /// </summary>
            public enum SmoothWaypointID
            {
                /// <summary>
                /// CurveScales property GUI viewer
                /// </summary>
                CurveScales,
            }

            /// <summary>
            /// Constructor to define converter
            /// </summary>
            /// <param name="property">Property field to draw</param>
            /// <param name="label">Label defining the title and tooltip</param>
            /// <param name="attribute">Property Attributes used on the field</param>
            public SmoothWaypointConverter(SerializedProperty property, GUIContent label, Attribute attribute)
                : base(property, label, attribute)
            {
                base.AddViewer(SmoothWaypointID.CurveScales, new PropertyViewerGUI(property, false, true, new GUIContent("CurveScales", ""), "m_CurveScales"));
            }
        }
    }
}