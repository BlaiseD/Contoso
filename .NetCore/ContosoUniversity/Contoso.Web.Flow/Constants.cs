namespace Contoso.Web.Flow
{
    public struct FileExtensions
    {
        public const string RESOURCESETEXTENSION = ".resources";
        public const string RULESETEXTENSION = ".module";
    }

    public enum ControlType
    {
        InputForm = 0,
        QuestionsForm = 1,
        StartFlow = 2,
        FlowCompleted = 3,
        Wait = 4
    }

    public struct JsonConstants
    {
        //public static readonly JsonConverter[] JsonConverters = { new BaseModelClassJsonConverter(), new ViewModelBaseJsonConverter() };
        //public static readonly JsonSerializerSettings FlowDataCacheSettings = new JsonSerializerSettings { Converters = JsonConverters };
    }
}
