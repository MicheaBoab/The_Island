using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compassImage;
    public Transform player;
    public Text CompassText;

    public GameObject iconPrefab;
    //[SerializeField]
    List<POIMarker> markers = new List<POIMarker>();
    public POIMarker campsite;
    float compassUnit;
    // Start is called before the first frame update
    void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;
        AddMarker(campsite);
    }

    // Update is called once per frame
    void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);
        Vector3 forward = player.transform.forward;
        forward.y = 0;


        foreach(POIMarker marker in markers)
        {
            marker.image.rectTransform.anchoredPosition = getPositionOnCompass(marker);
        }




        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5f));

        int displayAngle = Mathf.RoundToInt(headingAngle);
        //Debug.Log(displayAngle);
        switch (displayAngle)
        {
            case 0:
                CompassText.text = "N";
                break;
            case 360:
                CompassText.text = "N";
                break;
            case 45:
                CompassText.text = "NE";
                break;
            case 90:
                CompassText.text = "E";
                break;
            case 135:
                CompassText.text = "SE";
                break;
            case 180:
                CompassText.text = "S";
                break;
            case 225:
                CompassText.text = "SW";
                break;
            case 270:
                CompassText.text = "W";
                break;
            case 315:
                CompassText.text = "NW";
                break;
            default:
                CompassText.text = headingAngle.ToString();
                break;

        }

    }

    public void AddMarker(POIMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        markers.Add(marker);
    }

    Vector2 getPositionOnCompass(POIMarker marker)
    {
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPosition, playerFwd);
        return new Vector2(compassUnit * angle, 0f);
    }
}
