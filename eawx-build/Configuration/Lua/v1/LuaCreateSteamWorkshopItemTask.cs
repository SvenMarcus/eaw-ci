using System;
using System.Linq;
using EawXBuild.Core;
using NLua;

namespace EawXBuild.Configuration.Lua.v1 {
    public class LuaCreateSteamWorkshopItemTask : ILuaTask {
        public LuaCreateSteamWorkshopItemTask(ITaskBuilder taskBuilder, LuaTable table) {
            
            taskBuilder
                .With("AppId", Convert.ToUInt32(table["app_id"]))
                .With("Title", table["title"])
                .With("DescriptionFilePath", table["description_file"])
                .With("ItemFolderPath", table["item_folder"])
                .With("Visibility", table["visibility"])
                .With("Language", table["language"]);

            var tags = (LuaTable) table["tags"];
            var stringTags = tags?.Values.Cast<string>().ToHashSet();
            if (stringTags != null)
                taskBuilder.With("Tags", stringTags);

            Task = taskBuilder.Build();
        }

        public ITask Task { get; private set; }
    }
}