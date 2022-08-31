using ImageDeets.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDeets
{
    public class Deets
    {
        #region Constants

        /// <summary>
        /// The name of the folder containing sample images.
        /// </summary>
        private const string SAMPLE_IMAGE_FOLDER = "sample-images";

        #endregion Constants

        #region Constructors

        /// <summary>
        /// The constructor/Initializer.
        /// </summary>
        public Deets()
        {
            ImageFolder = Path.Combine(AppContext.BaseDirectory, SAMPLE_IMAGE_FOLDER);
            Logger = new DeetsLogger();
        }

        #endregion Constructors

        #region Methods

        public async Task ListAllImages()
        {
            if (Directory.Exists(ImageFolder))
            {
                FileInfo[] Files = new DirectoryInfo(ImageFolder).GetFiles();

                foreach (var file in Files)
                {
                    await Logger.Log(file);
                }
            }
            else
            {
                Console.WriteLine($"Unable to find the directory {ImageFolder}");
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// The folder containign images.
        /// </summary>
        private string ImageFolder { get; set; }

        /// <summary>
        /// The Image Detail Console Logger;
        /// </summary>
        private DeetsLogger Logger { get; set; }

        #endregion Properties
    }
}
