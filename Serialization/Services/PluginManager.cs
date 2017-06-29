using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Serialization.Configs;
using PluginInterface;
using Services;
using Serialization;

namespace Serialization.Services
{
    class PluginManager
    {
        private readonly Type _type;
        private readonly string _path;

        public void GetNewFunctionality(ref Formatter handlerTo, ref Formatter handlerFrom)
        {
            if (_type.GetInterfaces().Contains(typeof(IFuntionalPlugin)))
            {
                var plugin = Activator.CreateInstance(_type) as IFuntionalPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddToConfig(typeof(IFuntionalPlugin).Name, plugin.Name);
                    handlerTo.Handler = plugin.TransformTo;
                    handlerFrom.Handler = plugin.TransformFrom;
                    AddToConfig(typeof(IFuntionalPlugin).Name, plugin.Name);     
                }
            }
        }

        public Dictionary<string, string> GetNewClass()
        {
            if (_type.GetInterfaces().Contains(typeof(IHierarchyPlugin)))
            {
                var plugin = Activator.CreateInstance(_type) as IHierarchyPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddToConfig(typeof(IHierarchyPlugin).Name, plugin.Name);
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
                    AddToConfig(typeof(IContentPlugin).Name, plugin.Name);
                    return plugin.Content;
                }
            }
            return null; 
        }

        public string GetPluginName(Type type)
        {
            var plugin = Activator.CreateInstance(_type) as IPlugin;
            return plugin.Name;            
        }

        private void AddToConfig(string type, string name)
        {
            var pluginConfig = new PluginConfig();

            pluginConfig.Add(type, _type.Name, _path, name);
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
