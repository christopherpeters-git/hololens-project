using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

namespace RoomDesignerAssets.Scripts.Interaction
{
    public class CubeBehaviour : MonoBehaviour
    {

        private MeshRenderer _meshRenderer;
        
        // Start is called before the first frame update
        void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SayHello()
        {
            Debug.Log("Hello!");
        }
    }
}
