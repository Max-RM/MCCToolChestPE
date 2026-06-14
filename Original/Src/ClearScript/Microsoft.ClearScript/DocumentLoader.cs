using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public abstract class DocumentLoader
{
	private class DefaultImpl : DocumentLoader
	{
		public static readonly DefaultImpl Instance = new DefaultImpl();

		private static readonly IReadOnlyCollection<string> relativePrefixes = new List<string>
		{
			"." + Path.DirectorySeparatorChar,
			"." + Path.AltDirectorySeparatorChar,
			".." + Path.DirectorySeparatorChar,
			".." + Path.AltDirectorySeparatorChar
		};

		private readonly object cacheLock = new object();

		private readonly List<Document> cache = new List<Document>();

		private const int maxCacheSize = 1024;

		private DefaultImpl()
		{
		}

		private static async Task<List<Uri>> GetCandidateUrisAsync(DocumentSettings settings, DocumentInfo? sourceInfo, Uri uri)
		{
			List<Uri> candidateUris = new List<Uri>();
			if (string.IsNullOrWhiteSpace(settings.FileNameExtensions))
			{
				candidateUris.Add(uri);
			}
			else
			{
				foreach (Uri testUri in ApplyFileNameExtensions(sourceInfo, uri, settings.FileNameExtensions))
				{
					if (await IsCandidateUriAsync(settings, testUri).ConfigureAwait(continueOnCapturedContext: false))
					{
						candidateUris.Add(testUri);
					}
				}
			}
			return candidateUris;
		}

		private static async Task<List<Uri>> GetCandidateUrisAsync(DocumentSettings settings, DocumentInfo? sourceInfo, string specifier)
		{
			List<Uri> candidateUris = new List<Uri>();
			IEnumerable<Uri> enumerable = GetRawUris(settings, sourceInfo, specifier).Distinct();
			if (!string.IsNullOrWhiteSpace(settings.FileNameExtensions))
			{
				enumerable = enumerable.SelectMany((Uri uri) => ApplyFileNameExtensions(sourceInfo, uri, settings.FileNameExtensions));
			}
			foreach (Uri testUri in enumerable)
			{
				if (await IsCandidateUriAsync(settings, testUri).ConfigureAwait(continueOnCapturedContext: false))
				{
					candidateUris.Add(testUri);
				}
			}
			return candidateUris;
		}

		private static IEnumerable<Uri> GetRawUris(DocumentSettings settings, DocumentInfo? sourceInfo, string specifier)
		{
			Uri result;
			Uri result2;
			if (sourceInfo.HasValue && SpecifierMayBeRelative(settings, specifier))
			{
				result = GetBaseUri(sourceInfo.Value);
				if (result != null && Uri.TryCreate(result, specifier, out result2))
				{
					yield return result2;
				}
			}
			string searchPath = settings.SearchPath;
			if (!string.IsNullOrWhiteSpace(searchPath))
			{
				foreach (string item in searchPath.SplitSearchPath())
				{
					if (Uri.TryCreate(item, UriKind.Absolute, out result) && TryCombineSearchUri(result, specifier, out result2))
					{
						yield return result2;
					}
				}
			}
			if (MiscHelpers.Try(out var result3, () => Path.Combine(Directory.GetCurrentDirectory(), specifier)) && Uri.TryCreate(result3, UriKind.Absolute, out result2))
			{
				yield return result2;
			}
			if (MiscHelpers.Try(out result3, () => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, specifier)) && Uri.TryCreate(result3, UriKind.Absolute, out result2))
			{
				yield return result2;
			}
			using Process process = Process.GetCurrentProcess();
			ProcessModule mainModule = process.MainModule;
			if (mainModule != null && Uri.TryCreate(mainModule.FileName, UriKind.Absolute, out result) && Uri.TryCreate(result, specifier, out result2))
			{
				yield return result2;
			}
		}

		private static IEnumerable<Uri> ApplyFileNameExtensions(DocumentInfo? sourceInfo, Uri uri, string fileNameExtensions)
		{
			yield return uri;
			UriBuilder builder = new UriBuilder(uri);
			string path = builder.Path;
			if (string.IsNullOrEmpty(Path.GetFileName(path)) || Path.HasExtension(path))
			{
				yield break;
			}
			string sourceFileNameExtension = null;
			if (sourceInfo.HasValue)
			{
				sourceFileNameExtension = Path.GetExtension((sourceInfo.Value.Uri != null) ? new UriBuilder(sourceInfo.Value.Uri).Path : sourceInfo.Value.Name);
				if (!string.IsNullOrEmpty(sourceFileNameExtension))
				{
					builder.Path = Path.ChangeExtension(path, sourceFileNameExtension);
					yield return builder.Uri;
				}
			}
			foreach (string item in fileNameExtensions.SplitSearchPath())
			{
				string text = (item.StartsWith(".", StringComparison.Ordinal) ? item : ("." + item));
				if (!text.Equals(sourceFileNameExtension, StringComparison.OrdinalIgnoreCase))
				{
					builder.Path = Path.ChangeExtension(path, text);
					yield return builder.Uri;
				}
			}
		}

		private static bool SpecifierMayBeRelative(DocumentSettings settings, string specifier)
		{
			if (settings.AccessFlags.HasFlag(DocumentAccessFlags.EnforceRelativePrefix))
			{
				return relativePrefixes.Any(specifier.StartsWith);
			}
			return true;
		}

		private static Uri GetBaseUri(DocumentInfo sourceInfo)
		{
			Uri result = sourceInfo.Uri;
			if (result == null && !Uri.TryCreate(sourceInfo.Name, UriKind.RelativeOrAbsolute, out result))
			{
				return null;
			}
			if (!result.IsAbsoluteUri)
			{
				return null;
			}
			return result;
		}

		private static bool TryCombineSearchUri(Uri searchUri, string specifier, out Uri uri)
		{
			string absoluteUri = searchUri.AbsoluteUri;
			if (!absoluteUri.EndsWith("/", StringComparison.Ordinal))
			{
				searchUri = new Uri(absoluteUri + "/");
			}
			return Uri.TryCreate(searchUri, specifier, out uri);
		}

		private static async Task<bool> IsCandidateUriAsync(DocumentSettings settings, Uri uri)
		{
			bool result;
			if (uri.IsFile)
			{
				result = settings.AccessFlags.HasFlag(DocumentAccessFlags.EnableFileLoading) && File.Exists(uri.LocalPath);
			}
			else
			{
				bool flag = settings.AccessFlags.HasFlag(DocumentAccessFlags.EnableWebLoading);
				bool flag2 = flag;
				if (flag2)
				{
					flag2 = await WebDocumentExistsAsync(uri).ConfigureAwait(continueOnCapturedContext: false);
				}
				result = flag2;
			}
			return result;
		}

		private static async Task<bool> WebDocumentExistsAsync(Uri uri)
		{
			using HttpClient client = new HttpClient();
			using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, uri);
			using HttpResponseMessage httpResponseMessage = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			return httpResponseMessage.IsSuccessStatusCode;
		}

		private async Task<Document> LoadDocumentAsync(DocumentSettings settings, Uri uri, DocumentCategory category, DocumentContextCallback contextCallback)
		{
			Document cachedDocument = GetCachedDocument(uri);
			if (cachedDocument != null)
			{
				return cachedDocument;
			}
			DocumentAccessFlags accessFlags = settings.AccessFlags;
			string contents;
			if (uri.IsFile)
			{
				if (!accessFlags.HasFlag(DocumentAccessFlags.EnableFileLoading))
				{
					throw new UnauthorizedAccessException("This script engine is not configured for loading documents from the file system.");
				}
				using StreamReader reader = new StreamReader(uri.LocalPath);
				contents = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				if (!accessFlags.HasFlag(DocumentAccessFlags.EnableWebLoading))
				{
					throw new UnauthorizedAccessException("This script engine is not configured for downloading documents from the Web.");
				}
				using WebClient client = new WebClient();
				contents = await client.DownloadStringTaskAsync(uri).ConfigureAwait(continueOnCapturedContext: false);
			}
			DocumentInfo documentInfo = new DocumentInfo(uri);
			documentInfo.Category = category;
			documentInfo.ContextCallback = contextCallback;
			DocumentInfo info = documentInfo;
			settings.LoadCallback?.Invoke(ref info);
			return CacheDocument(new StringDocument(info, contents));
		}

		private Document GetCachedDocument(Uri uri)
		{
			lock (cacheLock)
			{
				for (int i = 0; i < cache.Count; i++)
				{
					Document document = cache[i];
					if (document.Info.Uri == uri)
					{
						cache.RemoveAt(i);
						cache.Insert(0, document);
						return document;
					}
				}
				return null;
			}
		}

		private Document CacheDocument(Document document)
		{
			lock (cacheLock)
			{
				Document document2 = cache.FirstOrDefault((Document testDocument) => testDocument.Info.Uri == document.Info.Uri);
				if (document2 != null)
				{
					return document2;
				}
				while (cache.Count >= 1024)
				{
					cache.RemoveAt(cache.Count - 1);
				}
				cache.Insert(0, document);
				return document;
			}
		}

		public override async Task<Document> LoadDocumentAsync(DocumentSettings settings, DocumentInfo? sourceInfo, string specifier, DocumentCategory category, DocumentContextCallback contextCallback)
		{
			MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
			if ((settings.AccessFlags & DocumentAccessFlags.EnableAllLoading) == 0)
			{
				throw new UnauthorizedAccessException("This script engine is not configured for loading documents.");
			}
			if (category == null)
			{
				category = (sourceInfo.HasValue ? sourceInfo.Value.Category : DocumentCategory.Script);
			}
			Uri result;
			List<Uri> list = ((!Uri.TryCreate(specifier, UriKind.RelativeOrAbsolute, out result) || !result.IsAbsoluteUri) ? (await GetCandidateUrisAsync(settings, sourceInfo, specifier).ConfigureAwait(continueOnCapturedContext: false)) : (await GetCandidateUrisAsync(settings, sourceInfo, result).ConfigureAwait(continueOnCapturedContext: false)));
			if (list.Count < 1)
			{
				throw new FileNotFoundException(null, specifier);
			}
			if (list.Count == 1)
			{
				return await LoadDocumentAsync(settings, list[0], category, contextCallback).ConfigureAwait(continueOnCapturedContext: false);
			}
			List<Exception> exceptions = new List<Exception>(list.Count);
			foreach (Uri item2 in list)
			{
				Task<Document> task = LoadDocumentAsync(settings, item2, category, contextCallback);
				try
				{
					return await task.ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception item)
				{
					if (task.Exception != null && task.Exception.InnerExceptions.Count == 1)
					{
						exceptions.Add(item);
					}
					else
					{
						exceptions.Add(task.Exception);
					}
				}
			}
			if (exceptions.Count < 1)
			{
				MiscHelpers.AssertUnreachable();
				throw new FileNotFoundException(null, specifier);
			}
			if (exceptions.Count == 1)
			{
				MiscHelpers.AssertUnreachable();
				throw new FileLoadException(exceptions[0].Message, specifier, exceptions[0]);
			}
			throw new AggregateException(exceptions).Flatten();
		}

		public override void DiscardCachedDocuments()
		{
			lock (cacheLock)
			{
				cache.Clear();
			}
			base.DiscardCachedDocuments();
		}
	}

	public static DocumentLoader Default => DefaultImpl.Instance;

	public virtual Document LoadDocument(DocumentSettings settings, DocumentInfo? sourceInfo, string specifier, DocumentCategory category, DocumentContextCallback contextCallback)
	{
		MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
		try
		{
			return LoadDocumentAsync(settings, sourceInfo, specifier, category, contextCallback).Result;
		}
		catch (AggregateException ex)
		{
			AggregateException ex2 = ex.Flatten();
			if (ex2.InnerExceptions.Count == 1)
			{
				throw new FileLoadException(null, specifier, ex2.InnerExceptions[0]);
			}
			throw new FileLoadException(null, specifier, ex2);
		}
	}

	public abstract Task<Document> LoadDocumentAsync(DocumentSettings settings, DocumentInfo? sourceInfo, string specifier, DocumentCategory category, DocumentContextCallback contextCallback);

	public virtual void DiscardCachedDocuments()
	{
	}
}
