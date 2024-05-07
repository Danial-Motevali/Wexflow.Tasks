using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.CallApiDanial
{
    public class CallApiDanial : Core.Task
    {
        public CallApiDanial(XElement ex, Workflow wf) : base(ex, wf)
        {

        }

        public override Core.TaskStatus Run()
        {
            try
            {
                string url = this.GetSetting("Address");
                string method = this.GetSetting("Method");

                if (url == null || method == null)
                    return new Core.TaskStatus(Status.Error);

                if(method == "GET")
                {
                    var clinent = new HttpClient();
                    var response = clinent.GetAsync(url);

                    return new Core.TaskStatus(Status.Success);
                }


                return new Core.TaskStatus(Status.Success);
            }catch (ThreadAbortException)
            {
                throw;
            }
        }
    }
}
