using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    private int level = 1;
    [SerializeField] private Text levelNumberText;
    [SerializeField] private Image[] arrowImages;

    public void IncrementLevel() {
        level++;
        levelNumberText.text = $"Level: {level}";
    }

    public void RefreshControlPanel(Vector2[] directionVectors) {
        for (int i = 0; i < 3; i++) {
            if (directionVectors[i] == Vector2.up) {
                var newRot = new Vector3(0, 0, 90);
                arrowImages[i].GetComponent<RectTransform>().eulerAngles = newRot;
            }
            if (directionVectors[i] == Vector2.right) {
                var newRot = new Vector3(0, 0, 0);
                arrowImages[i].GetComponent<RectTransform>().eulerAngles = newRot;
            }
            if (directionVectors[i] == Vector2.down) {
                var newRot = new Vector3(0, 0, 270);
                arrowImages[i].GetComponent<RectTransform>().eulerAngles = newRot;
            }
            if (directionVectors[i] == Vector2.left) {
                var newRot = new Vector3(0, 0, 180);
                arrowImages[i].GetComponent<RectTransform>().eulerAngles = newRot;
            }
        }
    }
}
