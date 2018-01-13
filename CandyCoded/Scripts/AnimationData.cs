using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public struct TransformData
    {
        public Vector3 position;
        public Vector3 scale;
        public Quaternion rotation;
    }

    public struct MaterialData
    {
        public Material material;
        public Color startColor;
    }

    public class AnimationData : MonoBehaviour
    {

        public float activeTime = 0;

        public TransformData transformData = new TransformData();

        public List<MaterialData> materials = new List<MaterialData>();

        void Awake()
        {

            RebuildCachedData();

        }

        public void ResetAnimationStartTime()
        {

            activeTime = 0;

        }

        public void RebuildCachedData()
        {

            transformData.position = gameObject.transform.localPosition;
            transformData.scale = gameObject.transform.localScale;
            transformData.rotation = gameObject.transform.localRotation;

            materials = new List<MaterialData>();

            Material[] materialsInChildren = CandyCoded.Materials.GetMaterialsInChildren(gameObject);

            CandyCoded.Materials.SetMaterialsToBlendMode(materialsInChildren, CandyCoded.StandardShader.BlendMode.Fade);

            foreach (Material material in materialsInChildren)
            {

                MaterialData materialData = new MaterialData();

                materialData.material = material;
                materialData.startColor = material.color;

                materials.Add(materialData);

            }

        }

    }

}
