namespace PluginInterface
{
    public interface IFuntionalPlugin
    {
        byte[] TransformTo(byte[] content);
        byte[] TransformFrom(byte[] stream);
    }
}