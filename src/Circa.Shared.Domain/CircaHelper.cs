namespace Circa.Shared.Domain
{
    public static class CircaHelper
    {
        public static string DefaultCircaExceptionMessage(string serviceName)
        {
            return $"A critical error happened in the {serviceName} service.";
        }
    }
}
