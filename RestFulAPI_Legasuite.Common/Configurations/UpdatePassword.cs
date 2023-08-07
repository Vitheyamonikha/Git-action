using Microsoft.Web.Administration;
using NLog;
using RestFulAPI_Legasuite.Common.Converter;
using RestFulAPI_Legasuite.Common.Interface;
using RestFulAPI_Legasuite.Common.Model;



namespace RestFulAPI_Legasuite.Common.Configurations
{
    public  class UpdatePassword : IUpdatePassword
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();         

public  void UpdateIisEnvironmentalVariable(UpdatePasswordInputs updatePasswordInputs)
    {
        using (ServerManager serverManager = new ServerManager())
        {
            Configuration config = serverManager.GetApplicationHostConfiguration();

            // Change the environmental variable for a specific site
            ConfigurationSection systemWebServerSection = config.GetSection("system.webServer", updatePasswordInputs.siteName);
            ConfigurationElementCollection environmentVariablesCollection = systemWebServerSection.GetCollection("environmentVariables");

            // Find the existing variable
            if(updatePasswordInputs.system == "EQ")
                {
                    ConfigurationElement existingElement_EQHSI = environmentVariablesCollection.FirstOrDefault(e => e.Attributes["name"].Value.ToString() == "EQ_HSI");
                    if (existingElement_EQHSI != null)
                    {
                        // Get the existing value
                        string existingValue = existingElement_EQHSI["value"].ToString();
                        string decryptedConString = Encryptor.DecryptString(existingValue);
                        int firstStringPosition = decryptedConString.IndexOf("Pwd=");
                        int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
                        firstStringPosition = firstStringPosition + 4;
                        string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
                        string newJDEConnString = removedOldpassword.Insert(firstStringPosition, updatePasswordInputs.newPassword);
                        string encryptedConnString = Encryptor.EncryptString(newJDEConnString);

                        // Update the value of the existing variable
                        existingElement_EQHSI["value"] = encryptedConnString;
                    }
                    ConfigurationElement existingElement_EQARC = environmentVariablesCollection.FirstOrDefault(e => e.Attributes["name"].Value.ToString() == "EQ_ARC");
                    if (existingElement_EQARC != null)
                    {
                        // Get the existing value
                        string existingValue = existingElement_EQARC["value"].ToString();
                        string decryptedConString = Encryptor.DecryptString(existingValue);
                        int firstStringPosition = decryptedConString.IndexOf("Pwd=");
                        int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
                        firstStringPosition = firstStringPosition + 4;
                        string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
                        string newJDEConnString = removedOldpassword.Insert(firstStringPosition, updatePasswordInputs.newPassword);
                        string encryptedConnString = Encryptor.EncryptString(newJDEConnString);

                        // Update the value of the existing variable
                        existingElement_EQARC["value"] = encryptedConnString;
                    }
                }
            if (updatePasswordInputs.system == "AQ")
                {
                    ConfigurationElement existingElement_AQHSI = environmentVariablesCollection.FirstOrDefault(e => e.Attributes["name"].Value.ToString() == "AQ_HSI");
                    if (existingElement_AQHSI != null)
                    {
                        // Get the existing value
                        string existingValue = existingElement_AQHSI["value"].ToString();
                        string decryptedConString = Encryptor.DecryptString(existingValue);
                        int firstStringPosition = decryptedConString.IndexOf("Pwd=");
                        int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
                        firstStringPosition = firstStringPosition + 4;
                        string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
                        string newJDEConnString = removedOldpassword.Insert(firstStringPosition, updatePasswordInputs.newPassword);
                        string encryptedConnString = Encryptor.EncryptString(newJDEConnString);

                        // Update the value of the existing variable
                        existingElement_AQHSI["value"] = encryptedConnString;
                    }
                    ConfigurationElement existingElement_AQARC = environmentVariablesCollection.FirstOrDefault(e => e.Attributes["name"].Value.ToString() == "AQ_ARC");
                    if (existingElement_AQARC != null)
                    {
                        // Get the existing value
                        string existingValue = existingElement_AQARC["value"].ToString();
                        string decryptedConString = Encryptor.DecryptString(existingValue);
                        int firstStringPosition = decryptedConString.IndexOf("Pwd=");
                        int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
                        firstStringPosition = firstStringPosition + 4;
                        string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
                        string newJDEConnString = removedOldpassword.Insert(firstStringPosition, updatePasswordInputs.newPassword);
                        string encryptedConnString = Encryptor.EncryptString(newJDEConnString);

                        // Update the value of the existing variable
                        existingElement_AQARC["value"] = encryptedConnString;
                    }
                }
                serverManager.CommitChanges();
        }
    }

