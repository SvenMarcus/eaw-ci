#nullable enable
using System.IO;
using System.Threading.Tasks;
using Steamworks;
using Steamworks.Ugc;
using static EawXBuild.Steam.Facepunch.Adapters.Utilities;

namespace EawXBuild.Steam.Facepunch.Adapters
{
    public class FacepunchSteamWorkshopAdapter : ISteamWorkshop
    {
        private FacepunchSteamWorkshopAdapter()
        {
        }

        public static FacepunchSteamWorkshopAdapter Instance { get; } = new FacepunchSteamWorkshopAdapter();

        private uint AppId { get; set; }

        public void Init(uint appId)
        {
            SteamClient.Init(appId);
            AppId = appId;
        }

        public void Shutdown()
        {
            SteamClient.Shutdown();
        }

        public async Task<WorkshopItemPublishResult> PublishNewWorkshopItemAsync(IWorkshopItemChangeSet settings)
        {
            Editor editor = Editor.NewCommunityFile;
            editor = EditorWithVisibility(settings.Visibility, ref editor)
                .ForAppId(AppId)
                .WithTitle(settings.Title)
                .WithDescription(settings.GetDescriptionTextFromFile())
                .WithContent(new DirectoryInfo(settings.ItemFolderPath))
                .InLanguage(settings.Language);
            WithTags(settings, ref editor);

            Steamworks.Ugc.PublishResult submitResult = await editor.SubmitAsync();
            PublishResult publishResult = submitResult.Success ? PublishResult.Ok : PublishResult.Failed;

            return new WorkshopItemPublishResult(submitResult.FileId, publishResult);
        }

        public async Task<IWorkshopItem?> QueryWorkshopItemByIdAsync(ulong id)
        {
            Item? result = await Item.GetAsync(id);

            return !result.HasValue ? null : new FacepunchWorkshopItemAdapter(result.Value);
        }

        private static void WithTags(IWorkshopItemChangeSet settings, ref Editor editor)
        {
            foreach (var tag in settings.Tags) editor.WithTag(tag);
        }
    }
}