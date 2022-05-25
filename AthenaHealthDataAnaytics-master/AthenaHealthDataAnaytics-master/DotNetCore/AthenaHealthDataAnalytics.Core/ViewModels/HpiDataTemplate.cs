using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace AthenaHealthDataAnalytics.Core.ViewModels
{
    public class Finding
    {
        [JsonProperty("findingid")] 
        public string FindingId { get; set; }
        
        [JsonProperty("findingnote", NullValueHandling = NullValueHandling.Ignore)] 
        public string FindingNote { get; set; }
        
        [JsonProperty("freetext", NullValueHandling = NullValueHandling.Ignore)] 
        public string FreeText { get; set; }

        [JsonProperty("selectedoptions")] 
        public List<string> SelectedOptions { get; set; }
    }

    public class Sentence
    {
        [JsonProperty("sentenceid")] 
        public string SentenceId { get; set; }
        
        [JsonProperty("sentencenote", NullValueHandling = NullValueHandling.Ignore)] 
        public string SentenceNote { get; set; }

        [JsonProperty("findings")] 
        public List<Finding> Findings { get; set; }
    }

    public class Paragraph
    {
        [JsonProperty("paragraphid")] 
        public string ParagraphId { get; set; }

        [JsonProperty("templateid")] 
        public string TemplateId { get; set; } = "283";

        [JsonProperty("sentences")] 
        public List<Sentence> Sentences { get; set; }
    }

    public class Template
    {
        [JsonProperty("templateid")] 
        public string TemplateId { get; set; } = "283";

        [JsonProperty("templatenote", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateNote { get; set; }

        [JsonProperty("reportedby", NullValueHandling = NullValueHandling.Ignore)]
        public string ReportedBy { get; set; }
    }

    public class HpiDataTemplate
    {
        public List<Paragraph> HpiData { get; set; }
        public List<Template> TemplateData { get; set; }
        public string SectionNote { get; set; } = string.Empty;
        public string ReplaceSectionNote { get; set; } = string.Empty;
    }
}