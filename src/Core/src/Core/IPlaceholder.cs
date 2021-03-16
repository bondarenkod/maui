﻿namespace Microsoft.Maui
{
	/// <summary>
	/// Provides functionality to be able to use a Placeholder.
	/// </summary>
	public interface IPlaceholder : IView
	{
		/// <summary>
		/// Gets the placeholder or hint text.
		/// </summary>
		string Placeholder { get; }
	}
}