        //public string Password(UpdatePasswordInputs updatePasswordInputs)
        //{

        //    string status = "";
        //    string newPassword = updatePasswordInputs.NewPassword;
        //    string system = updatePasswordInputs.system;

        //    try
        //    {

        //        if (system == "EQ")
        //        {
        //            string variableName = "EQ_HSI";
        //            string JdeConnString = Environment.GetEnvironmentVariable(variableName);
        //            string decryptedConString = Encryptor.DecryptString(JdeConnString);
        //            int firstStringPosition = decryptedConString.IndexOf("Pwd=");
        //            int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
        //            firstStringPosition = firstStringPosition + 4;
        //            string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
        //            string newJDEConnString = removedOldpassword.Insert(firstStringPosition, newPassword);
        //            string encryptedConnString = Encryptor.EncryptString(newJDEConnString);
        //            Environment.SetEnvironmentVariable(variableName, encryptedConnString);

        //            variableName = "EQ_ARC";
        //            JdeConnString = Environment.GetEnvironmentVariable(variableName);
        //            decryptedConString = Encryptor.DecryptString(JdeConnString);
        //            firstStringPosition = decryptedConString.IndexOf("Pwd=");
        //            secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
        //            firstStringPosition = firstStringPosition + 4;
        //            removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
        //            newJDEConnString = removedOldpassword.Insert(firstStringPosition, newPassword);
        //            encryptedConnString = Encryptor.EncryptString(newJDEConnString);
        //            Environment.SetEnvironmentVariable(variableName, encryptedConnString);


        //        }
        //        if (system == "AQ")
        //        {
        //            string variableName = "AQ_HSI";
        //            string NonJdeConnString = Environment.GetEnvironmentVariable(variableName);
        //            string decryptedConString = Encryptor.DecryptString(NonJdeConnString);
        //            int firstStringPosition = decryptedConString.IndexOf("Pwd=");
        //            int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
        //            firstStringPosition = firstStringPosition + 4;
        //            string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
        //            string newNonJDEConnString = removedOldpassword.Insert(firstStringPosition, newPassword);
        //            string encryptedConnString = Encryptor.EncryptString(newNonJDEConnString);
        //            Environment.SetEnvironmentVariable(variableName, encryptedConnString);

        //            variableName = "AQ_HSI";
        //            NonJdeConnString = Environment.GetEnvironmentVariable(variableName);
        //            decryptedConString = Encryptor.DecryptString(NonJdeConnString);
        //            firstStringPosition = decryptedConString.IndexOf("Pwd=");
        //            secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
        //            firstStringPosition = firstStringPosition + 4;
        //            removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
        //            newNonJDEConnString = removedOldpassword.Insert(firstStringPosition, newPassword);
        //            encryptedConnString = Encryptor.EncryptString(newNonJDEConnString);
        //            Environment.SetEnvironmentVariable(variableName, encryptedConnString);


        //        }

        //        return status;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info("statusex--------" + ex);
        //        return "System name must be AQ or EQ and Staging name must be Production or Staging";
        //    }

        //}






        //public static string Password(UpdatePasswordInputs updatePasswordInputs)
        //{

