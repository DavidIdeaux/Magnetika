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
using ValueConstraints.Extras;
using ValueConstraints.Interfaces;
using ValueConstraintsEditor.Utils;

namespace ValueConstraintsEditor.Extras
{
    /// <summary>
    /// Editor to present Test Value Vector in the Inspector
    /// </summary>
    [CustomEditor(typeof(ValuesLightColor), true)]
    public sealed class ValuesLightColorEditor : Editor
    {

        ValuesLightColor m_ValueLight;
        IValueSingle m_ValueFloat;
        Light m_Light;

        bool m_Testing = false;
        float m_DeltaTime = 0.02f;

        void OnEnable()
        {
            m_ValueLight = target as ValuesLightColor;
            m_ValueFloat = m_ValueLight.valueFloat;
            m_Light = m_ValueLight.GetComponent<Light>();

            EditorApplication.update -= OnUpdate;
            EditorApplication.update += OnUpdate;
        }

        void OnDisable()
        {
            EditorApplication.update -= OnUpdate;
        }

        /// <summary>
        /// Draws Value Vector to Inspector
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(GUILayout.Button(ValuePositionEditorUtils.GetTestButtonName(m_Testing)))
            {
                m_Testing = !m_Testing;

                if(m_Testing)
                {
                    m_ValueFloat.Prepare();
                }
            }
        }

        void OnUpdate()
        {
            if(m_Testing && !Application.isPlaying)
            {
                m_ValueFloat.PingPong(m_DeltaTime);

                m_Light.color = Color.Lerp(
                    m_ValueLight.startColor,
                    m_ValueLight.endColor,
                    m_ValueFloat.current);
            }
        }
    } 
}