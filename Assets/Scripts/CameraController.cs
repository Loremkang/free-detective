using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraController : MonoBehaviour
{
    public float moveTime = Const.cameraMoveTime;
    public Vector2 scaledFocusPos = new Vector2(-0.82f, -0.049f);
    public Vector2 defaultPos = new Vector2(9.6f, 5.4f);
    public Vector2 targetPos;
    Vector3 deltaPos;
    public float defaultSize;
    public float maximalSize;
    public float targetSize;
    float deltaSize;
    Camera camera;
    float movingTime;

    // Start is called before the first frame update
    void Start()
    {
        Data.cameraController = this;
        camera = gameObject.GetComponent<Camera>();
        defaultSize = camera.orthographicSize;
        maximalSize = defaultSize / 2;
        // targetSize = camera.orthographicSize;

        // Driver gameDriver = new Driver();
        // gameDriver.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTime > 0) {
            transform.position += deltaPos * Time.deltaTime;
            camera.orthographicSize += deltaSize * Time.deltaTime;
            movingTime -= Time.deltaTime;
            if (movingTime <= 0) {
                transform.position = new Vector3(targetPos.x, targetPos.y, -10);
                camera.orthographicSize = targetSize;
                movingTime = 0;
            }
        }
    }

    public void Move(Vector2 targetPos, float targetSize) {
        deltaPos = targetPos - new Vector2(transform.position.x, transform.position.y);
        deltaSize = targetSize - camera.orthographicSize;
        movingTime = moveTime;
    }

    public void MoveToCatchItem(Vector2 itemPos) {
        float lx = itemPos.x + defaultPos.x;
        float rx = defaultPos.x - itemPos.x;
        float dy = itemPos.y + defaultPos.y;
        float uy = defaultPos.y - itemPos.y;

        Assert.IsTrue(lx >= 0 && rx >= 0 && dy >= 0 && uy >= 0);
        targetSize = camera.orthographicSize;
        targetSize = Mathf.Min(targetSize, lx / (1.78f + scaledFocusPos.x));
        targetSize = Mathf.Min(targetSize, rx / (1.78f - scaledFocusPos.x));
        targetSize = Mathf.Min(targetSize, dy / (1.0f + scaledFocusPos.y));
        targetSize = Mathf.Min(targetSize, uy / (1.0f - scaledFocusPos.y));
        targetSize = Mathf.Min(targetSize, maximalSize);
        targetPos = itemPos - targetSize * scaledFocusPos;
        Move(targetPos, targetSize);
    }

    public void MoveBack() {
        targetPos = new Vector2(0, 0);
        targetSize = defaultSize;
        Move(new Vector2(0, 0), defaultSize);
    }


}
