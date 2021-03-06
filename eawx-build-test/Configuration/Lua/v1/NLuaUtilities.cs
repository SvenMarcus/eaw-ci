using NLua;

namespace EawXBuildTest.Configuration.Lua.v1
{
    public static class NLuaUtilities
    {
        public static LuaTable MakeLuaTable(NLua.Lua luaInterpreter, string tableName)
        {
            luaInterpreter.NewTable(tableName);
            LuaTable taskTable = luaInterpreter.GetTable(tableName);
            return taskTable;
        }
    }
}