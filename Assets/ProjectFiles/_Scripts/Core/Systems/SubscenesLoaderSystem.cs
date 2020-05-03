using Unity.Entities;
using Unity.Scenes;

public class SubscenesLoaderSystem : ComponentSystem
{
    private SceneSystem sceneSystem;

    protected override void OnCreate()
    {
        //sceneSystem = World.GetOrCreateSystem<SceneSystem>();
    }

    protected override void OnUpdate()
    {
        /*SubScene[] subscenes = SubsceneLoader.Instance.SubScenes;

        if (subscenes.Length > 0)
        {
            foreach (SubScene subScene in subscenes)
            {
                sceneSystem.LoadSceneAsync(subScene.SceneGUID);
            }
        }*/
    }
}
