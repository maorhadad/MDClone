using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTest.Model
{
    public class EmailModel : TabModel
    {
        public string From;
        public string To;
        public string Title;
        public string Content;

        public EmailModel(string tabName) : base(tabName)
        {

        }

        public override string ToString()
        {
            return $@"From: {From}{Environment.NewLine}To:{To}{Environment.NewLine}Title: {Title}{Environment.NewLine}Content: {Content}";
        }
    }

}
