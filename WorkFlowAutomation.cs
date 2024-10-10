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
            Console.WriteLine("Submit your document for approval:");
            
            Console.Write("Enter document name: ");
            string docName = Console.ReadLine();

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Document doc = new Document(docName, "mydoc.txt", description, "Hilario Nengare");

            // Simulate approval process
            WorkFlowEngine.processDocument(doc);
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
            Console.WriteLine($"Creating new document: {name}");
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

    class WorkFlowEngine{
        public static void ProcessDocument(Document doc){
            Console.WriteLine($"Processing document: {doc.Name}");
            string content =  File.ReadAllText(doc.Path);

            if(String.IsNullOrEmpty(content)){
                doc.DocumentStatus = Status.Rejected;
                Console.WriteLine($"Document {doc.Name} has been accepted.");
            }
            else{
                doc.DocumentStatus = Status.Submitted;
                Console.WriteLine($"Document {doc.Name} has been rejected.");
            }
            Console.WriteLine($"Finished processing document: {doc.Name}");
        }

        private static void NotifySubmitter(Document doc)
        {
            Console.WriteLine($"Notification: {doc.Submitter}, your document '{doc.Name}' is {doc.DocumentStatus}.");
        }
    }
}
