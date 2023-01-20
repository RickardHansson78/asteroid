using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asteroid Stats", fileName = "New Asteroid Stats")]
public class AsteroidStats : ScriptableObject
{
    [Header("Config:")]
    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;
    [SerializeField] private float _minSize;
    [SerializeField] private float _maxSize;
    [SerializeField] private float _minTorque;
    [SerializeField] private float _maxTorque;
    [SerializeField] private bool _split;
    [SerializeField] private int _splitNumber;
    [SerializeField] private AsteroidStats _splitStats;

    public float MinForce => _minForce;

    public float MaxForce => _maxForce;

    public float MinSize => _minSize;

    public float MaxSize => _maxSize;

    public float MinTorque => _minTorque;

    public float MaxTorque => _maxTorque;

    public bool Split => _split;

    public int SplitNumber => _splitNumber;

    public AsteroidStats SplitStats => _splitStats;
}
