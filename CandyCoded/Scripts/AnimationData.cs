using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded {

    public struct MaterialData {
        public Material material;
        public Color startColor;
    }

    public class AnimationData : MonoBehaviour {

        public float activeTime = 0;

        public List<MaterialData> materials = new List<MaterialData>();

        void Awake() {

            RebuildCachedData();

        }

        public void Reset() {

            activeTime = 0;

        }

        public void RebuildCachedData() {

            materials = new List<MaterialData>();

            Material[] materialsInChildren = CandyCoded.Materials.GetMaterialsInChildren(gameObject);

            CandyCoded.Materials.SetMaterialsToBlendMode(materialsInChildren, CandyCoded.StandardShader.BlendMode.Fade);

            foreach (Material material in materialsInChildren) {

                MaterialData materialData = new MaterialData();

                materialData.material = material;
                materialData.startColor = material.color;

                materials.Add(materialData);

            }

        }

    }

}
