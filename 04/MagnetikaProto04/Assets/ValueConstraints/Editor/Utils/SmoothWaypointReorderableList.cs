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

using UnityEditor;
using UnityEngine;

namespace ValueConstraintsEditor.Utils
{
    /// <summary>
    /// Utility class to draw ReorderableList Value Vector Smooth Waypoint types and interactions.
    /// </summary>
    public class SmoothWaypointReorderableList<V> : WaypointReorderableList<V>
    {

        /// <summary>
        /// Name for smooth waypoint scales field
        /// </summary>
        public const string SCALES_PROPERTY_NAME = "m_CurveScales";

        SerializedProperty m_CurveScalesProperty;

        /// <summary>
        /// Constructor
        /// <para>Call in OnEnable ot initilize fields</para>
        /// </summary>
        public SmoothWaypointReorderableList(SerializedObject serializedObject)
            : base(serializedObject)
        {
            m_CurveScalesProperty = serializedObject.FindProperty(MemberReferenceEditorUtils.GetValueControlName(serializedObject)).FindPropertyRelative(SmoothWaypointReorderableList<V>.SCALES_PROPERTY_NAME);
            elementHeight = EditorGUIUtility.singleLineHeight * 2.0f + EditorGUIUtility.standardVerticalSpacing * 4.0f;
            drawElementCallback = (rect, idx, isActive, isFocused) =>
            {
                rect = base.DrawElement(rect, idx);
                float labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = EditorGUIUtility.fieldWidth;
                SerializedProperty prop = m_CurveScalesProperty.GetArrayElementAtIndex(idx);
                rect.height = EditorGUIUtility.singleLineHeight;
                rect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                EditorGUI.Slider(rect, prop, -0.33f, 1.0f, new GUIContent("Curve"));
                
                EditorGUIUtility.labelWidth = labelWidth;
                if(isActive | isFocused)
                {
                    base.index = idx;
                }
            };

            drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Curve Waypoint List");
        }

        /// <summary>
        /// Inserts a node at the end of the array list
        /// </summary>
        /// <param name="insertIndex">Index to insert node</param>
        /// <returns>Last inserted property node</returns>
        protected override SerializedProperty InsertNodeElement(int insertIndex)
        {
            m_CurveScalesProperty.serializedObject.Update();

            m_CurveScalesProperty.InsertArrayElementAtIndex(insertIndex);
            m_CurveScalesProperty.GetArrayElementAtIndex(insertIndex).floatValue = 0.2f;

            m_CurveScalesProperty.serializedObject.ApplyModifiedProperties();

            return base.InsertNodeElement(insertIndex);
        }

    }
}