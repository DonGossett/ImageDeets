using Humanizer;
using ImageDeets.Core.Extensions;

namespace ImageDeets.Core
{
    public class DeetsLogger
    {
        public DeetsLogger(string prefix = "  ")
        {
            Prefix = prefix;
        }

        public async Task Log(FileInfo fileInfo, int indent = 0)
        {
            if (fileInfo != null)
            {
                int HeadSpace = indent;
                int ContentSpace = indent + 1;

                await Log("File Information", HeadSpace);
                await Log("Attributes", fileInfo.Attributes, ContentSpace);
                await Log("Creation Time", fileInfo.CreationTime, ContentSpace);
                await Log("Creation Time UTC", fileInfo.CreationTimeUtc, ContentSpace);
                await Log(fileInfo.Directory, ContentSpace);
                await Log("Directory Name", fileInfo.DirectoryName, ContentSpace);
                await Log("Exists", fileInfo.Exists, ContentSpace);
                await Log("Extension", fileInfo.Extension, ContentSpace);
                await Log("Full Name", fileInfo.FullName, ContentSpace);
                await Log("Is Read Only", fileInfo.IsReadOnly, ContentSpace);
                await Log("Last Access Time", fileInfo.LastAccessTime, ContentSpace);
                await Log("Last Access Time UTC", fileInfo.LastAccessTimeUtc, ContentSpace);
                await Log("Last Write Time", fileInfo.LastWriteTime, ContentSpace);
                await Log("Last Write Time UTC", fileInfo.LastWriteTimeUtc, ContentSpace);
                await Log("Length", fileInfo.Length.Bytes().ToString(), ContentSpace);
                await Log("Link Target", fileInfo.LinkTarget);
                await Log("Name", fileInfo.Name, ContentSpace);
            }
        }

        public async Task Log(DirectoryInfo? dirInfo, int indent = 0)
        {
            if (dirInfo != null)
            {
                int HeadSpace = indent;
                int ContentSpace = indent + 1;

                await Log("Directory Information", HeadSpace);
                await Log("Attributes", dirInfo.Attributes, ContentSpace);
                await Log("Creation Time", dirInfo.CreationTime, ContentSpace);
                await Log("Creation Time UTC", dirInfo.CreationTimeUtc, ContentSpace);
                await Log("Exists", dirInfo.Exists, ContentSpace);
                await Log("Extension", dirInfo.Extension, ContentSpace);
                await Log("Full Name", dirInfo.FullName, ContentSpace);
                await Log("Last Access Time", dirInfo.LastAccessTime, ContentSpace);
                await Log("Last Access Time UTC", dirInfo.LastAccessTimeUtc, ContentSpace);
                await Log("Last Write Time", dirInfo.LastWriteTime, ContentSpace);
                await Log("Last Write Time UTC", dirInfo.LastWriteTimeUtc, ContentSpace);
                await Log("Link Target", dirInfo.LinkTarget, ContentSpace);
                await Log("Name", dirInfo.Name, ContentSpace);
            }
        }

        /// <summary>
        /// Logs the description and associated value.
        /// </summary>
        /// <param name="itemDescription">The description to log.</param>
        /// <param name="itemValue">The value to log.</param>
        /// <param name="indent">The number indents to prefix the line.</param>
        /// <returns>The task background operation.</returns>
        private async Task Log(string itemDescription, long itemValue, int indent = 0)
        {
            await Log(itemDescription, itemValue.ToString(), indent);
        }

        /// <summary>
        /// Logs the description and associated value.
        /// </summary>
        /// <param name="itemDescription">The description to log.</param>
        /// <param name="itemValue">The value to log.</param>
        /// <param name="indent">The number indents to prefix the line.</param>
        /// <returns>The task background operation.</returns>
        private async Task Log(string itemDescription, bool itemValue, int indent = 0)
        {
            await Log(itemDescription, itemValue.ToYesNo(), indent);
        }

        /// <summary>
        /// Logs the description and associated value.
        /// </summary>
        /// <param name="itemDescription">The description to log.</param>
        /// <param name="itemValue">The value to log.</param>
        /// <param name="indent">The number indents to prefix the line.</param>
        /// <returns>The task background operation.</returns>
        private async Task Log(string itemDescription, DateTime? itemValue, int indent = 0)
        {
            string DateTime = "";

            if (itemValue.HasValue)
            {
                DateTime = itemValue.Value.ToString();
            }

            await Log(itemDescription, DateTime, indent);
        }

        /// <summary>
        /// Logs the description and associated value.
        /// </summary>
        /// <param name="itemDescription">The description to log.</param>
        /// <param name="itemValue">The value to log.</param>
        /// <param name="indent">The number indents to prefix the line.</param>
        /// <returns>The task background operation.</returns>
        private async Task Log(string itemDescription, FileAttributes itemValue, int indent = 0)
        {
            await Log(itemDescription, itemValue.Humanize(), indent);
        }

        /// <summary>
        /// Logs the description.
        /// </summary>
        /// <param name="itemDescription">The description to log.</param>
        /// <param name="indent">The number indents to prefix the line.</param>
        /// <returns>The task background operation.</returns>
        private async Task Log(string itemDescription, int indent = 0)
        {
            await Task.Run(() =>
            {
                var LogPrefix = GetLoggingPrefix(indent);
                Console.WriteLine($"{LogPrefix}{itemDescription.EmptyIfNull()}");
            });
        }

        /// <summary>
        /// Logs the description and associated value.
        /// </summary>
        /// <param name="itemDescription">The description to log.</param>
        /// <param name="itemValue">The value to log.</param>
        /// <param name="indent">The number indents to prefix the line.</param>
        /// <returns>The task background operation.</returns>
        private async Task Log(string itemDescription, string? itemValue, int indent = 0)
        {
            await Task.Run(() =>
            {
                var LogPrefix = GetLoggingPrefix(indent);
                var ItemValue = "";

                if (!string.IsNullOrWhiteSpace(itemValue))
                {
                    ItemValue = itemValue;
                }

                Console.WriteLine($"{LogPrefix}{itemDescription.EmptyIfNull()}: {ItemValue}");
            });
        }

        /// <summary>
        /// Gets prefix to use for logging.
        /// </summary>
        /// <param name="numberOfPrefixes">The number of prefixes to concatenate.</param>
        /// <returns>The prefix to use for logging.</returns>
        private string GetLoggingPrefix(int numberOfPrefixes)
        {
            var LogPrefix = "";

            for (int i = 0; i < numberOfPrefixes; i++)
            {
                LogPrefix += Prefix;
            }

            return LogPrefix;
        }

        /// <summary>
        /// The prefix to use when logging azure data.
        /// </summary>
        private string Prefix { get; set; }
    }
}