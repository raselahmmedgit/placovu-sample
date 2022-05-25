using System;
using System.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AthenaHealthDataAnalytics.Core.Util
{
    public class ApiCallResult
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}