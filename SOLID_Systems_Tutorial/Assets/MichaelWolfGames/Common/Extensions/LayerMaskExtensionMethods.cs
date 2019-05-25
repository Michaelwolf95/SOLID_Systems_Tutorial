using UnityEngine;

namespace MichaelWolfGames
{
    public static class LayerMaskExtensionMethods
    {
        public static bool Contains(this LayerMask mask, int layer)
        {
            return (mask.value == (mask.value | (1 << layer)));
        }
    }
}