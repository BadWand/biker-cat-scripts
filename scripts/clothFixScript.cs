//https://gist.github.com/aleannox/207c0089f98eed4d78706ab8fc240b9a
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothFixScript : MonoBehaviour
{
    
    private List<Bounds> manyBounds;
    [SerializeField]
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    public float boundsExtentFactor;

    void Start () 
    {
        skinnedMeshRenderers = FindObjectsOfType<SkinnedMeshRenderer>();
        manyBounds = new List<Bounds>();
        for (var i = 0; i < skinnedMeshRenderers.Length; i++) {
            Bounds bounds = skinnedMeshRenderers[i].sharedMesh.bounds;
            bounds.Expand(bounds.extents * boundsExtentFactor);
            manyBounds.Add(bounds);
        }
    }

    private void OnPreCull()
    {
        FixBounds();
    }

    private void FixBounds() {
        for (var i = 0; i < skinnedMeshRenderers.Length; i++) {
            skinnedMeshRenderers[i].localBounds = manyBounds[i];
        }
    }
}
