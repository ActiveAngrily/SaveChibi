using UnityEngine;
using UnityEngine.UI;

public class controlBar : MonoBehaviour {
    public Sprite mouse;
    public Sprite wasd;
    public Sprite unknown;

    public void Mouse() {
        enabled = true;
        GetComponent<Image>().sprite = mouse;
    }

    public void WASD() {
        enabled = true;
        GetComponent<Image>().sprite = wasd;
    }
    
    public void Unknown() {
        enabled = true;
        GetComponent<Image>().sprite = unknown;
    }

    public void Disable() {
        enabled = false;
    }
}
