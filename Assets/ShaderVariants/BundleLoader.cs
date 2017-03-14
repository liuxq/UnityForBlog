using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BundleLoader : MonoBehaviour
{

	void Start () {
        load();
	}


    public void load()
    {
        StartCoroutine(LoadMainGameObject("file://" + Application.dataPath + "/StreamingAssets/" + "ShaderVariantsShader"));
        StartCoroutine(LoadMainGameObject("file://" + Application.dataPath + "/StreamingAssets/" + "ShaderVariantsPrefab"));
    }

    private IEnumerator LoadMainGameObject(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;

        if (bundle.url.Contains("ShaderVariantsShader"))
        {
            //依赖shader包
            bundle.assetBundle.LoadAllAssets();
        }
        else
        {
            UnityEngine.Object obj = bundle.assetBundle.LoadAsset("assets/ShaderVariants/resources/red.prefab");
            Instantiate(obj);
            bundle.assetBundle.Unload(false);
        } 
    }

}
