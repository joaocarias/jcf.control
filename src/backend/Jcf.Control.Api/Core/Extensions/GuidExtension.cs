namespace Jcf.Control.Api.Core.Extensions
{
    public static class GuidExtension
    {
        public static bool ValidadeIsEquals(this Guid item1, Guid item2)
        {
            if (item1 != item2)
                throw new ArgumentException("Id não são iguais");

            return true; 
        }
    }
}
