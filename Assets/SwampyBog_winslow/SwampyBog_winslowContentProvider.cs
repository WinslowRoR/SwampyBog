using R2API;
using RoR2.ContentManagement;
using UnityEngine;
using RoR2;
using System.Collections;
using System;
using Path = System.IO.Path;
using System.Linq;
using ShaderSwapper;
using System.Collections.Generic;

namespace SwampyBog_winslow
{
    public class SwampyBog_winslowContent : IContentPackProvider
    {
        public string identifier => SwampyBog_winslowMain.GUID;

        public static ReadOnlyContentPack readOnlyContentPack => new ReadOnlyContentPack(SwampyBog_winslowContentPack);
        internal static ContentPack SwampyBog_winslowContentPack { get; } = new ContentPack();

        internal const string ScenesAssetBundleFileName = "swampybog_winslowscene";
        internal const string AssetsAssetBundleFileName = "swampybog_winslowassets";

        internal const string MusicSoundBankFileName = "SwampyBogMusic.bnk";
        internal const string InitSoundBankFileName = "SwampyBogInit.bnk";
        internal const string SoundsSoundBankFileName = "SwampyBogSounds.bnk";

        private static AssetBundle scenesAssetBundle;
        private static AssetBundle contentAssetBundle;

        public static SceneDef SwampyBogSceneDef;

        public IEnumerator LoadStaticContentAsync(LoadStaticContentAsyncArgs args)
        {
            var musicFolderFullPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(SwampyBog_winslowContent).Assembly.Location), "soundbanks");
            LoadSoundBanks(musicFolderFullPath);

            yield return LoadAssetBundle(
                Path.Combine(SwampyBog_winslowMain.assetBundleDir, ScenesAssetBundleFileName),
                args.progressReceiver,
                (assetBundle) => scenesAssetBundle = assetBundle);

            yield return LoadAssetBundle(
                Path.Combine(SwampyBog_winslowMain.assetBundleDir, AssetsAssetBundleFileName),
                args.progressReceiver,
                (assetBundle) => contentAssetBundle = assetBundle);

            yield return LoadAllAssetsAsync(contentAssetBundle, args.progressReceiver, (Action<SceneDef[]>)((assets) =>
            {
                SwampyBogSceneDef = assets.First(sceneDef => sceneDef.cachedName == "swampybog_winslow");
                SwampyBog_winslowContentPack.sceneDefs.Add(assets);
            }));

            var upgradeStubbedShaders = contentAssetBundle.UpgradeStubbedShadersAsync();
            while (upgradeStubbedShaders.MoveNext())
            {
                yield return upgradeStubbedShaders.Current;
            }

            yield return LoadAllAssetsAsync(contentAssetBundle, args.progressReceiver, (Action<UnlockableDef[]>)((assets) =>
            {
                SwampyBog_winslowContentPack.unlockableDefs.Add(assets);
            }));

            R2API.StageRegistration.RegisterSceneDefToNormalProgression(SwampyBogSceneDef);
        }

        private IEnumerator LoadAssetBundle(string assetBundleFullPath, IProgress<float> progress, Action<AssetBundle> onAssetBundleLoaded)
        {
            var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(assetBundleFullPath);
            while (!assetBundleCreateRequest.isDone)
            {
                progress.Report(assetBundleCreateRequest.progress);
                yield return null;
            }

            onAssetBundleLoaded(assetBundleCreateRequest.assetBundle);

            yield break;
        }

        public IEnumerator GenerateContentPackAsync(GetContentPackAsyncArgs args)
        {
            ContentPack.Copy(SwampyBog_winslowContentPack, args.output);
            args.ReportProgress(1f);
            yield break;
        }

        public IEnumerator FinalizeAsync(FinalizeAsyncArgs args)
        {
            args.ReportProgress(1f);
            yield break;
        }

        private void AddSelf(ContentManager.AddContentPackProviderDelegate addContentPackProvider)
        {
            addContentPackProvider(this);
        }

        internal SwampyBog_winslowContent()
        {
            ContentManager.collectContentPackProviders += AddSelf;
        }

        private static IEnumerator LoadAllAssetsAsync<T>(AssetBundle assetBundle, IProgress<float> progress, Action<T[]> onAssetsLoaded) where T : UnityEngine.Object
        {
            var sceneDefsRequest = assetBundle.LoadAllAssetsAsync<T>();
            while (!sceneDefsRequest.isDone)
            {
                progress.Report(sceneDefsRequest.progress);
                yield return null;
            }

            onAssetsLoaded(sceneDefsRequest.allAssets.Cast<T>().ToArray());

            yield break;
        }

        internal static void LoadSoundBanks(string soundbanksFolderPath)
        {
            var akResult = AkSoundEngine.AddBasePath(soundbanksFolderPath);
            SwampyBog_winslowMain.LogInfo($"AddBasePath result: {akResult} | Path: {soundbanksFolderPath}");

            akResult = AkSoundEngine.LoadBank(InitSoundBankFileName, out var _);
            SwampyBog_winslowMain.LogInfo($"LoadBank {InitSoundBankFileName}: {akResult}");

            akResult = AkSoundEngine.LoadBank(MusicSoundBankFileName, out var _);
            SwampyBog_winslowMain.LogInfo($"LoadBank {MusicSoundBankFileName}: {akResult}");
        }

    }

}