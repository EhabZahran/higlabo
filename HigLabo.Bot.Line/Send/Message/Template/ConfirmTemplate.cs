﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Bot.Line.Send
{
    public class ConfirmTemplate : TemplateMessage
    {
        public String Text { get; set; }
        public String Title { get; set; }
        public List<TemplateAction> Actions { get; private set; } = new List<TemplateAction>();

        public override string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"template\",");
                sb.Append("\"altText\":\"").AppendJsonEncoded(this.AltText).Append("\",");
                sb.Append("\"template\": {");
                {
                    sb.Append("\"type\":\"confirm\",");
                    sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\",");
                    if (this.Title.IsNullOrEmpty() == false)
                    {
                        sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                    }
                    sb.Append("\"actions\":[");
                    for (int i = 0; i < this.Actions.Count; i++)
                    {
                        sb.Append(this.Actions[i].CreateJson());
                        if (i < this.Actions.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                }
                sb.Append("}");
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}
