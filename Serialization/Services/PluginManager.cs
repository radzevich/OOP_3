using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PluginInterface;
using Serialization.Configs;

namespace Serialization.Services
{
    class PluginManager
    {
        private readonly Type _type;
        private readonly string _path;

        public Dictionary<string, string> GetNewClass()
        {
            if (_type.GetInterfaces().Contains(typeof(IHierarchyPlugin)))
            {
                var plugin = Activator.CreateInstance(_type) as IHierarchyPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddToConfig(typeof(IHierarchyPlugin).Name);
                    return plugin.Content;
                }
            }
            return null;
        }

        public List<string> GetNewContent()
        {
            if (_type.GetInterfaces().Contains(typeof(IContentPlugin)))
            {
                var plugin = Activator.CreateInstance(_type) as IContentPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddToConfig(typeof(IContentPlugin).Name);
                    return plugin.Content;
                }
            }
            return null; 
        }

        private void AddToConfig(string type)
        {
            var pluginConfig = new PluginConfig();

            pluginConfig.Add(type, _type.Name, _path);
        }

        private bool IsValid(string path)
        {
            return true;
        }

        public PluginManager(string pluginPath)
        {
            _type = Assembly.LoadFrom(pluginPath).GetTypes().First(); ;
            _path = pluginPath;
        }
    }
}
