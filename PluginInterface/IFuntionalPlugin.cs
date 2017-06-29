namespace PluginInterface
{
    public interface IFuntionalPlugin : IPlugin
    {
        byte[] TransformTo(byte[] content);
        byte[] TransformFrom(byte[] stream);
    }
}