        //    string status= "";
        //    string stageName = updatePasswordInputs.stageName;
        //    string newPassword = updatePasswordInputs.NewPassword;
        //    string system = updatePasswordInputs.system;

        //    try
        //    {
        //        string variableName = "Test";
        //        string value = Environment.GetEnvironmentVariable(variableName);
        //        logger.Info("EnvironmentVariableOutputttt-------" + value);
        //        logger.Info("stageName--------" + stageName);
        //        if ((stageName == "Production") || (stageName == "Development") || (stageName == "Staging") || (stageName == "Test"))
        //        {
        //            stageName = "appsettings" + "." + stageName + ".json";

        //            //To load json by using File.ReadAllText():

        //            var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), stageName);
        //            var json = File.ReadAllText(appSettingsPath);

        //            //To deserialize string into a dynamic object with Newtonsoft 

        //            //var jsonSettings = new JsonSerializerSettings();
        //            //jsonSettings.Converters.Add(new ExpandoObjectConverter());
        //            //jsonSettings.Converters.Add(new StringEnumConverter());



        //            //Deserializing Json
        //            AppSettingProperty property = JsonConvert.DeserializeObject<AppSettingProperty>(json);
        //            if (system == "EQ")

        //            {
        //                String JdeConnString = property.ConnectionStrings.JDESystem;
        //                string decryptedConString = Encryptor.DecryptString(JdeConnString);
        //                int firstStringPosition = decryptedConString.IndexOf("Pwd=");
        //                int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
        //                firstStringPosition = firstStringPosition + 4;
        //                string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
        //                string newJDEConnString = removedOldpassword.Insert(firstStringPosition, newPassword);
        //                string encryptedConnString = Encryptor.EncryptString(newJDEConnString);
        //                property.ConnectionStrings.JDESystem = encryptedConnString;
        //                var newJson = JsonConvert.SerializeObject(property, Newtonsoft.Json.Formatting.Indented);
        //                //finally overwrite appsettings.json with the new JSON:
        //                File.WriteAllText(appSettingsPath, newJson);
        //                status = "Successfully Updated Passsword for EQ System in " + stageName + "Environment";
        //            }
        //            else if (system == "AQ")
        //            {
        //                String NonJdeConnString = property.ConnectionStrings.NonJDESystem;
        //                string decryptedConString = Encryptor.DecryptString(NonJdeConnString);
        //                int firstStringPosition = decryptedConString.IndexOf("Pwd=");
        //                int secondStringPosition = decryptedConString.IndexOf(";", firstStringPosition);
        //                firstStringPosition = firstStringPosition + 4;
        //                string removedOldpassword = decryptedConString.Remove(firstStringPosition, secondStringPosition - firstStringPosition);
        //                string newNonJDEConnString = removedOldpassword.Insert(firstStringPosition, newPassword);
        //                string encryptedConnString = Encryptor.EncryptString(newNonJDEConnString);
        //                property.ConnectionStrings.NonJDESystem = encryptedConnString;
        //                var newJson = JsonConvert.SerializeObject(property, Newtonsoft.Json.Formatting.Indented);
        //                //finally overwrite appsettings.json with the new JSON:
        //                File.WriteAllText(appSettingsPath, newJson);
        //                status = "Successfully Updated Passsword for AQ System in " + stageName + "Environment";
        //            }
        //            else
        //            {
        //                status = "Error:Please Enter Sytem Name as EQ or AQ";
        //            }
        //        }
        //        else
        //        {
        //            status = "Error:Please Enter Status Name as Production or Development or Staging or Test";
        //        }

        //        logger.Info("status--------" + status);
        //        return status;
        //    }
        //    catch(Exception ex)
        //    {
        //        logger.Info("statusex--------" + ex);
        //        return "System name must be AQ or EQ and Staging name must be Production or Staging";
        //    }

        //}
    }
}
