using ImageDeets;

Console.WriteLine("Image Deets");
Console.WriteLine("Retrieving all details for any image.");
Console.WriteLine(string.Empty);

var ImageInfo = new Deets();
await ImageInfo.ListAllImages();