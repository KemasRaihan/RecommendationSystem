// See https://aka.ms/new-console-template for more information

using System.Text;
using static System.Net.Mime.MediaTypeNames;
//using Excel = Microsoft.Office.Interop.Excel;
namespace RecommendationSystem
{
    class DataGenerator
    {
        const string filePathTrain = "G:\\My Drive\\Sheffield_Hallam_University\\Second_Year\\Professional_Software_Projects\\ASP_Net_Core\\RecommendationSystem\\Data\\train.csv";
        const string filePathTest = "G:\\My Drive\\Sheffield_Hallam_University\\Second_Year\\Professional_Software_Projects\\ASP_Net_Core\\RecommendationSystem\\Data\\test.csv";
        static string[] intents = new string[]{"AI beginners", "AI Intermediate", "Cloud beginners", "Cloud intermediate", "Cyber Security beginners",
    "Cyber Security intermediate", "Design Thinking beginners","Design Thinking intermediate", "AI credentials", "Cloud credentials",
    "Cyber Security credentials", "Design Thinking credentials", "AI Careers", "Cloud Careers", "Cyber Security Careers"};
        //static string[,] topics = new string[10,4]{ { "AI" ,"AI beginners", "AI Intermediate", "AI credentials", "AI Careers" }, "" }

        static Random rand = new Random();
        DataGenerator()
        {
        }

        // generate the random data for training the model and write to csv file
        public static void generateTrainData(int numberOfSamples)
        {

            var csv = new StringBuilder();
            var header = "sessionID, intentID, intent, target";
            csv.AppendLine(header);
            for (int sessionID = 1; sessionID < numberOfSamples + 1; sessionID++)
            { // for each user get all data
                for (int intentID = 0; intentID < intents.Length; intentID++)
                {
                    // for each intent randomly decide whether the user is interested or not
                    int target = rand.Next(0,2);

                    // get new line
                    var newLine = string.Format("{0},{1" +
                        "},{2}, {3}",sessionID, intentID, intents[intentID], target);
                    csv.AppendLine(newLine);
                }
            }

            // write to csv file
            File.WriteAllText(filePathTrain, csv.ToString());    
        }

        // generate the random data for testing and write to csv file
        public static void generateTestData(int numberOfSamples)
        {

            var csv = new StringBuilder();
            var header = "sessionID, intentID, intent";
            csv.AppendLine(header);
            for (int i = 0; i < numberOfSamples; i++)
            { // for each user get all data

                int intentID = rand.Next(0, intents.Length);
                // generate random user ID
                int sessionID = rand.Next(0, numberOfSamples);

                // get new line
                var newLine = string.Format("{0},{1" +
                    "},{2}", sessionID, intentID, intents[intentID]);
                csv.AppendLine(newLine);
            }

            // write to csv file
            File.WriteAllText(filePathTest, csv.ToString());
        }

        public void convertJSONToCSV()
        {

        }

        public static void Main(string[] args)
        {
            generateTrainData(100);
        }

    }

  
}