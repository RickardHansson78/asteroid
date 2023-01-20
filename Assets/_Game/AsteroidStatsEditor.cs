using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(AsteroidStats))]
public class AsteroidStatsEditor : Editor
{
    public VisualTreeAsset m_UXML;

    private AsteroidStats asteroidStats;

    private void OnEnable()
    {
        asteroidStats = (AsteroidStats)target;
    }

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();
        m_UXML.CloneTree(root);

        return root;
    }
}
