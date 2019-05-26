using Microsoft.ProjectOxford.Face;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceApiSdk
{
    class Program
    {
        /// <summary>
        /// Go through the following article to enable async Main method if you work on .Net Framework lesser thatn 4.7: 
        /// https://www.c-sharpcorner.com/article/enabling-c-sharp-7-compilation-with-visual-studio-2017/
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            IFaceServiceClient faceServiceClient = new FaceServiceClient("<Key>",
                "https://centralindia.api.cognitive.microsoft.com/face/v1.0");

            var faceAttributes = new[] { FaceAttributeType.Emotion, FaceAttributeType.Age };

            var detectedFaces = await faceServiceClient.DetectAsync("https://www.codeproject.com/script/Membership/Uploads/7869570/Faces.png",
                returnFaceAttributes:faceAttributes);

            foreach (var detectedFace in detectedFaces)
            {
                Console.WriteLine($"{detectedFace.FaceId}");
                Console.WriteLine($"Age = {detectedFace.FaceAttributes.Age}, Happiness = {detectedFace.FaceAttributes.Emotion.Happiness}");

            }
            Console.ReadLine();
        }
    }
}
