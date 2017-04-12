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
using UnityEditor;
using UnityEngine;
using ValueConstraints.Interfaces;
using ValueConstraints.ValueControls;
using ValueConstraints.ValueControls.Behaviours;
using ValueConstraintsEditor.Utils;

namespace ValueConstraintsEditor.ValueEditors
{

    /// <summary>
    /// Draws a Value class of SmoothWaypoint2D
    /// </summary>
    [CustomEditor(typeof(SmoothWaypoint2DBehaviour), true)]
    public class SmoothWaypoint2DBehaviourEditor : SmoothWaypointBehaviourEditor<Vector2> { }

    /// <summary>
    /// Draws a Value class of SmoothWaypoint3D
    /// </summary>
    [CustomEditor(typeof(SmoothWaypoint3DBehaviour), true)]
    public class SmoothWaypoint3DBehaviourEditor : SmoothWaypointBehaviourEditor<Vector3> { }

    /// <summary>
    /// Editor to present Value SmoothWaypoint Vector in the Inspector
    /// </summary>
    public abstract class SmoothWaypointBehaviourEditor<V> : MemberReferenceSceneGUIEditor<Vector3>
    {
        /// <summary>
        ///  Utility class to draw ReorderableList Value Vector Smooth Waypoint types and interactions.
        /// </summary>
        protected SmoothWaypointReorderableList<V> m_ReorderableSmoothWaypoint;
        
        /// <summary>
        /// Used to init variables
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            m_ReorderableSmoothWaypoint = new SmoothWaypointReorderableList<V>(serializedObject);
            base.m_ComponentViewer.visible = false;
            base.m_MemberIndexViewer.visible = false;
        }

        /// <summary>
        /// Additional actions to preform on undoRedo action
        /// <para>Clamps index to limits between -1 and list.count -1</para>
        /// </summary>
        protected override void OnUndoRedo()
        {
            base.OnUndoRedo();
            if(m_ReorderableSmoothWaypoint != null)
            {
                m_ReorderableSmoothWaypoint.index = Mathf.Clamp(m_ReorderableSmoothWaypoint.index, -1, m_ReorderableSmoothWaypoint.count - 1);
            }
        }

        /// <summary>
        /// Draws Value SmoothWaypoint to Inspector
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            m_ReorderableSmoothWaypoint.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Draws scene view handles
        /// </summary>
        protected override void OnSceneGUI()
        {
            base.OnSceneGUI();
            IValueSmoothWaypoint valueSmoothWaypoint = m_MemberTarget.valueControl as IValueSmoothWaypoint;

            ValueWaypointEditorUtils.SelectionHandles(valueSmoothWaypoint, target, transform, m_ReorderableSmoothWaypoint.index);

            Color color = Handles.color;
            Handles.color = Color.green;

            if(valueSmoothWaypoint.selectionType != SelectionType.None)
            {
                IControlNode[] controlNodes = new IControlNode[valueSmoothWaypoint.nodes.Length];
                for(int i = 0; i < valueSmoothWaypoint.nodes.Length; i++)
                {
                    controlNodes[i] = ControlNode.CreateNode(i, valueSmoothWaypoint.nodes[i], Quaternion.identity, valueSmoothWaypoint.curveScales[i]);
                }
                
                var controlSections = CurveControlArgs.GetComputedAndSlicedSections(new CurveControlArgs(controlNodes, true));
                float lineWidth = 2;
                for(int i = 0; i < controlSections.Length; i++)
                {
                    var item = controlSections[i];
                    Handles.DrawBezier(item.p0.position,
                                            item.p1.position,
                                            item.q0.position,
                                            item.q1.position,
                                            Handles.color,
                                            null,
                                            lineWidth);
                }

                m_ReorderableSmoothWaypoint.SceneViewDrawSelected(valueSmoothWaypoint, Color.yellow);
                m_ReorderableSmoothWaypoint.SceneViewCreateWaypoint(valueSmoothWaypoint);
            }
        
            Handles.color = color;
        }
    }
}