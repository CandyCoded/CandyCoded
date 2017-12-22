using UnityEngine;

namespace CandyCoded {

    public static class InputManager {

        public static bool InputDown {
            get {

                if (SystemInfo.deviceType == DeviceType.Desktop) {

                    return Input.GetMouseButtonDown(0);

                } else if (SystemInfo.deviceType == DeviceType.Handheld) {

                    return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;

                }

                return false;

            }
            private set { }
        }

        public static Vector3 InputScreenPosition {
            get {

                if (SystemInfo.deviceType == DeviceType.Desktop) {

                    return Input.mousePosition;

                } else if (SystemInfo.deviceType == DeviceType.Handheld) {

                    return Input.GetTouch(0).position;

                }

                return Vector3.zero;

            }
            private set { }
        }

        public static bool InputUp {
            get {

                if (SystemInfo.deviceType == DeviceType.Desktop) {

                    return Input.GetMouseButtonUp(0);

                } else if (SystemInfo.deviceType == DeviceType.Handheld) {

                    return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;

                }

                return false;

            }
            private set { }
        }

    }

}
