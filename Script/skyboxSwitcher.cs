using System.Collections;
using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex = 0;

    public float timeInterval = 5f; // 切换天空盒的时间间隔

    private Coroutine switchSkyboxCoroutine;

    void Start()
    {
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        StartSwitchSkyboxCoroutine();
    }

    void Update()
    {
        // 示例：按下空格键切换天空盒并重置时间间隔
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchSkybox();
            ResetSwitchSkyboxCoroutine();
        }
    }

    void SwitchSkybox()
    {
        currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
    }

    void StartSwitchSkyboxCoroutine()
    {
        if (switchSkyboxCoroutine != null)
            StopCoroutine(switchSkyboxCoroutine);

        switchSkyboxCoroutine = StartCoroutine(SwitchSkyboxWithTimeInterval());
    }

    void ResetSwitchSkyboxCoroutine()
    {
        StartSwitchSkyboxCoroutine();
    }

    IEnumerator SwitchSkyboxWithTimeInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            // 切换天空盒
            SwitchSkybox();
        }
    }
}
