using System.Threading.Tasks;

namespace Microsoft.Maui.Essentials
{
	public static partial class Email
	{
		internal static bool IsComposeSupported =>
			throw ExceptionUtils.NotSupportedOrImplementedException;

		static Task PlatformComposeAsync(EmailMessage message) =>
			throw ExceptionUtils.NotSupportedOrImplementedException;
	}

#if NETSTANDARD1_0 || NETSTANDARD2_0 || NET6_0
	public partial class EmailAttachment
	{
		string PlatformGetContentType(string extension) =>
			throw ExceptionUtils.NotSupportedOrImplementedException;
	}
#endif
}
