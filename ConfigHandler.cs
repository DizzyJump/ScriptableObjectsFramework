﻿using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework
{
    public class ConfigHandler<T> where T : ScriptableObject
    {
        static T m_ConfigRef;
        public static T Config {
            get
            {
                /*if(m_ConfigRef == null)
            {
                m_ConfigRef = Resources.Load<T>();
                if(m_ConfigRef == null)
                    m_ConfigRef = ScriptableObject.CreateInstance<T>();
            }*/
                return m_ConfigRef;    
            }
        }
    }
}
