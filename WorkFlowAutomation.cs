/*
*   Author: Hilario Junior Nengare
*   Deliverable: Automated Doc Approval Workflow Console Application
*/

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WorkflowAutomation
{
    class WorkFlowAutomation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
        }
    }

    class Document{

        public string Name {get; set;}
        public string Path {get; set;}
        public string Description {get; set;}
        public string Submitter {get; set;}
        public Status DocumentStatus {get; set;}
        
        public Document(string name, string path, string description, string submitter){
            Name = name;
            Path = path;
            Description = description;
            Submitter = submitter;
            DocumentStatus = Status.Submitted;
        }
    }

    enum Status {
        Submitted,
        Approved,
        Rejected
    }

    class WriteFileEngine{
        public static void processDocument(Document doc){
            string content =  File.ReadAllText(doc.Path);

            if(String.IsNullOrEmpty(content)){
                doc.DocumentStatus = Status.Rejected;
                Console.WriteLine($"The above file has been accepted.");
            }
            else{
                doc.DocumentStatus = Status.Submitted;
                Console.WriteLine("The above file has been rejected.");
            }
        }
    }
}
