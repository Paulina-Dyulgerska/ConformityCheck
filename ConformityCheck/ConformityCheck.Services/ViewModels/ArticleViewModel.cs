using System;
using System.Collections.Generic;
using System.Text;

namespace ConformityCheck.Services.ViewModels
{
    public class ArticleViewModel
    {
        public string Number { get; set; }

        public string Description { get; set; }

        public bool IsConfirmed { get; set; } //confirmed - not confirmed
    }
}
