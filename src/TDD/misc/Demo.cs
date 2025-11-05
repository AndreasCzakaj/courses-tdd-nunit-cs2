using System.Text.Json;

namespace TDD.Misc
{
    public class Demo
    {
        private Dictionary<string, string> RevProperties = new Dictionary<string, string>(){
            {"Author", "John Doe"},
            {"Version", "1.0.0"},
            {"Project", "Sample Project"}
        };
       
        public void ExportDataset(string filePath)                                                                      
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new InvalidOperationException("Cannot export dataset: FilePath is not set");
            }

            try
            {
                string jsonContent = SerializeRevitPropertiesToJson(RevProperties);
                WriteToFile(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error exporting dataset: {ex.Message}", ex);
            }

        }

        protected virtual void WriteToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        protected virtual string SerializeRevitPropertiesToJson(Dictionary<string, string> RevitProperties) {
            return JsonSerializer.Serialize(RevProperties);
        }


        private string HostWall = "something";   

        public void BakeFromBrep()
        {
            // add placing parameters to the baking data
            if (HostWall == null)
            {
                // log warning and skip baking
                return;
            }
            Dictionary<string, object> placingParameters = new Dictionary<string, object>
            {
                { "host", HostWall }
            };

            BakeScopeElement(RevProperties, placingParameters);
        }

        protected virtual void BakeScopeElement(Dictionary<string, string> RevProperties, Dictionary<string, object> placingParameters)
        {
            //Layer doorLayer = RhinoUtilities.CreateLayer();
            //ScopeUtilities.BakeScopeElement(RevitProperty, placingParameters);
        }
    }
}