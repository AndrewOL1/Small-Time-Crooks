using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace AO.Scripts
{
    public class HandVisualHider : MonoBehaviour
    {
        [Tooltip("Assign the XRDirectInteractor or XRRayInteractor component here")]
        public MonoBehaviour interactorComponent;

        private IXRSelectInteractor interactor;

        [Tooltip("Assign ONLY the mesh object of the hand, not the entire controller")]
        public GameObject handVisual;

        private void Awake()
        {
            // Convert the assigned component into the interface
            interactor = interactorComponent as IXRSelectInteractor;
        }

        private void OnEnable()
        {
            if (interactor != null)
            {
                interactor.selectEntered.AddListener(OnSelectEnter);
                interactor.selectExited.AddListener(OnSelectExit);
            }
        }

        private void OnDisable()
        {
            if (interactor != null)
            {
                interactor.selectEntered.RemoveListener(OnSelectEnter);
                interactor.selectExited.RemoveListener(OnSelectExit);
            }
        }

        private void OnSelectEnter(SelectEnterEventArgs args)
        {
            if (handVisual != null)
                handVisual.SetActive(false);
        }

        private void OnSelectExit(SelectExitEventArgs args)
        {
            if (handVisual != null)
                handVisual.SetActive(true);
        }
    }
}