using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Toolkid.BoundsToolkit
{
    public static class BoundsUtility 
    {
        public static Bounds[] GetBounds(this Collider[] values) {
            Bounds[] result = new Bounds[values.Length];
            for (int i = 0; i < values.Length; i++) {
                result[i] = values[i].bounds;
            }
            return result;
        }
        public static Bounds[] GetBounds(this Renderer[] values) {
            Bounds[] result = new Bounds[values.Length];
            for (int i = 0; i < values.Length; i++) {
                result[i] = values[i].bounds;
            }
            return result;
        }

        public static Bounds[] GetBounds(this Mesh[] values) {
            Bounds[] result = new Bounds[values.Length];
            for (int i = 0; i < values.Length; i++) {
                result[i] = values[i].bounds;
            }
            return result;
        }
        
        public static Bounds FindBounds(this Bounds[] values) {            
            Vector3 max = values[0].GetMaxBounds();
            Vector3 min = values[0].GetMinBounds();
            for (int i = 1; i< values.Length; i++) {
                max = max.TryGetMaxValue(values[i].GetMaxBounds());
                min = min.TryGetMinValue(values[i].GetMinBounds());
            }
            Vector3 center = (max + min) / 2f;
            Vector3 size = max - min;
            return new Bounds(center, size);
        }

        public static Vector3 TryGetMaxValue(this Vector3 origin, Vector3 compare) {
            float x = Mathf.Max(origin.x, compare.x);
            float y = Mathf.Max(origin.y, compare.y);
            float z = Mathf.Max(origin.z, compare.z);
            return new Vector3(x, y, z);
        }

        public static Vector3 TryGetMinValue(this Vector3 origin, Vector3 compare) {
            float x = Mathf.Min(origin.x, compare.x);
            float y = Mathf.Min(origin.y, compare.y);
            float z = Mathf.Min(origin.z, compare.z);
            return new Vector3(x, y, z);
        }

        public static Vector3 GetMaxBounds(this Bounds value) {
            float x = Mathf.Max(value.max.x, value.min.x);
            float y = Mathf.Max(value.max.y, value.min.y);
            float z = Mathf.Max(value.max.z, value.min.z);
            return new Vector3(x, y, z);
        }

        public static Vector3 GetMinBounds(this Bounds value) {
            float x = Mathf.Min(value.max.x, value.min.x);
            float y = Mathf.Min(value.max.y, value.min.y);
            float z = Mathf.Min(value.max.z, value.min.z);
            return new Vector3(x, y, z);
        }

    }
}
